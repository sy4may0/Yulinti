using Yulinti.MinisteriaUnity.MinisteriaRationis;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class OstiumCameraMutabile : IOstiumCameraMutabile {
        private readonly MinisteriumCamera _miCamera;

        public OstiumCameraMutabile(MinisteriumCamera miCamera) {
            if (miCamera == null) {
                ModeratorErrorum.Fatal("MinisteriumCameraのインスタンスがnullです。");
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
