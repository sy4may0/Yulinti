using System;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class MinisteriumPuellaeAnimationes : IPulsabilis {
        private readonly TabulaPuellaeAnimationumFundamenti _tabulaFundamenti;
        private readonly TabulaPuellaeAnimationumCorporis _tabulaCorporis;

        private readonly LuditorAnimationis _luditorFundamenti;
        private readonly LuditorAnimationis _luditorCorporis;

        public MinisteriumPuellaeAnimationes(ConfiguratioPuellaeAnimationis config) {
            if (config == null) {
                ModeratorErrorum.Fatal("MinisteriumPuellaeAnimationesのConfiguratioPuellaeAnimationisがnullです。");
            }
            if (config.Animancer == null) {
                ModeratorErrorum.Fatal("MinisteriumPuellaeAnimationesのAnimancerがnullです。");
            }
            _tabulaFundamenti = new TabulaPuellaeAnimationumFundamenti(config.LuditorisFundamenti);
            _tabulaCorporis = new TabulaPuellaeAnimationumCorporis(config.LuditorisCorporis);
            _luditorFundamenti = new LuditorAnimationis(config.Animancer, 0);
            _luditorCorporis = new LuditorAnimationis(config.Animancer, 1);
        }

        public void PostulareFundamenti(
            IDPuellaeAnimationisFundamenti idFundamenti, 
            Action fInvocanda, bool estObsignatus = false
        ) {
            _luditorFundamenti.Postulare(_tabulaFundamenti.Lego(idFundamenti), fInvocanda, estObsignatus);
        }

        public void CogereFundamenti(
            IDPuellaeAnimationisFundamenti idFundamenti, 
            Action fInvocanda, bool estObsignatus = false
        ) {
            _luditorFundamenti.Cogere(_tabulaFundamenti.Lego(idFundamenti), fInvocanda, estObsignatus);
        }

        public void PostulareCorporis(
            IDPuellaeAnimationisCorporis idCorporis, 
            Action fInvocanda, bool estObsignatus = false
        ) {
            _luditorCorporis.Postulare(_tabulaCorporis.Lego(idCorporis), fInvocanda, estObsignatus);
        }

        public void CogereCorporis(
            IDPuellaeAnimationisCorporis idCorporis, 
            Action fInvocanda, bool estObsignatus = false
        ) {
            _luditorCorporis.Cogere(_tabulaCorporis.Lego(idCorporis), fInvocanda, estObsignatus);
        }

        public void CogereDesinentiamFundamenti() {
            _luditorFundamenti.CogereDesinentiam();
        }

        public void CogereDesinentiamCorporis() {
            _luditorCorporis.CogereDesinentiam();
        }

        public void InjicereVelocitatem(float vel) {
            _luditorFundamenti.InjicereVelocitatem(vel);
            _luditorCorporis.InjicereVelocitatem(vel);
            // TODO: 実装
        }

        // 内部時間のみ同期し、Animancerの時間は同期しない。
        // Animancer同期は、Play()が実行されたときだけ。
        public void TemporareLuditores() {
            float tempusFun = _luditorFundamenti.LegoTempusSimultaneum();
            _luditorCorporis.PonoTempusSimultaneum(tempusFun);
        }

        public void Pulsus() {
            _luditorFundamenti.Pulsus();
            _luditorCorporis.Pulsus();
            TemporareLuditores();
        }
    }
}
