using UnityEngine;


[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Inventory/Items", order = 0)]
public class ItemCreator : ScriptableObject
{
    public string itemName = "Item";
    [Header("Item value"), Tooltip("Value of the item when u what sell it")]
    public int value = 0;


    public int maxSize = 1;



    public bool isStackable = false;
    public bool isConsumable = false;
    public bool isEquipable = false;


    public Sprite icon = null;

}