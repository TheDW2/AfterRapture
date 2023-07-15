using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ConversationData))]
public class ConversationDataEdit : Editor
{
    private SerializedProperty dataBoolListProperty;
    private SerializedProperty dataIntListProperty;

    private void OnEnable()
    {
        dataBoolListProperty = serializedObject.FindProperty("dataBoolList");
        dataIntListProperty = serializedObject.FindProperty("dataIntList");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(dataBoolListProperty, true);
        EditorGUILayout.PropertyField(dataIntListProperty, true);

        EditorGUILayout.BeginHorizontal();

        if (GUILayout.Button("Clean bool"))
        {
            dataBoolListProperty.ClearArray();
        }

        if (GUILayout.Button("Clean int"))
        {
            dataIntListProperty.ClearArray();
        }

        if (GUILayout.Button("Clean all"))
        {
            dataBoolListProperty.ClearArray();
            dataIntListProperty.ClearArray();
        }

        EditorGUILayout.EndHorizontal();

        serializedObject.ApplyModifiedProperties();
    }
}
