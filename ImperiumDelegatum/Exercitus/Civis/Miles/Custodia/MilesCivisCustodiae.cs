using Yulinti.ImperiumDelegatum.Contractus;
using System;


namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class MilesCivisCustodiae {
        private readonly ResolutorCivisIctuumVisae _resolutorCivisIctuum;
        private readonly ResolutorCivisIctuumAuditae _resolutorCivisIctuumAuditae;

        private readonly ResolutorCivisDistantia _resolutorCivisDistantia;
        private readonly ResolutorCivisNudusVisae _resolutorCivisNudusVisae;
        private readonly ResolutorCivisVisa _resolutorCivisVisa;
        private readonly ResolutorCivisSuspectae _resolutorCivisSuspectae;
        private readonly ResolutorCivisMutareCustodiae _resolutorCivisMutareCustodiae;
        private readonly ResolutorCivisAuditae _resolutorCivisAuditae;

        public MilesCivisCustodiae(
            IConfiguratioCivisCustodiae configuratioCustodiae,
            IOstiumTemporisLegibile temporis,
            IOstiumCivisLegibile civis,
            IOstiumCivisLociLegibile loci,
            IOstiumCivisVisaeLegibile visa,
            IOstiumPuellaeResVisaeLegibile puellaeResVisae,
            IResFluidaPuellaeLegibile resFPuellae,
            IOstiumCarrusCivis carrus,
            Random random
        ) {
            _resolutorCivisDistantia = new ResolutorCivisDistantia(
                configuratioCustodiae,
                civis,
                loci,
                puellaeResVisae
            );
            _resolutorCivisIctuum = new ResolutorCivisIctuumVisae(
                configuratioCustodiae,
                civis,
                visa,
                puellaeResVisae,
                _resolutorCivisDistantia
            );
            _resolutorCivisIctuumAuditae = new ResolutorCivisIctuumAuditae(
                configuratioCustodiae,
                civis,
                resFPuellae,
                _resolutorCivisDistantia
            );

            _resolutorCivisNudusVisae = new ResolutorCivisNudusVisae(
                carrus,
                visa,
                puellaeResVisae,
                _resolutorCivisDistantia
            );
            _resolutorCivisVisa = new ResolutorCivisVisa(
                configuratioCustodiae,
                temporis,
                civis,
                carrus,
                resFPuellae,
                _resolutorCivisIctuum,
                _resolutorCivisDistantia
            );
            _resolutorCivisSuspectae = new ResolutorCivisSuspectae(
                configuratioCustodiae,
                temporis,
                civis,
                carrus,
                resFPuellae,
                _resolutorCivisIctuum,
                _resolutorCivisDistantia
            );
            _resolutorCivisMutareCustodiae = new ResolutorCivisMutareCustodiae(
                configuratioCustodiae,
                carrus,
                civis
            );
            _resolutorCivisAuditae = new ResolutorCivisAuditae(
                configuratioCustodiae,
                temporis,
                carrus,
                civis,
                random,
                _resolutorCivisIctuumAuditae,
                _resolutorCivisDistantia
            );
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
