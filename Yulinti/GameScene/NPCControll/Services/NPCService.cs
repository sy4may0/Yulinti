namespace Yulinti.NPCControllSuite {

    public interface INPCService {
        int GetMaxNPCs();
        int GetCountInUse();
        bool IsNPCIdInUse(int id);
        int AllocateNPCId();
        void FreeNPCId(int id);
        bool IsNPCIdValid(int id);
    }

    public sealed class NPCService : INPCService {
        private readonly NPCIdAllocator _npcIdAllocator;

        public NPCService(NPCIdAllocator npcIdAllocator) {
            _npcIdAllocator = npcIdAllocator;
        }

        public int GetMaxNPCs() => _npcIdAllocator.Capacity;
        public int GetCountInUse() => _npcIdAllocator.CountInUse;
        public bool IsNPCIdInUse(int id) => _npcIdAllocator.IsInUse(id);
        public int AllocateNPCId() => _npcIdAllocator.Allocate();
        public void FreeNPCId(int id) => _npcIdAllocator.Free(id);
        public bool IsNPCIdValid(int id) => (uint)id < (uint)_npcIdAllocator.Capacity;
    }

}