using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PrefixSums))]
public class PrefixSumEditor : Editor
{
    PrefixSums _target;
    private void OnEnable()
    {
        _target = (PrefixSums)target;
    }
    public override void OnInspectorGUI()
    {
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("prefixSums"))
        {
            _target.RunPrefixSums();
        }
        if (GUILayout.Button("SumCounts"))
        {
            _target.RunPrefixSumsWithCount();
        }


        GUILayout.EndHorizontal();
        base.OnInspectorGUI();
    }
}
