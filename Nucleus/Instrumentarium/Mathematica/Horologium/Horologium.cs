using System;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Nucleus.Instrumentarium {
    public sealed class Horologium : IHorologium {
        private readonly float _tempusMaximus;
        private float _tempusActualis;
        private bool _estActivum;

        public bool EstActivum => _estActivum;

        public Horologium(float tempusMaximus) {
            _tempusMaximus = tempusMaximus;
            _tempusActualis = 0f;
            _estActivum = false;
        }

        public void Activare() {
            _estActivum = true;
            Purgere();
        }

        public void Deactivare() {
            _estActivum = false;
        }

        public bool EstExhaurita(float intervullum) {
            if (!_estActivum) return false;
            _tempusActualis += intervullum;
            if (_tempusActualis >= _tempusMaximus) {
                _tempusActualis = 0f;
                return true;
            }
            return false;
        }

        public void Purgere() {
            _tempusActualis = 0f;
        }
    }
}