using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MyEditorWindow : EditorWindow
{
    [MenuItem("MyTool/MyEditorWindow %g")] // ����Ű ctrl + g
    static void Open()
    {
        var window = GetWindow<MyEditorWindow>();
        window.titleContent = new GUIContent("MyTool");
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(250, 0, 100, 50), "GUI.Label");
        EditorGUI.LabelField(new Rect(250, 50, 100, 50), "EditorGUI.LabelField");

        // Layout�� �ǹ̴� Unity�� �ڵ� Layout system�� ����� GUI
        GUILayout.Label("GUILayout.Label");
        EditorGUILayout.LabelField("EditorGUILayout.LabelField");

        // GUI�� Editor GUI�� �и��� ����
        // Editor GUI�� Inspector�� ���� Editor������ ��� ����
        // Editor�� �ƴ϶� ���� �������� ��밡���� GUI�� GUI�� ����ؾ���
    }
}
