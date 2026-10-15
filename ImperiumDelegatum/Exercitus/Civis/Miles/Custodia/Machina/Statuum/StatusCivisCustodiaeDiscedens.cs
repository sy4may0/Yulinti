using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class StatusCivisCustodiaeDiscedens : StatusBasisCivisCustodiaePatrulatio {

        public override IDCivisStatusCustodiae Id => IDCivisStatusCustodiae.Discedens;

        public StatusCivisCustodiaeDiscedens(
            IConfiguratioCivisCustodiaeStatuum configuratio,
            IResFluidaCivisVeletudinisLegibile resFluidaCivisVeletudinis,
            IResFluidaCivisCustodiaeLegibile resFluidaCivisCustodiae,
            IResFluidaPuellaeVeletudinisLegibile resFluidaPuellaeVeletudinis,
            HorologiaCivisStatuumCustodiae horologiaCivisStatuumCustodiae,
            IOstiumCarrusCivis ostiumCarrusCivis,
            IOstiumTemporisLegibile ostiumTemporisLegibile
        ) : base(configuratio, resFluidaCivisVeletudinis, resFluidaCivisCustodiae, resFluidaPuellaeVeletudinis, horologiaCivisStatuumCustodiae, ostiumCarrusCivis, ostiumTemporisLegibile) {
        }

        public override void Intrare(int idCivis) {
            Carrus.PostulareVeletudinisCondicionis(
                idCivis,
                statusCustodiaeCurrens: IDCivisStatusCustodiae.Discedens
            );
        }

        public override void Exire(int idCivis) {
        }

        public override void Ordinare(int idCivis) {
            float dtSuspecta = -Configuratio.ConsumptioSuspectaeBasis * Temporis.Intervallum;
            Carrus.PostulareVeletudinisValoris(
                idCivis,
                dtSuspecta: dtSuspecta
            );
            PurgereIntentionem(idCivis);
        }

        public override IDCivisStatusCustodiae MutareStatus(int idCivis) {
            // 終端ステート。
            // Discedensに入ったらActioステートをSuicidumにしてデスポーンすること。
            return IDCivisStatusCustodiae.Nihil;
        }
    }
}