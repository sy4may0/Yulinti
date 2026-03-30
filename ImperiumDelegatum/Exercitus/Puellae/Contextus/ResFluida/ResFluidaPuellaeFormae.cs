using System;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    // 初回はEstApplicandumがfalseになる。
    // 骨Executorは強制同期フラグを実装すること。シーン開始時(Start())のスライダ適用は強制同期で行う。
    internal sealed class ResFluidaPuellaeFormae : IResFluidaPuellaeFormaeLegibile {
        private bool _estApplicandum;
        private float[] _ratiosActualium;

        public bool EstApplicandum => _estApplicandum;

        public ResFluidaPuellaeFormae(ITurrisSalsamenti turrisSalsamenti) {
            IOstiumSalsamenti ostiumSalsamenti;
            if (!turrisSalsamenti.ConareActualis(out ostiumSalsamenti)) {   
                Carnifex.Intermissio(LogTextus.ResFluidaPuellaeFormae_SALSAMENTUM_ACTUALIS_NULL);
            }

            int longitudo = Enum.GetValues(typeof(IDPuellaeFormae)).Length;
            _ratiosActualium = new float[longitudo];

            for (int i = 0; i < longitudo; i++) {
                if (i == (int)IDPuellaeFormae.Nihil) {
                    continue;
                }
                 // セーブデータから値をロード。
                 // PuellaeFormarumは内部的にIDPuellaeFormaeを基に初期化しているから、チェック不要。
                _ratiosActualium[i] = ostiumSalsamenti.PuellaeFormarum.RatioActualis(
                    (IDPuellaeFormae)i
                );
            }
            ApplicatumEst();
        }

        public float RatioActualis(IDPuellaeFormae idFormae) {
            if (idFormae == IDPuellaeFormae.Nihil) {
                Carnifex.Error(LogTextus.ResFluidaPuellaeFormae_LEGERE_NIHIL);
                return 0.5f;
            }
            return _ratiosActualium[(int)idFormae];
        }

        public void RenovareRatioActualis(IDPuellaeFormae idFormae, float ratioActualis) {
            if (idFormae == IDPuellaeFormae.Nihil) {
                Carnifex.Error(LogTextus.ResFluidaPuellaeFormae_LEGERE_NIHIL);
                return;
            }
            _ratiosActualium[(int)idFormae] = ratioActualis;
            ApplicandumEst();
        }

        // Executorで骨のスケール適用したらこれを呼ぶ。
        public void ApplicatumEst() {
            _estApplicandum = false;
        }

        public void ApplicandumEst() {
            _estApplicandum = true;
        }

        public void Purgare() {
            for (int i = 0; i < _ratiosActualium.Length; i++) {
                _ratiosActualium[i] = 0.5f;
            }
            ApplicatumEst();
        }
    }
}