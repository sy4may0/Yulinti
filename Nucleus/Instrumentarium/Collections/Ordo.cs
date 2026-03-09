using System.Collections.Generic;

namespace Yulinti.Nucleus.Instrumentarium {
    public sealed class Ordo<T> where T : class {
        private readonly Queue<T> _ordo;
        private readonly int _longitudo;

        public int Longitudo => _longitudo;
        public int Capacitas => _ordo.Count;

        public Ordo(int longitudo) {
            _ordo = new Queue<T>(longitudo);
            _longitudo = longitudo;
        }

        public bool ConarePono(T item) {
            if (_ordo.Count >= _longitudo) {
                return false;
            }
            _ordo.Enqueue(item);
            return true;
        }

        public bool ConareLego(out T item) {
            if (_ordo.Count == 0) {
                item = default;
                return false;
            }
            item = _ordo.Dequeue();
            return true;
        }

        public void Purgere() {
            _ordo.Clear();
        }
    }
}