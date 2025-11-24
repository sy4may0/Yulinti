
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

        public T Evolvare() {
            if (_valor != null) {
                return _valor;
            } else {
                Errorum.Fatal("Unwrap(Evolvere) Failed. Unwrap nihil result. Result type: " + typeof(T).Name);
                return default(T); // コンパイル用。Fatalで落ちる。
            }
        }

        public T EvolvareNuncium(string nuncium) {
            if (_valor != null) {
                return _valor;
            } else {
                Errorum.Fatal("Unwrap(Evolvere) Failed. " + nuncium);
                return default(T); // コンパイル用。Fatalで落ちる。
            }
        }

        public T EvolvareAut(T defalta) {
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

        public bool Successus() {
            return _estSuccessus;
        }

        public bool Error() {
            return !_estSuccessus;
        }

        public IDErrorum ID() {
            return _error;
        }

        public T Evolvare() {
            if (Successus()) {
                return _valor;
            } else {
                Errorum.Fatal("Unwrap(Evolvere) Failed. Error: " + _error);
                return default(T); // コンパイル用。Fatalで落ちる。
            }
        }

        public T EvolvareNuncium(string nuncium) {
            if (Successus()) {
                return _valor;
            } else {
                Errorum.Fatal("Unwrap(Evolvere) Failed. " + nuncium + " Error: " + _error);
                return default(T); // コンパイル用。Fatalで落ちる。
            }
        }

        public T EvolvareAut(T defalta) {
            if (Successus()) {
                return _valor;
            } else {
                return defalta;
            }
        }
    }
}




