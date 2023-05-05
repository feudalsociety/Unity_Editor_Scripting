using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SerializedPropEditorWindow : EditorWindow
{
    [MenuItem("MyTool/SerializedPropEditor")]
    static void Open()
    {
        var window = GetWindow<SerializedPropEditorWindow>();
        window.titleContent = new GUIContent("SerializedPropEditor");
    }

    Dictionary<SerializedObject, List<SerializedProperty>> Targets = new Dictionary<SerializedObject, List<SerializedProperty>>();
    bool isFocused;

    private void Update()
    {
       if(isFocused == false)
       {
           foreach(var item in Targets)
           {
               item.Key.Update();
           }
           Repaint();
       }
    }

    private void OnGUI()
    {
        if(GUILayout.Button("Refresh!!"))
        {
            Targets.Clear();

            // scene�� �ִ� ��� CustomScripts���� �����´�.
            var allCustoms = FindObjectsOfType<CustomScript>();

            if(allCustoms != null)
            {
                for(int i = 0; i < allCustoms.Length; i++)
                {
                    var so = new SerializedObject(allCustoms[i]);
                    var props = new List<SerializedProperty>()
                    {
                        so.FindProperty(nameof(CustomScript.otherObject)),
                        so.FindProperty(nameof(CustomScript.myName)),
                        so.FindProperty(nameof(CustomScript.myHP))
                    };
                    Targets.Add(so, props);
                }
            }
        }

        foreach (var pair in Targets)
        {
            EditorGUI.BeginChangeCheck();
            {
                EditorGUILayout.LabelField(pair.Key.targetObject.name, EditorStyles.boldLabel);
                EditorGUI.indentLevel++;
                {
                    foreach (var prop in pair.Value)
                    {
                        // ���� datatype�� �´� gui ������� drawing
                        // Serializedpropety ��ü�� gui drawing�� �������� �ٰŰ� �ִ�.
                        EditorGUILayout.PropertyField(prop);
                    }
                }
                EditorGUI.indentLevel--;

                EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
            }

            if (EditorGUI.EndChangeCheck())
            {
                pair.Key.ApplyModifiedProperties();
            }
        }
    }

    private void OnFocus()
    {
        isFocused = true;
    }

    private void OnLostFocus()
    {
        isFocused = false;
    }
}
