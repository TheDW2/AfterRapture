using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DialogueEditor;
using UnityEngine;

public class NPCStartDialog : MonoBehaviour
{
    [SerializeField] private NPCConversation nPCConversation;
    [SerializeField] private ConversationData Data;

    private void OnMouseDown()
    {
        if (!ConversationManager.Instance.IsConversationActive && ConversationManager.Instance != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
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
                var existingParameter = Data.dataIntList.Find(p => p.name == param.ParameterName);
                if (existingParameter != null)
                {
                    existingParameter.value = ConversationManager.Instance.GetInt(param.ParameterName);
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
