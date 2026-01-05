
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
                Errorum.Fatal("Unwrap(Evolvere) Failed. Unwrap nihil result. Result type: " + typeof(T).Name);
                return default(T); // 繧ｳ繝ｳ繝代う繝ｫ逕ｨ縲・atal縺ｧ關ｽ縺｡繧九・
            }
        }
        public T Evolvo(IDErrorum error) {
            if (_valor != null) {
                return _valor;
            } else {
                Errorum.Fatal(error);
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
        private readonly IDErrorum _error;
        private readonly bool _estSuccessus;

        public static ErrorAut<T> Successus(T v) => new ErrorAut<T>(v, default(IDErrorum), true);
        public static ErrorAut<T> Error(IDErrorum e) => new ErrorAut<T>(default(T), e, false);

        private ErrorAut(T valor, IDErrorum error, bool estSuccessus) {
            _valor = valor;
            _error = error;
            _estSuccessus = estSuccessus;
        }

        public bool EstSuccessus() {
            return _estSuccessus;
        }

        public bool EstError() {
            return !_estSuccessus;
        }

        public IDErrorum ID() {
            return _error;
        }

        public T Evolvo() {
            if (EstSuccessus()) {
                return _valor;
            } else {
                Errorum.Fatal("Unwrap(Evolvere) Failed. Error: " + _error);
                return default(T); // 繧ｳ繝ｳ繝代う繝ｫ逕ｨ縲・atal縺ｧ關ｽ縺｡繧九・
            }
        }

        public T Evolvo(IDErrorum error) {
            if (EstSuccessus()) {
                return _valor;
            } else {
                Errorum.Fatal(error, _error);
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


