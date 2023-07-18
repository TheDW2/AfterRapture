using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerBar : MonoBehaviour
{
    
    public Slider hungerBar;

    

    //Use hungerBar.value to change hunger (0-20, 0 being starving and 20 being full)
    void Start() {
        hungerBar.value = 20;
    }
    
    //Right click to eat
    void Update()
    {
        if (InvManager.holding == 2 && Input.GetMouseButtonDown(1)) {
            if (hungerBar.value < 20) {
                hungerBar.value += 2;
                InvManager.inventory[InvManager.onSlot] = 0;
            }
        }

        
    }
}
