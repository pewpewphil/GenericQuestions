using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonBase : MonoBehaviour
{
    public TextMeshProUGUI currentText;
    public Button currentButton; 
    public ColorState currentState;

    public void InitializeButton(ColorState inputState)
    {
        currentState = inputState;
        currentText.text = inputState.ToString();
    }

}
