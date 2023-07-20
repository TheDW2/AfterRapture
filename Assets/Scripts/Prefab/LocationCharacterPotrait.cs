using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationCharacterPotrait : MonoBehaviour
{
    [SerializeField] private Image _characterSprite;

    public void Setup(Sprite _sprite)
    {
        _characterSprite.sprite = _sprite;
    }
}
