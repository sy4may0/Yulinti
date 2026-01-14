using System.Collections.Generic;

namespace Yulinti.Dux.Exercitus {
    internal sealed class DuxQueue<T> where T : class {
        private readonly Queue<T> _queue;
        private readonly int _longitudo;

        public DuxQueue(int longitudo) {
            _queue = new Queue<T>(longitudo);
            _longitudo = longitudo;
        }

        public bool ConarePono(T item) {
            if (_queue.Count >= _longitudo) {
                return false;
            }
            _queue.Enqueue(item);
            return true;
        }

        public bool ConareLego(out T item) {
            if (_queue.Count == 0) {
                item = default;
                return false;
            }
            item = _queue.Dequeue();
            return true;
        }

        public void Purgere() {
            _queue.Clear();
        }
    }

    internal sealed class Lacus<T> where T : class, new() {
        private readonly Stack<T> _lacus;
        private readonly int _longitudo;

        public int Longitudo => _longitudo;
        public int Capacitas => _lacus.Count;


        public Lacus(int longitudo) {
            _longitudo = longitudo;
            _lacus = new Stack<T>(longitudo);

            for (int i = 0; i < _longitudo; i++) {
                _lacus.Push(new T());
            }
        }

        public bool ConareLego(out T res) {
            if (Capacitas == 0) {
                res = null;
                return false;
            }
            res = _lacus.Pop();
            return true;
        }

        public bool ConarePono(T res) {
            if (res == null) return false;
            if (Capacitas >= Longitudo) return false;
            _lacus.Push(res);
            return true;
        }
    }
}