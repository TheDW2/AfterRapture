using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialItems : MonoBehaviour
{
    //This script holds special items
    public UnityEngine.Rendering.Universal.Light2D lightSource;

    public static Vector3 camPos;

    void Update() {
        camPos = Camera.main.transform.position;
        Torch();
    }
    
    void Torch() {
        //Disable GlobalLight and Background for normal view
        
        if (InvManager.holding == 3) {
            lightSource.enabled = true;
        } else {
            lightSource.enabled = false;
        }
    }
}
