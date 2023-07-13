using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvItems : MonoBehaviour
{
    //Script for slot items inside inventory
    char myIDchar;
    int myID;
    int myTextureID;


    public Image itemImage;
    public CollectiblesList c;
    

    

    void Start() {
        myIDchar = this.name[4];
        myID = int.Parse(myIDchar.ToString());
        //What slot it is
    }

    void Update()
    {
        //What the slot will contain
        myTextureID = InvManager.inventory[myID - 1];


        //If the slot contains an item
        if (myTextureID > 0) {
            //Enable the image
            itemImage.enabled = true;
            //Change the sprite to the texture
            itemImage.sprite = c.collectableItems[myTextureID];
        } else {
            //Disable the image
            itemImage.enabled = false;
        }

        
        
    }

    

    void WhenUsed() {
        //Do something


        //Keep these three lines
        InvSelector.clickedBox = 0;
        itemImage.enabled = false;
        InvManager.inventory[myID - 1] = 0;
    }
}
