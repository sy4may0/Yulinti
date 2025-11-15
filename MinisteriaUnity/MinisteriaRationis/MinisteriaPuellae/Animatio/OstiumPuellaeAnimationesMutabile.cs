using System;
using Yulinti.MinisteriaUnity.MinisteriaNuclei;
using Yulinti.ContractusMinisterii.Puellae;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class OstiumPuellaeAnimationesMutabile : IOstiumPuellaeAnimationesMutabile {
        private readonly MinisteriumPuellaeAnimationes _miPuellaeAnimationes;
        public OstiumPuellaeAnimationesMutabile(MinisteriumPuellaeAnimationes miPuellaeAnimationes) {
            if (miPuellaeAnimationes == null) {
                ModeratorErrorum.Fatal("MinisteriumPuellaeAnimationesのインスタンスがnullです。");
            }
            _miPuellaeAnimationes = miPuellaeAnimationes;
        }

        public void PostulareFundamenti(IDPuellaeAnimationisBasis idBasis, Action fInvocanda, bool estObsignatus = false) {
            _miPuellaeAnimationes.PostulareFundamenti(idBasis, fInvocanda, estObsignatus);
        }
        public void CogereFundamenti(IDPuellaeAnimationisBasis idBasis, Action fInvocanda, bool estObsignatus = false) {
            _miPuellaeAnimationes.CogereFundamenti(idBasis, fInvocanda, estObsignatus);
        }
        public void PostulareCorporisToti(IDPuellaeAnimationisActionis idActionis, Action fInvocanda, bool estObsignatus = false) {
            _miPuellaeAnimationes.PostulareCorporisToti(idActionis, fInvocanda, estObsignatus);
        }
        public void CogereCorporisToti(IDPuellaeAnimationisActionis idActionis, Action fInvocanda, bool estObsignatus = false) {
            _miPuellaeAnimationes.CogereCorporisToti(idActionis, fInvocanda, estObsignatus);
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