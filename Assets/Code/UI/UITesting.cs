using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;

public class UITesting:MonoBehaviour
{
    public string m_Make = "Toyota";
    public float m_year = 1969;
    public Color m_currentColor = Color.black;

    public UITestSubclass[] m_testingSub = new UITestSubclass[4];
    private void Start()
    {
        Debug.Log("starting");
    }

}
//EditorWindow
//createGui
