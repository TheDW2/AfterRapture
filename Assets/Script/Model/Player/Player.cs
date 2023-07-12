using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerPronoun
{
    he, she, them
}

public class Player : MonoBehaviour
{
    public string _playerName {get; private set;}
    public PlayerPronoun _playerPronoun {get; private set;}
    public Sprite _playerSprite {get; private set;}
}
