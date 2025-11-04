using UnityEngine;
using System.Collections.Generic;
using Yulinti.NPCControllSuite;

namespace Yulinti.SpottedManagerSuite {

    public class SpottedManager {
        private readonly INPCIDService _npcIdService;
        private readonly BitArray _isSpottedFlags;
        private readonly int _spottedCount;

        public int SpottedCount => _spottedCount;

        public SpottedManager(INPCIDService npcIdService) {
            _npcIdService = npcIdService;
            _isSpottedFlags = new BitArray(_npcIdService.GetMaxNPCs(), false);
            _spottedCount = 0;
        }

        public void Initialize(int npcId) {
            if (!_npcIdService.IsNPCIdValid(npcId)) return;
            _isSpottedFlags[npcId] = false;
        }

        public bool IsSpotted(int npcId) {
            if (!_npcIdService.IsNPCIdValid(npcId) || !_npcIdService.IsNPCIdInUse(npcId)) return false;
            return _isSpottedFlags[npcId];
        }

        public void Spotted(int npcId) {
            if (!_npcIdService.IsNPCIdValid(npcId) || !_npcIdService.IsNPCIdInUse(npcId)) return;
            if (_isSpottedFlags[npcId]) return;
            _isSpottedFlags[npcId] = true;
            _spottedCount++;
        }

        public void Unspotted(int npcId) {
            if (!_npcIdService.IsNPCIdValid(npcId) || !_npcIdService.IsNPCIdInUse(npcId)) return;
            if (!_isSpottedFlags[npcId]) return;
            _isSpottedFlags[npcId] = false;
            _spottedCount--;
        }

        public void Clear() {
            for (int i = 0; i < _isSpottedFlags.Count; i++) _isSpottedFlags[i] = false;
            _spottedCount = 0;
        }
    }
}