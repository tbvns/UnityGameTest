using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public enum ItemType
{
    Tools,
    ToolsWithPower,
    Equipement,
    Default
}
public abstract class ItemObject : ScriptableObject
{
    public GameObject prefab;
    public ItemType type;
    [TextArea(15, 20)]
    public string Description;
    public GameObject ItemPrefab;

}
