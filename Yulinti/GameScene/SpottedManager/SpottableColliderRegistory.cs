using UnityEngine;
using System.Collections.Generic;

namespace Yulinti.SpottedManager {
    [System.Serializable]
    public sealed class SpottableColliderRegistry {
        private readonly SpottedManagerConfig _spottedManagerConfig;
        private readonly SpottableCollider _headSpottableCollider;
        private readonly SpottableCollider _breastSpottableCollider;
        private readonly SpottableCollider _hipFrontSpottableCollider;
        private readonly SpottableCollider _hipBackSpottableCollider;

        public void Initialize(SpottedManagerConfig spottedManagerConfig, INPCIDService npcIdService) {
            _spottedManagerConfig = spottedManagerConfig;
            _headSpottableCollider = new SpottableCollider(_spottedManagerConfig.HeadCollider, npcIdService);
            _breastSpottableCollider = new SpottableCollider(_spottedManagerConfig.BreastCollider, npcIdService);
            _hipFrontSpottableCollider = new SpottableCollider(_spottedManagerConfig.HipFrontCollider, npcIdService);
            _hipBackSpottableCollider = new SpottableCollider(_spottedManagerConfig.HipBackCollider, npcIdService);
        }

        public void InitializeNPCId(int npcId) {
            _headSpottableCollider.InitializeNPCId(npcId);
            _breastSpottableCollider.InitializeNPCId(npcId);
            _hipFrontSpottableCollider.InitializeNPCId(npcId);
            _hipBackSpottableCollider.InitializeNPCId(npcId);
        }
    }
}