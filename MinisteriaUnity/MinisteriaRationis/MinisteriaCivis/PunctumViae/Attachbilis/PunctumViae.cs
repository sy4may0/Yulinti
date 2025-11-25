using UnityEngine;
using Yulinti.Nucleus;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class PunctumViae : MonoBehaviour, IPunctumViae {
        [Header("PunctumViae/PunctumViaeTypi: WayPointのタイプ。これによりリゾルバを変える。")]
        [SerializeField] private readonly IDPunctumViaeTypi _idPunctumViaeTypi;
        [Header("PunctumViae/PunctumViaeConsequens: このWayPointに続くWayPoint。最大21に制限する。")]
        [SerializeField] private readonly MonoBehaviour[] _mbs;
        private IPunctumViae[] _punctaViaeConsequens;
        private bool _estActivum;
        private IResolvorPunctumViae _resolvorPunctumViae;

        public void PonoResolvor(IResolvorPunctumViae resolvorPunctumViae) {
            _resolvorPunctumViae = resolvorPunctumViae;
        }

        public IDPunctumViaeTypi Typus => _idPunctumViaeTypi;
        public bool EstActivum => _estActivum;
        public Vector3 Positio => transform.position;
        public void Activare() {
            _estActivum = true;
        }
        public void Deactivare() {
            _estActivum = false;
        }
        public ErrorAut<IPunctumViae> Resolvo(IPunctumViae pAntecedens) {
            if (_resolvorPunctumViae == null) {
                return ErrorAut<IPunctumViae>.Error(IDErrorum.PUNCTUMVIAE_RESOLVOR_NULL);
            }
            return _resolvorPunctumViae.Resolvo(pAntecedens, _punctaViaeConsequens);
        }

        private void Awake() {
            if (_punctaViaeConsequens.Length > 21) {
                Memorator.MemorareErrorum(IDErrorum.PUNCTUMVIAE_LENGTH_OF_P_CONSEQUENS_IS_GREATER_THAN_21);

                _punctaViaeConsequens = new IPunctumViae[21];
                for (int i = 0; i < 21; i++) {
                    _punctaViaeConsequens[i] = (IPunctumViae)_mbs[i];
                }
            }
        }
    }
}