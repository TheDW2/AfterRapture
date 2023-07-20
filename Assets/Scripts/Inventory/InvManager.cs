using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InvManager : MonoBehaviour
{
    //This script manages the contents of the inventory.
    //Assign this script to an empty object
    public static int onSlot = 0;
    public static List<int> inventory, amountInventory;

    public List<TextMeshProUGUI> inventoryText;

    //Item ID that is being held
    public static int holding;

    public int amountOfSlots;


    public static int amountOfSlotsStatic;

    void Start() {
        inventory = new List<int>();
        amountInventory = new List<int>();
        inventoryText = new List<TextMeshProUGUI>();
        for (int i = 0; i < amountOfSlots; i++) {
            inventory.Add(0);
            amountInventory.Add(0);
        }
        amountOfSlotsStatic = amountOfSlots;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
        

        
    }

    [SerializeField] public static void AddItem(int item) {
        for (int i = 0; i < amountOfSlotsStatic; i++) {
            if (inventory[i] == 0) {
                inventory[i] = item;
                amountInventory[i] = 1;
                return;
            } else {
                if (inventory[i] == item) {
                    amountInventory[i]++;
                    return;
                }
            }
        }
    }

    
}
