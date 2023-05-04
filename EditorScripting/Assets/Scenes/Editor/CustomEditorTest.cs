using Codice.Client.BaseCommands.BranchExplorer.Layout;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CustomScript))]
public class CustomEditorTest : Editor
{
    CustomScript targetRef;

    SerializedProperty targetObjectProp;
    SerializedProperty nameProp;
    SerializedProperty hpProp;

    private void OnEnable()
    {
        // ������ Ÿ���� ������� ���� (Generic)
        targetObjectProp = serializedObject.FindProperty($"{nameof(CustomScript.otherObject)}");
        nameProp = serializedObject.FindProperty($"{nameof(CustomScript.myName)}");
        hpProp = serializedObject.FindProperty($"{nameof(CustomScript.myHP)}");

        targetRef = (CustomScript)base.target;
    }

    public override void OnInspectorGUI()
    {
        // base.OnInspectorGUI();

        // ��𼱰� ����� ���� ���� �� �����Ƿ� ������Ʈ
        serializedObject.Update();

        if (hpProp.intValue < 500) GUI.color = Color.red;
        else GUI.color = Color.green;

        hpProp.intValue = EditorGUILayout.IntSlider("HP��", hpProp.intValue, 0, 1000);

        EditorGUILayout.BeginHorizontal();
        {
            GUI.color = Color.blue;
            EditorGUILayout.PrefixLabel("�̸�");
            GUI.color = Color.white;
            nameProp.stringValue = EditorGUILayout.TextArea(nameProp.stringValue);
        }
        EditorGUILayout.EndHorizontal();

        // PropertyField : �ش� Property�� ���� type�� ���� ������� �ٸ��� ó��
        EditorGUILayout.PropertyField(targetObjectProp);

        // ���̿��� ����� ���� ���� �� �����Ƿ� ����
        serializedObject.ApplyModifiedProperties();
    }
}
