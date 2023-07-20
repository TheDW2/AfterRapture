using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   private SaveFile _saveFile;
   [SerializeField] private RectTransform _canvas;
   [SerializeField] private List<Location> _locationList;

   private LocationObjectManager _locationItem;

   void Start()
   {
       int index = PlayerPrefs.GetInt("current_location");
        foreach(Location loc in _locationList)
        {
            if(loc._locationId == index)
            {
                _locationItem = Instantiate(loc._locationGameObject, _canvas).GetComponent<LocationObjectManager>();
            }
        }
      _saveFile = SaveHandler.instance.LoadSlot(PlayerPrefs.GetInt("current_slot_used"));
      _locationItem.AddOnClickToggleCycle(ToggleCycle);
   }

   private void ToggleCycle()
   {
      if(_saveFile._playerSave._timeCycle == TimeCycle.Day)
      {
         _saveFile._playerSave._timeCycle = TimeCycle.Night;
         _saveFile._playerSave.hunger_bar -= 0.2f; 
         _saveFile._playerSave.energy_bar = 1;
      }

      else
      {
         _saveFile._playerSave._timeCycle = TimeCycle.Day;
         _saveFile._playerSave.dayCount += 1;
         _saveFile._playerSave.hunger_bar -= 0.2f;
         _saveFile._playerSave.energy_bar = 1;
      }

      SaveHandler.instance.SaveSlot(_saveFile, PlayerPrefs.GetInt("current_slot_used"));
      SceneManagerHandler.instance.LoadScene(2);
   }
}
