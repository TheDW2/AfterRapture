using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [CreateAssetMenu(fileName = "Character", menuName = "ScriptableObjects/Character")]
public class Character : ScriptableObject
{
    public int _characterId;
    public string _characterName;
    public string _characterDescription;
    public int _playerRelationshipPoint;
    public Sprite _characterSprite;
    public Sprite _characterPotrait;
    public int _lastStoryId;
    public List<CharacterStory> _characterStory;
    public bool _hasMetPlayer;
}
