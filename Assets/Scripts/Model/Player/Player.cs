using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
   public float hunger_bar;
   public float energy_bar;
   public int story_progress;
   public Inventory _inventory;
   public CharacterProgression _characterPlayerProgression;
}
