using UnityEngine;

namespace Yulinti.GameScene {
    public class Orchestrator : MonoBehaviour {
        [SerializeField] private NPCSetting _npcSetting;
        [SerializeField] private SpottedManagerConfig _spottedManagerConfig;

        private NPCManager _npcManager;
        private SpottableColliderRegistry _spottableColliderRegistry;

        private void Awake() {
            _npcManager = new NPCManager(_npcSetting);
            _spottableColliderRegistry = new SpottableColliderRegistry(_spottedManagerConfig, _npcManager.GetNPCService());
        }
    }
}