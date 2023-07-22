using System;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

[CustomEditor(typeof(ConversationData))]
public class ConversationDataEdit : Editor
{
    private SerializedProperty dataBoolListProperty;
    private SerializedProperty dataIntListProperty;
    private ConversationData Data;

    private void OnEnable()
    {
        dataBoolListProperty = serializedObject.FindProperty("dataBoolList");
        dataIntListProperty = serializedObject.FindProperty("dataIntList");

        Data = (ConversationData)target;
        Data.LoadConversationData();
    }

    public override void OnInspectorGUI()
    {

        serializedObject.Update();

        EditorGUILayout.PropertyField(dataBoolListProperty, true);
        EditorGUILayout.PropertyField(dataIntListProperty, true);

        EditorGUILayout.BeginHorizontal();

        if (GUILayout.Button("Clean bool"))
        {
            bool confirm = EditorUtility.DisplayDialog("Confirm", "Are you sure you want to clean the bool list?", "Yes", "No");
            if (confirm)
            {
                dataBoolListProperty.ClearArray();
                Data.SaveConversationData();
            }
        }

        if (GUILayout.Button("Clean int"))
        {
            bool confirm = EditorUtility.DisplayDialog("Confirm", "Are you sure you want to clean the int list?", "Yes", "No");
            if (confirm)
            {
                dataIntListProperty.ClearArray();
                Data.SaveConversationData();
            }
        }

        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space(10);

        if (GUILayout.Button("Open IntModifier"))
        {
            IntModifierWindow.ShowWindow((ConversationData)target);
        }

        if(GUILayout.Button("SaveChanges"))
        {
            Data.SaveConversationData();
        }

        serializedObject.ApplyModifiedProperties();
    }
}

public class IntModifierWindow : EditorWindow
{
    private ConversationData conversationData;
    private Vector2 scrollPosition;

    public static void ShowWindow(ConversationData data)
    {
        IntModifierWindow window = GetWindow<IntModifierWindow>("IntModifier");
        window.minSize = new Vector2(200, 200);
        data.LoadConversationData();
        window.conversationData = data;
    }

    private void OnGUI()
    {
        EditorGUILayout.LabelField("IntModifier Window");

        if (conversationData != null)
        {
            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);

            for (int i = 0; i < conversationData.IntModifierClassList.Count; i++)
            {
                IntModifierClass intModifier = conversationData.IntModifierClassList[i];

                EditorGUILayout.BeginVertical(EditorStyles.helpBox);

                EditorGUILayout.BeginHorizontal();

                GUILayout.Label("ID", GUILayout.Width(20));
                intModifier.id = i;
                GUILayout.Label(i.ToString(), GUILayout.Width(20));

                EditorGUILayout.LabelField("Name", GUILayout.Width(50));
                intModifier.name = EditorGUILayout.TextField(intModifier.name);

                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();

                GUILayout.Space(20);

                intModifier.valueToBeAddedOrSubtracted = EditorGUILayout.IntField("Value", intModifier.valueToBeAddedOrSubtracted);

                GUILayout.FlexibleSpace();

                GUIStyle redButtonStyle = new GUIStyle(GUI.skin.button);
                redButtonStyle.normal.textColor = Color.red;

                if (GUILayout.Button("Delete", redButtonStyle, GUILayout.Width(60)))
                {
                    DeleteIntModifierClass(i);
                    conversationData.SaveConversationData();
                }

                EditorGUILayout.EndHorizontal();

                EditorGUILayout.EndVertical();

                GUILayout.Space(10);
            }

            if (GUILayout.Button("Add Class"))
            {
                AddNewIntModifierClass();
                conversationData.SaveConversationData();
            }

            EditorGUILayout.EndScrollView();
        }
    }

    private void AddNewIntModifierClass()
    {
        IntModifierClass newIntModifier = new IntModifierClass();
        conversationData.IntModifierClassList.Add(newIntModifier);
        
        conversationData.SaveConversationData();
    }

    private void DeleteIntModifierClass(int index)
    {
        conversationData.IntModifierClassList.RemoveAt(index);

        conversationData.SaveConversationData();
    }
}