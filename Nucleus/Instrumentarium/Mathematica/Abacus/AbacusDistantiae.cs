using System.Numerics;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Nucleus.Instrumentarium {
    public sealed class AbacusDistantiae {
        private readonly float _distantiaMaxima;
        private readonly float _distantiaMinima;
        private readonly float _distantiaMedia;
        private readonly float _praeruptioDistantiae;

        private readonly ITabulaLUT01<float> _tabulaLUT;

        public AbacusDistantiae (
            float distantiaMaxima,
            float distantiaMinima,
            float distantiaMedia,
            float praeruptioDistantiae,
            ITabulaLUT01<float> tabulaLUT = null
        ) {
            if (distantiaMinima >= distantiaMedia ||
                distantiaMedia >= distantiaMaxima) {
                Carnifex.Intermissio(LogTextus.AbacusDistantiae_ABACUSDISTANTIAE_INVALID_DISTANTIA);
            }

            if (praeruptioDistantiae <= 0f) {
                Carnifex.Intermissio(LogTextus.AbacusDistantiae_ABACUSDISTANTIAE_INVALID_PRAERUPTIO_DISTANTIA);
            }

            _distantiaMaxima = distantiaMaxima;
            _distantiaMinima = distantiaMinima;
            _distantiaMedia = distantiaMedia;
            _praeruptioDistantiae = praeruptioDistantiae;
            _tabulaLUT = tabulaLUT;

            if (_tabulaLUT == null) {
                float ratioMedia = Mathematica.InverseLerp01(
                    _distantiaMinima, _distantiaMaxima, _distantiaMedia
                );
                _tabulaLUT = new TabulaLUTSigmoid(
                    _praeruptioDistantiae, ratioMedia, ConstansAbacus.LongitudoLUT
                );
            }
        }

        public float ComputareRatio(float distantia) {
            if (distantia <= _distantiaMinima) return 0f;
            if (distantia >= _distantiaMaxima) return 1f;
            float ratio = Mathematica.InverseLerp01(
                _distantiaMinima, _distantiaMaxima, distantia
            );
            return _tabulaLUT[ratio];
        }

        public float ComputareRatioInversus(float distantia) {
            return 1f - ComputareRatio(distantia);
        }

        public float ComputareRatioVectorialis(Vector3 positio0, Vector3 positio1) {
            float distantia = (positio0 - positio1).Length();
            return ComputareRatio(distantia);
        }

        public float ComputareRatioVectorialisInversus(Vector3 positio0, Vector3 positio1) {
            return 1f - ComputareRatioVectorialis(positio0, positio1);
        }
    }
}