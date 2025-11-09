using System;
using UnityEngine;

namespace Yulinti.UnityServices.CoreServices {
    public static class ErrorHandleService {
        public static void Fatal(string message, Exception ex = null) {
            Exception exception = ex ?? new Exception(message);
            #if UNITY_EDITOR
            UnityEngine.Debug.LogException(exception);
            throw exception;
            #else
            UnityEngine.Debug.LogException(exception);
            // [TODO] UI表示してQUITに変更する。
            UnityEngine.Application.Quit();
            #endif
        }
    }
}