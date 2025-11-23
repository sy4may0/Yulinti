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
                ModeratorErrorum.Fatal("MinisteriumPuellaeAnimationes ConfiguratioPuellaeAnimationis is null.");
            }

            var animancer = config.Animancer.EvolvareNuncium("MinisteriumPuellaeAnimationes Animancer is null.");
            _tabulaFundamenti = new TabulaPuellaeAnimationumFundamenti(config.LuditorisFundamenti);
            _tabulaCorporis = new TabulaPuellaeAnimationumCorporis(config.LuditorisCorporis);
            _luditorFundamenti = new LuditorAnimationis(animancer, 0);
            _luditorCorporis = new LuditorAnimationis(animancer, 1);
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
            // TODO: 実裁E
        }

        // 冁E��時間のみ同期し、Animancerの時間は同期しなぁE��E
        // Animancer同期は、Play()が実行されたときだけ、E
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
