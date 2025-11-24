using UnityEngine;
using System.Diagnostics;

namespace Yulinti.Nucleus {
    public static class Memorator {

        [Conditional("UNITY_EDITOR")]
        public static void MemorareErrorum(IDErrorum error) {
            UnityEngine.Debug.LogError("Error: " + error);
        }
    }
}



