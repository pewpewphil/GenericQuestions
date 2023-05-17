using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;
using UnityEditor.UIElements;

[CustomEditor(typeof(UITesting))]

public class UITestingEditor : Editor
{
    UITesting _target;
    public VisualTreeAsset m_InspectorXML;

    //private void CreateGUI()
    //{
    //    Debug.Log("creating GUI");
    //    _target = (UITesting)target;
    //}

    public override VisualElement CreateInspectorGUI()
    {
        // Create a new VisualElement to be the root of our inspector UI
        VisualElement myInspector = new VisualElement();
        // Add a simple label
        myInspector.Add(new Label("This is a custom inspector"));
        //myInspector.Add(new Button());

        // Load and clone a visual tree from UXML
        //VisualTreeAsset visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Code/UI/Editor/UITestingEditor.uxml");
        m_InspectorXML.CloneTree(myInspector);

        // Get a reference to the default inspector foldout control
        VisualElement inspectorFoldout = myInspector.Q("Default_Inspector");

        // Attach a default inspector to the foldout
        InspectorElement.FillDefaultInspector(inspectorFoldout, serializedObject, this);

        return myInspector;
    }
}
