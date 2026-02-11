using Yulinti.Unity.Ministeria;
using Yulinti.Nucleus;
using Yulinti.Exercitus.Contractus;
using Yulinti.Unity.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Unity.Ministeria {
    internal sealed class OstiumCameraMutabile : IOstiumCameraMutabile {
        private readonly MinisteriumCamera _miCamera;

        public OstiumCameraMutabile(MinisteriumCamera miCamera) {
            if (miCamera == null) {
                Carnifex.Intermissio(LogTextus.OstiumCameraMutabile_OSTIUMCAMERAMUTABILE_INSTANCE_NULL);
            }
            _miCamera = miCamera;
        }

        public void PonoPositionem(System.Numerics.Vector3 pos) {
            _miCamera.PonoPositionem(InterpressNumericus.ToUnity(pos));
        }
        public void PonoRotationem(System.Numerics.Quaternion rot) {
            _miCamera.PonoRotationem(InterpressNumericus.ToUnity(rot));
        }
    }
}


