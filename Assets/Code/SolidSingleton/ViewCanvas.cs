using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewCanvas : MonoBehaviour
{
    public Canvas currentCanvas;
    public GraphicRaycaster currentGRayCaster;
    public GameObject ButtonParent;
    
    bool _isOn;
    public bool isOn 
    {
        set
        {
            _isOn = isOn;
            currentCanvas.enabled = isOn;
            currentGRayCaster.enabled = isOn;
        }
        
        get 
        {
            return _isOn;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ColorStateSingleton.OnColorStateChange -= listeningToColorStateChange;
        ColorStateSingleton.OnColorStateChange += listeningToColorStateChange;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        ColorStateSingleton.OnColorStateChange -= listeningToColorStateChange;
    }

    public static void listeningToColorStateChange(ColorState cs )
    {
        Debug.Log("ViewCanvas colorstate is=" + cs);
    }
}
