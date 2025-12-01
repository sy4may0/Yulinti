using System;
using Animancer;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;


namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class MinisteriumPuellaeAnimationes : IPulsabilis {
        private readonly TabulaPuellaeAnimationumFundamenti _tabulaFundamenti;
        private readonly TabulaPuellaeAnimationumCorporis _tabulaCorporis;
        private readonly TabulaPuellaeAnimationumPartis _tabulaPartis;

        private readonly LuditorAnimationis _luditorFundamenti;
        private readonly LuditorAnimationis _luditorCorporis;
        private readonly LuditorAnimationis _luditorPartis;

        public MinisteriumPuellaeAnimationes(IConfiguratioPuellaeAnimationis config, IAnchoraPuellae anchora) {
            AnimancerComponent animancer = anchora.Animancer;
            _tabulaFundamenti = new TabulaPuellaeAnimationumFundamenti(config.Fundamentum);
            _tabulaCorporis = new TabulaPuellaeAnimationumCorporis(config.Corpus);
            _tabulaPartis = new TabulaPuellaeAnimationumPartis(config.Pars);
            _luditorFundamenti = new LuditorAnimationis(animancer, 0);
            _luditorCorporis = new LuditorAnimationis(animancer, 1);
            _luditorPartis = new LuditorAnimationis(animancer, 2);
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

        public void PostularePartis(
            IDPuellaeAnimationisPartis idPartis,
            Action fInvocanda, bool estObsignatus = false
        ) {
            _luditorPartis.Postulare(_tabulaPartis.Lego(idPartis), fInvocanda, estObsignatus);
        }

        public void CogerePartis(
            IDPuellaeAnimationisPartis idPartis,
            Action fInvocanda, bool estObsignatus = false
        ) {
            _luditorPartis.Cogere(_tabulaPartis.Lego(idPartis), fInvocanda, estObsignatus);
        }

        public void CogereDesinentiamFundamenti() {
            _luditorFundamenti.CogereDesinentiam();
        }

        public void CogereDesinentiamCorporis() {
            _luditorCorporis.CogereDesinentiam();
        }

        public void CogereDesinentiamPartis() {
            _luditorPartis.CogereDesinentiam();
        }

        public void InjicereVelocitatem(float vel) {
            _luditorFundamenti.InjicereVelocitatem(vel);
            _luditorCorporis.InjicereVelocitatem(vel);
            _luditorPartis.InjicereVelocitatem(vel);
        }

        // 蜀・・ｽ・ｽ譎る俣縺ｮ縺ｿ蜷梧悄縺励、nimancer縺ｮ譎る俣縺ｯ蜷梧悄縺励↑縺・・ｽ・ｽE
        // Animancer蜷梧悄縺ｯ縲￣lay()縺悟ｮ溯｡後＆繧後◆縺ｨ縺阪□縺代・
        public void TemporareLuditores() {
            float tempusFun = _luditorFundamenti.LegoTempusSimultaneum();
            _luditorCorporis.PonoTempusSimultaneum(tempusFun);
            _luditorPartis.PonoTempusSimultaneum(tempusFun);
        }

        public void Pulsus() {
            _luditorFundamenti.Pulsus();
            _luditorCorporis.Pulsus();
            _luditorPartis.Pulsus();
            TemporareLuditores();
        }
    }
}


