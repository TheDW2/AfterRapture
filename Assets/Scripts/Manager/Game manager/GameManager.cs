using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using DialogueEditor;

public class GameManager : MonoBehaviour
{
   private SaveFile _saveFile;
   [SerializeField] private RectTransform _canvas;
   [SerializeField] private List<Location> _locationList;

   private LocationObjectManager _locationItem;
   public GlobalVariables globalVariables;
   private static GameManager instance;

    public static GameManager Instance 
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

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

   public void SaveGlobalVariables(ConversationData nPCConversation)
    {
        foreach (var boolParam in globalVariables.globalParameterListBool)
        {
            if (nPCConversation.dataBoolList.Any(p => p.name == boolParam.name))
            {
                boolParam.value = ConversationManager.Instance.GetBool(boolParam.name);
            }
        }

        foreach (var intParam in globalVariables.globalParameterListInt)
        {
            if (nPCConversation.dataIntList.Any(p => p.name == intParam.name))
            {
                intParam.value = ConversationManager.Instance.GetInt(intParam.name);
            }
        }
    }


    public void LoadGlobalVariables(ConversationData nPCConversation)
    {
        foreach (var boolParam in globalVariables.globalParameterListBool)
        {
            if (nPCConversation.dataBoolList.Any(p => p.name == boolParam.name))
            {
               ConversationManager.Instance.SetBool(boolParam.name, boolParam.value);
            }
        }

        foreach (var intParam in globalVariables.globalParameterListInt)
        {
            if (nPCConversation.dataIntList.Any(p => p.name == intParam.name))
            {
                ConversationManager.Instance.SetInt(intParam.name, intParam.value);
            }
        }
    } 
}
