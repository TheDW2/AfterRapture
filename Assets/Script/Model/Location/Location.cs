using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TimeCycle
{
    Day, Night
}
 [CreateAssetMenu(fileName = "Locations", menuName = "ScriptableObjects/Location")]
public class Location : ScriptableObject
{
    public int _locationId;
    public string _locationName;
    public string _locationDescription;
    public TimeCycle _locationTimeCycle;
    public Sprite _mapIcon;
    public Sprite _locationBackground;
    public bool unlocked;
    public Character [] _locationCharacters;
}
