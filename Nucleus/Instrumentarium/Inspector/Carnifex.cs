using Yulinti.Nucleus.Contractus;
using System;

namespace Yulinti.Nucleus.Instrumentarium {
    public static class Carnifex {
        private static ICarnifex CarnifexEns;

        public static void Inscribere(ICarnifex carnifex) {
            CarnifexEns = carnifex;
        }

        public static void Notare(string textus) {
            CarnifexEns?.Notare(textus);
        }

        public static void Error(string textus) {
            CarnifexEns?.Error(textus);
        }

        public static void Error(Exception exception) {
            CarnifexEns?.Error(exception);
        }

        public static void Intermissio(string textus) {
            CarnifexEns?.Intermissio(textus);
        }

        public static void Intermissio(Exception exception) {
            CarnifexEns?.Intermissio(exception);
        }
    }
}
