using Yulinti.Nucleus.Contractus;
using System;

namespace Yulinti.Nucleus.Instrumentarium {
    public static class Carnifex {
        public static IInspector Inspector;

        public static void Inscribere(IInspector inspector) {
            Inspector = inspector;
        }

        public static void Intermissio(string textus) {
            Inspector?.Intermissio(textus);
        }

        public static void Intermissio(Exception exception) {
            Inspector?.Intermissio(exception);
        }
    }
}
