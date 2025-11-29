using UnityEngine;
using Yulinti.MinisteriaUnity.Anchora;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.Anchora {
    public sealed class AnchoraCamera : MonoBehaviour, IAnchora {
        [SerializeField] private Camera _camera;

        public Camera Camera => _camera;

        public Vector3 Positio => transform.position;
        public Quaternion Rotatio => transform.rotation;
        public Vector3 Scala => transform.localScale;

        public bool Validare() {
            if (_camera == null) {
                Errorum.Fatal(IDErrorum.ANCHORACAMERA_CAMERA_NULL);
                return false;
            }
            return true;
        }
    }
}