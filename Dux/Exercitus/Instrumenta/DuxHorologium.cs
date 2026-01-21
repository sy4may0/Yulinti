using System;

namespace Yulinti.Dux.Exercitus {
    internal interface IDuxHorologium {
        bool EstExhaurita(float tempus);
        void Purgere();
    }

    // タイムカウンター。
    //　Updateループなどの中で一定時間を測りboolを返すクラス。
    internal sealed class DuxHorologium {
        private readonly float _tempusMaxima;
        private float _tempusActualis;

        public DuxHorologium(float tempusMaxima) {
            _tempusMaxima = tempusMaxima;
            _tempusActualis = 0f;
        }

        // Deltatime, FrameCountを渡し、_tempusMaximaまで経過したかを返す。
        // 経過していない場合、現在の経過時間を加算。
        // 経過していた場合、現在の経過時間を0にリセット。
        public bool EstExhaurita(float tempus) {
            _tempusActualis += tempus;

            if (_tempusActualis >= _tempusMaxima) {
                _tempusActualis = 0f;
                return true;
            }
            return false;
        }

        // リセット
        public void Purgere() {
            _tempusActualis = 0f;
        }
    }

    // ランダムタイムカウンター
    internal sealed class DuxHorologiumTemere {
        private readonly Random _random;
        private readonly float _temereMaxima;
        private readonly float _temereMinima;
        private float _tempusMaxima;
        private float _tempusActualis;

        public DuxHorologiumTemere(float temereMinima, float temereMaxima, Random random) {
            _temereMinima = temereMinima;
            _temereMaxima = temereMaxima;
            _tempusActualis = 0f;
            _random = random;
            _tempusMaxima = InitareTemere();
        }

        private float InitareTemere() {
            return DuxMath.NLerp(_temereMinima, _temereMaxima, (float)_random.NextDouble());
        }

        public bool EstExhaurita(float tempus) {
            _tempusActualis += tempus;

            if (_tempusActualis >= _tempusMaxima) {
                _tempusActualis = 0f;
                _tempusMaxima = InitareTemere();
                return true;
            }
            return false;
        }

        public void Purgere() {
            _tempusActualis = 0f;
            _tempusMaxima = InitareTemere();
        }
    }
}