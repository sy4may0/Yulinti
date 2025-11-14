using UnityEngine;
using Yulinti.UnityServices.ServiceContracts;

namespace Yulinti.Nucleus.InstrumentaMinisterii {
    public static class InterpresStratum {
        public static LayerMask ToStratum(LayerID layerID) {
            return 1 << (int)layerID;
        }
    }
}