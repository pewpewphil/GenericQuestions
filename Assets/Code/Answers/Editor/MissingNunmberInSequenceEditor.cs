using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MissingNunmberInSequence))]
public class MissingNunmberInSequenceEditor : Editor
{
    MissingNunmberInSequence _target;
    private void OnEnable()
    {
        _target = (MissingNunmberInSequence)target;
    }
    public override void OnInspectorGUI()
    {
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("MissingWExcept"))
        {
            _target.EditorRunMissionException();
        }

        if (GUILayout.Button("MissingWDict"))
        {
            _target.EditorRunDictMissionException();
        }

        if (GUILayout.Button("MissingWAdd"))
        {
            _target.EditorRunAddMissionException();
        }

        GUILayout.EndHorizontal();
        base.OnInspectorGUI();
    }
}
