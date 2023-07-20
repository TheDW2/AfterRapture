using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LocationObjectManager : MonoBehaviour
{
    //put all location related action (including the apartment here)
   [SerializeField] private Button _toggleCycle;

   public void AddOnClickToggleCycle(UnityAction onClick)
   {
        _toggleCycle.onClick.AddListener(onClick);
   }
}
