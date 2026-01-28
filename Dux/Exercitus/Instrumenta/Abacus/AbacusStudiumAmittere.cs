namespace Yulinti.Dux.Exercitus {
    // 時間によって増加するレシオを提供するクラス。
    // レシオはシグモイド曲線に従って増加し、最大値を超えると1になる。
    internal sealed class AbacusStudiumAmittere {
        private float _tempusStudiumAmittereActualis;
        private float _tempusStudiumAmittereSec;
        private float _tempusStudiumAmittereMaxima;
        private readonly float _ratioTempusStudiumAmittere;
        private readonly SigmoidLUT _sigmoid;

        // コンストラクタ
        // tempusStudiumAmittereSec: 興味を失い始める時間(シグモイド曲線でy=0.5になるxの値)
        // tempusStudiumAmittereMaximaSec: 興味を失い終わる時間(シグモイド曲線でy=1になるxの値)
        // praeruptioTempusAmittere: シグモイド曲線の傾き
        public AbacusStudiumAmittere(
            float tempusStudiumAmittereSec,
            float tempusStudiumAmittereMaximaSec,
            float praeruptioTempusAmittere
        ) {
            _tempusStudiumAmittereActualis = 0f;
            _tempusStudiumAmittereSec = tempusStudiumAmittereSec;
            _tempusStudiumAmittereMaxima = tempusStudiumAmittereMaximaSec;

            _ratioTempusStudiumAmittere = DuxMath.Clamp(tempusStudiumAmittereSec / tempusStudiumAmittereMaximaSec, 0f, 1f);
            _sigmoid = new SigmoidLUT(praeruptioTempusAmittere, _ratioTempusStudiumAmittere, ConstansCivis.LongitudoSigmoidStudiumAmittere);
        }

        public void Pulsus(float intervallum) {
            _tempusStudiumAmittereActualis += intervallum;
        }

        public void Purgere() {
            _tempusStudiumAmittereActualis = 0f;
        }

        public float ComputareRatio() {
            float rt = DuxMath.Clamp(_tempusStudiumAmittereActualis / _tempusStudiumAmittereMaxima, 0f, 1f);
            float ratio = _sigmoid[rt];
            return ratio;
        }
    }
}