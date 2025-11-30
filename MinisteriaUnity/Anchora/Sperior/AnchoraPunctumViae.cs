using UnityEngine;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.Anchora {
    public sealed class AnchoraPunctumViae : MonoBehaviour, IAnchora, IAnchoraPunctumViae {
        [SerializeField] private IDPunctumViaeTypi _idPunctumViaeTypi;
        [SerializeField] private GameObject[] _punctaViaeConsequens;

        public IDPunctumViaeTypi Typus => _idPunctumViaeTypi;
        public GameObject[] PunctaViaeConsequens => _punctaViaeConsequens;
        public Vector3 Positio => transform.position;
        public Quaternion Rotatio => transform.rotation;
        public Vector3 Scala => transform.localScale;

        public bool Validare() {
            bool result = true;
            if (_punctaViaeConsequens == null) {
                Errorum.Fatal(IDErrorum.ANCHORAPUNCTUMVIAE_CONSEQUENS_NULL);
                result = false;
            }
            if (_punctaViaeConsequens.Length > 21) {
                Errorum.Fatal(IDErrorum.ANCHORAPUNCTUMVIAE_CONSEQUENS_LENGTH_OF_P_CONSEQUENS_IS_GREATER_THAN_21);
                result = false;
            }
            return result;
        }

    }
}
