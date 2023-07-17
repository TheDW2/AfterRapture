using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemName : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    // Update is called once per frame
    void LateUpdate()
    {
        text.text = InvItems.itemName;
    }
}
