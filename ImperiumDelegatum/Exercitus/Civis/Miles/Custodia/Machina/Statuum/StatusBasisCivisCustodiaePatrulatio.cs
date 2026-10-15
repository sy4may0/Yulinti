using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Contractus;

// Abstract
// Suspecta計算のみ行うステートの基底クラス。
namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal abstract class StatusBasisCivisCustodiaePatrulatio : IStatusCivisCustodiae {
        protected readonly IConfiguratioCivisCustodiaeStatuum Configuratio;
        protected readonly IResFluidaCivisVeletudinisLegibile ResFluidaCivisVeletudinis;
        protected readonly IResFluidaCivisCustodiaeLegibile ResFluidaCivisCustodiae;
        protected readonly IResFluidaPuellaeVeletudinisLegibile ResFluidaPuellaeVeletudinis;
        protected readonly HorologiaCivisStatuumCustodiae Horologia;
        protected readonly IOstiumCarrusCivis Carrus;
        protected readonly IOstiumTemporisLegibile Temporis;

        public abstract IDCivisStatusCustodiae Id { get; }

        protected StatusBasisCivisCustodiaePatrulatio(
            IConfiguratioCivisCustodiaeStatuum configuratio,
            IResFluidaCivisVeletudinisLegibile resFluidaCivisVeletudinis,
            IResFluidaCivisCustodiaeLegibile resFluidaCivisCustodiae,
            IResFluidaPuellaeVeletudinisLegibile resFluidaPuellaeVeletudinis,
            HorologiaCivisStatuumCustodiae horologiaCivisStatuumCustodiae,
            IOstiumCarrusCivis ostiumCarrusCivis,
            IOstiumTemporisLegibile ostiumTemporisLegibile
        ) {
            Configuratio = configuratio;
            ResFluidaCivisVeletudinis = resFluidaCivisVeletudinis;
            ResFluidaCivisCustodiae = resFluidaCivisCustodiae;
            ResFluidaPuellaeVeletudinis = resFluidaPuellaeVeletudinis;
            Horologia = horologiaCivisStatuumCustodiae;
            Carrus = ostiumCarrusCivis;
            Temporis = ostiumTemporisLegibile;
        }

        public abstract void Intrare(int idCivis);

        public abstract void Exire(int idCivis);

        public virtual void Ordinare(int idCivis) {
            float intervallum = Temporis.Intervallum;

            float dtSuspecta = InstrumentaCivisSuspectae.ComputareIncrementumSuspectae(
                idCivis,
                Configuratio.IncrementumSuspectaeBasis,
                Configuratio.ConsumptioSuspectaeBasis,
                ResFluidaPuellaeVeletudinis,
                ResFluidaCivisVeletudinis,
                ResFluidaCivisCustodiae,
                Configuratio.LimenAnomaliaeSuspectaeNonNudus
            ) * intervallum;

            // 増加 -> 減少に切り替わった直後は一定時間減少させない。
            Horologia.CommutareProhibitionemConsumptionisSuspectae(idCivis, dtSuspecta, intervallum);
            if (dtSuspecta < 0f && Horologia.EstProhibitioConsumptionisSuspectae(idCivis)) {
                dtSuspecta = 0f;
            }

            dtSuspecta = InstrumentaCivisSuspectae.LimitareSuspectae(
                idCivis,
                dtSuspecta,
                Configuratio.ConsumptioSuspectaeBasis * intervallum,
                Configuratio.LimitatioSuspectaeAuditae,
                Configuratio.LimitatioSuspectaeNonNudus,
                ResFluidaCivisVeletudinis,
                ResFluidaCivisCustodiae
            );

            Carrus.PostulareVeletudinisValoris(
                idCivis,
                dtSuspecta: dtSuspecta
            );
        }

        public abstract IDCivisStatusCustodiae MutareStatus(int idCivis);

        // Intentioを計算しないステートはOrdinareから毎フレーム呼び、Intentioを0に保つこと。
        protected void PurgereIntentionem(int idCivis) {
            float intentio = ResFluidaCivisVeletudinis.Intentio(idCivis);
            if (intentio <= Numerus.Epsilon) {
                return;
            }
            Carrus.PostulareVeletudinisValoris(
                idCivis,
                dtIntentio: -intentio
            );
        }

        protected bool EstSuspectaPlena(int idCivis) {
            return 1 - ResFluidaCivisVeletudinis.RatioSuspecta(idCivis) <= Numerus.Epsilon;
        }

        // Anomalia超過を視認したかどうか。NudusとしてみなすかはCivisの視認状態を規準とする。
        protected bool EstExcessusAnomaliaeVisae(int idCivis) {
            if (!ResFluidaCivisCustodiae.EstVisa(idCivis)) {
                return false;
            }

            float anomaliaPuellae = ResFluidaCivisVeletudinis.EstSpectareNudus(idCivis)
                ? ResFluidaPuellaeVeletudinis.AnomaliaNudus
                : ResFluidaPuellaeVeletudinis.Anomalia;

            return anomaliaPuellae > ResFluidaCivisVeletudinis.TorelantiaAnomaliaeMaxima(idCivis);
        }
    }
}
