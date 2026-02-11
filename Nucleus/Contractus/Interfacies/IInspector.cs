using System;
using System.Numerics;

namespace Yulinti.Nucleus.Contractus {
    public interface IInspector {
        // ロギング
        void Memorare(IDVitium idVitium, string textus);
        void Memorare(IDVitium idVitium, Exception exception);

        // 値のロギング
        void MemorareParametrum(string key, int value);
        void MemorareParametrum(string key, float value);
        void MemorareParametrum(string key, bool value);
        void MemorareParametrum(string key, string value);
        void MemorareParametrum(string key, Vector3 value);
        void MemorareParametrum(string key, Quaternion value);
        void MemorareParametrum(string key, Vector2 value);

        // エラー終了
        void Intermissio(string textus);
        void Intermissio(Exception exception);
    }
}