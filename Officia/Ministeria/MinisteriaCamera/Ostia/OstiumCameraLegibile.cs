using Yulinti.Officia.Ministeria;
using Yulinti.Nucleus;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Officia.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;
using Yulinti.Officia.Instrumentarium;

namespace Yulinti.Officia.Ministeria {
    internal sealed class OstiumCameraLegibile : IOstiumCameraLegibile {
        private readonly MinisteriumCamera _miCamera;

        public OstiumCameraLegibile(MinisteriumCamera miCamera) {
            if (miCamera == null) {
                Carnifex.Intermissio(LogTextus.OstiumCameraLegibile_OSTIUMCAMERALEGIBILE_INSTANCE_NULL);
            }
            _miCamera = miCamera;
        }

        public System.Numerics.Quaternion RotatioVerticalis => InterpresNumeri.ToNumerics(_miCamera.RotatioVerticalis);
        public System.Numerics.Vector3 DexterXZ => InterpresNumeri.ToNumerics(_miCamera.DexterXZ);
        public System.Numerics.Vector3 AnteriorXZ => InterpresNumeri.ToNumerics(_miCamera.AnteriorXZ);
    }
}

