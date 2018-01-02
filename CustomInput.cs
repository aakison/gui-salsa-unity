using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Relentless {
    public class CustomInput {

        public static void Capture(GameObject captureTarget) {
            CaptureTarget = captureTarget;
        }

        public static void Release(GameObject captureTarget) {
            if(CaptureTarget == captureTarget) {
                CaptureTarget = null;
            }
        }

        public static bool IsCaptured() {
            return CaptureTarget != null;
        }

        public static GameObject CaptureTarget { get; private set; }

        public static bool GetInput(CustomInputCode code) {
            switch(code) {
                case CustomInputCode.Inventory1:
                    return Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1);
                case CustomInputCode.Inventory2:
                    return Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2);
                case CustomInputCode.Inventory3:
                    return Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3);
                case CustomInputCode.Inventory4:
                    return Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4);
                case CustomInputCode.Inventory5:
                    return Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5);
                case CustomInputCode.Inventory6:
                    return Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6);
                case CustomInputCode.Inventory7:
                    return Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad7);
                case CustomInputCode.Inventory8:
                    return Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Keypad8);
                case CustomInputCode.Inventory9:
                    return Input.GetKeyDown(KeyCode.Alpha9) || Input.GetKeyDown(KeyCode.Keypad9);
                case CustomInputCode.StatsPanel:
                    return Input.GetKeyDown(KeyCode.F4);
                case CustomInputCode.CommandPanel:
                    return Input.GetKeyDown(KeyCode.Slash);
                case CustomInputCode.Use:
                    return Input.GetKeyDown(KeyCode.E);
                case CustomInputCode.Escape:
                    return Input.GetKeyDown(KeyCode.Escape);
                case CustomInputCode.Craft:
                    return Input.GetKeyDown(KeyCode.C);
                default:
                    return false;
            }
        }

    }

    public enum CustomInputCode {
        Inventory1,
        Inventory2,
        Inventory3,
        Inventory4,
        Inventory5,
        Inventory6,
        Inventory7,
        Inventory8,
        Inventory9,
        StatsPanel,
        CommandPanel,
        Use,
        Escape,
        Craft,
    }

}
