using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorStateSingleton : MonoBehaviour
{

    [Header("selectionResponse subclass")]
    private ISelectColor selectionResponse;
    private ISelectColorButtons selectionColor;

    [SerializeField]
    ColorState _currentColor;
    public ColorState currentColor
    {
        set
        {
            _currentColor = value;
           
        }
       get
        {
            return _currentColor;
        }
    }

    private void Awake()
    {
        selectionResponse = GetComponent<ISelectColor>();
        selectionColor = GetComponent<ISelectColorButtons>();
    }


    private void Start()
    {
        selectionColor.InitializeButtons();
        OnColorStateChange -= listeningToColorStateChange;
        OnColorStateChange += listeningToColorStateChange;
    }

    public void OnDestroy()
    {
        OnColorStateChange -= listeningToColorStateChange;
    }

    public void listeningToColorStateChange(ColorState cs)
    {
        currentColor = cs;
    }

    public delegate void ColorStateChange(ColorState currentColor);
    public static ColorStateChange OnColorStateChange;// event for inclasss invoking, non eveent for out of class useage 
}



public enum ColorState 
{ 
    red=0,
    green=1,
    blue=2
}
