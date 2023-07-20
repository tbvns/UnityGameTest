using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDisplay : MonoBehaviour
{
    public InventoryObject InventoryObject;
    public GameObject oldItem;
    public GameObject hand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InventoryObject.Container.ForEach(container =>
        {
            if (container.item.GetHeld() && container.item != oldItem)
            {
                if(oldItem != null)
                {
                    Destroy(oldItem);
                }
                GameObject newitem = Instantiate(container.item.ItemPrefab);
                newitem.SetActive(true);
                newitem.transform.SetParent(hand.transform, false);
                newitem.transform.SetLocalPositionAndRotation(hand.transform.localPosition, hand.transform.localRotation);
                oldItem = newitem;
            }
        });
    }
}
