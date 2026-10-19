using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;
using System;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class TabulaCivisStatusCustodiae {
        private readonly IStatusCivisCustodiae[] _statuum;

        public TabulaCivisStatusCustodiae(
            IConfiguratioCivisCustodiaeStatuum configuratio,
            IResFluidaCivisVeletudinisLegibile resFluidaCivisVeletudinis,
            IResFluidaCivisCustodiaeLegibile resFluidaCivisCustodiae,
            IResFluidaPuellaeVeletudinisLegibile resFluidaPuellaeVeletudinis,
            HorologiaCivisStatuumCustodiae horologiaCivisStatuumCustodiae,
            IOstiumCarrusCivisVeletudinis ostiumCarrusCivisVeletudinis,
            IOstiumTemporisLegibile ostiumTemporisLegibile,
            HorologiaCivisStatuumCustodiaeMutationis horologiaCivisStatuumCustodiaeMutationis
        ) {
            int longitudo = Enum.GetValues(typeof(IDCivisStatusCustodiae)).Length;
            _statuum = new IStatusCivisCustodiae[longitudo];

            Registrare(new StatusCivisCustodiaeCircumitus(
                configuratio, resFluidaCivisVeletudinis, resFluidaCivisCustodiae, resFluidaPuellaeVeletudinis,
                horologiaCivisStatuumCustodiae, ostiumCarrusCivisVeletudinis, ostiumTemporisLegibile
            ));
            Registrare(new StatusCivisCustodiaeVigilantia(
                configuratio, resFluidaCivisVeletudinis, resFluidaCivisCustodiae, resFluidaPuellaeVeletudinis,
                horologiaCivisStatuumCustodiae, ostiumCarrusCivisVeletudinis, ostiumTemporisLegibile,
                horologiaCivisStatuumCustodiaeMutationis
            ));
            Registrare(new StatusCivisCustodiaeSpectans(
                configuratio, resFluidaCivisVeletudinis, resFluidaCivisCustodiae, resFluidaPuellaeVeletudinis,
                horologiaCivisStatuumCustodiae, ostiumCarrusCivisVeletudinis, ostiumTemporisLegibile,
                horologiaCivisStatuumCustodiaeMutationis
            ));
            Registrare(new StatusCivisCustodiaeSequens(
                configuratio, resFluidaCivisVeletudinis, resFluidaCivisCustodiae, resFluidaPuellaeVeletudinis,
                horologiaCivisStatuumCustodiae, ostiumCarrusCivisVeletudinis, ostiumTemporisLegibile,
                horologiaCivisStatuumCustodiaeMutationis
            ));
            Registrare(new StatusCivisCustodiaeQuaerens(
                configuratio, resFluidaCivisVeletudinis, resFluidaCivisCustodiae, resFluidaPuellaeVeletudinis,
                horologiaCivisStatuumCustodiae, ostiumCarrusCivisVeletudinis, ostiumTemporisLegibile,
                horologiaCivisStatuumCustodiaeMutationis
            ));
            Registrare(new StatusCivisCustodiaeRefrigeratio(
                configuratio, resFluidaCivisVeletudinis, resFluidaCivisCustodiae, resFluidaPuellaeVeletudinis,
                horologiaCivisStatuumCustodiae, ostiumCarrusCivisVeletudinis, ostiumTemporisLegibile,
                horologiaCivisStatuumCustodiaeMutationis
            ));
            Registrare(new StatusCivisCustodiaeDiscedens(
                configuratio, resFluidaCivisVeletudinis, resFluidaCivisCustodiae, resFluidaPuellaeVeletudinis,
                horologiaCivisStatuumCustodiae, ostiumCarrusCivisVeletudinis, ostiumTemporisLegibile
            ));

            for (int i = 0; i < longitudo; i++) {
                IDCivisStatusCustodiae id = (IDCivisStatusCustodiae)i;
                if (id == IDCivisStatusCustodiae.Nihil) continue;
                if (_statuum[i] == null) {
                    Carnifex.Intermissio(LogTextus.MachinaCivisStatuumCustodiae_MACHINACIVISSTATUUMCUSTODIAE_STATUS_MISSING);
                }
            }
        }

        private void Registrare(IStatusCivisCustodiae status) {
            _statuum[(int)status.Id] = status;
        }

        public IStatusCivisCustodiae Legere(IDCivisStatusCustodiae id) => _statuum[(int)id];
    }
}
