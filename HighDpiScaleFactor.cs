using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasScaler))]
public class HighDpiScaleFactor : MonoBehaviour {

    [Tooltip("The DPI to switch to 2X mode, recommended value is 250.")]
    public float doubleDpi = 250;

    [Tooltip("The DPI to switch to 3X mode, recommended value is 360.")]
    public float tripleDpi = 360;

    internal void Start () {
        var scaler = GetComponent<CanvasScaler>();
        if(Screen.dpi >= tripleDpi || Screen.height > 2100) { // iPad and iPhone screenshots on PC.
            scaler.scaleFactor = 3;
        }
        else if(Screen.dpi > doubleDpi || Screen.height > 1050) {
            scaler.scaleFactor = 2;
        }
        else {
            scaler.scaleFactor = 1;
        }
    }

}
