using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FoodManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    [SerializeField] private float flashtime = 0.5f;

    public static int foodLeft = 10;
    private bool noFoodLeft = false;

    float timer;
    
    
    void Update()
    {
        text.text = "x " + foodLeft.ToString();

        if (noFoodLeft) {
            timer = timer + Time.deltaTime;
            if (timer < flashtime/4) {
                text.color = new Color(120, 0, 0, 255);
            } else {
                if (timer < flashtime/2) {
                    text.color = new Color(255, 255, 255, 255);
                } else {
                    if (timer < flashtime/1.5f) {
                        text.color = new Color(120, 0, 0, 255);
                    } else {
                        text.color = new Color(255, 255, 255, 255);
                        noFoodLeft = false;
                    }
                }
            }
        } else {
            timer = 0f;
        }

        
    }

    public void TakeFood()
    {
        if (foodLeft > 0) {
            if (InvManager.inventory.Contains(0)) {
                InvManager.AddItem(2);
                foodLeft--;
            } else {
                Collectibles.invFull = true;
            }
        } else {
            noFoodLeft = true;
        }
    }
}
