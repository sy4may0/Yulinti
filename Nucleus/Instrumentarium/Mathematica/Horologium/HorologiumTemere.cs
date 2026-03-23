using System;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Nucleus.Instrumentarium {
    public sealed class HorologiumTemere : IHorologium {
        private readonly Random _random;
        private readonly float _temereMaxima;
        private readonly float _temereMinima;
        private float _tempusMaximus;
        private float _tempusActualis;
        private bool _estActivum;
    
        public bool EstActivum => _estActivum;

        public HorologiumTemere(
            float temereMinima, float temereMaxima, Random random
        ) {
            _temereMinima = temereMinima;
            _temereMaxima = temereMaxima;
            _random = random;
            _estActivum = false;
            _tempusActualis = 0f;
            _tempusMaximus = InitareTemere();
        }

        private float InitareTemere() {
            return Mathematica.Lerp01(
                _temereMinima, _temereMaxima, (float)_random.NextDouble()
            );
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
                _tempusMaximus = InitareTemere();
                return true;
            }
            return false;
        }

        public void Purgere() {
            _tempusActualis = 0f;
            _tempusMaximus = InitareTemere();
        }
    }
}
    