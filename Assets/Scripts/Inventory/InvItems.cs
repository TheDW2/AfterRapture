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

        //Turning IEnumerable<int> into List<int>
        var toconvert = InvManager.inventory.Take(InvManager.hotbarSizeStatic);
        hotbar = toconvert.ToList();

        var _toconvert = InvManager.inventory.Skip(InvManager.hotbarSizeStatic).Take(InvManager.amountOfSlotsStatic - InvManager.hotbarSizeStatic);
        storage = _toconvert.ToList();


        //What the slot will contain
        
        
        
        //if outside of the apartment, then stop storing into the storage
        if (l._locationId != 0) {
            if (myID > InvManager.hotbarSizeStatic && myTextureID == 0) {
                InvManager.inventory[myID-1] = 0;
            }
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


        
        if (hovering) {
            if (Input.GetMouseButtonDown(0)) {
                if (myTextureID == 2 && EventHandler.isFridgeOpen) {
                    //If clicked on and has food in it, store it back to the fridge.
                    FoodManager.foodLeft++;
                    myTextureID = 0;
                    InvManager.inventory[myID - 1] = 0;
                } else {
                    
                    if (myID > InvManager.hotbarSizeStatic) {
                        if (hotbar.Contains(0)) {
                            InvManager.AddItem(myTextureID);
                            myTextureID = 0;
                            InvManager.inventory[myID - 1] = 0;
                        } else {
                            Collectibles.invFull = true;
                        }
                    } else {
                        if (myID <= InvManager.hotbarSizeStatic && EventHandler.isStorageOpen) {
                            if (storage.Contains(0)) {
                                InvManager.AddItemToStorage(myTextureID);
                                myTextureID = 0;
                                InvManager.inventory[myID - 1] = 0;
                            } else {
                                Collectibles.invFull = true;
                            }
                        }
                    }
                        

                }
            }
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
