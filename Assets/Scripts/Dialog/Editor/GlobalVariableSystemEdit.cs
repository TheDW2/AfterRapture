using System.Linq;
using UnityEngine;
using UnityEditor;
using DialogueEditor;

[CustomEditor(typeof(GlobalVariables))]
public class GlobalVariableSystemEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        if (GUILayout.Button("Open Global Variables"))
        {
            GlobalVariableSystemWindow.ShowWindow((GlobalVariables)target);
        }

        serializedObject.ApplyModifiedProperties();
    }
}

public class GlobalVariableSystemWindow : EditorWindow
{
    private GlobalVariables globalVariables;
    private Vector2 scrollPosition;
    private NPCConversation currentAsset;
    private Transform newlySelectedAsset;

    public static void ShowWindow(GlobalVariables globalVariable)
    {
        var window = GetWindow<GlobalVariableSystemWindow>();
        window.titleContent = new GUIContent("GlobalVariableSystem");
        window.Show();
        globalVariable.LoadConversationData();
        window.globalVariables = globalVariable;

    }

    private void OnGUI()
    {
        if (globalVariables != null)
        {
            if (GUILayout.Button("SaveChanges"))
            {
                globalVariables.SaveConversationData();
            }
            if (GUILayout.Button("SetParam"))
            {
                SetBoolParameters();
                SetIntParameters();
            }

            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Add bool"))
            {
                string newName = GetValidBoolParamName("New Global bool");
                BuleanDataConversation newBoolParam = new BuleanDataConversation();
                newBoolParam.name = newName;
                globalVariables.globalParameterListBool.Add(newBoolParam);

                globalVariables.SaveConversationData();
            }
            if (GUILayout.Button("Add int"))
            {
                string newName = GetValidIntParamName("New Global int");
                IntDataConversation newIntParam = new IntDataConversation();
                newIntParam.name = newName;
                globalVariables.globalParameterListInt.Add(newIntParam);
                
                globalVariables.SaveConversationData();
            }
            GUILayout.EndHorizontal();

            for (int i = 0; i < globalVariables.globalParameterListInt.Count + globalVariables.globalParameterListBool.Count; i++)
            {
                EditorGUILayout.BeginVertical(EditorStyles.helpBox);

                float paramNameWidth = 250 * 0.6f;

                if (i < globalVariables.globalParameterListBool.Count)
                {
                    // Boolean variable
                    BuleanDataConversation boolParam = globalVariables.globalParameterListBool[i];
                    string paramName = boolParam.name;
                    bool paramValue = boolParam.value;

                    paramName = GUILayout.TextField(paramName, 24, GUILayout.Width(paramNameWidth), GUILayout.ExpandWidth(false));
                    paramValue = EditorGUILayout.Toggle(paramValue);

                    boolParam.name = paramName;
                    boolParam.value = paramValue;
                }
                else
                {
                    // Integer variable
                    int intIndex = i - globalVariables.globalParameterListBool.Count;
                    IntDataConversation intParam = globalVariables.globalParameterListInt[intIndex];
                    string paramName = intParam.name;
                    int paramValue = intParam.value;

                    paramName = GUILayout.TextField(paramName, 24, GUILayout.Width(paramNameWidth), GUILayout.ExpandWidth(false));
                    paramValue = EditorGUILayout.IntField(paramValue);

                    intParam.name = paramName;
                    intParam.value = paramValue;
                }

                if (GUILayout.Button("X"))
                {
                    if (i < globalVariables.globalParameterListBool.Count)
                    {
                        // Remove from the boolean variables list
                        globalVariables.globalParameterListBool.RemoveAt(i);

                        globalVariables.SaveConversationData();
                    }
                    else
                    {
                        // Remove from the integer variables list
                        int intIndex = i - globalVariables.globalParameterListBool.Count;
                        globalVariables.globalParameterListInt.RemoveAt(intIndex);
                        
                        globalVariables.SaveConversationData();
                    }
                    i--;
                }

                EditorGUILayout.EndVertical();
            }

            EditorGUILayout.EndScrollView();
        }
    }

    private string GetValidIntParamName(string baseName)
    {
        string newName = baseName;

        if (globalVariables != null && globalVariables.globalParameterListInt != null)
        {
            if (globalVariables.globalParameterListInt.Any(param => param.name == newName))
            {
                int counter = 0;
                do
                {
                    newName = baseName + "_" + counter;
                    counter++;
                } while (globalVariables.globalParameterListInt.Any(param => param.name == newName));
            }
        }
        return newName;
    }

    private string GetValidBoolParamName(string baseName)
    {
        string newName = baseName;

        if (globalVariables != null && globalVariables.globalParameterListBool != null)
        {
            if (globalVariables.globalParameterListBool.Any(param => param.name == newName))
            {
                int counter = 0;
                do
                {
                    newName = baseName + "_" + counter;
                    counter++;
                } while (globalVariables.globalParameterListBool.Any(param => param.name == newName));
            }
        }
        return newName;
    }

    private void SetBoolParameters()
    {

        newlySelectedAsset = Selection.activeTransform;
        if (newlySelectedAsset == null)
        {
            // Handle the case when no object is selected
            EditorUtility.DisplayDialog("Error", "No object is selected", "OK");
            return;
        }

        currentAsset = newlySelectedAsset.GetComponent<NPCConversation>();
        if (currentAsset == null)
        {
            // Handle the case when NPCConversation component is missing
            EditorUtility.DisplayDialog("Error", "NPCConversation component is missing", "OK");
            return;
        }

        foreach (var globalParameter in globalVariables.globalParameterListBool)
        {
            var existingParameter = currentAsset.ParameterList.Find(p => p.ParameterName == globalParameter.name);
            if (existingParameter != null)
            {
                if (existingParameter is EditableBoolParameter boolParameter)
                {
                    boolParameter.BoolValue = globalParameter.value;
                }
            }
            else
            {
                if (globalParameter.value)
                {
                    currentAsset.ParameterList.Add(new EditableBoolParameter(globalParameter.name) { BoolValue = true });
                }
                else
                {
                    currentAsset.ParameterList.Add(new EditableBoolParameter(globalParameter.name));
                }
            }
        }

        globalVariables.SaveConversationData();
    }

    private void SetIntParameters()
    {

        newlySelectedAsset = Selection.activeTransform;
        if (newlySelectedAsset == null)
        {
            // Handle the case when no object is selected
            EditorUtility.DisplayDialog("Error", "No object is selected", "OK");
            return;
        }

        currentAsset = newlySelectedAsset.GetComponent<NPCConversation>();
        if (currentAsset == null)
        {
            // Handle the case when NPCConversation component is missing
            EditorUtility.DisplayDialog("Error", "NPCConversation component is missing", "OK");
            return;
        }

        foreach (var globalParameter in globalVariables.globalParameterListInt)
        {
            var existingParameter = currentAsset.ParameterList.Find(p => p.ParameterName == globalParameter.name);
            if (existingParameter != null)
            {
                if (existingParameter is EditableIntParameter intParameter)
                {
                    intParameter.IntValue = globalParameter.value;
                }
            }
            else
            {
                currentAsset.ParameterList.Add(new EditableIntParameter(globalParameter.name) { IntValue = globalParameter.value });
            }
        }

        globalVariables.SaveConversationData();
    }
}
