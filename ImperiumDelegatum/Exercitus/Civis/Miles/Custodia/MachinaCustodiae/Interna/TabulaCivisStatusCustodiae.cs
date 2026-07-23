using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using System;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class TabulaCivisStatusCustodiae {
        private readonly IStatusCivisCustodiae[] _statuum;

        public TabulaCivisStatusCustodiae(
            IConfiguratioCivisStatusCustodiaeCircumitus configuratioStatusCustodiaeCircumitus,
            IConfiguratioCivisStatusCustodiaeVigilantia configuratioStatusCustodiaeVigilantia,
            IConfiguratioCivisStatusCustodiaeSpectans configuratioStatusCustodiaeSpectans,
            IConfiguratioCivisStatusCustodiaeSequens configuratioStatusCustodiaeSequens,
            IConfiguratioCivisStatusCustodiaeQuaerens configuratioStatusCustodiaeQuaerens,
            IConfiguratioCivisStatusCustodiaeRefrigerationis configuratioStatusCustodiaeRefrigerationis,
            IConfiguratioCivisStatusCustodiaeDiscedens configuratioStatusCustodiaeDiscedens,
            IResFluidaCivisVeletudinisLegibile resFluidaCivisVeletudinis,
            IResFluidaPuellaeVeletudinisLegibile resFluidaPuellaeVeletudinis,
            IOstiumCivisLegibile civis,
            IResolutorCivisIctuumAuditae resolutorCivisIctuumAuditae,
            IResolutorCivisIctuumVisae resolutorCivisIctuumVisae,
            IResolutorCivisDistantia resolutorCivisDistantia,
            IOstiumCarrusCivis carrus,
            IOstiumTemporisLegibile temporis
        ) {
            int longitudo = Enum.GetValues(typeof(IDCivisStatusCustodiae)).Length;
            _statuum = new IStatusCivisCustodiae[longitudo];

            _statuum[(int)IDCivisStatusCustodiae.Nihil] = null;

            _statuum[(int)IDCivisStatusCustodiae.Circumitus] = new StatusCivisCustodiaeCircumitus(
                resFluidaCivisVeletudinis,
                resFluidaPuellaeVeletudinis,
                civis,
                resolutorCivisIctuumAuditae,
                resolutorCivisIctuumVisae,
                resolutorCivisDistantia,
                carrus,
                temporis,
                configuratioStatusCustodiaeCircumitus
            );
            _statuum[(int)IDCivisStatusCustodiae.Vigilantia] = new StatusCivisCustodiaeVigilantia(
                carrus,
                temporis,
                resFluidaCivisVeletudinis,
                configuratioStatusCustodiaeVigilantia
            );
            _statuum[(int)IDCivisStatusCustodiae.Spectans] = new StatusCivisCustodiaeSpectans(
                resFluidaCivisVeletudinis,
                resFluidaPuellaeVeletudinis,
                resolutorCivisIctuumAuditae,
                resolutorCivisIctuumVisae,
                resolutorCivisDistantia,
                carrus,
                temporis,
                configuratioStatusCustodiaeSpectans
            );
            _statuum[(int)IDCivisStatusCustodiae.Sequens] = new StatusCivisCustodiaeSequens(
                resFluidaCivisVeletudinis,
                resFluidaPuellaeVeletudinis,
                resolutorCivisIctuumAuditae,
                resolutorCivisIctuumVisae,
                resolutorCivisDistantia,
                carrus,
                temporis,
                configuratioStatusCustodiaeSequens
            );
            _statuum[(int)IDCivisStatusCustodiae.Quaerens] = new StatusCivisCustodiaeQuaerens(
                resFluidaCivisVeletudinis,
                resFluidaPuellaeVeletudinis,
                resolutorCivisIctuumAuditae,
                resolutorCivisIctuumVisae,
                resolutorCivisDistantia,
                carrus,
                temporis,
                configuratioStatusCustodiaeQuaerens
            );
            _statuum[(int)IDCivisStatusCustodiae.Refrigeratio] = new StatusCivisCustodiaeRefrigerationis(
                resFluidaCivisVeletudinis,
                resFluidaPuellaeVeletudinis,
                civis,
                resolutorCivisIctuumAuditae,
                resolutorCivisIctuumVisae,
                resolutorCivisDistantia,
                carrus,
                temporis,
                configuratioStatusCustodiaeRefrigerationis
            );
            _statuum[(int)IDCivisStatusCustodiae.Discedens] = new StatusCivisCustodiaeDiscedens(
                resFluidaCivisVeletudinis,
                resFluidaPuellaeVeletudinis,
                civis,
                resolutorCivisIctuumAuditae,
                resolutorCivisIctuumVisae,
                resolutorCivisDistantia,
                carrus,
                temporis,
                configuratioStatusCustodiaeDiscedens
            );
        }

        public IStatusCivisCustodiae Legere(IDCivisStatusCustodiae id) => _statuum[(int)id];
    }
}
