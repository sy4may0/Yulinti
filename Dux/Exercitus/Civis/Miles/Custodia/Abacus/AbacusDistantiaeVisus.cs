using Yulinti.Nucleus;
using System.Numerics;

namespace Yulinti.Dux.Exercitus {
    // 距離によるレシオを計算するクラス。
    internal sealed class AbacusDistantiaeVisus {
        // 最大距離
        private readonly float _distantiaMaxima;
        // 最小距離
        private readonly float _distantiaMin;
        // 中間距離(シグモイドカーブにおけるy=0.5となるxの値)
        private readonly float _ratioDistantiaeMed;

        private readonly SigmoidLUT _sigmoid;
        private readonly SigmoidLUT _sigmoidInversus;

        public AbacusDistantiaeVisus(
            float distantiaMaxima,
            float distantiaMin,
            float distantiaMedius,
            float praeruptioDistantiaeVisus
        ) {
            if ( distantiaMin >= distantiaMedius ||
                distantiaMedius >= distantiaMaxima ) {
                Errorum.Fatal(IDErrorum.ABACUSDISTANTIAEVISUS_INVALID_DISTANTIA);
            }

            _distantiaMaxima = distantiaMaxima;
            _distantiaMin = distantiaMin;
            _ratioDistantiaeMed = DuxMath.InverseLerp(distantiaMin, distantiaMaxima, distantiaMedius);
            _sigmoid = new SigmoidLUT(praeruptioDistantiaeVisus, _ratioDistantiaeMed, ConstansCivis.LongitudoSigmoidDistantiaeVisus);
            _sigmoidInversus = new SigmoidLUT(praeruptioDistantiaeVisus, _ratioDistantiaeMed, ConstansCivis.LongitudoSigmoidDistantiaeVisus, true);
        }

        public float ComputareRatio(float distantia) {
            if (distantia <= _distantiaMin) return 0f;
            if (distantia >= _distantiaMaxima) return 1f;
            float ratio = _sigmoid[DuxMath.InverseLerp(_distantiaMin, _distantiaMaxima, distantia)];
            return ratio;
        }

        public float ComputareRatio(Vector3 positio0, Vector3 positio1)
        {
            float distantia = (positio0 - positio1).Length();
            return ComputareRatio(distantia);
        }

        public float ComputareRatioInversus(float distantia) {
            if (distantia <= _distantiaMin) return 1f;
            if (distantia >= _distantiaMaxima) return 0f;
            float ratio = _sigmoidInversus[DuxMath.InverseLerp(_distantiaMin, _distantiaMaxima, distantia)];
            return ratio;
        }

        public float ComputareRatioInversus(Vector3 positio0, Vector3 positio1)
        {
            float distantia = (positio0 - positio1).Length();
            return ComputareRatioInversus(distantia);
        }
    }
}