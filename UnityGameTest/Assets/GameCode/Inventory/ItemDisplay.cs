using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDisplay : MonoBehaviour
{
    public InventoryObject InventoryObject;
    GameObject oldItem;
    public GameObject hand;
    public TerrainLayer ItemLayer;
    // Start is called before the first frame update
    void Start()
    {
        InventoryObject.Container.ForEach(container => {
            container.item.SetDrop(false);
            container.item.SetHeld(false);
        
        });
        oldItem = new GameObject();
        oldItem.name = "null";
    }

    // Update is called once per frame
    void Update()
    {
        InventoryObject.Container.ForEach(container =>
        {
            if (container.item.GetHeld())
            {
                if (container.item.name != oldItem.name)
                {
                    if (oldItem != null)
                    {
                        Destroy(oldItem);
                    }
                    Debug.Log("NewItem");
                    GameObject newitem = Instantiate(container.item.ItemPrefab);
                    newitem.SetActive(true);
                    newitem.transform.SetParent(hand.transform, false);
                    newitem.transform.SetLocalPositionAndRotation(hand.transform.localPosition, hand.transform.localRotation);
                    newitem.name = newitem.name.Split('(')[0];
                    Debug.Log(oldItem.name + "   " + newitem.name);
                    Destroy(newitem.GetComponent<Collider>());
                    Destroy(newitem.GetComponent<Rigidbody>());
                    oldItem = newitem;
                }
            }
            if (container.item.GetDrop())
            {
                if (container.item.name == oldItem.name) { 
                    Destroy(oldItem);
                }
                GameObject newitem = Instantiate(container.item.ItemPrefab);
                newitem.SetActive(true);
                newitem.transform.SetLocalPositionAndRotation(hand.transform.position, hand.transform.localRotation);
                newitem.gameObject.layer = 8;
                container.item.SetDrop(false);
            }
        });
    }
}
