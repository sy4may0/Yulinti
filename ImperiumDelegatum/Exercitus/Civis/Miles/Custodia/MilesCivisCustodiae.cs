using Yulinti.ImperiumDelegatum.Contractus;
using System;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class MilesCivisCustodiae {
        private readonly ResolutorCivisIctuumVisae _resolutorCivisIctuum;
        private readonly ResolutorCivisIctuumAuditae _resolutorCivisIctuumAuditae;

        private readonly ResolutorCivisDistantia _resolutorCivisDistantia;
        private readonly ResolutorCivisNudusVisae _resolutorCivisNudusVisae;

        private readonly MachinaCivisStatuumCustodiae _machinaCivisStatuumCustodiae;

        public MilesCivisCustodiae(
            IConfiguratioCivisCustodiaeIctuum configuratioCustodiae,
            IConfiguratioCivisCustodiaeStatuum configuratioStatuum,
            IOstiumCivisLegibile civis,
            IOstiumCivisLociLegibile loci,
            IOstiumCivisVisaeLegibile visa,
            IOstiumPuellaeResVisaeLegibile puellaeResVisae,
            IResFluidaPuellaeLegibile resFPuellae,
            IResFluidaCivisLegibile resFCivis,
            IOstiumCarrusCivis carrus,
            IOstiumTemporisLegibile temporis,
            Random random
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

            _machinaCivisStatuumCustodiae = new MachinaCivisStatuumCustodiae(
                civis.Longitudo,
                configuratioStatuum,
                resFCivis,
                resFPuellae,
                carrus,
                temporis,
                random
            );
        }

        public void Initare(
            int idCivis
        ) {
            _resolutorCivisDistantia.Initare(idCivis);
            _resolutorCivisNudusVisae.Initare(idCivis);
            _resolutorCivisIctuum.Initare(idCivis);
            _resolutorCivisIctuumAuditae.Initare(idCivis);

            _machinaCivisStatuumCustodiae.Initare(idCivis);
        }

        public void OrdinareCustodiae(
            int idCivis, IResFluidaCivisLegibile resFluida
        ) {
            // 視認範囲の解決
            _resolutorCivisDistantia.Ordinare(idCivis);
            // SpectareNudusの解決
            _resolutorCivisNudusVisae.Ordinare(idCivis);

            _machinaCivisStatuumCustodiae.Ordinare(idCivis);
        }

        public void ResolvereIctuum(int idCivis) {
            // Puellae視認数を解決
            _resolutorCivisIctuum.Resolvere(idCivis);
            // Auditaの解決
            _resolutorCivisIctuumAuditae.Resolvere(idCivis);
        }
    }
}
