using System;
using UnityEngine;
using Yulinti.Nucleus;

namespace Yulinti.Unity.Ministeria {
    internal static class ModeratorErrorum {
        public static void Fatal(string message, Exception ex = null) {
            Errorum.Fatal(message, ex);
        }

        public static void Fatal(IDErrorum error) {
            Errorum.Fatal(error);
        }
    }
}


