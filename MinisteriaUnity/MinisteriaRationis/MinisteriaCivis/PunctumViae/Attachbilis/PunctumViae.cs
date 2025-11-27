using UnityEngine;
using Yulinti.Nucleus;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class PunctumViae : MonoBehaviour, IPunctumViae {
        [Header("PunctumViae/PunctumViaeTypi: WayPointのタイプ。これによりリゾルバを変える。")]
        [SerializeField] private IDPunctumViaeTypi _idPunctumViaeTypi;
        [Header("PunctumViae/PunctumViaeConsequens: このWayPointに続くWayPoint。最大21に制限する。")]
        [SerializeField] private MonoBehaviour[] _mbs;

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

        // Awakeにすると実行順が面倒。
        // Rexのコンストラクタツリーにこれは含める。
        // 必ずこれを呼ぶこと。
        public void Initio() {
            if (_mbs == null || _mbs.Length == 0) {
                Errorum.Fatal(IDErrorum.PUNCTUMVIAE_MONOBEHAVIOURS_NULL_OR_EMPTY);
            }
            if (_mbs.Length > 21) {
                Errorum.Fatal(IDErrorum.PUNCTUMVIAE_LENGTH_OF_P_CONSEQUENS_IS_GREATER_THAN_21);
            } 

            _punctaViaeConsequens = new IPunctumViae[_mbs.Length];
            for (int i = 0; i < _mbs.Length; i++) {
                if (_mbs[i] == null) {
                    Errorum.Fatal(IDErrorum.PUNCTUMVIAE_MONOBEHAVIOUR_ITEM_IS_NULL);
                }
                IPunctumViae pv = _mbs[i] as IPunctumViae;
                if (pv == null) {
                    Errorum.Fatal(IDErrorum.PUNCTUMVIAE_MONOBEHAVIOUR_ITEM_IS_NOT_IPUNCTUMVIAE);
                }
                _punctaViaeConsequens[i] = pv;
            }
        }
    }
}