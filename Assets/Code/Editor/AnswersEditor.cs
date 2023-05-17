using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Answers))]
public class AnswersEditor : Editor
{
    Answers _target;
    private void OnEnable()
    {
        _target = (Answers)target;
    }
    public override void OnInspectorGUI()
    {
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("answerTwoSum"))
        {
            _target.AnswerTwoSum();
        }
        if (GUILayout.Button("answerAddTwo"))
        {
            _target.AnswerTwoNumbers();
        }
        if (GUILayout.Button("answerSubString"))
        {
            _target.AnswerSubString();
        }
        if (GUILayout.Button("heapSortAnswer"))
        {
            _target.heapSortAnswer();
        }

        GUILayout.EndHorizontal();
        base.OnInspectorGUI();
    }
}
