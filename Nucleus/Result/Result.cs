using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Nucleus {
    public readonly struct NihilAut<T> {
        private readonly T _valor;

        public NihilAut(T valor) {
            _valor = valor;
        }

        public bool Aliquid() {
            return _valor != null;
        }

        public bool Nihil() {
            return _valor == null;
        }

        public T Evolvo() {
            if (_valor != null) {
                return _valor;
            } else {
                Notarius.MemorareParametrum("result_type", typeof(T).Name);
                Carnifex.Intermissio(LogTextus.NihilAut_UnwrapFailed);
                return default(T); // 繧ｳ繝ｳ繝代う繝ｫ逕ｨ縲・atal縺ｧ關ｽ縺｡繧九・
            }
        }
        public T EvolvoAut(T defalta) {
            if (_valor != null) {
                return _valor;
            } else {
                return defalta;
            }
        }
    }

    public readonly struct ErrorAut<T> {
        private readonly T _valor;
        private readonly bool _estSuccessus;

        public static ErrorAut<T> Successus(T v) => new ErrorAut<T>(v, true);
        public static ErrorAut<T> Error() => new ErrorAut<T>(default(T), false);

        private ErrorAut(T valor, bool estSuccessus) {
            _valor = valor;
            _estSuccessus = estSuccessus;
        }

        public bool EstSuccessus() {
            return _estSuccessus;
        }

        public bool EstError() {
            return !_estSuccessus;
        }

        public T Evolvo() {
            if (EstSuccessus()) {
                return _valor;
            } else {
                Carnifex.Intermissio(LogTextus.ErrorAut_UnwrapFailed);
                return default(T); // 繧ｳ繝ｳ繝代う繝ｫ逕ｨ縲・atal縺ｧ關ｽ縺｡繧九・
            }
        }

        public T EvolvoAut(T defalta) {
            if (EstSuccessus()) {
                return _valor;
            } else {
                return defalta;
            }
        }

        public bool Conare(out T valor) {
            if (EstSuccessus()) {
                valor = _valor;
                return true;
            } else {
                valor = default(T);
                return false;
            }
        }
    }
}

