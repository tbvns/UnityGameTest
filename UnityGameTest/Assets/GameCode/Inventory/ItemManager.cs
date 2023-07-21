using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class ItemManager : MonoBehaviour
{
    public InventoryObject inventory;
    public ItemObject item;
    public TMP_Dropdown dropdown;
    bool firstFrame = true;


    void Update()
    {
        int index = dropdown.value;
        if (firstFrame)
        {
            dropdown.value = 3;
            firstFrame = false;
        }
        else
        {
            switch (index)
            {
                case 0:
                    dropdown.value = 2;
                    inventory.Container.ForEach(itm =>
                    {
                        if (itm.item.GetHeld())
                        {
                            itm.item.SetHeld(false);
                        }
                    });
                    item.SetHeld(true);
                    break;
                case 1:
                    inventory.RemItem(item, 1);
                    item.SetDrop(true);
                    dropdown.value = 2;
                    break;
                case 2:
                    break;

            }
        }
    }
}
