using Yulinti.ImperiumDelegatum.Contractus;


namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class MilesCivisCustodiae {
        private readonly ResolutorCivisIctuumVisae _resolutorCivisIctuum;
        private readonly ResolutorCivisIctuumAuditae _resolutorCivisIctuumAuditae;

        private readonly ResolutorCivisDistantia _resolutorCivisDistantia;
        private readonly ResolutorCivisNudusVisae _resolutorCivisNudusVisae;

        private readonly MachinaCivisCustodiae _machinaCivisCustodiae;

        public MilesCivisCustodiae(
            IConfiguratioCivisCustodiaeIctuum configuratioCustodiae,
            IConfiguratioCivisCustodiaeStatus configuratioCivisStatusCustodiae,
            IOstiumTemporisLegibile temporis,
            IOstiumCivisLegibile civis,
            IOstiumCivisLociLegibile loci,
            IOstiumCivisVisaeLegibile visa,
            IOstiumPuellaeResVisaeLegibile puellaeResVisae,
            IResFluidaPuellaeLegibile resFPuellae,
            IResFluidaCivisLegibile resFCivis,
            IOstiumCarrusCivis carrus
        ) {
            _resolutorCivisDistantia = new ResolutorCivisDistantia(
                configuratioCustodiae,
                civis,
                loci,
                puellaeResVisae,
                carrus
            );
            _resolutorCivisIctuum = new ResolutorCivisIctuumVisae(
                configuratioCustodiae,
                civis,
                visa,
                puellaeResVisae,
                carrus,
                resFCivis.Custodiae
            );
            _resolutorCivisIctuumAuditae = new ResolutorCivisIctuumAuditae(
                configuratioCustodiae,
                civis,
                carrus,
                resFPuellae,
                resFCivis.Custodiae
            );

            _resolutorCivisNudusVisae = new ResolutorCivisNudusVisae(
                carrus,
                visa,
                puellaeResVisae,
                resFCivis.Custodiae
            );

            _machinaCivisCustodiae = new MachinaCivisCustodiae(
                configuratioCivisStatusCustodiae,
                resFCivis.Veletudinis,
                resFPuellae.Veletudinis,
                civis,
                resFCivis.Custodiae,
                carrus,
                temporis
            );
        }

        public void Initare(
            int idCivis
        ) {
            _resolutorCivisDistantia.Initare(idCivis);
            _resolutorCivisNudusVisae.Initare(idCivis);
            _resolutorCivisIctuum.Initare(idCivis);
            _resolutorCivisIctuumAuditae.Initare(idCivis);
            _machinaCivisCustodiae.Initare(idCivis);
        }

        public void OrdinareCustodiae(
            int idCivis, IResFluidaCivisLegibile resFluida
        ) {
            // 視認範囲の解決
            _resolutorCivisDistantia.Ordinare(idCivis);
            // SpectareNudusの解決
            _resolutorCivisNudusVisae.Ordinare(idCivis);
            // 状態の解決
            _machinaCivisCustodiae.Ordinare(idCivis);
        }

        public void ResolvereIctuum(int idCivis) {
            // Puellae視認数を解決
            _resolutorCivisIctuum.Resolvere(idCivis);
            // Auditaの解決
            _resolutorCivisIctuumAuditae.Resolvere(idCivis);
        }
    }
}
