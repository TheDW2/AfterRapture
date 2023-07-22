using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDataContainer", menuName = "ConversationData/Data")]
public class ConversationData : PersistentScriptableObject
{
    public List<BuleanDataConversation> dataBoolList = new List<BuleanDataConversation>();
    public List<IntDataConversation> dataIntList = new List<IntDataConversation>();
    public List<IntModifierClass> IntModifierClassList = new List<IntModifierClass>();
}


[System.Serializable]
public class BuleanDataConversation
{
    public string name;
    public bool value;
}

[System.Serializable]
public class IntDataConversation
{
    public string name;
    public int value;
}

[System.Serializable]
public class IntModifierClass
{
    public int id;
    public string name;
    public int valueToBeAddedOrSubtracted;  
}

