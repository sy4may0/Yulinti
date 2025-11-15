using UnityEngine;
using Yulinti.ContractusMinisterii.Terrae;

namespace Yulinti.Nucleus.InstrumentaMinisterii {
    public static class InterpresStratum {
        public static LayerMask ToStratum(IDStrati idStrati) {
            return 1 << (int)idStrati;
        }
    }
}