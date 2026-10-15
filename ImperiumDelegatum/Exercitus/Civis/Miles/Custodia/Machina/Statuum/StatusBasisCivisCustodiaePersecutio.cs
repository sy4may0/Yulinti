using Yulinti.ImperiumDelegatum.Contractus;

// Abstract
// Suspecta計算とIntentio計算を行うステートの基底クラス。
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

            float intervallum = Temporis.Intervallum;

            float dtIntentio = InstrumentaCivisIntentionis.ComputareIncrementumIntentionis(
                idCivis,
                Configuratio.IncrementumIntentionisBasis,
                Configuratio.ConsumptioIntentionisDefectusAnomaliaeBasis,
                Configuratio.ConsumptioIntentionisExcessusAnomaliaeBasis,
                ResFluidaPuellaeVeletudinis,
                ResFluidaCivisVeletudinis,
                ResFluidaCivisCustodiae,
                Configuratio.MargoTorelantiaeAnomaliae
            ) * intervallum;

            // 増加 -> 減少に切り替わった直後は一定時間減少させない。
            Horologia.CommutareProhibitionemConsumptionisIntentionis(idCivis, dtIntentio, intervallum);
            if (dtIntentio < 0f && Horologia.EstProhibitioConsumptionisIntentionis(idCivis)) {
                dtIntentio = 0f;
            }

            Carrus.PostulareVeletudinisValoris(
                idCivis,
                dtIntentio: dtIntentio
            );
        }
    }
}
