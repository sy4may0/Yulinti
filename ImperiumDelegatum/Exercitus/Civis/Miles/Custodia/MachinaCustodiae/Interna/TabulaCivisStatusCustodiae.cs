using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using System;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class TabulaCivisStatusCustodiae {
        private readonly IStatusCivisCustodiae[] _statuum;

        public TabulaCivisStatusCustodiae(
            IConfiguratioCivisCustodiaeStatusCircumitus configuratioStatusCustodiaeCircumitus,
            IConfiguratioCivisCustodiaeStatusVigilantia configuratioStatusCustodiaeVigilantia,
            IConfiguratioCivisCustodiaeStatusSpectans configuratioStatusCustodiaeSpectans,
            IConfiguratioCivisCustodiaeStatusSequens configuratioStatusCustodiaeSequens,
            IConfiguratioCivisCustodiaeStatusQuaerens configuratioStatusCustodiaeQuaerens,
            IConfiguratioCivisCustodiaeStatusRefrigerationis configuratioStatusCustodiaeRefrigerationis,
            IConfiguratioCivisCustodiaeStatusDiscedens configuratioStatusCustodiaeDiscedens,
            IResFluidaCivisVeletudinisLegibile resFluidaCivisVeletudinis,
            IResFluidaPuellaeVeletudinisLegibile resFluidaPuellaeVeletudinis,
            IOstiumCivisLegibile civis,
            IResFluidaCivisCustodiaeLegibile resFluidaCivisCustodiae,
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
                resFluidaCivisCustodiae,
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
                resFluidaCivisCustodiae,
                carrus,
                temporis,
                configuratioStatusCustodiaeSpectans
            );
            _statuum[(int)IDCivisStatusCustodiae.Sequens] = new StatusCivisCustodiaeSequens(
                resFluidaCivisVeletudinis,
                resFluidaPuellaeVeletudinis,
                resFluidaCivisCustodiae,
                carrus,
                temporis,
                configuratioStatusCustodiaeSequens
            );
            _statuum[(int)IDCivisStatusCustodiae.Quaerens] = new StatusCivisCustodiaeQuaerens(
                resFluidaCivisVeletudinis,
                resFluidaPuellaeVeletudinis,
                resFluidaCivisCustodiae,
                carrus,
                temporis,
                configuratioStatusCustodiaeQuaerens
            );
            _statuum[(int)IDCivisStatusCustodiae.Refrigeratio] = new StatusCivisCustodiaeRefrigerationis(
                resFluidaCivisVeletudinis,
                resFluidaPuellaeVeletudinis,
                civis,
                resFluidaCivisCustodiae,
                carrus,
                temporis,
                configuratioStatusCustodiaeRefrigerationis
            );
            _statuum[(int)IDCivisStatusCustodiae.Discedens] = new StatusCivisCustodiaeDiscedens(
                resFluidaCivisVeletudinis,
                resFluidaPuellaeVeletudinis,
                civis,
                resFluidaCivisCustodiae,
                carrus,
                temporis,
                configuratioStatusCustodiaeDiscedens
            );
        }

        public IStatusCivisCustodiae Legere(IDCivisStatusCustodiae id) => _statuum[(int)id];
    }
}
