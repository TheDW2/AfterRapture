using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TimeCycle
{
    Day, Night
}

public enum Action
{
    Work, Food, Story
}
 [CreateAssetMenu(fileName = "Locations", menuName = "ScriptableObjects/Location")]
public class Location : ScriptableObject
{
    public int _locationId;
    public string _locationName;
    public Action[] _actionCanBeDone;
    public string _locationDescription;
    public TimeCycle _locationTimeCycle;
    public Sprite _mapIcon;
    public GameObject _locationGameObject;
    public bool unlocked;
    public Character [] _locationCharacters;
    public Vector2 _positionOnMap;
}
