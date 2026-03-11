using Yulinti.Nucleus.Contractus;
using System;
using UnityEngine;

namespace Yulinti.ImperiumMaius.Augustus {
    public class CarnifexBasis : ICarnifex {
        public void Notare(string textus) {
#if UNITY_EDITOR
            UnityEngine.Debug.LogWarning(textus);
#endif
        }

        public void Error(string textus) {
            UnityEngine.Debug.LogError(textus);
        }

        public void Error(Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
        
        public void Intermissio(string textus) {
            UnityEngine.Debug.LogError(textus);
            UnityEngine.Application.Quit();
        }

        public void Intermissio(Exception exception) {
            UnityEngine.Debug.LogException(exception);
            UnityEngine.Application.Quit();
        }
    }
}