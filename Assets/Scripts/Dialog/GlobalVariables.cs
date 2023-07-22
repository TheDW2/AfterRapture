using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GlobalVariableSystem", menuName = "ConversationData/GlobalVariable")]
public class GlobalVariables : PersistentScriptableObject
{
    public List<IntDataConversation> globalParameterListInt = new List<IntDataConversation>();
    public List<BuleanDataConversation> globalParameterListBool = new List<BuleanDataConversation>();

    public IntDataConversation GetParameterInt(string name)
    {
        for (int i = 0; i < this.globalParameterListInt.Count; i++)
        {
            if (globalParameterListInt[i].name == name)
            {
                return globalParameterListInt[i];
            }
        }
        return null;
    }

    public BuleanDataConversation GetParameterBool(string name)
    {
        for (int i = 0; i < this.globalParameterListBool.Count; i++)
        {
            if (globalParameterListBool[i].name == name)
            {
                return globalParameterListBool[i];
            }
        }
        return null;
    }
}
