using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class LocationItem : MonoBehaviour
{
    [SerializeField] private Button _itemButton;
    [SerializeField] private Image _locationSprite;
    [SerializeField] private TextMeshProUGUI _locationName;
    [SerializeField] private GameObject _circle;

    public void Setup(UnityAction onClick, Location _location)
    {
        _locationSprite.sprite = _location._mapIcon;
        if(_location.unlocked)
        {
            _locationName.text = _location._locationName;
            _itemButton.onClick.AddListener(onClick);
        }

        else
        {
            _locationName.text = "???";
        }
       
    }

    public void Showselected()
    {
        _circle.SetActive(true);
    }

    public void UnshowSelected()
    {
        _circle.SetActive(false);
    }
}
