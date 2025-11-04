namespace Yulinti.NPCControllSuite {
    public sealed class NPCManager {
        private readonly NPCSetting _npcSetting;
        private readonly NPCIdAllocator _npcIdAllocator;
        private readonly NPCService _npcService;

        public NPCManager(NPCSetting npcSetting) {
            _npcSetting = npcSetting;
            _npcIdAllocator = new NPCIdAllocator(_npcSetting.MaxNPCs);
            _npcService = new NPCService(_npcIdAllocator);
        }

        public int GetNPCService() => _npcService;
    }
}