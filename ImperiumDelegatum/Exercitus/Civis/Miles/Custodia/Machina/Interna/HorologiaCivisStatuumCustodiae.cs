using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using System;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    // 消費制限はステート遷移をまたいで継続させるため、PurgereはCivis生成時のみ行う。
    internal sealed class HorologiaCivisStatuumCustodiae {
        private readonly float[] _dtSuspectaPrior;
        private readonly float[] _dtIntentioPrior;
        private readonly Horologium[] _horologiaProhibitionisConsumptionisSuspectae;
        private readonly Horologium[] _horologiaProhibitionisConsumptionisIntentionis;

        public HorologiaCivisStatuumCustodiae(
            int longitudoCivis,
            IConfiguratioCivisCustodiaeStatuum configuratio,
            Random random
        ) {
            _dtSuspectaPrior = new float[longitudoCivis];
            _dtIntentioPrior = new float[longitudoCivis];
            _horologiaProhibitionisConsumptionisSuspectae = new Horologium[longitudoCivis];
            _horologiaProhibitionisConsumptionisIntentionis = new Horologium[longitudoCivis];

            for (int i = 0; i < longitudoCivis; i++) {
                _dtSuspectaPrior[i] = 0f;
                _dtIntentioPrior[i] = 0f;
                _horologiaProhibitionisConsumptionisSuspectae[i] = new Horologium(
                    configuratio.TempusProhibitioConsumptioSuspectae
                );
                _horologiaProhibitionisConsumptionisIntentionis[i] = new Horologium(
                    configuratio.TempusProhibitioConsumptioIntentio
                );
            }
        }

        // 消費制限ブロック中かどうか
        public bool EstProhibitioConsumptionisSuspectae(int idCivis) {
            return _horologiaProhibitionisConsumptionisSuspectae[idCivis].EstActivum;
        }

        // Ordinareから呼ぶ。Horologiumの起動or停止を行う。
        // dtSuspectaには消費制限を適用する前の増減値を渡すこと。
        public void CommutareProhibitionemConsumptionisSuspectae(
            int idCivis, float dtSuspecta, float intervallum
        ) {
            Commutare(
                _horologiaProhibitionisConsumptionisSuspectae[idCivis],
                _dtSuspectaPrior,
                idCivis, dtSuspecta, intervallum
            );
        }

        public void PurgereProhibitionemConsumptionisSuspectae(int idCivis) {
            _dtSuspectaPrior[idCivis] = 0f;
            _horologiaProhibitionisConsumptionisSuspectae[idCivis].Deactivare();
            _horologiaProhibitionisConsumptionisSuspectae[idCivis].Purgere();
        }

        // 消費制限ブロック中かどうか
        public bool EstProhibitioConsumptionisIntentionis(int idCivis) {
            return _horologiaProhibitionisConsumptionisIntentionis[idCivis].EstActivum;
        }

        // Ordinareから呼ぶ。Horologiumの起動or停止を行う。
        // dtIntentioには消費制限を適用する前の増減値を渡すこと。
        public void CommutareProhibitionemConsumptionisIntentionis(
            int idCivis, float dtIntentio, float intervallum
        ) {
            Commutare(
                _horologiaProhibitionisConsumptionisIntentionis[idCivis],
                _dtIntentioPrior,
                idCivis, dtIntentio, intervallum
            );
        }

        public void PurgereProhibitionemConsumptionisIntentionis(int idCivis) {
            _dtIntentioPrior[idCivis] = 0f;
            _horologiaProhibitionisConsumptionisIntentionis[idCivis].Deactivare();
            _horologiaProhibitionisConsumptionisIntentionis[idCivis].Purgere();
        }

        public void PurgereOmnia(int idCivis) {
            PurgereProhibitionemConsumptionisSuspectae(idCivis);
            PurgereProhibitionemConsumptionisIntentionis(idCivis);
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
