using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class MachinaCivisCustodiae {
        private readonly TabulaCivisStatusCustodiae _tabulaCivisStatusCustodiae;
        private readonly AbaciCivisStatus _abaciCivisStatus;
        private readonly int _longitudo;
        private readonly IDCivisStatusCustodiae[] _statusCustodiaeCurrens;

        public MachinaCivisCustodiae(
            IConfiguratioCivisCustodiaeStatus configuratioCivisStatusCustodiae,
            IResFluidaCivisVeletudinisLegibile resFluidaCivisVeletudinis,
            IResFluidaPuellaeVeletudinisLegibile resFluidaPuellaeVeletudinis,
            IOstiumCivisLegibile civis,
            IResFluidaCivisCustodiaeLegibile resFluidaCivisCustodiae,
            IOstiumCarrusCivis carrus,
            IOstiumTemporisLegibile temporis
        ) {
            _tabulaCivisStatusCustodiae = new TabulaCivisStatusCustodiae(
                configuratioCivisStatusCustodiae.ConfiguratioCustodiaeStatusCircumitus,
                configuratioCivisStatusCustodiae.ConfiguratioCustodiaeStatusVigilantia,
                configuratioCivisStatusCustodiae.ConfiguratioCustodiaeStatusSpectans,
                configuratioCivisStatusCustodiae.ConfiguratioCustodiaeStatusSequens,
                configuratioCivisStatusCustodiae.ConfiguratioCustodiaeStatusQuaerens,
                configuratioCivisStatusCustodiae.ConfiguratioCustodiaeStatusRefrigerationis,
                configuratioCivisStatusCustodiae.ConfiguratioCustodiaeStatusDiscedens,
                resFluidaCivisVeletudinis,
                resFluidaPuellaeVeletudinis,
                civis,
                resFluidaCivisCustodiae,
                carrus,
                temporis
            );
            _abaciCivisStatus = new AbaciCivisStatus(
                civis,
                configuratioCivisStatusCustodiae.ConfiguratioCustodiaeStatusCommunis
            );
            _longitudo = civis.Longitudo;
            _statusCustodiaeCurrens = new IDCivisStatusCustodiae[_longitudo];
        }

        public void Initare(int idCivis) {
            _statusCustodiaeCurrens[idCivis] = IDCivisStatusCustodiae.Circumitus;
            IStatusCivisCustodiae circumitus = _tabulaCivisStatusCustodiae.Legere(IDCivisStatusCustodiae.Circumitus);
            circumitus.Initare(idCivis, _abaciCivisStatus);
        }

        public void Ordinare(int idCivis) {
            IDCivisStatusCustodiae idCurrens = _statusCustodiaeCurrens[idCivis];
            IStatusCivisCustodiae currens = _tabulaCivisStatusCustodiae.Legere(idCurrens);

            IDCivisStatusCustodiae idProximus = currens.MutareStatus(idCivis);
            if (idCurrens != idProximus && idProximus != IDCivisStatusCustodiae.Nihil) {
                currens.Exire(idCivis, _abaciCivisStatus);

                idCurrens = idProximus;
                currens = _tabulaCivisStatusCustodiae.Legere(idCurrens);

                currens.Initare(idCivis, _abaciCivisStatus);
            }

            currens.Ordinare(idCivis, _abaciCivisStatus);
        }
    }
}