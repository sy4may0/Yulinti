using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class StatusCivisCustodiaeCircumitus : StatusBasisCivisCustodiaePatrulatio {

        public override IDCivisStatusCustodiae Id => IDCivisStatusCustodiae.Circumitus;

        public StatusCivisCustodiaeCircumitus(
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
        }

        public override void Exire(int idCivis) {
        }

        public override void Ordinare(int idCivis) {
            base.Ordinare(idCivis);
        }

        public override IDCivisStatusCustodiae MutareStatus(int idCivis) {
            // Anomalia超過時は即時Discedensにする。
            // なぜVigilantiaにしないかというと、DiscedensではIntentio計算を停止する必要が無いため。
            // Civisのアクション側は以下のようにすること。
            // - Vigilantiaの場合: Vigilantiaステートで発覚アクション、その後Spectansステートで注視アクション。
            // - Discedensの場合: Discedens開始で発覚アクション、その後アクション側の遷移で逃走アクションに移動。
            if (1 - ResFluidaCivisVeletudinis.RatioSuspecta(idCivis) <= Numerus.Epsilon) {

                // Anomalia超過時 -> Discedens
                float anomaliaPuellae = ResFluidaPuellaeVeletudinis.Anomalia;
                if (ResFluidaCivisVeletudinis.EstSpectareNudus(idCivis)) {
                    anomaliaPuellae = ResFluidaPuellaeVeletudinis.AnomaliaNudus;
                }
                if (anomaliaPuellae > ResFluidaCivisVeletudinis.TorelantiaAnomaliaeMaxima(idCivis)) {
                    return IDCivisStatusCustodiae.Discedens;
                }

                return IDCivisStatusCustodiae.Vigilantia;
            }

            return IDCivisStatusCustodiae.Nihil;
        }
    }
}