using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Instantiations : MonoBehaviour
{
    
    //This script is for methods for eventTriggers

    
    [SerializeField] private Sprite closedBox, openBox;
    private bool openedBox = false;

    public void StayOpen()
    {
        if (!openedBox) {
            openedBox = true;
            if (this.gameObject.name == "Box") {
                InvManager.AddItem(4);
            }
            if (this.gameObject.name == "Safe") {
                InvManager.AddItem(1);
            }
            gameObject.GetComponent<Image>().sprite = openBox;
        }
    }



    //------------------------------------------------------------------------------------------------
    private static bool tv;
    [SerializeField] private SpriteRenderer TV;
    float timer = 0;
    public void TVclicked(){
        tv = true;
    }
    private void Update() {
        if (tv) {
            timer += Time.deltaTime;
            if (timer > 1) {
                tv = false;
                timer = 0;
            }
        }
        TV.enabled = tv;
    }
}
