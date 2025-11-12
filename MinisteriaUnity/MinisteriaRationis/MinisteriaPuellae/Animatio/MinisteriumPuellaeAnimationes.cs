using System;
using Yulinti.UnityServices.ServiceConfig;
using Yulinti.MinisteriaUnity.MinisteriaNuclei;
using Yulinti.UnityServices.ServiceContracts;
using Yulinti.MinisteriaUnity.Interna.InstulmentaAnimancer;
using Yulinti.MinisteriaUnity.MinisteriaRationis.MinisteriaPuellae.Animatio.Interna;
using Yulinti.Nucleus.Interfacies;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class MinisteriumPuellaeAnimationes : IPulsabilis {
        private readonly TabulaAnimationumFundamenti _tabulaFundamenti;
        private readonly TabulaAnimationumCorporisToti _tabulaCorporisToti;

        private readonly LuditorAnimationis _luditorFundamenti;
        private readonly LuditorAnimationis _luditorCorporisToti;

        public MinisteriumPuellaeAnimationes(FukaAnimationConfig animationConfig) {
            if (animationConfig == null) {
                ModeratorErrorum.Fatal("MinisteriumPuellaeAnimationesのアニメーション設定がnullです。");
            }
            if (animationConfig.Animancer == null) {
                ModeratorErrorum.Fatal("MinisteriumPuellaeAnimationesのAnimancerがnullです。");
            }

            _tabulaFundamenti = new TabulaAnimationumFundamenti(animationConfig.BaseLayerConfig);
            _tabulaCorporisToti = new TabulaAnimationumCorporisToti(animationConfig.ActionLayerConfig);

            _luditorFundamenti = new LuditorAnimationis(animationConfig.Animancer, 0);
            _luditorCorporisToti = new LuditorAnimationis(animationConfig.Animancer, 1);
        }

        public void PostulareFundamenti(
            FukaBaseLayerAnimationID baseLayerAnimationID, 
            Action fInvocanda, bool estObsignatus = false
        ) {
            _luditorFundamenti.Postulare(_tabulaFundamenti.Lego(baseLayerAnimationID), fInvocanda, estObsignatus);
        }

        public void CogereFundamenti(
            FukaBaseLayerAnimationID baseLayerAnimationID, 
            Action fInvocanda, bool estObsignatus = false
        ) {
            _luditorFundamenti.Cogere(_tabulaFundamenti.Lego(baseLayerAnimationID), fInvocanda, estObsignatus);
        }

        public void PostulareCorporisToti(
            FukaActionLayerAnimationID actionLayerAnimationID, 
            Action fInvocanda, bool estObsignatus = false
        ) {
            _luditorCorporisToti.Postulare(_tabulaCorporisToti.Lego(actionLayerAnimationID), fInvocanda, estObsignatus);
        }

        public void CogereCorporisToti(
            FukaActionLayerAnimationID actionLayerAnimationID, 
            Action fInvocanda, bool estObsignatus = false
        ) {
            _luditorCorporisToti.Cogere(_tabulaCorporisToti.Lego(actionLayerAnimationID), fInvocanda, estObsignatus);
        }

        public void CogereDesinentiamFundamenti() {
            _luditorFundamenti.CogereDesinentiam();
        }

        public void CogereDesinentiamCorporisToti() {
            _luditorCorporisToti.CogereDesinentiam();
        }

        public void InjicereVelocitatem(float vel) {
            _luditorFundamenti.InjicereVelocitatem(vel);
            _luditorCorporisToti.InjicereVelocitatem(vel);
            // TODO: 実装
        }

        // 内部時間のみ同期し、Animancerの時間は同期しない。
        // Animancer同期は、Play()が実行されたときだけ。
        public void TemporareLuditores() {
            float tempusFun = _luditorFundamenti.LegoTempusSimultaneum();
            _luditorCorporisToti.PonoTempusSimultaneum(tempusFun);
        }

        public void Pulsus() {
            _luditorFundamenti.Pulsus();
            _luditorCorporisToti.Pulsus();
            TemporareLuditores();
        }
    }
}