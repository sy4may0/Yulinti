using System.Collections.Generic;

namespace Yulinti.Nucleus.Instrumentarium {
    public sealed class Lacus<T> where T : class, new() {
        private readonly Stack<T> _lacus;
        private readonly HashSet<T> _signa;
        private readonly int _longitudo;

        public int Longitudo => _longitudo;
        public int Capacitas => _lacus.Count;

        public Lacus(int longitudo) {
            _longitudo = longitudo;
            _lacus = new Stack<T>(longitudo);
            _signa = new HashSet<T>();

            for (int i = 0; i < _longitudo; i++) {
                var item = new T();
                _lacus.Push(item);
                _signa.Add(item);
            }
        }

        public bool ConareLego(out T res) {
            if (Capacitas == 0) {
                res = null;
                return false;
            }

            res = _lacus.Pop();
            _signa.Remove(res);
            return true;
        }

        public bool ConarePono(T res) {
            if (res == null) return false;
            if (Capacitas >= Longitudo) return false;
            if (_signa.Contains(res)) return false;

            _lacus.Push(res);
            _signa.Add(res);
            return true;
        }
    }
}
