using Yulinti.Nucleus.Instrumentarium;
using UnityEngine;
using Yulinti.Nucleus;
using Yulinti.Officia.Contractus;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Imperium.Anchora {
    public sealed class AnchoraCamera : MonoBehaviour, IAnchora, IAnchoraCamera {
        [SerializeField] private Camera _camera;

        public Camera Camera => _camera;

        public Vector3 Positio => transform.position;
        public Quaternion Rotatio => transform.rotation;
        public Vector3 Scala => transform.localScale;

        public bool Validare() {
            if (_camera == null) {
                Carnifex.Intermissio(LogTextus.AnchoraCamera_ANCHORACAMERA_CAMERA_NULL);
                return false;
            }
            return true;
        }
    }
}
