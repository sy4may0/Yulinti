using UnityEngine;
using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class MinisteriumCamera  {
        private readonly Camera _camera;

        public MinisteriumCamera(IConfiguratioCamera configuratio) {
            _camera = configuratio.Camera.Evolvo(IDErrorum.MINISTERIUMCAMERA_CAMERA_NULL);
        }

        public Quaternion RotatioVerticalis
        {
            get
            {
                var e = _camera.transform.eulerAngles;
                return Quaternion.Euler(0f, e.y, 0f);
            }
        }
        public Vector3 DexterXZ   => (RotatioVerticalis * Vector3.right).normalized;
        public Vector3 AnteriorXZ => (RotatioVerticalis * Vector3.forward).normalized;

        public void PonoPositionem(Vector3 pos) {
            _camera.transform.position = pos;
        }
        public void PonoRotationem(Quaternion rot) {
            _camera.transform.rotation = rot;
        }
    }
}
