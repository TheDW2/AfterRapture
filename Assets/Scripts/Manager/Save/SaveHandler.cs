using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.IO;

public class SaveHandler : MonoBehaviour
{
    public static SaveHandler instance;
    void Awake()
    {
        instance = this;
        SaveManager.Init();
    }

    public void deleteSlot(int number)
    {
        SaveManager.deleteSaveSlot(number);
    }

    public void SaveSlot(SaveFile _file, int slotNumber)
    {
        string jsonString = JsonUtility.ToJson(_file);
        SaveManager.SaveProgress(jsonString, slotNumber);
    }

    public SaveFile LoadSlot(int slotNumber)
    {
         string contents = SaveManager.LoadProgress(slotNumber);

        if (contents != null)
        {
            SaveFile slot = JsonUtility.FromJson<SaveFile>(contents);
            return slot;
        }

        else
        {
            return null;
        }
    }
}

