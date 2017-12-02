using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasScaler))]
public class HighDpiScaleFactor : MonoBehaviour {

    internal void Start () {
        var scaler = GetComponent<CanvasScaler>();
        if(Screen.dpi >= 360 || Screen.height > 2100) { // iPad and iPhone screenshots on PC.
            scaler.scaleFactor = 3;
        }
        else if(Screen.dpi > 250 || Screen.height > 1050) {
            scaler.scaleFactor = 2;
        }
        else {
            scaler.scaleFactor = 1;
        }
    }

}
