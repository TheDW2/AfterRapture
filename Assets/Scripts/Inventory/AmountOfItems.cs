using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmountOfItems : MonoBehaviour
{
    private int myID;
    private TextMeshProUGUI text;

    void Start()
    {
        myID = Int32.Parse(gameObject.name);
        text = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = InvManager.amountInventory[myID - 1].ToString();
        if (InvManager.amountInventory[myID - 1] < 2) {
            text.enabled = false;
        } else {
            text.enabled = true;
        }
    }
}
