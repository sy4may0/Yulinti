using UnityEngine;
using Yulinti.Nucleus;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;

// Fabricaはコンストラクタ以外で使うな。Spqwn処理中に生成するな。
namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class FabricaCivisOrdinatae : IFabricaCivis {
        private readonly GameObject _civisPrefab;
        private readonly IConfiguratioCivisOrdinatae _configuratio;

        public FabricaCivisOrdinatae(IConfiguratioCivisOrdinatae configuratio) {
            _configuratio = configuratio;
            _civisPrefab = _configuratio.CivisPrefab.EvolvareNuncium("FabricaCivisOrdinataeのCivisPrefabがnullです。");
        }

        public ErrorAut<GameObject> ManifestatioCivis() {
            Vector3 positioManifestatio = new Vector3(0, 0, 0);
            GameObject civisInstance = UnityEngine.Object.Instantiate(_civisPrefab);

            if (civisInstance == null) {
                return ErrorAut<GameObject>.Error(IDErrorum.GENERATENPC_INSTANTIATE_FAILED);
            }

            // NavMeshAgentを生成する。
            if (_configuratio is IConfiguratioCivisNavMesh configuratioNavMesh && configuratioNavMesh.GenerareNavMeshAgent) {
                if (!GenerareNavMeshAgent(civisInstance)) {
                    return ErrorAut<GameObject>.Error(IDErrorum.GENERATENPC_NAVMESH_AGENT_FAILED);
                }
            }

            return ErrorAut<GameObject>.Successus(civisInstance);
        }

        public void DeletioCivis(GameObject civis) {
            if (civis == null) {
                return;
            }
            UnityEngine.Object.Destroy(civis);
        }

        public bool GenerareNavMeshAgent(GameObject civisInstance) {
            // すでにNavMeshAgentが存在する場合は生成しない。
            if (civisInstance.GetComponent<UnityEngine.AI.NavMeshAgent>() != null) {
                return false;
            }

            UnityEngine.AI.NavMeshAgent agent = civisInstance.AddComponent<UnityEngine.AI.NavMeshAgent>(); 
            if (agent == null) {
                return false;
            }

            agent.radius = _configuratio.RadiusNavMeshAgent;
            agent.height = _configuratio.AltitudoNavMeshAgent;
            agent.speed = _configuratio.VelocitasNavMeshAgent;
            agent.acceleration = _configuratio.AceleratioNavMeshAgent;
            agent.angularSpeed = _configuratio.VelocitasRotationis;
            agent.baseOffset = _configuratio.AltitudoBasisPedis;

            return true;
        }

    }
}