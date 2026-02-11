using Yulinti.Nucleus.Contractus;
using System;
using System.Numerics;

namespace Yulinti.Nucleus.Instrumentarium {
    public static class Notarius {
        // InspectorはUnity依存のDebug Logを使用するため、UnityNamespace内からDIする。
        // これにより、Unity非依存環境でのInspectorの使用が可能となる。
        public static IInspector Inspector;

        public static void Inscribere(IInspector inspector) {
            Inspector = inspector;
        }

        public static void Memorare(IDVitium idVitium, string textus) {
            Inspector?.Memorare(idVitium, textus);
        }

        public static void Memorare(IDVitium idVitium, Exception exception) {
            Inspector?.Memorare(idVitium, exception);
        }

        public static void Memorare(string textus) {
            Memorare(IDVitium.ERROR, textus);
        }

        public static void Memorare(Exception exception) {
            Memorare(IDVitium.ERROR, exception);
        }

        public static void MemorareParametrum(string key, int value) {
            Inspector?.MemorareParametrum(key, value);
        }

        public static void MemorareParametrum(string key, float value) {
            Inspector?.MemorareParametrum(key, value);
        }

        public static void MemorareParametrum(string key, bool value) {
            Inspector?.MemorareParametrum(key, value);
        }

        public static void MemorareParametrum(string key, string value) {
            Inspector?.MemorareParametrum(key, value);
        }

        public static void MemorareParametrum(string key, Vector3 value) {
            Inspector?.MemorareParametrum(key, value);
        }

        public static void MemorareParametrum(string key, Quaternion value) {
            Inspector?.MemorareParametrum(key, value);
        }

        public static void MemorareParametrum(string key, Vector2 value) {
            Inspector?.MemorareParametrum(key, value);
        }
    }
}
