using UnityEngine;
using System.Collections;

namespace Relentless {

    public class UserInterfaceToggle : MonoBehaviour {

        [Tooltip("The abstract input that triggers this toggle as defined by the InputManager")]
        public string input;

        [Tooltip("The UI game object that is activated during this toggle")]
        public GameObject target;

        [Tooltip("The initial active state of the toggled game object")]
        public bool initialState;

        [Tooltip("Indicates if this hotkey respects or ignores the capture of input")]
        public bool respectsKeyCapture = true;

        [Tooltip("Allows the Escape custom input to double as the dismiss key")]
        public bool escapeToCancel = false;

        internal void OnEnable() {
            target.SetActive(initialState);
        }

        internal void Update() {
            var match = Input.GetButtonDown(input);
            var escape = escapeToCancel && Input.GetButtonDown("Cancel");
            if((escape || match) && target.activeSelf) { // dismissing UI doesn't require capture,
                target.SetActive(false);
                return;
            }
            if(respectsKeyCapture && CustomInput.IsCaptured()) {
                return;
            }
            if(match && !target.activeSelf) { // but enabling it does.
                target.SetActive(true);
            }
        }

    }

}
