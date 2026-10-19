using Yulinti.ImperiumDelegatum.Contractus;
using System;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    // ステートはidCivisを引数で受け取るステートレスな実装のため、全Civisで1インスタンスを共有する。
    internal sealed class MachinaCivisStatuumCustodiae {
        private readonly HorologiaCivisStatuumCustodiae _horologiaCivisStatuumCustodiae;
        private readonly HorologiaCivisStatuumCustodiaeMutationis _horologiaCivisStatuumCustodiaeMutationis;
        private readonly TabulaCivisStatusCustodiae _tabulaCivisStatusCustodiae;

        private readonly IDCivisStatusCustodiae[] _statusCurrens;

        public MachinaCivisStatuumCustodiae(
            int longitudoCivis,
            IConfiguratioCivisCustodiaeStatuum configuratio,
            IResFluidaCivisLegibile resFCivis,
            IResFluidaPuellaeLegibile resFPuellae,
            IOstiumCarrusCivisVeletudinis carrus,
            IOstiumTemporisLegibile temporis,
            Random random
        ) {
            _horologiaCivisStatuumCustodiae = new HorologiaCivisStatuumCustodiae(
                longitudoCivis, configuratio, random
            );
            _horologiaCivisStatuumCustodiaeMutationis = new HorologiaCivisStatuumCustodiaeMutationis(
                longitudoCivis, configuratio, random
            );
            _tabulaCivisStatusCustodiae = new TabulaCivisStatusCustodiae(
                configuratio,
                resFCivis.Veletudinis,
                resFCivis.Custodiae,
                resFPuellae.Veletudinis,
                _horologiaCivisStatuumCustodiae,
                carrus,
                temporis,
                _horologiaCivisStatuumCustodiaeMutationis
            );

            _statusCurrens = new IDCivisStatusCustodiae[longitudoCivis];
            for (int i = 0; i < longitudoCivis; i++) {
                _statusCurrens[i] = IDCivisStatusCustodiae.Nihil;
            }
        }

        public IDCivisStatusCustodiae StatusCurrens(int idCivis) => _statusCurrens[idCivis];

        public void Initare(int idCivis) {
            _horologiaCivisStatuumCustodiae.PurgereOmnia(idCivis);
            _horologiaCivisStatuumCustodiaeMutationis.PurgereOmnia(idCivis);

            _statusCurrens[idCivis] = IDCivisStatusCustodiae.Circumitus;
            _tabulaCivisStatusCustodiae.Legere(IDCivisStatusCustodiae.Circumitus).Intrare(idCivis);
        }

        public void Ordinare(int idCivis) {
            // Initare前は何もしない。
            if (_statusCurrens[idCivis] == IDCivisStatusCustodiae.Nihil) {
                return;
            }

            IStatusCivisCustodiae statusCurrens = _tabulaCivisStatusCustodiae.Legere(_statusCurrens[idCivis]);

            IDCivisStatusCustodiae idProximus = statusCurrens.MutareStatus(idCivis);
            if (idProximus != IDCivisStatusCustodiae.Nihil && idProximus != _statusCurrens[idCivis]) {
                statusCurrens = Mutare(idCivis, statusCurrens, idProximus);
            }

            statusCurrens.Ordinare(idCivis);
        }

        private IStatusCivisCustodiae Mutare(
            int idCivis, IStatusCivisCustodiae statusPrior, IDCivisStatusCustodiae idProximus
        ) {
            IStatusCivisCustodiae statusProximus = _tabulaCivisStatusCustodiae.Legere(idProximus);

            statusPrior.Exire(idCivis);
            _statusCurrens[idCivis] = idProximus;
            statusProximus.Intrare(idCivis);

            return statusProximus;
        }
    }
}
