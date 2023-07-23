using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvManager : MonoBehaviour
{
    //This script manages the contents of the inventory.
    //Assign this script to an empty object
    public static int onSlot = 0;
    public static List<int> inventory;

    //Item ID that is being held
    public static int holding;

    public int amountOfSlots;
    public int hotbarSize;


    public static int amountOfSlotsStatic;
    public static int hotbarSizeStatic;

    public static InvManager instance;

    [SerializeField] private List<InvItems> _allInvItem;

    void Awake()
    {
        instance = this;
    }

    void Start() {
        inventory = new List<int>();
        for (int i = 0; i < amountOfSlots; i++) {
            inventory.Add(0);
        }
        amountOfSlotsStatic = amountOfSlots;
        hotbarSizeStatic = hotbarSize;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        holding = inventory[onSlot];
        if (Input.GetKeyDown("right")) {
            if (onSlot == amountOfSlots - 1) {
                onSlot = 0;
            } else  {
                onSlot++;
            }
        }
        if (Input.GetKeyDown("left")) {
            if (onSlot == 0) {
                onSlot = amountOfSlots - 1;
            } else  {
                onSlot--;
            }
        }

        
    }

    [SerializeField] public static void AddItem(int item) {
        for (int i = 0; i < amountOfSlotsStatic; i++) {
            if (inventory[i] == 0) {
                inventory[i] = item;
                InvManager.instance.SaveItemInventory();
                return;
            }
        }
    }

    [SerializeField] public static void AddItemToStorage(int item) {
        for (int i = 0; i < amountOfSlotsStatic - hotbarSizeStatic; i++) {
            if (inventory[i + hotbarSizeStatic] == 0) {
                inventory[i + hotbarSizeStatic] = item;
                InvManager.instance.SaveItemInventory();
                return;
            }
        }
    }

    private void SaveItemInventory()
    {
        SaveFile _saveFile = SaveHandler.instance.LoadSlot(PlayerPrefs.GetInt("current_slot_used"));
        List<InventoryItem> _invItem = new List<InventoryItem>();
        foreach(int inv in inventory)
        {
            if(inv != 0)
            {
                foreach(InvItems itm in InvManager.instance._allInvItem)
                {
                    if(itm.myTextureID == inv)
                    {
                        InventoryItem _item = new InventoryItem
                        {
                            id = inv,
                            name = itm.GetItemName()
                        };
                        _invItem.Add(_item);
                    }
                }
            }
        }

        Inventory _saveInv = new Inventory{
            _inventoryItemList = _invItem
        };

        _saveFile._playerSave._inventory = _saveInv;
        SaveHandler.instance.SaveSlot(_saveFile, PlayerPrefs.GetInt("current_slot_used"));
    }

    
}
