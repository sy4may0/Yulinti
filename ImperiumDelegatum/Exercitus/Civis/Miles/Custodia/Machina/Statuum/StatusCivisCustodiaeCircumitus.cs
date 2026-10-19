using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class StatusCivisCustodiaeCircumitus : StatusBasisCivisCustodiaePatrulatio {

        public override IDCivisStatusCustodiae Id => IDCivisStatusCustodiae.Circumitus;

        public StatusCivisCustodiaeCircumitus(
            IConfiguratioCivisCustodiaeStatuum configuratio,
            IResFluidaCivisVeletudinisLegibile resFluidaCivisVeletudinis,
            IResFluidaCivisCustodiaeLegibile resFluidaCivisCustodiae,
            IResFluidaPuellaeVeletudinisLegibile resFluidaPuellaeVeletudinis,
            HorologiaCivisStatuumCustodiae horologiaCivisStatuumCustodiae,
            IOstiumCarrusCivisVeletudinis ostiumCarrusCivisVeletudinis,
            IOstiumTemporisLegibile ostiumTemporisLegibile
        ) : base(configuratio, resFluidaCivisVeletudinis, resFluidaCivisCustodiae, resFluidaPuellaeVeletudinis, horologiaCivisStatuumCustodiae, ostiumCarrusCivisVeletudinis, ostiumTemporisLegibile) {
        }

        public override void Intrare(int idCivis) {
            CarrusVeletudinis.PostulareVeletudinisCondicionis(
                idCivis,
                statusCustodiaeCurrens: IDCivisStatusCustodiae.Circumitus
            );
        }

        public override void Exire(int idCivis) {
        }

        public override void Ordinare(int idCivis) {
            base.Ordinare(idCivis);
            PurgereIntentionem(idCivis);
        }

        public override IDCivisStatusCustodiae MutareStatus(int idCivis) {
            // Suspecta 100%到達時、Anomalia超過を視認していればVigilantiaを挟まず即時Discedensにする。
            // - Vigilantia: 発覚アイコンを表示する。アイコン表示中にIntentioゲージが進まないよう、Spectansの前にVigilantiaを挟む。
            // - Discedens: 恐怖アイコンを表示したまま消失まで逃走するため、Vigilantiaは不要。
            if (EstSuspectaPlena(idCivis)) {
                if (EstExcessusAnomaliaeVisae(idCivis)) {
                    return IDCivisStatusCustodiae.Discedens;
                }
                return IDCivisStatusCustodiae.Vigilantia;
            }

            return IDCivisStatusCustodiae.Nihil;
        }
    }
}
