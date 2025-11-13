using UnityEngine;
using Yulinti.MinisteriaUnity.MinisteriaNuclei;
using Yulinti.UnityServices.ServiceConfig;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class MinisteriumCamera  {
        private readonly ICameraConfig _cameraConfig;

        public MinisteriumCamera(ICameraConfig cameraConfig) {
            if (cameraConfig == null) {
                ModeratorErrorum.Fatal("MinisteriumCameraのCameraConfigがnullです。");
            }
            _cameraConfig = cameraConfig;
        }

        public Quaternion RotatioVerticalis
        {
            get
            {
                if (!_cameraConfig.Camera) return Quaternion.identity;
                var e = _cameraConfig.Camera.transform.eulerAngles;
                return Quaternion.Euler(0f, e.y, 0f);
            }
        }
        public Vector3 DexterXZ   => (RotatioVerticalis * Vector3.right).normalized;
        public Vector3 AnteriorXZ => (RotatioVerticalis * Vector3.forward).normalized;

        public void PonoPositionem(Vector3 pos) {
            _cameraConfig.Camera.transform.position = pos;
        }
        public void PonoRotationem(Quaternion rot) {
            _cameraConfig.Camera.transform.rotation = rot;
        }
    }
}