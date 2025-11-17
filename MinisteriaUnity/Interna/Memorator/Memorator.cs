using UnityEngine;
using System.Diagnostics;
using Yulinti.MinisteriaUnity.Interna.InstulmentaAnimancer;

namespace Yulinti.MinisteriaUnity.Interna {
    public static class Memorator {

        [Conditional("UNITY_EDITOR")]
        public static void MemorareErrorum(string msg) {
            UnityEngine.Debug.LogError(msg);
        }

        // UpdateからはGC回避のため↓を使え。
        [Conditional("UNITY_EDITOR")]
        public static void MemorareLuditorAnimationisCircularisImpeditivus(IStructuraAnimationis animatio) {
            string msg = $"{animatio?.GetType()} はループかつブロッキングが許可されています。.";
            MemorareErrorum(msg);
        }
    }
}



