using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Tools Object", menuName = "Inventory System/Items/Tools")]
public class ToolsObject : ItemObject
{
    public int Durability;
    public void Awake()
    {
        type = ItemType.Tools;
    }
}
