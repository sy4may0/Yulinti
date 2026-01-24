using Yulinti.Nucleus;
using Yulinti.Dux.ContractusDucis;
using System;
using System.Numerics;


namespace Yulinti.Dux.Exercitus {
    internal sealed class MilesCivisCustodiae {
        private readonly ContextusCivisOstiorumLegibile _contextus;

        private readonly ResolutorCivisIctuumVisae _resolutorCivisIctuum;
        private readonly ResolutorCivisIctuumAuditae _resolutorCivisIctuumAuditae;

        private readonly ResolutorCivisDistantia _resolutorCivisDistantia;
        private readonly ResolutorCivisNudusVisae _resolutorCivisNudusVisae;
        private readonly ResolutorCivisVisa _resolutorCivisVisa;
        private readonly ResolutorCivisSuspectae _resolutorCivisSuspectae;
        private readonly ResolutorCivisMutareCustodiae _resolutorCivisMutareCustodiae;
        private readonly ResolutorCivisAuditae _resolutorCivisAuditae;

        public MilesCivisCustodiae(ContextusCivisOstiorumLegibile contextus) {
            _contextus = contextus;

            _resolutorCivisDistantia = new ResolutorCivisDistantia(contextus);
            _resolutorCivisIctuum = new ResolutorCivisIctuumVisae(contextus, _resolutorCivisDistantia);
            _resolutorCivisIctuumAuditae = new ResolutorCivisIctuumAuditae(contextus, _resolutorCivisDistantia);

            _resolutorCivisNudusVisae = new ResolutorCivisNudusVisae(contextus, _resolutorCivisDistantia);
            _resolutorCivisVisa = new ResolutorCivisVisa(contextus, _resolutorCivisIctuum, _resolutorCivisDistantia);
            _resolutorCivisSuspectae = new ResolutorCivisSuspectae(contextus, _resolutorCivisIctuum, _resolutorCivisDistantia);
            _resolutorCivisMutareCustodiae = new ResolutorCivisMutareCustodiae(contextus);
            _resolutorCivisAuditae = new ResolutorCivisAuditae(contextus, _resolutorCivisIctuumAuditae, _resolutorCivisDistantia);
        }

        public void Initare(
            int idCivis
        ) {
            _resolutorCivisDistantia.Initare(idCivis);
            _resolutorCivisNudusVisae.Initare(idCivis);
            _resolutorCivisVisa.Initare(idCivis);
            _resolutorCivisSuspectae.Initare(idCivis);
            _resolutorCivisIctuum.Initare(idCivis);
            _resolutorCivisIctuumAuditae.Initare(idCivis);
            _resolutorCivisMutareCustodiae.Initare(idCivis);
            _resolutorCivisAuditae.Initare(idCivis);
        }

        public void OrdinareCustodiae(
            int idCivis, IResFluidaCivisLegibile resFluida
        ) {
            // 視認範囲の解決
            _resolutorCivisDistantia.Ordinare(idCivis);
            // SpectareNudusの解決
            _resolutorCivisNudusVisae.Ordinare(idCivis);

            // Nudus視認前後の挙動を解決
            _resolutorCivisMutareCustodiae.OrdinareVisa(idCivis, resFluida);

            // Visaの解決
            _resolutorCivisVisa.Ordinare(idCivis, resFluida);
            // Suspectaの解決
            _resolutorCivisSuspectae.Ordinare(idCivis, resFluida);
            // Auditaの解決
            _resolutorCivisAuditae.Ordinare(idCivis, resFluida);
        }

        public void ResolvereIctuum(
            int idCivis, IResFluidaCivisLegibile resFluida
        ) {
            // Puellae視認数を解決
            _resolutorCivisIctuum.Resolvere(idCivis, resFluida);
            // Auditaの解決
            _resolutorCivisIctuumAuditae.Resolvere(idCivis, resFluida);
        }

        public void ResolvereDetectio(
            int idCivis, IResFluidaCivisLegibile resFluida
        ) {
            // Detectio, Vigilantiaの解決
            _resolutorCivisMutareCustodiae.ResolvereDetectio(idCivis, resFluida);
            // Suspectaの解決
            _resolutorCivisMutareCustodiae.ResolvereSuspecta(idCivis, resFluida);
            // DetectioSonoraの解決
            _resolutorCivisMutareCustodiae.ResolvereDetectioSonora(idCivis, resFluida);
        }
    }
}