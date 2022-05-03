using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine;

[CustomEditor(typeof(UIUpdater))]
public class Inspector_UIUpdater : Editor
{
    float thumbnailWidth = 70;
    float thumbnailHeight = 70;
    float labelWidth = 150f;

    SerializedProperty allSceneButtons;
    SerializedProperty hoverSprite;
    SerializedProperty clickedSprite;
    SerializedProperty normalSprite;
    SerializedProperty eventProp;

    private void OnEnable()
    {
        allSceneButtons = serializedObject.FindProperty("AllSceneButtons");
        hoverSprite = serializedObject.FindProperty("HoverSprite");
        clickedSprite = serializedObject.FindProperty("ClickedSprite");
        normalSprite = serializedObject.FindProperty("NormalSprite");
        eventProp = serializedObject.FindProperty("Event");
    }

    public override void OnInspectorGUI()
    {

        UIUpdater uIUpdater = (UIUpdater)target;

        GUILayout.Space(20f);
        GUILayout.Label("UI Updater", EditorStyles.boldLabel);
        GUILayout.Space(20f);


        GUILayout.Label("Button Sprites:", EditorStyles.boldLabel);
        GUILayout.Space(20f);


        EditorGUILayout.PropertyField(normalSprite, new GUIContent("Normal Sprite"), true);
        EditorGUILayout.PropertyField(hoverSprite, new GUIContent("Hover Sprite"), true);
        EditorGUILayout.PropertyField(clickedSprite, new GUIContent("Clicked Sprite"), true);
        GUILayout.Space(20f);
        EditorGUILayout.PropertyField(allSceneButtons, new GUIContent("All Scene Buttons"), true);
        GUILayout.Space(20f);

        GUILayout.Label("Generic OnClick Functions:", EditorStyles.boldLabel);
        GUILayout.Space(20f);
        EditorGUILayout.PropertyField(eventProp, new GUIContent("Event"), true);
        GUILayout.Space(20f);

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Update Button UI"))
        {
            uIUpdater.AllSceneButtons.Clear();

            uIUpdater.CanvasScalar = FindObjectOfType<CanvasScaler>();

            var buttons = FindObjectsOfType<Button>();

            foreach (var button in buttons)
            {
                uIUpdater.AllSceneButtons.Add(button);
            }

            uIUpdater.UpdateButtonSprites();

            Debug.Log("Buttons Found");
        }

        if (GUILayout.Button("Apply OnClick Functions"))
        {
            uIUpdater.ApplyGenericOnClickFunction();
        }

        GUILayout.EndHorizontal();


        serializedObject.ApplyModifiedProperties();
    }
}
