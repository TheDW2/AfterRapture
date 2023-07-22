using System.Net.Mime;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using DialogueEditor;

public abstract class PersistentScriptableObject : ScriptableObject
{
    public void SaveConversationData(string fileName = null)
    {
        var bf = new BinaryFormatter();
        var file = File.Create(GethPath(fileName));
        var json = JsonUtility.ToJson(this);

        bf.Serialize(file, json);
        file.Close();
    }

    public virtual void LoadConversationData(string fileName = null)
    {
        if(File.Exists(GethPath(fileName)))
        {
            var bf = new BinaryFormatter();
            var file = File.Open(GethPath(fileName), FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), this);
            file.Close();
        }
    }

    private string GethPath(string fileName = null)
    {
        var fullFileName = string.IsNullOrEmpty(fileName) ? name : fileName;
        return string.Format("{0}/{1}.pso", Application.persistentDataPath, fullFileName);
    }
}