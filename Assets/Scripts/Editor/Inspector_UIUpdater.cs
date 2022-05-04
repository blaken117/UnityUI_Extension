using UnityEditor;
using UnityEngine.UI;
using UnityEngine;

[CustomEditor(typeof(UIUpdater))]
public class Inspector_UIUpdater : Editor
{
    SerializedProperty allSceneButtons;
    SerializedProperty hoverSprite;
    SerializedProperty clickedSprite;
    SerializedProperty normalSprite;

    private void OnEnable()
    {
        allSceneButtons = serializedObject.FindProperty("AllSceneButtons");
        hoverSprite = serializedObject.FindProperty("HoverSprite");
        clickedSprite = serializedObject.FindProperty("ClickedSprite");
        normalSprite = serializedObject.FindProperty("NormalSprite");
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

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Find All Buttons"))
        {
            uIUpdater.AllSceneButtons.Clear();

            uIUpdater.CanvasScalar = FindObjectOfType<CanvasScaler>();

            var buttons = FindObjectsOfType<Button>();

            foreach (var button in buttons)
            {
                uIUpdater.AllSceneButtons.Add(button);
            }

            Debug.Log(uIUpdater.AllSceneButtons.Count + " Buttons Found");
        }

        if (GUILayout.Button("Apply Sprites"))
        {
            uIUpdater.UpdateButtonSprites();

            Debug.Log("All Button Sprites Updated");
        }

        if (GUILayout.Button("Apply Event Triggers"))
        {
            uIUpdater.ApplyEventTriggersToButtons();

            Debug.Log("All Events Applied to Buttons");

            Repaint();
        }

        GUILayout.EndHorizontal();

        serializedObject.ApplyModifiedProperties();
    }
}
