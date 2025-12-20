using System;
using UnityEngine;

namespace Yulinti.Nucleus {
    public static class Errorum {
        public static void Fatal(string message, Exception ex = null) {
            Exception exception = ex ?? new Exception(message);
            #if UNITY_EDITOR
            UnityEngine.Debug.LogException(exception);
            throw exception;
            #else
            UnityEngine.Debug.LogException(exception);
            // [TODO] UI陦ｨ遉ｺ縺励※QUIT縺ｫ螟画峩縺吶ｋ縲・
            UnityEngine.Application.Quit();
            #endif
        }

        public static void Fatal(IDErrorum error) {
            Fatal(error.ToString());
        }

        public static void Fatal(IDErrorum error, IDErrorum from) {
            Fatal("Error: " + error.ToString() + "\nFrom: " + from.ToString());
        }

        public static void Fatal(Exception ex) {
            Fatal(ex.Message, ex);
        }
    }
}
