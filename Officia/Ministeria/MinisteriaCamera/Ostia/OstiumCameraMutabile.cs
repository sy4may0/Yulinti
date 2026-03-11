using Yulinti.Officia.Ministeria;
using Yulinti.Nucleus;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Officia.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;
using Yulinti.Officia.Instrumentarium;

namespace Yulinti.Officia.Ministeria {
    internal sealed class OstiumCameraMutabile : IOstiumCameraMutabile {
        private readonly MinisteriumCamera _miCamera;

        public OstiumCameraMutabile(MinisteriumCamera miCamera) {
            if (miCamera == null) {
                Carnifex.Intermissio(LogTextus.OstiumCameraMutabile_OSTIUMCAMERAMUTABILE_INSTANCE_NULL);
            }
            _miCamera = miCamera;
        }

        public void PonoPositionem(System.Numerics.Vector3 pos) {
            _miCamera.PonoPositionem(InterpresNumeri.ToUnity(pos));
        }
        public void PonoRotationem(System.Numerics.Quaternion rot) {
            _miCamera.PonoRotationem(InterpresNumeri.ToUnity(rot));
        }
    }
}

