using System;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Nucleus.Instrumentarium {
    public sealed class TabulaLUTSigmoid : ITabulaLUT01<float> {
        private readonly float[] _lut;
        private readonly float _praeruptio;
        private readonly float _centrum;
        private readonly float _min;
        private readonly float _max;

        public TabulaLUTSigmoid(
            float praeruptio,
            float centrum,
            int longitudo,
            bool inversus = false
        ) {
            if (longitudo < 2) {
                Carnifex.Intermissio(LogTextus.TabulaLUT_LUT_LENGTH_TOO_SHORT);
            }
            _praeruptio = praeruptio;
            _centrum = centrum;

            _min = Mathematica.Sigmoid(0f, centrum, praeruptio);
            _max = Mathematica.Sigmoid(1f, centrum, praeruptio);

            _lut = new float[longitudo];

            for (int i = 0; i < longitudo; i++) {
                _lut[i] = Mathematica.Sigmoid01(
                    i / (longitudo - 1f), centrum, praeruptio, _min, _max
                );
            }

            if (inversus) {
                for (int i = 0; i < longitudo; i++) {
                    _lut[i] = 1f - _lut[i];
                }
            }
        }

        public float this[float x] {
            get {
                x = Mathematica.Clamp01(x);

                int index = (int)MathF.Round(x * (_lut.Length - 1f));
                return _lut[index];
            }
        }
    }

    public sealed class TabulaLUTAcos : ITabulaLUTSignedToRad<float> {
        private readonly float[] _lut;

        public TabulaLUTAcos(
            int longitudo
        ) {
            if (longitudo < 2) {
                Carnifex.Intermissio(LogTextus.TabulaLUT_LUT_LENGTH_TOO_SHORT);
            }
            _lut = new float[longitudo];

            for (int i = 0; i < longitudo; i++) {
                float x = Mathematica.Lerp(-1f, 1f, i / (longitudo - 1f));
                _lut[i] = MathF.Acos(x);
            }
        }

        public float this[float x] {
            get {
                x = Mathematica.InverseLerp01(-1f, 1f, x);
                int index = (int)MathF.Round(x * (_lut.Length - 1f));
                return _lut[index];
            }
        }
    }
}