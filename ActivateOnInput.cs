using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnInput : MonoBehaviour {

    [Tooltip("The key to determine if the game object should be toggled.")]
    public KeyCode key;

    [Tooltip("The game object to show/hide, typically a GUI element.")]
    public GameObject target;
	
	internal void Update () {
	    if(Input.GetKeyDown(key)) {
            target.SetActive(!target.activeSelf);
        }
	}

}
