using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectibles : MonoBehaviour
{
    //Drag this script to any prefab/gameobject that you want to be collectable.
    //Assign a texture ID. The texture ID tells the inventory what texture to use for the item.
    public int textureID;
    public static bool invFull = false;
    
    
    //OnMouseDrag is basically just when it's clicked, right?
    void OnMouseDrag() {
        Location l = ScriptableObject.CreateInstance<Location>();

        //Check if at least one slot is empty
        if (InvManager.inventory.Contains(0)) {
            //If so, check if the player is at home
            if (l._locationId == 0) {
                //If so, add the item to the inventory
                InvManager.AddItem(textureID);
                Destroy(this.gameObject);

            } else {
                //Else, don't add the item to the inventory
                invFull = true;
            }
        } else {
            //That means the inventory is full. Show a message to the user that the inventory is full
           invFull = true;
        }
    }

   
}
