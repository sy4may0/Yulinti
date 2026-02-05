using Yulinti.Exercitus.Contractus;
using System;
using UnityEngine;
using System.Numerics;

namespace Yulinti.Unity.Deus {
    internal sealed class TurrisVitium : ITurrisVitium {
        private void MemorareTextus(IDVitium idVitium, string textus) {
            UnityEngine.Debug.Log(idVitium.ToString() + ": " + textus);
        }

        public void Memorare(IDVitium idVitium, Exception exception) {
            MemorareTextus(idVitium, exception.Message);
        }
        public void Memorare(IDVitium idVitium, string textus) {
            MemorareTextus(idVitium, textus);
        }

        // 入力をStringに変換する。
        public void MemorareParametrum(string k, int v) {
            MemorareTextus(IDVitium.INFO, k + ": " + v);
        }

        public void MemorareParametrum(string k, float v) {
            MemorareTextus(IDVitium.INFO, k + ": " + v);
        }

        public void MemorareParametrum(string k, bool v) {
            MemorareTextus(IDVitium.INFO, k + ": " + v);
        }

        public void MemorareParametrum(string k, string v) {
            MemorareTextus(IDVitium.INFO, k + ": " + v);
        }

        public void MemorareParametrum(string k, UnityEngine.Vector3 v) {
            MemorareTextus(IDVitium.INFO, k + ": " + v.ToString());
        }

        public void MemorareParametrum(string k, UnityEngine.Quaternion v) {
            MemorareTextus(IDVitium.INFO, k + ": " + v.ToString());
        }

        public void MemorareParametrum(string k, UnityEngine.Vector2 v) {
            MemorareTextus(IDVitium.INFO, k + ": " + v.ToString());
        }

        public void MemorareParametrum(string k, System.Numerics.Vector3 v) {
            MemorareTextus(IDVitium.INFO, k + ": " + v.ToString());
        }

        public void MemorareParametrum(string k, System.Numerics.Quaternion v) {
            MemorareTextus(IDVitium.INFO, k + ": " + v.ToString());
        }

        public void MemorareParametrum(string k, System.Numerics.Vector2 v) {
            MemorareTextus(IDVitium.INFO, k + ": " + v.ToString());
        }

        public void Intermissio(string textus) {
            UnityEngine.Debug.LogError("Intermission: " + textus);
            UnityEngine.Application.Quit();
        }
    }
}