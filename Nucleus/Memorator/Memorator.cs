using UnityEngine;
using System.Diagnostics;
using System;

namespace Yulinti.Nucleus {
    public static class Memorator {

        [Conditional("UNITY_EDITOR")]
        public static void MemorareErrorum(IDErrorum error) {
            UnityEngine.Debug.LogError("Error: " + error);
        }

        [Conditional("UNITY_EDITOR")]
        public static void MemorareException(Exception exception) {
            UnityEngine.Debug.LogError("Error: " + exception);
        }
    }
}



