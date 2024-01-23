using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private int inventorySize;

    public Button[] slots;
    public InventoryItem[] itemsInventory;
    public GameObject slotsContainer;

    void Awake()
    {
        inventorySize = slotsContainer.transform.childCount;
        slots = new Button[inventorySize];
        itemsInventory = new InventoryItem[inventorySize];
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = slotsContainer.transform.GetChild(i).GetComponentInChildren<Button>();
        }

        InitializedInventory();

        InteractDetector.AddItem += ItemConventer;


    }

    public bool AddItemToInventory(InventoryItem _item)
    {
        if (_item.isStackable == true)
        {
            for (int i = 0; i < itemsInventory.Length; i++)
            {
                if (itemsInventory[i].itemName == _item.itemName)// the same item
                {


                    if (itemsInventory[i].stackSize < _item.maxStackSize)// is space to add item to current item
                    {
                        int amount = itemsInventory[i].stackSize + _item.stackSize;

                        if (amount > itemsInventory[i].maxStackSize)
                        {
                            amount = amount - _item.maxStackSize;
                            itemsInventory[i].stackSize = _item.maxStackSize;
                            SlotUpdate(i, _item.icon, itemsInventory[i].stackSize);

                            for (int j = 0; j < itemsInventory.Length; j++)
                            {
                                if (itemsInventory[j].itemName == null)
                                {
                                    CreateSlot(_item, j, amount);
                                    return true;
                                }
                            }
                        }
                        else if (amount < itemsInventory[i].maxStackSize)
                        {
                            itemsInventory[i].stackSize = _item.stackSize;
                            return true;
                        }
                    }
                    else
                    {
                        for (int j = 0; j < itemsInventory.Length; ++j)
                        {
                            if (itemsInventory[j].stackSize < _item.maxStackSize)
                            {
                                int amount = itemsInventory[j].stackSize + _item.stackSize;
                                itemsInventory[j].stackSize = _item.maxStackSize;
                                SlotUpdate(j, _item.icon, itemsInventory[j].stackSize);


                                for (int k = 0; k < itemsInventory.Length; k++)
                                {
                                    if (itemsInventory[k].itemName == null)
                                    {
                                        amount = amount - _item.maxStackSize;
                                        itemsInventory[k].stackSize = amount;
                                        CreateSlot(_item, k, amount);
                                        print("This Code");
                                        return true;
                                    }


                                }
                            }

                        }
                    }



                }
                else
                {
                    if (itemsInventory[i].itemName == null)
                    {
                        CreateSlot(_item, i, _item.stackSize);
                        return true;
                    }
                    else
                    {
                        Debug.Log("No space for adding item");
                        return false;
                    }
                }
            }

        }
        else if (_item.isStackable == false)
        {
            for (int i = 0; i < itemsInventory.Length; i++)
            {
                if (itemsInventory[i].itemName == null)
                {
                    itemsInventory[i] = _item;
                    CreateSlot(_item, i, _item.stackSize);
                    print(itemsInventory[i].itemName + itemsInventory[i].stackSize);
                    return true;
                }
            }
        }
        Debug.LogError("Someting wrong with adding item to inventory");
        return false;

    }



    public void RemoveItem(InventoryItem Item)
    {

    }
    void CreateSlot(InventoryItem _item, int slotIndex, int slotSize)
    {
        itemsInventory[slotIndex] = _item;
        SlotUpdate(slotIndex, _item.icon, slotSize);


    }
    /// <summary>
    /// Update Inventory slot
    /// </summary>
    /// <param name="slotIndex">Index of solot to update</param>
    /// <param name="icon">Reference to slots image</param>
    /// <param name="slotSize">Amount of items in slot</param>
    void SlotUpdate(int slotIndex, Sprite icon, int slotSize)
    {
        Image slotImage = slots[slotIndex].GetComponent<Button>().image;
        slotImage.sprite = icon;
        Text _text = slots[slotIndex].GetComponentInChildren<Text>(true);
        if (slotSize == 0)
        {
            _text.text = "";
        }
        else
        {
            _text.text = slotSize.ToString();
        }




    }
    /// <summary>
    /// Converting data from IteamCreator object vriables to InventoryItem struct
    /// </summary>
    /// <param name="_item">It's picked item of ItemCreator scruptableobjec</param>
    void ItemConventer(ItemCreator _item, int amount)
    {
        InventoryItem Item = new InventoryItem();
        Item.icon = _item.icon;
        Item.itemName = _item.itemName;
        Item.stackSize = amount;
        Item.maxStackSize = _item.maxSize;

        Item.value = _item.value;

        Item.isStackable = _item.isStackable;
        Item.isConsumable = _item.isConsumable;
        Item.isEquipable = _item.isEquipable;

        if (_item.itemName == null)
        {
            Debug.Log("No Data");
        }
        else
        {
            //Debug.Log("There is Data");
        }

        AddItemToInventory(Item);
        //SlotUpdate(0, Item.icon, _item.stackSize);



    }

    void InitializedInventory()
    {
        for (int i = 0; i < slots.Length; i++)
        {

            SlotUpdate(i, itemsInventory[i].icon, itemsInventory[i].stackSize);
        }
    }

}
