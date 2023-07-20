using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public static class Last {
    public static string GetLast(this string source, int numberOfChars)
    {
        if(numberOfChars >= source.Length)
            return source;
        return source.Substring(source.Length - numberOfChars);
    }
}

public class InvItems : MonoBehaviour
{
    //Script for slot items inside inventory
    int myID;
    int myTextureID;

    bool hovering = false;


    public Image itemImage;
    CollectiblesList c;

    public static string itemName;

    public static int hoveringID = 0;
    
    GameObject index;

    private List<int> hotbar, storage;
    

    

    void Start() {
        c = GameObject.Find("CollectiblesList").GetComponent<CollectiblesList>();

        myID = Int32.Parse(Last.GetLast(this.gameObject.name, this.gameObject.name.Length - 4));
        //What slot it is
    }

    void Update()
    {
        
        
        Location l = ScriptableObject.CreateInstance<Location>();

        
        


        
        
        
        
        
        
            if (myID > InvManager.amountOfSlotsStatic && myTextureID == 0) {
                InvManager.inventory[myID-1] = 0;
            }
        

        myTextureID = InvManager.inventory[myID - 1];


        //If the slot contains an item
        if (myTextureID > 0) {
            //Enable the image
            itemImage.enabled = true;
            //Change the sprite to the texture
            index = c.collectableItems[myTextureID];
            itemImage.sprite = index.GetComponent<SpriteRenderer>().sprite;
            if (hoveringID == myID || InvSelector.hoveredBox == myID) {
                itemName = index.name;
            } else {
                if (InvSelector.hoveredBox == 0 && hoveringID == 0) {
                    itemName = "";
                }
            }
        } else {
            //Disable the image
            itemImage.enabled = false;
            if (hoveringID == myID) {
                itemName = "";
            }
        }


        
        if (InvManager.amountInventory[myID - 1] == 0) {
            InvManager.inventory[myID - 1] = 0;
        }
    }

        

        

        
        
    

    //Show item name
    public void PointerEnter() {
        hoveringID = myID;
        hovering = true;
    }   
    public void PointerExit() {
        if (hoveringID == myID) {
            hoveringID = 0;
        }
        hovering = false;
    }

    
}
