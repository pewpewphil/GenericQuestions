using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Anagrams))]
public class AnagramsEditor : Editor
{
    Anagrams _target;
    private void OnEnable()
    {
        _target = (Anagrams)target;
    }

    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("Check Anagram"))
        {
            _target.CheckAnagrams();
        }
        base.OnInspectorGUI();
    }
}