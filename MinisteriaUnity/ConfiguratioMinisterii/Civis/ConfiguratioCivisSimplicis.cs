using UnityEngine;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.ConfiguratioMinisterii {
    [CreateAssetMenu(menuName = "Ministeria/ConfiguratioCivisSimplicis")]
    public sealed class ConfiguratioCivisSimplicis : ScriptableObject, IConfiguratioCivisOrdinatae, IConfiguratioCivisNavMesh {
        [Header("ConfiguratioCivisSimplicis/市民プレハブ")]
        [SerializeField] private GameObject _civisPrefab;
        [SerializeField] private string  _iterAdCapitis;

        [Header("ConfiguratioCivisSimplicis/NavMeshAgent設定")]
        [SerializeField] private bool _generareNavMeshAgent = true;
        [SerializeField] private float _radiusNavMeshAgent = 10f;
        [SerializeField] private float _altitudoNavMeshAgent = 2f;
        [SerializeField] private float _velocitasNavMeshAgent = 1f;
        [SerializeField] private float _aceleratioNavMeshAgent = 10f;
        [SerializeField] private float _velocitasRotationis = 180f;
        [SerializeField] private float _altitudoBasisPedis = 0f;

        public NihilAut<GameObject> CivisPrefab => new NihilAut<GameObject>(_civisPrefab);
        public string IterAdCapitis => _iterAdCapitis;

        public bool GenerareNavMeshAgent => _generareNavMeshAgent;
        public float RadiusNavMeshAgent => _radiusNavMeshAgent;
        public float AltitudoNavMeshAgent => _altitudoNavMeshAgent;
        public float VelocitasNavMeshAgent => _velocitasNavMeshAgent;
        public float AceleratioNavMeshAgent => _aceleratioNavMeshAgent;
        public float VelocitasRotationis => _velocitasRotationis;
        public float AltitudoBasisPedis => _altitudoBasisPedis;
    }
}