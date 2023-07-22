using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

[System.Serializable]
public class CharacterStory
{
    public int _storyId;
    public GameObject _conversation;
    public bool _finished;
    public ConversationData _storyParameter;
}
