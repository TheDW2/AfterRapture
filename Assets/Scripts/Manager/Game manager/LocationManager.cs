using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationManager : MonoBehaviour
{
    [SerializeField] private RectTransform _canvas;
    [SerializeField] private List<Location> _locationList;

    private GameObject _locationItem;
    void Start()
    {
        int index = PlayerPrefs.GetInt("current_location");
        foreach(Location loc in _locationList)
        {
            if(loc._locationId == index)
            {
                _locationItem = Instantiate(_locationItem, _canvas);
            }
        }
    }
}
