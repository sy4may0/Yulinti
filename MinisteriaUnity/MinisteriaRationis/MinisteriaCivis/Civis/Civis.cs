using UnityEngine;
using UnityEngine.AI;
using Cysharp.Threading.Tasks;
using Yulinti.MinisteriaUnity.Anchora;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class Civis : ICivis {
        private AnchoraCivis _anchora;
        private LuditorPunctumViae _luditorPunctumViae;

        private PunctumViae _punctumViaeAntecedens;
        private PunctumViae _punctumViaeConsequens;

        private bool _estMigrare;


        public Civis(AnchoraCivis anchora, LuditorPunctumViae luditorPunctumViae) {
            _anchora = anchora;
            _luditorPunctumViae = luditorPunctumViae;
        }

        // Spawn
        public void Oriri() {
            OririAsync().Forget(e => Memorator.MemorareException(e));
        }

        public async UniTask OririAsync() {
            await _anchora.Manifestatio();
            bool result = _anchora.ValidareManifestatio();

            if (!result) {
                _anchora.Deleto();
                Memorator.MemorareErrorum(IDErrorum.CIVIS_INSTANTIATE_FAILED);
            }

            _estMigrare = false;
            IncipereMigrare();
        }

        // Despawn
        public void Evanescere() {
            _anchora.Deleto();
            _estMigrare = false;
        }

        // インスタンスは生成されているか。
        public bool EstActivum => _anchora.EstEns;
        public Vector3 LegoPositionem => _anchora.Positio;
        public Quaternion LegoRotationem => _anchora.Rotatio;
        public Vector3 LegoScalam => _anchora.Scala;


        // テレポート
        public void Transporto(Vector3 positio) {
            if (!EstActivum) {
                return;
            }
            _anchora.CharacterController.enabled = false;
            _anchora.NavMeshAgent.Warp(positio);
            _anchora.CharacterController.enabled = true;
        }

        // NavMesh移動開始
        public void IncipereMigrare() {
            if (!EstActivum) {
                return;
            }
            // 生成ポイント
            int indexN = UnityEngine.Random.Range(0, _luditorPunctumViae.PunctaNatorium.Length);

            // FailBack用 消失ポイント
            int indexC = UnityEngine.Random.Range(0, _luditorPunctumViae.PunctaCrematorium.Length);

            // 生成ポイントにテレポート
            _punctumViaeAntecedens = _luditorPunctumViae.PunctaNatorium[indexN];
            Transporto(_punctumViaeAntecedens.Positio);

            // 次ポイントを解決 / エラーならFailBack -> 消失ポイント
            _punctumViaeConsequens = _punctumViaeAntecedens.Resolvo(null)
                                    .EvolvoAut(_luditorPunctumViae.PunctaCrematorium[indexC]);

            // 移動開始
            _anchora.NavMeshAgent.isStopped = false;
            bool result = _anchora.NavMeshAgent.SetDestination(_punctumViaeConsequens.Positio);

            if (!result) {
                Memorator.MemorareErrorum(IDErrorum.CIVIS_WAYPOINT_LOST);
                Evanescere();
            }

            _estMigrare = true;
        }

        public bool EstAdPerveni() {
            if (!EstActivum) {
                return false;
            }
            // [TODO] CONFIG化
            float _distantia = 0.3f;
            NavMeshAgent agent = _anchora.NavMeshAgent;

            if (!agent.pathPending &&
                agent.remainingDistance < _distantia
            ) {
                return true;
            }

            return false;
        }

        public void Migrare() {
            if (!EstActivum || !_estMigrare ) {
                return;
            }
            if (!EstAdPerveni()) {
                return;
            }

            // Crematriumなら消去。
            if (_punctumViaeConsequens.Typus == IDPunctumViaeTypi.Crematorium) {
                Evanescere();
                return;
            }

            // FailBack用
            int indexC = UnityEngine.Random.Range(0, _luditorPunctumViae.PunctaCrematorium.Length);
        
            PunctumViae punctumViaeNeo = _punctumViaeAntecedens.Resolvo(_punctumViaeAntecedens)
                                    .EvolvoAut(_luditorPunctumViae.PunctaCrematorium[indexC]);
            _punctumViaeAntecedens = _punctumViaeConsequens;
            _punctumViaeConsequens = punctumViaeNeo;

            // これはガード。CrematriumのTypeをCrematriumにしていないとNullがError無しで返る。
            if (_punctumViaeConsequens == null) {
                Memorator.MemorareErrorum(IDErrorum.CIVIS_WAYPOINT_LOST);
                Evanescere();
            }

            // 移動開始
            _anchora.NavMeshAgent.isStopped = false;
            bool result = _anchora.NavMeshAgent.SetDestination(_punctumViaeConsequens.Positio);

            if (!result) {
                Memorator.MemorareErrorum(IDErrorum.CIVIS_WAYPOINT_LOST);
                Evanescere();
            }
        }
    }
}
