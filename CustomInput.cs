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

    }

}
