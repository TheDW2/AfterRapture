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


    public static int amountOfSlotsStatic;

    void Start() {
        inventory = new List<int>();
        for (int i = 0; i < amountOfSlots; i++) {
            inventory.Add(0);
        }
        amountOfSlotsStatic = amountOfSlots;
    }

    // Update is called once per frame
    void Update()
    {
        Location l = ScriptableObject.CreateInstance<Location>();
        
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

    public static void AddItem(int item) {
        for (int i = 0; i < amountOfSlotsStatic; i++) {
            if (inventory[i] == 0) {
                inventory[i] = item;
                return;
            }
        }
    }

    
}
