using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using System;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    // ProhibitioConsumptioのPurgereのタイミングはCivis生成時でよい。
    // それ以外はステート遷移で使われるため、ステートのintrare, exireでPurgereする。
    internal sealed class HorologiaCivisStatuumCustodiae {
        private readonly float[] _dtSuspectaPrior;
        private readonly float[] _dtIntentioPrior;
        private readonly Horologium[] _horologiaProhibitioConsumptioSuspectae;
        private readonly Horologium[] _horologiaProhibitioConsumptioIntentionis;

        public HorologiaCivisStatuumCustodiae(
            int longitudoCivis,
            IConfiguratioCivisCustodiaeStatuum configuratio,
            Random random
        ) {
            _dtSuspectaPrior = new float[longitudoCivis];
            _dtIntentioPrior = new float[longitudoCivis];
            _horologiaProhibitioConsumptioSuspectae = new Horologium[longitudoCivis];
            _horologiaProhibitioConsumptioIntentionis = new Horologium[longitudoCivis];

            for (int i = 0; i < longitudoCivis; i++) {
                _dtSuspectaPrior[i] = 0f;
                _dtIntentioPrior[i] = 0f;
                _horologiaProhibitioConsumptioSuspectae[i] = new Horologium(
                    configuratio.TempusProhibitioConsumptioSuspectae
                );
                _horologiaProhibitioConsumptioIntentionis[i] = new Horologium(
                    configuratio.TempusProhibitioConsumptioIntentio
                );
            }
        }

        // 消費制限ブロック中かどうか
        public bool EstProhibitioConsumptioSuspectae(int idCivis) {
            return _horologiaProhibitioConsumptioSuspectae[idCivis].EstActivum;
        }

        // Ordinareから呼ぶ。Horologiumの起動or停止を行う。
        // dtSuspectaには消費制限を適用する前の増減値を渡すこと。
        public void CommutareProhibitioConsumptioSuspectae(
            int idCivis, float dtSuspecta, float intervallum
        ) {
            Commutare(
                _horologiaProhibitioConsumptioSuspectae[idCivis],
                _dtSuspectaPrior,
                idCivis, dtSuspecta, intervallum
            );
        }

        public void PurgereProhibitioConsumptioSuspectae(int idCivis) {
            _dtSuspectaPrior[idCivis] = 0f;
            _horologiaProhibitioConsumptioSuspectae[idCivis].Deactivare();
            _horologiaProhibitioConsumptioSuspectae[idCivis].Purgere();
        }

        // 消費制限ブロック中かどうか
        public bool EstProhibitioConsumptioIntentionis(int idCivis) {
            return _horologiaProhibitioConsumptioIntentionis[idCivis].EstActivum;
        }

        // Ordinareから呼ぶ。Horologiumの起動or停止を行う。
        // dtIntentioには消費制限を適用する前の増減値を渡すこと。
        public void CommutareProhibitioConsumptioIntentionis(
            int idCivis, float dtIntentio, float intervallum
        ) {
            Commutare(
                _horologiaProhibitioConsumptioIntentionis[idCivis],
                _dtIntentioPrior,
                idCivis, dtIntentio, intervallum
            );
        }

        public void PurgereProhibitioConsumptioIntentionis(int idCivis) {
            _dtIntentioPrior[idCivis] = 0f;
            _horologiaProhibitioConsumptioIntentionis[idCivis].Deactivare();
            _horologiaProhibitioConsumptioIntentionis[idCivis].Purgere();
        }

        private static void Commutare(
            Horologium horologium, float[] dtPrior,
            int idCivis, float dt, float intervallum
        ) {
            bool estDecrescensPrior = EstDecrescens(dtPrior[idCivis]);
            bool estDecrescens = EstDecrescens(dt);
            dtPrior[idCivis] = dt;

            // 時計が有効な場合は時間を進め、満了または減少終了で解除する。
            if (horologium.EstActivum) {
                if (!estDecrescens || horologium.EstExhaurita(intervallum)) {
                    horologium.Deactivare();
                }
                return;
            }

            // 増加or維持 -> 減少に切り替わる際、Horologiumを起動する。
            if (!estDecrescensPrior && estDecrescens) {
                horologium.Activare();
            }
        }

        private static bool EstDecrescens(float dt) {
            return dt < -Numerus.Epsilon;
        }
    }
}
