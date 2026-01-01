namespace Yulinti.Nucleus {
    public struct RingQueue<T> where T : struct
    {
        private T[] buffer;
        private int head;
        private int tail;
        private int count;
    
        public RingQueue(int capacity)
        {
            buffer = new T[capacity]; // ← ここだけGC
            head = tail = count = 0;
        }
    
        public bool Enqueue(T item)
        {
            if (count == buffer.Length) return false;
            buffer[tail] = item;
            tail = (tail + 1) % buffer.Length;
            count++;
            return true;
        }
    
        public bool Dequeue(out T item)
        {
            if (count == 0)
            {
                item = default;
                return false;
            }
            item = buffer[head];
            head = (head + 1) % buffer.Length;
            count--;
            return true;
        }
    }
}