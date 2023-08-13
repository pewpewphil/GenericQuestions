using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ClimbingStairs))]
public class ClimbingStairsEditor : Editor
{
    ClimbingStairs _target;
    private void OnEnable()
    {
        _target = (ClimbingStairs)target;
    }

    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("Check Anagram"))
        {
            _target.CheckClimbStairs();
        }
        base.OnInspectorGUI();
    }
}