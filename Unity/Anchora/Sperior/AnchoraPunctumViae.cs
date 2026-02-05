using UnityEngine;
using Yulinti.Unity.Contractus;
using Yulinti.Nucleus;

using Yulinti.Exercitus.Contractus;
namespace Yulinti.Unity.Anchora {
    public sealed class AnchoraPunctumViae : MonoBehaviour, IAnchora, IAnchoraPunctumViae {
        [SerializeField] private IDPunctumViaeTypi _idPunctumViaeTypi;

        public IDPunctumViaeTypi Typus => _idPunctumViaeTypi;
        public Vector3 Positio => transform.position;
        public Quaternion Rotatio => transform.rotation;
        public Vector3 Scala => transform.localScale;

        public bool Validare() {
            return true;
        }

    }
}
