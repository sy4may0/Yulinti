using UnityEngine;
using Yulinti.Nucleus.Contractus;
using System;

namespace Yulinti.Imperium.Augustus {
    public sealed class Inspector : IInspector {
        public void Memorare(IDVitium idVitium, string textus) {
#if UNITY_EDITOR
            switch (idVitium) {
                case IDVitium.WARNING:
                    UnityEngine.Debug.LogWarning(textus);
                    break;
                case IDVitium.ERROR:
                case IDVitium.FATAL:
                    UnityEngine.Debug.LogError(textus);
                    break;
                default:
                    UnityEngine.Debug.Log(textus);
                    break;
            }
#endif
        }

        public void Memorare(IDVitium idVitium, Exception exception) {
#if UNITY_EDITOR
            UnityEngine.Debug.LogException(exception);
#endif
        }

        public void MemorareParametrum(string key, int value) {
#if UNITY_EDITOR
            UnityEngine.Debug.Log(key);
            UnityEngine.Debug.Log(value);
#endif
        }

        public void MemorareParametrum(string key, float value) {
#if UNITY_EDITOR
            UnityEngine.Debug.Log(key);
            UnityEngine.Debug.Log(value);
#endif
        }

        public void MemorareParametrum(string key, bool value) {
#if UNITY_EDITOR
            UnityEngine.Debug.Log(key);
            UnityEngine.Debug.Log(value);
#endif
        }

        public void MemorareParametrum(string key, string value) {
#if UNITY_EDITOR
            UnityEngine.Debug.Log(key);
            UnityEngine.Debug.Log(value);
#endif
        }

        public void MemorareParametrum(string key, System.Numerics.Vector3 value) {
#if UNITY_EDITOR
            UnityEngine.Debug.Log(key);
            UnityEngine.Debug.Log(value);
#endif
        }

        public void MemorareParametrum(string key, System.Numerics.Quaternion value) {
#if UNITY_EDITOR
            UnityEngine.Debug.Log(key);
            UnityEngine.Debug.Log(value);
#endif
        }

        public void MemorareParametrum(string key, System.Numerics.Vector2 value) {
#if UNITY_EDITOR
            UnityEngine.Debug.Log(key);
            UnityEngine.Debug.Log(value);
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
