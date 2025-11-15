using UnityEngine;
using Yulinti.MinisteriaUnity.MinisteriaNuclei;
using Yulinti.ConfiguratioMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class MinisteriumCamera  {
        private readonly IConfiguratioCamera _configuratio;

        public MinisteriumCamera(IConfiguratioCamera configuratio) {
            if (configuratio == null) {
                ModeratorErrorum.Fatal("MinisteriumCameraのConfiguratioがnullです。");
            }
            _configuratio = configuratio;
        }

        public Quaternion RotatioVerticalis
        {
            get
            {
                if (!_configuratio.Camera) return Quaternion.identity;
                var e = _configuratio.Camera.transform.eulerAngles;
                return Quaternion.Euler(0f, e.y, 0f);
            }
        }
        public Vector3 DexterXZ   => (RotatioVerticalis * Vector3.right).normalized;
        public Vector3 AnteriorXZ => (RotatioVerticalis * Vector3.forward).normalized;

        public void PonoPositionem(Vector3 pos) {
            _configuratio.Camera.transform.position = pos;
        }
        public void PonoRotationem(Quaternion rot) {
            _configuratio.Camera.transform.rotation = rot;
        }
    }
}