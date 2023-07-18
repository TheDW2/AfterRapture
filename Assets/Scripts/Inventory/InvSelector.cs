using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvSelector : MonoBehaviour
{
    //Assign this to selector gameobject


    public float startingY;
    public float distanceBewteenBoxes;

    public static int hoveredBox;

    public RectTransform rectTransform;

    private int slot;

    float midpoint;
    
    void Start()
    {
        
    }

    void Update()
    {
        slot = InvManager.onSlot + 1;
        //This 
        if (InvManager.amountOfSlotsStatic%2 == 0) {
            //if there are an even number of boxes in the inventory
            midpoint = ((float)InvManager.amountOfSlotsStatic / 2f)*distanceBewteenBoxes + distanceBewteenBoxes / 2f;
            rectTransform.localPosition = new Vector3((float)slot*distanceBewteenBoxes - midpoint, startingY, transform.position.z);
        } else {
            //if there are an odd number of boxes in the inventory
            midpoint = (((float)InvManager.amountOfSlotsStatic+1) / 2f)*distanceBewteenBoxes;
            rectTransform.localPosition = new Vector3((float)slot*distanceBewteenBoxes - midpoint, startingY, transform.position.z);
        }
    }

    public void Enter() {
        hoveredBox = slot;
    }

    public void Exit() {
        hoveredBox = 0;
    }

    


}
