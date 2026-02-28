using UnityEngine;
using Yulinti.Exercitus.Contractus;
using Yulinti.Unity.Ministeria;
using Yulinti.Nucleus;
using Yulinti.Unity.Contractus;

namespace Yulinti.Unity.Ministeria {
    internal sealed class MinisteriumCamera  {
        private readonly Camera _camera;

        public MinisteriumCamera(IAnchoraCamera anchoraCamera) {
            _camera = anchoraCamera.Camera;
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



