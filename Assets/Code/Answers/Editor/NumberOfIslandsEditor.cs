using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(NumberOfIslands))]
public class NumberOfIslandsEditor : Editor
{
    NumberOfIslands _target;
    private void OnEnable()
    {
        _target = (NumberOfIslands)target;
    }

    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("NumberOfIslandsV1"))
        {
            _target.CountIslandsCallV1();
        }

        if (GUILayout.Button("NumberOfIslandsV2"))
        {
            _target.CountIslandsCallV2();
        }
        base.OnInspectorGUI();
    }
}
