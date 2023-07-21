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
    public bool Held = false;
    public bool Drop = false;
    public void SetHeld(bool held)
    {
        Held = held;
    }
    public bool GetHeld()
    {
        return Held;
    }
    private void OnApplicationQuit()
    {
        Held = false;
        Drop = false;
    }
    public void SetDrop(bool SetDrop)
    {
        Drop = SetDrop;
    }
    public bool GetDrop()
    {
        return Drop;
    }
}
