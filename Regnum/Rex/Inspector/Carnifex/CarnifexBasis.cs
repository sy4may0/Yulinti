using Yulinti.Nucleus.Contractus;
using System;
using UnityEngine;

namespace Yulinti.Regnum.Rex {
    public class CarnifexBasis : ICarnifex {
        public void Notare(string textus) {
#if UNITY_EDITOR
            UnityEngine.Debug.LogWarning(textus);
#endif
        }

        public void Error(string textus) {
#if UNITY_EDITOR
            UnityEngine.Debug.LogError(textus);
#endif
        }

        public void Error(Exception exception) {
#if UNITY_EDITOR
            UnityEngine.Debug.LogException(exception);
#endif
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