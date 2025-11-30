using System;
using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class OstiumPuellaeAnimationesMutabile : IOstiumPuellaeAnimationesMutabile {
        private readonly MinisteriumPuellaeAnimationes _miPuellaeAnimationes;
        public OstiumPuellaeAnimationesMutabile(MinisteriumPuellaeAnimationes miPuellaeAnimationes) {
            if (miPuellaeAnimationes == null) {
                Errorum.Fatal(IDErrorum.OSTIUMPUELLAEANIMATIONESMUTABILE_INSTANCE_NULL);
            }
            _miPuellaeAnimationes = miPuellaeAnimationes;
        }

        public void PostulareFundamenti(IDPuellaeAnimationisFundamenti idFundamenti, Action fInvocanda, bool estObsignatus = false) {
            _miPuellaeAnimationes.PostulareFundamenti(idFundamenti, fInvocanda, estObsignatus);
        }
        public void CogereFundamenti(IDPuellaeAnimationisFundamenti idFundamenti, Action fInvocanda, bool estObsignatus = false) {
            _miPuellaeAnimationes.CogereFundamenti(idFundamenti, fInvocanda, estObsignatus);
        }
        public void PostulareCorporis(IDPuellaeAnimationisCorporis idCorporis, Action fInvocanda, bool estObsignatus = false) {
            _miPuellaeAnimationes.PostulareCorporis(idCorporis, fInvocanda, estObsignatus);
        }
        public void CogereCorporis(IDPuellaeAnimationisCorporis idCorporis, Action fInvocanda, bool estObsignatus = false) {
            _miPuellaeAnimationes.CogereCorporis(idCorporis, fInvocanda, estObsignatus);
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


