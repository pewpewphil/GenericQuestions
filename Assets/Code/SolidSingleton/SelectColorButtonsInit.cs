using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectColorButtonsInit : MonoBehaviour, ISelectColorButtons
{
    [Header("background object ")]
    public GameObject spawningPrefab;
    [Header("related view canvas ")]
    public ViewCanvas viewCanvas;
    [Header("all the buttons  ")]
    public List<ButtonBase> allButtons;
     

    public void InitializeButtons()
    {
        ButtonBase[] allButtonBase = viewCanvas.ButtonParent.GetComponentsInChildren<ButtonBase>();
        allButtons = new List<ButtonBase>();
        foreach (int i in System.Enum.GetValues(typeof(ColorState)))
        {
            int currentInt = i;
            ColorState currentColorState = (ColorState)i;
            GameObject spawningObject = Instantiate(spawningPrefab, viewCanvas.ButtonParent.transform);
            ButtonBase currentButtonBase = spawningObject.GetComponent<ButtonBase>();
            currentButtonBase.InitializeButton(currentColorState);
            currentButtonBase.currentButton.onClick.RemoveAllListeners();
            currentButtonBase.currentButton.onClick.AddListener(() => ButtonSelected(currentColorState));
            allButtons.Add(currentButtonBase);
        }
    }
    public void ButtonSelected(ColorState currentColorState)
    {
        ColorStateSingleton.OnColorStateChange.Invoke(currentColorState);
    }


}
