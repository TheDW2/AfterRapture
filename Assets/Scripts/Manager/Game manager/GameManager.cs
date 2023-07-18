using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   [SerializeField] private Button _toggleCycle;
   private SaveFile _saveFile;

   void Start()
   {
      _saveFile = SaveHandler.instance.LoadSlot(PlayerPrefs.GetInt("current_slot_used"));
      _toggleCycle.onClick.AddListener(ToggleCycle);
   }

   private void ToggleCycle()
   {
      if(_saveFile._playerSave._timeCycle == TimeCycle.Day)
      {
         _saveFile._playerSave._timeCycle = TimeCycle.Night;
      }

      else
      {
         _saveFile._playerSave._timeCycle = TimeCycle.Day;
         _saveFile._playerSave.dayCount += 1;
      }

      SaveHandler.instance.SaveSlot(_saveFile, PlayerPrefs.GetInt("current_slot_used"));
      SceneManagerHandler.instance.LoadScene(2);
   }
}
