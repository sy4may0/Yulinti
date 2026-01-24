using UnityEngine;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;

using Yulinti.Dux.ContractusDucis;
namespace Yulinti.MinisteriaUnity.Anchora {
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
