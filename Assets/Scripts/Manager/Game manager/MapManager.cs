using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
   [SerializeField] private GameObject _menuGameObject;
   [SerializeField] private GameObject _popUpGameObject;
   [SerializeField] private GameObject _aboutGameObject;

   [Header("Day Info")]
   [SerializeField] private Slider _hungerSlider;
   [SerializeField] private Slider _energySlider;
   [SerializeField] private Image _dayNightImage;
   [SerializeField] private Sprite _daySprite;
   [SerializeField] private Sprite _nightSprite;
   [SerializeField] private TextMeshProUGUI _dayText;

   [Header("Map Interaction")]
   private TimeCycle _currentTime;
   [SerializeField] private Button _openMenuButton;
   [SerializeField] private List<Location> _locationList;
   [SerializeField] private RectTransform _locationPlacer;
    private List<LocationItem> _locationItemList;

    [Header("Location Detail")]
    [SerializeField] private Sprite[] _locationActionIcons;
    [SerializeField] private TextMeshProUGUI _emptyLocationText;
    [SerializeField] private TextMeshProUGUI _locationTitle;
    [SerializeField] private TextMeshProUGUI _locationDesc;
    [SerializeField] private RectTransform _actionItemPlacer;
    [SerializeField] private RectTransform _characterPotraitPlacer;
    [SerializeField] private Sprite _placeHolderPicture;
    [SerializeField] private Button _goButton;
    

    [Header("Pause Menu")]
    [SerializeField] private Button _aboutButton;
    [SerializeField] private Button _closeAboutButton;
    [SerializeField] private Button _closeButton;
    [SerializeField] private Button _exitButton;

    [Header("Exit Pop")]
    [SerializeField] private Button _cancelButton;
    [SerializeField] private Button _exitMainMenuButton;

    [Header("Prefabs")]
    [SerializeField] private LocationItem _locationItem;
    [SerializeField] private LocationActionIcon _actionItem;
    [SerializeField] private LocationCharacterPotrait _characterPotrait;

    private SaveFile _saveFile;

    void Start()
    {
        _saveFile = SaveHandler.instance.LoadSlot(PlayerPrefs.GetInt("current_slot_used"));
        Setup();
    }

    private void Setup()
    {
        _openMenuButton.onClick.AddListener(OpenMenuGameObject);
        _closeButton.onClick.AddListener(CloseMenuGameObject);
        _aboutButton.onClick.AddListener(OpenAboutGameObject);
        _closeAboutButton.onClick.AddListener(CloseAboutGameObject);
        _exitButton.onClick.AddListener(OpenPopUpGameObject);
        _cancelButton.onClick.AddListener(ClosePopUpGameObject);
        _exitMainMenuButton.onClick.AddListener(ExitToTheMainMenu);

        _currentTime = _saveFile._playerSave._timeCycle;
        _dayText.text  = $"Day {_saveFile._playerSave.dayCount}";
        _hungerSlider.value = _saveFile._playerSave.hunger_bar;
        _energySlider.value = _saveFile._playerSave.energy_bar;

        switch(_currentTime)
        {
            case TimeCycle.Day:
            _dayNightImage.sprite = _daySprite;

            for(int i=0; i< _locationList.Count;i++)
            {
                if(_locationList[i]._locationTimeCycle == TimeCycle.Day)
                {
                    var obj = Instantiate(_locationItem, _locationPlacer).GetComponent<LocationItem>();
                    obj.gameObject.GetComponent<RectTransform>().anchoredPosition = _locationList[i]._positionOnMap;

                    int index = i;
                    obj.Setup(() => ShowLocationDetail(_locationList[index]), _locationList[index]);
                    _locationItemList.Add(obj);
                }
            }
            break;

            case TimeCycle.Night:
            _dayNightImage.sprite = _nightSprite;

            for(int i=0; i< _locationList.Count;i++)
            {
                if(_locationList[i]._locationTimeCycle == TimeCycle.Night)
                {
                    var obj = Instantiate(_locationItem, _locationPlacer).GetComponent<LocationItem>();
                    obj.gameObject.GetComponent<RectTransform>().anchoredPosition = _locationList[i]._positionOnMap;

                    int index = i;
                    obj.Setup(() => ShowLocationDetail(_locationList[index]), _locationList[index]);
                    _locationItemList.Add(obj);
                }
            }
            break;
        }
    }

    private void ShowLocationDetail(Location loc)
    {
        _emptyLocationText.gameObject.SetActive(false);
        _locationTitle.text = loc._locationName;
        _locationDesc.text = loc._locationDescription;

        foreach(LocationAction _action in loc._actionCanBeDone)
        {
            var obj = Instantiate(_actionItem, _actionItemPlacer).GetComponent<LocationActionIcon>();
            switch(_action)
            {
                case LocationAction.Food:
                obj.Setup(_locationActionIcons[0], "Can Get Food");

                break;

                case LocationAction.Item:
                obj.Setup(_locationActionIcons[1], "Can Get Item");
                break;

                case LocationAction.Story:
                obj.Setup(_locationActionIcons[2], "Story Progression");

                break;
            }
        }

        foreach(Character _char in loc._locationCharacters)
        {
            var obj = Instantiate(_characterPotrait, _characterPotraitPlacer).GetComponent<LocationCharacterPotrait>();
            if(_char._hasMetPlayer)
            {
                obj.Setup(_char._characterPotrait);
            }
            else
            {
                obj.Setup(_placeHolderPicture);
            }
        }
        _goButton.onClick.AddListener(() => GoToLocation(loc._locationId));

    }

    private void GoToLocation(int id)
    {
        PlayerPrefs.SetInt("current_location", id);
        SceneManagerHandler.instance.LoadScene(3);
    }


    private void OpenMenuGameObject()
    {
        _menuGameObject.SetActive(true);
    }

    private void CloseMenuGameObject()
    {
        _menuGameObject.SetActive(false);
    }

    private void OpenPopUpGameObject()
    {
        _popUpGameObject.SetActive(true);
    }

    private void ClosePopUpGameObject()
    {
        _popUpGameObject.SetActive(false);
    }

     private void OpenAboutGameObject()
    {
        _aboutGameObject.SetActive(true);
    }

    private void CloseAboutGameObject()
    {
        _aboutGameObject.SetActive(false);
    }

    private void ExitToTheMainMenu()
    {
        PlayerPrefs.DeleteKey("current_used_id");
        SceneManagerHandler.instance.LoadScene(0);
    }


}
