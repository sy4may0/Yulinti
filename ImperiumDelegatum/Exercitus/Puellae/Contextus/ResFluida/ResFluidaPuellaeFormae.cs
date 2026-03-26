using System;
using System.Numerics;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    // 初回はEstApplicandumがfalseになる。
    // 骨Executorは強制同期フラグを実装すること。シーン開始時(Start())のスライダ適用は強制同期で行う。
    internal sealed class ResFluidaPuellaeFormae : IResFluidaPuellaeFormaeLegibile {
        private bool _estApplicandum;
        private Vector3[] _magnitudinesActualium;

        public bool EstApplicandum => _estApplicandum;

        public ResFluidaPuellaeFormae(ITurrisSalsamenti turrisSalsamenti) {
            IOstiumSalsamenti ostiumSalsamenti;
            if (!turrisSalsamenti.ConareActualis(out ostiumSalsamenti)) {   
                Carnifex.Intermissio(LogTextus.ResFluidaPuellaeFormae_SALSAMENTUM_ACTUALIS_NULL);
            }

            int longitudo = Enum.GetValues(typeof(IDPuellaeFormae)).Length;
            _magnitudinesActualium = new Vector3[longitudo];

            for (int i = 0; i < longitudo; i++) {
                if (i == (int)IDPuellaeFormae.Nihil) {
                    continue;
                }
                 // セーブデータから値をロード。
                 // PuellaeFormarumは内部的にIDPuellaeFormaeを基に初期化しているから、チェック不要。
                _magnitudinesActualium[i] = ostiumSalsamenti.PuellaeFormarum.MagnitudoActualis(
                    (IDPuellaeFormae)i
                );
            }
            ApplicatumEst();
        }

        public Vector3 MagnitudoActualis(IDPuellaeFormae idFormae) {
            if (idFormae == IDPuellaeFormae.Nihil) {
                Carnifex.Error(LogTextus.ResFluidaPuellaeFormae_LEGERE_NIHIL);
                return new Vector3(1f, 1f, 1f);
            }
            return _magnitudinesActualium[(int)idFormae];
        }

        public void RenovareMagnitudoActualis(IDPuellaeFormae idFormae, Vector3 magnitudoActualis) {
            if (idFormae == IDPuellaeFormae.Nihil) {
                Carnifex.Error(LogTextus.ResFluidaPuellaeFormae_LEGERE_NIHIL);
                return;
            }
            _magnitudinesActualium[(int)idFormae] = magnitudoActualis;
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
            for (int i = 0; i < _magnitudinesActualium.Length; i++) {
                _magnitudinesActualium[i] = new Vector3(1f, 1f, 1f);
            }
            ApplicatumEst();
        }
    }
}