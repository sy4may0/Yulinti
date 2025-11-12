using System;
using Yulinti.MinisteriaUnity.MinisteriaNuclei;
using Yulinti.UnityServices.ServiceContracts;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class OstiumPuellaeAnimationesMutabile : IOstiumPuellaeAnimationesMutabile {
        private readonly MinisteriumPuellaeAnimationes _miPuellaeAnimationes;
        public OstiumPuellaeAnimationesMutabile(MinisteriumPuellaeAnimationes miPuellaeAnimationes) {
            if (miPuellaeAnimationes == null) {
                ModeratorErrorum.Fatal("MinisteriumPuellaeAnimationesのインスタンスがnullです。");
            }
            _miPuellaeAnimationes = miPuellaeAnimationes;
        }

        public void PostulareFundamenti(FukaBaseLayerAnimationID baseLayerAnimationID, Action fInvocanda, bool estObsignatus = false) {
            _miPuellaeAnimationes.PostulareFundamenti(baseLayerAnimationID, fInvocanda, estObsignatus);
        }
        public void CogereFundamenti(FukaBaseLayerAnimationID baseLayerAnimationID, Action fInvocanda, bool estObsignatus = false) {
            _miPuellaeAnimationes.CogereFundamenti(baseLayerAnimationID, fInvocanda, estObsignatus);
        }
        public void PostulareCorporisToti(FukaActionLayerAnimationID actionLayerAnimationID, Action fInvocanda, bool estObsignatus = false) {
            _miPuellaeAnimationes.PostulareCorporisToti(actionLayerAnimationID, fInvocanda, estObsignatus);
        }
        public void CogereCorporisToti(FukaActionLayerAnimationID actionLayerAnimationID, Action fInvocanda, bool estObsignatus = false) {
            _miPuellaeAnimationes.CogereCorporisToti(actionLayerAnimationID, fInvocanda, estObsignatus);
        }
        public void CogereDesinentiamFundamenti() {
            _miPuellaeAnimationes.CogereDesinentiamFundamenti();
        }
        public void CogereDesinentiamCorporisToti() {
            _miPuellaeAnimationes.CogereDesinentiamCorporisToti();
        }
        public void TemporareLuditores() {
            _miPuellaeAnimationes.TemporareLuditores();
        }
        public void InjicereVelocitatem(float vel) {
            _miPuellaeAnimationes.InjicereVelocitatem(vel);
        }
    }
}