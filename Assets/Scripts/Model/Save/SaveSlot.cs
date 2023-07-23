using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

[System.Serializable]
public class SaveSlot: MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] private Button _saveSlotBtn;
    [SerializeField] private GameObject _textPanel;
    [SerializeField] private TextMeshProUGUI _saveSlotDayType;
    [SerializeField] private TextMeshProUGUI _saveSlotHunger;
    [SerializeField] private TextMeshProUGUI _saveSlotEnergy;
    [SerializeField] private TextMeshProUGUI _saveSlotStoryProgress;
    [SerializeField] private TextMeshProUGUI _saveSlotNoSave;
    [SerializeField] private Button _deleteSlotBtn;

    [SerializeField] private List<Location> _locationList;
    [SerializeField] private List<Character> _characterList;

    private SaveFile _saveFile;

    void Start()
    {
        _saveSlotBtn.onClick.AddListener(LoadSlot);
        _deleteSlotBtn.onClick.AddListener(DeleteSlot);

        _saveFile = SaveHandler.instance.LoadSlot(id);

        if(_saveFile != null)
        {
            SetSaveSlot(true);
            if(_saveFile._playerSave._timeCycle == TimeCycle.Day) _saveSlotDayType.text = $"Day {_saveFile._playerSave.dayCount}: Daytime";
            else _saveSlotDayType.text = $"Day {_saveFile._playerSave.dayCount}: Night";
            _saveSlotHunger.text = String.Format("Hunger: {0:0.0}", _saveFile._playerSave.hunger_bar);
            _saveSlotEnergy.text = String.Format("Energy: {0:0.0}", _saveFile._playerSave.energy_bar);
            int allStoryCount = 100;
            _saveSlotStoryProgress.text = $"Story Progress: {_saveFile._playerSave.story_progress}/{allStoryCount}";
        }

        else
        {
            SetSaveSlot(false);
        }

       
    }

    private void LoadSlot()
    {
        if(_saveFile != null)
        {
            PlayerPrefs.SetInt("current_slot_used", id);
            if(_saveFile._playerSave._hasPastPrologue)
            {
                SceneManagerHandler.instance.LoadScene(1);
            }
            else
            {
                SceneManagerHandler.instance.LoadScene(2);
            }
        }

        else
        {
            CreateNewSaveFile();
        }
    }

    private void DeleteSlot()
    {
        SaveHandler.instance.deleteSlot(id);
        SetSaveSlot(false);
    }

    private void CreateNewSaveFile()
    {

        List<LocationSave> _locSave = new List<LocationSave>();

        for(int j=0;j<_locationList.Count;j++)
        {
            LocationSave lc = new LocationSave
            {
                _locationId = _locationList[j]._locationId,
                unlocked = _locationList[j].unlocked
            };
            _locSave.Add(lc);
        }
        LocationProgression _locProg = new LocationProgression
        {
            _locationProgressions = _locationList
        };
        List<CharacterSave> _charSave = new List<CharacterSave>();

       for(int i=0;i<_characterList.Count;i++)
       {
             CharacterSave ch = new CharacterSave {
                 id = _characterList[i]._characterId,
                _playerRelationshipPoint = _characterList[i]._playerRelationshipPoint,
                _hasMetPlayer = _characterList[i]._hasMetPlayer
            };
            _charSave.Add(ch);
       }

        CharacterProgression _charProg = new CharacterProgression
        {
            _characterProgressions = _charSave
        };

        Player _newSave = new Player
        {
            dayCount = 1,
            _timeCycle = TimeCycle.Day,
            hunger_bar = 1,
            energy_bar = 1,
            story_progress = 0,
            _inventory = new Inventory(),
            _characterPlayerProgression = _charProg,
            _locationProgression = _locProg,
            _hasPastPrologue = false
        };

        _saveFile = new SaveFile
        {
            id = id,
            _playerSave = _newSave
        };

        SaveHandler.instance.SaveSlot(_saveFile, id);
        PlayerPrefs.SetInt("current_slot_used", id);
        SceneManagerHandler.instance.LoadScene(1);
    }  

    private void SetSaveSlot(bool active)
    {
        _saveSlotDayType.gameObject.SetActive(active);
        _textPanel.SetActive(active);
        _deleteSlotBtn.gameObject.SetActive(active);
        _saveSlotNoSave.gameObject.SetActive(!active);
    }

}
