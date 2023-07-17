using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotBar : MonoBehaviour
{
    public Image image;
    float timer;
    public float flashime = 0.5f;

    //I need to know if there's a better way to do this XD

    //This is the script for the flashing red telling the player that the hotbar is full
    void Update()
    {
        if (Collectibles.invFull) {
            timer = timer + Time.deltaTime;
            if (timer < flashime/4) {
                image.color = new Color(120, 0, 0, 255);
            } else {
                if (timer < flashime/2) {
                    image.color = new Color(255, 255, 255, 255);
                } else {
                    if (timer < flashime/1.5f) {
                        image.color = new Color(120, 0, 0, 255);
                    } else {
                        image.color = new Color(255, 255, 255, 255);
                        Collectibles.invFull = false;
                    }
                }
            }
        } else {
            timer = 0;
            image.color = new Color(255, 255, 255, 139);
        }
    }
}
