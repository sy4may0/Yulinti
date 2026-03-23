using Yulinti.Nucleus.Contractus;

namespace Yulinti.Nucleus.Instrumentarium {

    public sealed class AbacusTemporis {
        private float _tempusStudiumAmittereActualis;
        private readonly float _tempusStudiumAmittereMinima;
        private readonly float _tempusStudiumAmittereMedia;
        private readonly float _tempusStudiumAmittereMaxima;
        private readonly ITabulaLUT01<float> _tabulaLUT;

        public AbacusTemporis(
            float tempusStudiumAmittereMaxima,
            float tempusStudiumAmittereMinima,
            float tempusStudiumAmittereMedia,
            float praeruptioTempusAmittere,
            ITabulaLUT01<float> tabulaLUT = null
        ) {
            if (tempusStudiumAmittereMinima >= tempusStudiumAmittereMedia ||
                tempusStudiumAmittereMedia >= tempusStudiumAmittereMaxima) {
                Carnifex.Intermissio(LogTextus.AbacusTemporis_ABACUSTEMPORIS_INVALID_TEMPUS);
            }

            if (praeruptioTempusAmittere <= 0f) {
                Carnifex.Intermissio(LogTextus.AbacusTemporis_ABACUSTEMPORIS_INVALID_PRAERUPTIO_TEMPUS);
            }

            _tempusStudiumAmittereActualis = 0f;
            _tempusStudiumAmittereMinima = tempusStudiumAmittereMinima;
            _tempusStudiumAmittereMedia = tempusStudiumAmittereMedia;
            _tempusStudiumAmittereMaxima = tempusStudiumAmittereMaxima;

            if (tabulaLUT == null) {
                float ratioMedius = Mathematica.InverseLerp01(
                    _tempusStudiumAmittereMinima, _tempusStudiumAmittereMaxima, _tempusStudiumAmittereMedia
                );
                _tabulaLUT = new TabulaLUTSigmoid(
                    praeruptioTempusAmittere, ratioMedius, ConstansAbacus.LongitudoLUT
                );
            }
        }

        // 毎フレームDeltaTimeを入れる想定
        public void Pulsus(float intervallum) {
            _tempusStudiumAmittereActualis += intervallum;
        }

        public void Purgere() {
            _tempusStudiumAmittereActualis = 0f;
        }

        public float ComputareRatio() {
            float ratio = Mathematica.InverseLerp01(
                _tempusStudiumAmittereMinima, _tempusStudiumAmittereMaxima, _tempusStudiumAmittereActualis
            );
            return _tabulaLUT[ratio];
        }
    }
}