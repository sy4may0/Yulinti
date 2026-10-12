using Yulinti.ImperiumDelegatum.Contractus;

// Abstract
// Spectans計算とIntentio計算を行うステート状態の基底クラス。
namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal abstract class StatusBasisCivisCustodiaePersecutio : StatusBasisCivisCustodiaePatrulatio {
        protected StatusBasisCivisCustodiaePersecutio(
            IConfiguratioCivisCustodiaeStatuum configuratio,
            IResFluidaCivisVeletudinisLegibile resFluidaCivisVeletudinis,
            IResFluidaCivisCustodiaeLegibile resFluidaCivisCustodiae,
            IResFluidaPuellaeVeletudinisLegibile resFluidaPuellaeVeletudinis,
            HorologiaCivisStatuumCustodiae horologiaCivisStatuumCustodiae,
            IOstiumCarrusCivis ostiumCarrusCivis,
            IOstiumTemporisLegibile ostiumTemporisLegibile
        ) : base(
            configuratio,
            resFluidaCivisVeletudinis,
            resFluidaCivisCustodiae,
            resFluidaPuellaeVeletudinis,
            horologiaCivisStatuumCustodiae,
            ostiumCarrusCivis,
            ostiumTemporisLegibile
        ) {
        }

        public override void Ordinare(int idCivis) {
            base.Ordinare(idCivis);

            float dtIntentio = InstrumentaCivisIntentionis.ComputareIncrementumIntentionis(
                idCivis,
                Configuratio.IncrementumIntentionisBasis,
                Configuratio.ConsumptioIntentionisDefectusAnomaliaeBasis,
                Configuratio.ConsumptioIntentionisExcessusAnomaliaeBasis,
                ResFluidaPuellaeVeletudinis,
                ResFluidaCivisVeletudinis,
                ResFluidaCivisCustodiae,
                Configuratio.MargoTorelantiaeAnomaliae
            ) * Temporis.Intervallum;

            Carrus.PostulareVeletudinisValoris(
                idCivis,
                dtIntentio: dtIntentio
            );
        }
    }
}
