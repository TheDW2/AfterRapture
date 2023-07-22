using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DialogueEditor;
using UnityEngine;

public class NPCStartDialog : MonoBehaviour
{
    [SerializeField] private Character _character;

    private ConversationData Data;
    private NPCConversation nPCConversation;

    private void OnMouseDown()
    {
        if (!ConversationManager.Instance.IsConversationActive && ConversationManager.Instance != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                List<CharacterStory> _stories = _character._characterStory;
                foreach(CharacterStory story in _stories)
                {
                    if(story._storyId == _character._lastStoryId)
                    {
                        nPCConversation = Instantiate(story._conversation).GetComponent<NPCConversation>();
                        Data = story._storyParameter;
                    }
                }

                ConversationManager.Instance.StartConversation(nPCConversation);
                LoadInformation();
                GameManager.Instance.LoadGlobalVariables(Data);
               
            }
        }
    }

    //-------Public--------

    public void SaveAll()
    {
        Data.LoadConversationData();
        foreach (var param in nPCConversation.ParameterList)
        {
            if (param is EditableBoolParameter boolParameter)
            {
                var existingParameter = Data.dataBoolList.Find(p => p.name == param.ParameterName);
                if (existingParameter != null)
                {
                    existingParameter.value = ConversationManager.Instance.GetBool(param.ParameterName);
                }
                else
                {
                    var newBoolParam = new BuleanDataConversation();
                    newBoolParam.name = param.ParameterName;
                    newBoolParam.value = ConversationManager.Instance.GetBool(param.ParameterName);
                    Data.dataBoolList.Add(newBoolParam);
                }
            }
            else if (param is EditableIntParameter intParameter)
            {
                if(param.ParameterName == "_charRelationPoint")
                {
                    _character._playerRelationshipPoint += ConversationManager.Instance.GetInt(param.ParameterName);
                }
                
                var existingParameter = Data.dataIntList.Find(p => p.name == param.ParameterName);
                if (existingParameter != null)
                {
                    if(param.ParameterName == "_charRelationPoint")
                    {
                        existingParameter.value += ConversationManager.Instance.GetInt(param.ParameterName);
                    }

                    else
                    {
                        existingParameter.value = ConversationManager.Instance.GetInt(param.ParameterName);
                    }
                    
                }
                else
                {
                    var newIntParam = new IntDataConversation();
                    newIntParam.name = param.ParameterName;
                    newIntParam.value = ConversationManager.Instance.GetInt(param.ParameterName);
                    Data.dataIntList.Add(newIntParam);
                }
            }
        }

        List<CharacterStory> _stories = _character._characterStory;
        foreach(CharacterStory story in _stories)
        {
            if(story._storyId == _character._lastStoryId)
            {
               story._finished = true;

            }
        }

        _character._lastStoryId += 1;

        if(!_character._hasMetPlayer) _character._hasMetPlayer = true;
        SaveFile _saveFile = SaveHandler.instance.LoadSlot(PlayerPrefs.GetInt("current_slot_used"));
        List<CharacterSave> _charSave = _saveFile._playerSave._characterPlayerProgression._characterProgressions;

        foreach(CharacterSave _save in _charSave)
        {
            if(_save.id == _character._characterId)
            {
                _save._lastStoryId = _character._lastStoryId;
                _save._playerRelationshipPoint = _character._playerRelationshipPoint;
                _save._hasMetPlayer = _character._hasMetPlayer;
            }
        }

        _saveFile._playerSave._characterPlayerProgression._characterProgressions = _charSave;

        SaveHandler.instance.SaveSlot(_saveFile, PlayerPrefs.GetInt("current_slot_used"));


        GameManager.Instance.SaveGlobalVariables(Data);
        Data.SaveConversationData();
    }

    public void IntegerModifier(int id)
    {
        Data.LoadConversationData();
        foreach (var intModifier in Data.IntModifierClassList)
        {
            var existingParameter = GameManager.Instance.globalVariables.globalParameterListInt.Find(p => p.name == intModifier.name);
            if (id == intModifier.id)
            {
                if (existingParameter != null)
                {
                    ConversationManager.Instance.SetInt(existingParameter.name, existingParameter.value + intModifier.valueToBeAddedOrSubtracted);
                }
                else
                {
                    ConversationManager.Instance.SetInt(intModifier.name, ConversationManager.Instance.GetInt(intModifier.name) + intModifier.valueToBeAddedOrSubtracted);
                }
            }
        }
        Data.SaveConversationData();
    }


    //-------Private---------

    private void LoadInformation()
    {
        // Set all bool parameters
        Data.LoadConversationData();
        foreach (var boolData in Data.dataBoolList)
        {
            if (nPCConversation.ParameterList.Any(p => p.ParameterName == boolData.name))
            {
                ConversationManager.Instance.SetBool(boolData.name, boolData.value);
            }
        }

        // Set all int parameters
        foreach (var intData in Data.dataIntList)
        {
            if (nPCConversation.ParameterList.Any(p => p.ParameterName == intData.name))
            {
                ConversationManager.Instance.SetInt(intData.name, intData.value);
            }
        }
    }

}
