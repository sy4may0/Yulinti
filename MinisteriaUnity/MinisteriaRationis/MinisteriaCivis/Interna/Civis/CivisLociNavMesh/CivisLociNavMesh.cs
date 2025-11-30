using UnityEngine;
using UnityEngine.AI;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
   internal sealed class CivisLociNavMesh : ICivisLociNavMesh {
        private IAnchoraCivis _anchora;
        private LuditorPunctumViae _luditorPunctumViae;
        private PunctumViae _punctumViaeAntecedens;
        private PunctumViae _punctumViaeConsequens;

        public bool EstMigrare => _anchora.NavMeshAgent.enabled;

        private bool estInMigrare() {
            return (
                _punctumViaeAntecedens != null &&
                _punctumViaeConsequens != null
            );
        }

        public void Activare() {
            if (!_anchora.EstEns) {
                return;
            }
            _anchora.NavMeshAgent.enabled = true;
        }

        public void Deactivare() {
            if (!_anchora.EstEns) {
                return;
            }
            _anchora.NavMeshAgent.enabled = false;
        }

        public CivisLociNavMesh(LuditorPunctumViae luditorPunctumViae, IAnchoraCivis anchora) {
            _luditorPunctumViae = luditorPunctumViae;
            _anchora = anchora;
        }

        public void Transporto(Vector3 positio) {
            if (!_anchora.EstEns || !EstMigrare) {
                return;
            }
            _anchora.NavMeshAgent.Warp(positio);
        }

        // 謌仙粥縺ｪ繧画ｬ｡WayPoint(Consequens)縺ｮID繧定ｿ斐☆縲ょ､ｱ謨励↑繧右rror繧定ｿ斐☆縲・
        public EventusCivisLociNavMesh IncipereMigrare() {
            if (!_anchora.EstEns || !EstMigrare) {
                return new EventusCivisLociNavMesh(
                    ErrorAut<IDPunctumViaeTypi>.Error(IDErrorum.CIVISLOCI_INCIPEREMIGRARE_TO_NO_INSTANCE),
                    false
                );
            }

            int indexN = UnityEngine.Random.Range(0, _luditorPunctumViae.PunctaNatorium.Length);
            int indexC = UnityEngine.Random.Range(0, _luditorPunctumViae.PunctaCrematorium.Length);
            _punctumViaeAntecedens = _luditorPunctumViae.PunctaNatorium[indexN];
            Transporto(_punctumViaeAntecedens.Positio);

            _punctumViaeConsequens = _punctumViaeAntecedens.Resolvo(null)
                                    .EvolvoAut(_luditorPunctumViae.PunctaCrematorium[indexC]);

            _anchora.NavMeshAgent.isStopped = false;
            bool result = _anchora.NavMeshAgent.SetDestination(_punctumViaeConsequens.Positio);

            if (!result) {
                // NavMeshAgent縺梧ｬ｡縺ｮWayPoint繧定ｨｭ螳壹〒縺阪↑縺・り・蜻ｽ逧・↑繧ｨ繝ｩ繝ｼ縲・
                return new EventusCivisLociNavMesh(
                    ErrorAut<IDPunctumViaeTypi>.Error(IDErrorum.CIVIS_WAYPOINT_LOST), 
                    true
                );
            }

            return new EventusCivisLociNavMesh(
                ErrorAut<IDPunctumViaeTypi>.Successus(_punctumViaeConsequens.Typus),
                false
            );
        }

        // 謌仙粥縺ｪ繧画ｬ｡WayPoint(Consequens)縺ｮID繧定ｿ斐☆縲ょ､ｱ謨励↑繧右rror繧定ｿ斐☆縲・
        // Crematorium蛻ｰ驕疲凾縺ｯIDErrorum.None繧定ｿ斐☆縲・
        public EventusCivisLociNavMesh Migrare() {
            if (!_anchora.EstEns || !EstMigrare) {
                return new EventusCivisLociNavMesh(
                    ErrorAut<IDPunctumViaeTypi>.Error(IDErrorum.CIVISLOCI_MIGRARE_TO_NO_INSTANCE),
                    false
                );
            }
            if (!EstAdPerveni()) {
                return new EventusCivisLociNavMesh(
                    ErrorAut<IDPunctumViaeTypi>.Error(IDErrorum.CIVISLOCI_MIGRARE_NOT_AT_DESTINATION),
                    false
                );
            }
            if (!estInMigrare()) {
                // 驕ｷ遘ｻ縺ｮ謨ｴ蜷域ｧ縺悟ｴｩ繧後※縺・ｋ縲り・蜻ｽ逧・↑繧ｨ繝ｩ繝ｼ縲・
                return new EventusCivisLociNavMesh(
                    ErrorAut<IDPunctumViaeTypi>.Error(IDErrorum.CIVISLOCI_MIGRARE_NOT_IN_MIGRATION),
                    true
                );
            }

            if (_punctumViaeConsequens.Typus == IDPunctumViaeTypi.Crematorium) {
                return new EventusCivisLociNavMesh(
                    ErrorAut<IDPunctumViaeTypi>.Successus(IDPunctumViaeTypi.None),
                    true
                );
            }

            int indexC = UnityEngine.Random.Range(0, _luditorPunctumViae.PunctaCrematorium.Length);            

            // 蠑墓焚縺ｮ_punctumViaeAntecedens縺ｯnull蜿ｯ閭ｽ
            PunctumViae punctumViaeNeo = _punctumViaeAntecedens.Resolvo(_punctumViaeAntecedens)
                                    .EvolvoAut(_luditorPunctumViae.PunctaCrematorium[indexC]);

            _punctumViaeAntecedens = _punctumViaeConsequens;
            _punctumViaeConsequens = punctumViaeNeo;

            if (_punctumViaeConsequens == null) {
                // 谺｡縺ｮWayPoint縺瑚ｦ九▽縺九ｉ縺ｪ縺・り・蜻ｽ逧・↑繧ｨ繝ｩ繝ｼ縲・
                return new EventusCivisLociNavMesh(
                    ErrorAut<IDPunctumViaeTypi>.Error(IDErrorum.CIVIS_WAYPOINT_LOST),
                    true
                );
            }

            _anchora.NavMeshAgent.isStopped = false;
            bool result = _anchora.NavMeshAgent.SetDestination(_punctumViaeConsequens.Positio);

            if (!result) {
                // NavMeshAgent縺梧ｬ｡縺ｮWayPoint繧定ｨｭ螳壹〒縺阪↑縺・り・蜻ｽ逧・↑繧ｨ繝ｩ繝ｼ縲・
                return new EventusCivisLociNavMesh(
                    ErrorAut<IDPunctumViaeTypi>.Error(IDErrorum.CIVIS_WAYPOINT_LOST),
                    true
                );
            }

            return new EventusCivisLociNavMesh(
                ErrorAut<IDPunctumViaeTypi>.Successus(_punctumViaeConsequens.Typus),
                false
            );
        }

        public IDPunctumViaeTypi TypusAntecedens => _punctumViaeAntecedens != null ? _punctumViaeAntecedens.Typus : IDPunctumViaeTypi.None;
        public IDPunctumViaeTypi TypusConsequens => _punctumViaeConsequens != null ? _punctumViaeConsequens.Typus : IDPunctumViaeTypi.None;

        public bool EstAdPerveni(float distantia = 0.3f) {
            if (!_anchora.EstEns || !EstMigrare) {
                return false;
            }

            NavMeshAgent agent = _anchora.NavMeshAgent;

            if (!agent.pathPending &&
                agent.remainingDistance < distantia
            ) {
                return true;
            }

            return false;
        }
    }
}


