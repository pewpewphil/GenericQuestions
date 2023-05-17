using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

[CustomPropertyDrawer(typeof(UITestingEditor))]
public class SubClassPropertyDrawer : PropertyDrawer
{
   public override VisualElement CreatePropertyGUI(SerializedProperty property)
    {
        // Create a new VisualElement to be the root the property UI
        var container = new VisualElement();

        // Create drawer UI using C#
        var popup = new UnityEngine.UIElements.PopupWindow();
        popup.text = "sub class Details";
        popup.Add(new PropertyField(property.FindPropertyRelative("m_depth"), "depth (m)"));
        popup.Add(new PropertyField(property.FindPropertyRelative("m_priority"), "priority (#)"));
        container.Add(popup);

        // Return the finished UI
        return container;
    }
}
