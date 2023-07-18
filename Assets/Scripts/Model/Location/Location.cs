using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TimeCycle
{
    Day, Night, Both
}

public enum LocationAction
{
    Food, Item, Story
}
 [CreateAssetMenu(fileName = "Locations", menuName = "ScriptableObjects/Location")]
public class Location : ScriptableObject
{
    public int _locationId;
    public string _locationName;
    public List<LocationAction> _actionCanBeDone;
    public string _locationDescription;
    public TimeCycle _locationTimeCycle;
    public Sprite _mapIcon;
    public GameObject _locationGameObject;
    public bool unlocked;
    public List<Character> _locationCharacters;
    public Vector2 _positionOnMap;
}
