using UnityEngine;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal static class InterpresStratum {
        public static LayerMask ToStratum(IDStrati idStrati) {
            return 1 << (int)idStrati;
        }
    }
}
