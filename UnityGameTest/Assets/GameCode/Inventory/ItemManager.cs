using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemManager : MonoBehaviour
{
    public InventoryObject inventory;
    public ItemObject item;
    public TMP_Dropdown dropdown;

    void Update()
    {
        int index = dropdown.value;
        switch (index)
        {
            case 0:
                inventory.AddItem(item, 1);
                dropdown.value = 2;
                break;
            case 1:
                inventory.RemItem(item, 1);
                dropdown.value = 2;
                break;
            case 2:
                break;
            
        }
    }
}
