using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal interface ISelectColorButtons 
{
    void InitializeButtons();
    void ButtonSelected(ColorState currentColorState);
}
