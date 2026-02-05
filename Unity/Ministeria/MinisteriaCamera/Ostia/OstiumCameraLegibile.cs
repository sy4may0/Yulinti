using Yulinti.Unity.Ministeria;
using Yulinti.Nucleus;
using Yulinti.Exercitus.Contractus;
using Yulinti.Unity.Contractus;

namespace Yulinti.Unity.Ministeria {
    internal sealed class OstiumCameraLegibile : IOstiumCameraLegibile {
        private readonly MinisteriumCamera _miCamera;

        public OstiumCameraLegibile(MinisteriumCamera miCamera) {
            if (miCamera == null) {
                Errorum.Fatal(IDErrorum.OSTIUMCAMERALEGIBILE_INSTANCE_NULL);
            }
            _miCamera = miCamera;
        }

        public System.Numerics.Quaternion RotatioVerticalis => InterpressNumericus.ToNumerics(_miCamera.RotatioVerticalis);
        public System.Numerics.Vector3 DexterXZ => InterpressNumericus.ToNumerics(_miCamera.DexterXZ);
        public System.Numerics.Vector3 AnteriorXZ => InterpressNumericus.ToNumerics(_miCamera.AnteriorXZ);
    }
}


