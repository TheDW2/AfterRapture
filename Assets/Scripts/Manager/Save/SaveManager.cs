using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.IO;

public static class SaveManager 
{
    public static readonly string save_folder = Application.persistentDataPath + "/GameData/";

    public static void Init()
    {
        if (!Directory.Exists(save_folder))
        {
            Directory.CreateDirectory(save_folder);
        }
    }

    public static void SaveProgress(string saveString, int slotNumber)
    {
        File.WriteAllText(save_folder + "/playerSave_" + slotNumber + ".json", saveString);
    }

    public static string LoadProgress(int slotNumber)
    {
         if (File.Exists(save_folder + "/playerSave_" + slotNumber + ".json"))
        {
            string contents = File.ReadAllText(save_folder + "/playerSave_" + slotNumber + ".json");
            return contents;
        }

        else
        {
            return null;
        }
    }

    public static void deleteSaveSlot(int slotNumber)
    {
        if(File.Exists(save_folder + "/playerSave_" + slotNumber + ".json"))
        {
            File.Delete(save_folder + "/playerSave_" + slotNumber + ".json");
        }
    }
    
}
