using Yulinti.Nucleus.Contractus;

namespace Yulinti.Nucleus.Instrumentarium {
    public sealed class AbacusLenis {
        private readonly float _lenisMaxima;
        private readonly float _lenisMinima;
        private readonly float _praeruptioLenis;

        private readonly ITabulaLUT01<float> _tabulaLUT;

        public AbacusLenis(
            float lenisMaxima,
            float lenisMinima,
            float praeruptioLenis,
            ITabulaLUT01<float> tabulaLUT = null
        ) {
            if (lenisMinima >= lenisMaxima) {
                Carnifex.Intermissio(LogTextus.AbacusLenis_ABACUSLENIS_INVALID_LENIS);
            }

            if (praeruptioLenis <= 0f) {
                Carnifex.Intermissio(LogTextus.AbacusLenis_ABACUSLENIS_INVALID_PRAERUPTIO_LENIS);
            }

            _lenisMaxima = lenisMaxima;
            _lenisMinima = lenisMinima;
            _praeruptioLenis = praeruptioLenis;

            _tabulaLUT = tabulaLUT;

            if (_tabulaLUT == null) {
                _tabulaLUT = new TabulaLUTExponentialSaturation(
                    ConstansAbacus.LongitudoLUT,
                    _praeruptioLenis
                );
            }
        }

        public float ComputareRatio(float lenis) {
            if (lenis <= _lenisMinima) return 0f;
            if (lenis >= _lenisMaxima) return 1f;
            float ratio = Mathematica.InverseLerp01(
                _lenisMinima, _lenisMaxima, lenis
            );
            return _tabulaLUT[ratio];
        }

        public float ComputareRatioInversus(float lenis) {
            return 1f - ComputareRatio(lenis);
        }
    }
}
