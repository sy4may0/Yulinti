using UnityEngine;
using Yulinti.Nucleus;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class PunctumViae : MonoBehaviour {
        [Header("PunctumViae/PunctumViaeTypi: WayPointのタイプ。これによりリゾルバを変える。")]
        [SerializeField] private IDPunctumViaeTypi _idPunctumViaeTypi;
        [Header("PunctumViae/PunctumViaeConsequens: このWayPointに続くWayPoint。最大21に制限する。")]
        [SerializeField] private PunctumViae[] _punctaViaeConsequens;

        private bool _estActivum = false;
        private IResolvorPunctumViae _resolvorPunctumViae;

        public IDPunctumViaeTypi Typus => _idPunctumViaeTypi;
        public bool EstActivum => _estActivum;
        public Vector3 Positio => transform.position;

        public void Activare() {
            _estActivum = true;
        }
        public void Deactivare() {
            _estActivum = false;
        }

        public ErrorAut<PunctumViae> Resolvo(PunctumViae pAntecedens) {
            if (_resolvorPunctumViae == null) {
                return ErrorAut<PunctumViae>.Error(IDErrorum.PUNCTUMVIAE_RESOLVOR_NULL);
            }
            return _resolvorPunctumViae.Resolvo(pAntecedens, _punctaViaeConsequens);
        }

        // Awakeにすると実行順が面倒。
        // Rexのコンストラクタツリーにこれは含める。
        // 必ずこれを呼ぶこと。
        public void Initio() {
            if (_punctaViaeConsequens == null || _punctaViaeConsequens.Length == 0) {
                Errorum.Fatal(IDErrorum.PUNCTUMVIAE_MONOBEHAVIOURS_NULL_OR_EMPTY);
            }
            if (_punctaViaeConsequens.Length > 21) {
                Errorum.Fatal(IDErrorum.PUNCTUMVIAE_LENGTH_OF_P_CONSEQUENS_IS_GREATER_THAN_21);
            } 

            for (int i = 0; i < _punctaViaeConsequens.Length; i++) {
                if (_punctaViaeConsequens[i] == null) {
                    Errorum.Fatal(IDErrorum.PUNCTUMVIAE_MONOBEHAVIOUR_ITEM_IS_NULL);
                }
            }
            _resolvorPunctumViae = FabricaResolvor.Creare(_idPunctumViaeTypi)
                                    .Evolvo(IDErrorum.PUNCTUMVIAE_RESOLVOR_CREATION_FAILED);
            _estActivum = true;
        }
    }
}