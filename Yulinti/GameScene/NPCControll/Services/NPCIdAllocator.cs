namespace Yulinti.NPCControllSuite {
    // フリーリストでNPCIDを管理する。
    public sealed class NPCIdAllocator {
        private readonly int[] _free;
        private readonly bool[] _inUse;
        private int _top;
        private int _inUseCount;

        public int Capacity => _free.Length;
        public int CountInUse => _inUseCount;

        public NPCIdAllocator(int capacity) {
            _free = new int[capacity];
            _inUse = new bool[capacity];
            for (int i = 0; i < capacity; i++) _free[i] = capacity - i - 1;
            _top = capacity;
            _inUseCount = 0;
        }

        public int Allocate() {
            if (_top <= 0) return -1;
            int id = _free[--_top];
            _inUse[id] = true;
            _inUseCount++;
            return id;
        }

        public bool Free(int id) {
            if ((uint)id >= (uint)_free.Length) return false;
            if (!_inUse[id]) return false;

            _inUse[id] = false;
            _free[_top++] = id;
            _inUseCount--;
            return true;
        }

        public bool IsInUse(int id) {
            return (uint)id < (uint)_inUse.Length && _inUse[id];
        }

        public void Clear() {
            for (int i = 0; i < _inUse.Length; i++) _inUse[i] = false;
            for (int i = 0; i < _free.Length; i++) _free[i] = _free.Length - i - 1;
            _top = _free.Length;
            _inUseCount = 0;
        }
    }
}
    
