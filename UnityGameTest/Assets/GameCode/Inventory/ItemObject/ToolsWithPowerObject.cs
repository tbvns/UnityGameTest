using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Tools with power Object", menuName = "Inventory System/Items/Tools with power")]

public class ToolsWithPowerObject : ItemObject
{
    public int power;
    public void Awake()
    {
        type = ItemType.ToolsWithPower;
    }
}
