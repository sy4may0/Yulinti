using UnityEngine;

namespace Yulinti.SpottedManager {
    public sealed class SpottableCollider {
        private readonly Collider _collider;
        private readonly INPCIDService _npcIdService;
        private readonly SpottedManager _spottedManager;

        public SpottableCollider(Collider collider, INPCIDService npcIdService) {
            if (collider == null || npcIdService == null) {
                Debug.LogError("SpottableCollider/Collider or NPCIDService is null");
                return;
            }

            _collider = collider;
            _npcIdService = npcIdService;
            _spottedManager = new SpottedManager(npcIdService);
        }

        public void InitializeNPCId(int npcId) {
            _spottedManager.Initialize(npcId);
        }
    }
}
        