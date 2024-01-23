using UnityEngine;
public struct InventoryItem
{
    public string itemName;
    public Sprite icon;

    public bool isStackable;
    public bool isConsumable;
    public bool isEquipable;

    public int value;

    public int stackSize;
    public int maxStackSize;
    public int minStackSize
    {
        get { return value; }
        set { if (value < minStackSize) value = minStackSize; }
    }
}