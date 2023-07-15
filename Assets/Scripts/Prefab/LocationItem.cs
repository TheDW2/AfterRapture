using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LocationItem : MonoBehaviour
{
    [SerializeField] private Image _locationSprite;
    [SerializeField] private TextMeshProUGUI _locationName;

    public void Setup(Location _location)
    {
        _locationSprite.sprite = _location._mapIcon;
        _locationName.text = _location._locationName;
    }
}
