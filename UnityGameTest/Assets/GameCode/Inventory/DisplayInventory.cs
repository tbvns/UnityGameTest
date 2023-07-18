using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayInventory : MonoBehaviour
{

    public InventoryObject inventory;

    public int X_Space_BETWEEN_ITEM;
    public int Y_Space_BETWEEN_ITEM;
    public int NumberOfItemInColumn;
    public Vector3 DefaultPosition = new Vector3 (-200, 150, 0);
    Dictionary<InventorySlot, GameObject> ItemDisplayed = new Dictionary<InventorySlot, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
       UpdateDisplay();
    }

    public void CreateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            var OBJ = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
            OBJ.GetComponent<RectTransform>().localPosition = GetPosition(i);
            OBJ.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            ItemDisplayed.Add(inventory.Container[i], OBJ);
        }
    }
    public void UpdateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            if (ItemDisplayed.ContainsKey(inventory.Container[i]))
            {
                ItemDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            }
            else
            {
                var OBJ = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
                OBJ.GetComponent<RectTransform>().localPosition = GetPosition(i);
                OBJ.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
                ItemDisplayed.Add(inventory.Container[i], OBJ);
            }
        }
    }
    public Vector3 GetPosition(int i)
    {
        return new Vector3(DefaultPosition.x + (X_Space_BETWEEN_ITEM * (i % NumberOfItemInColumn)), DefaultPosition.y + ((-Y_Space_BETWEEN_ITEM * (i / NumberOfItemInColumn))), 0f);
    }
}
