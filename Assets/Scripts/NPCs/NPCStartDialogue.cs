using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class NPCStartDialogue : MonoBehaviour
{
    [SerializeField] private NPCConversation nPCConversation;
    [SerializeField] private ConversationData Data;
    private List<bool> boolList = new List<bool>();
    private List<int> IntList = new List<int>();

    private void OnMouseDown() {

        if(!ConversationManager.Instance.IsConversationActive && ConversationManager.Instance != null)
        {
            if(Input.GetMouseButtonDown(0))
            {
               ConversationManager.Instance.StartConversation(nPCConversation);
              LoadInformation();
            }
        } 
        
    }

    private void Update() {
        if(ConversationManager.Instance != null)
        {
           if(!ConversationManager.Instance.IsConversationActive)
            {
                if(Input.GetKeyDown(KeyCode.UpArrow))
                    ConversationManager.Instance.SelectPreviousOption();
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                    ConversationManager.Instance.SelectNextOption();
                else if (Input.GetKeyDown(KeyCode.F))
                    ConversationManager.Instance.PressSelectedOption();                    
            } 
        }
    }

    
    //-------Public--------

    public void SaveBool(string objectName)
    {
        // Check if the name already exists in the list
        if (IsBoolNameUnique(objectName))
        {
        
            BuleanDataConversation newObj = new BuleanDataConversation();
            newObj.name = objectName;
            Data.dataBoolList.Add(newObj);
            ChangeBoolValue(objectName);
        }
        else
        {
            ChangeBoolValue(objectName);
        }
    }

    public void SaveInt(string objectName)
    {
        if (IsIntNameUnique(objectName))
        {
            IntDataConversation newObj = new IntDataConversation();
            newObj.name = objectName;
            Data.dataIntList.Add(newObj);
            ChangeIntValue(objectName);
        }
        else
        {
            ChangeIntValue(objectName);
        }
        
    }


    //-------Update---------

    private void LoadInformation()
    {
        // SetAllBool
        foreach (var boolData in Data.dataBoolList)
        {
            ConversationManager.Instance.SetBool(boolData.name, boolData.value);
        }

        // SetAllInt
        foreach (var intData in Data.dataIntList)
        {
            ConversationManager.Instance.SetInt(intData.name, intData.value);
        }
    }

    //-------Private---------

    private bool IsBoolNameUnique(string objectName)
    {
        foreach (BuleanDataConversation obj in Data.dataBoolList)
        {
            if (obj.name == objectName)
            {
                return false; // Duplicate name found
            }
        }
        return true; // Unique name, no duplicates
    }
    private bool IsIntNameUnique(string objectName)
    {
        foreach (IntDataConversation obj in Data.dataIntList)
        {
            if (obj.name == objectName)
            {
                return false; 
            }
        }
        return true; 
    }

    private void ChangeBoolValue(string objectName)
    {
        foreach (BuleanDataConversation obj in Data.dataBoolList)
            {
                if (obj.name == objectName)
                {
                    for (int i = 0; i < Data.dataBoolList.Count; i++)
                    {
                        Data.dataBoolList[i].value = ConversationManager.Instance.GetBool(objectName);
                    }
                }
            }
    }
    private void ChangeIntValue(string objectName)
    {
        foreach (IntDataConversation obj in Data.dataIntList)
            {
                if (obj.name == objectName)
                {
                    for (int i = 0; i < Data.dataIntList.Count; i++)
                    {
                        Data.dataIntList[i].value = ConversationManager.Instance.GetInt(objectName);
                    }
                }
            }
    }
}
