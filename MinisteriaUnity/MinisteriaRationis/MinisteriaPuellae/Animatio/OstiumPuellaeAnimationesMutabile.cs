using System;
using Yulinti.MinisteriaUnity.Interna;
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
        public void PostulareCorporis(IDPuellaeAnimationisActionis idActionis, Action fInvocanda, bool estObsignatus = false) {
            _miPuellaeAnimationes.PostulareCorporis(idActionis, fInvocanda, estObsignatus);
        }
        public void CogereCorporis(IDPuellaeAnimationisActionis idActionis, Action fInvocanda, bool estObsignatus = false) {
            _miPuellaeAnimationes.CogereCorporis(idActionis, fInvocanda, estObsignatus);
        }
        public void CogereDesinentiamFundamenti() {
            _miPuellaeAnimationes.CogereDesinentiamFundamenti();
        }
        public void CogereDesinentiamCorporis() {
            _miPuellaeAnimationes.CogereDesinentiamCorporis();
        }
        public void TemporareLuditores() {
            _miPuellaeAnimationes.TemporareLuditores();
        }
        public void InjicereVelocitatem(float vel) {
            _miPuellaeAnimationes.InjicereVelocitatem(vel);
        }
    }
}