using System;
using UnityEngine;
using System.Numerics;

namespace Yulinti.Exercitus.Contractus {

    public enum IDVitium {
        INFO,
        WARNING,
        ERROR
    }

    public interface ITurrisVitium {
        // ログを書き出し。
        void Memorare(IDVitium idVitium, Exception exception);
        void Memorare(IDVitium idVitium, string textus);

        // パラメータを書き出し。
        void MemorareParametrum(string k, int v);
        void MemorareParametrum(string k, float v);
        void MemorareParametrum(string k, bool v);
        void MemorareParametrum(string k, string v);
        void MemorareParametrum(string k, UnityEngine.Vector3 v);
        void MemorareParametrum(string k, UnityEngine.Quaternion v);
        void MemorareParametrum(string k, UnityEngine.Vector2 v);
        void MemorareParametrum(string k, System.Numerics.Vector3 v);
        void MemorareParametrum(string k, System.Numerics.Quaternion v);
        void MemorareParametrum(string k, System.Numerics.Vector2 v);

        // ゲーム異常終了
        void Intermissio(string textus);
    }
}