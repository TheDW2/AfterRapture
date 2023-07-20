using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DialogueEditor;

public class VariableManager : MonoBehaviour
{
    [SerializeField] public GlobalVariables globalVariables;


    private static VariableManager instance;

    public static VariableManager Instance 
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveGlobalVariables(ConversationData nPCConversation)
    {
        foreach (var boolParam in globalVariables.globalParameterListBool)
        {
            if (nPCConversation.dataBoolList.Any(p => p.name == boolParam.name))
            {
                boolParam.value = ConversationManager.Instance.GetBool(boolParam.name);
            }
        }

        foreach (var intParam in globalVariables.globalParameterListInt)
        {
            if (nPCConversation.dataIntList.Any(p => p.name == intParam.name))
            {
                intParam.value = ConversationManager.Instance.GetInt(intParam.name);
            }
        }
    }


    public void LoadGlobalVariables(ConversationData nPCConversation)
    {
        foreach (var boolParam in globalVariables.globalParameterListBool)
        {
            if (nPCConversation.dataBoolList.Any(p => p.name == boolParam.name))
            {
               ConversationManager.Instance.SetBool(boolParam.name, boolParam.value);
            }
        }

        foreach (var intParam in globalVariables.globalParameterListInt)
        {
            if (nPCConversation.dataIntList.Any(p => p.name == intParam.name))
            {
                ConversationManager.Instance.SetInt(intParam.name, intParam.value);
            }
        }
    }  
}
