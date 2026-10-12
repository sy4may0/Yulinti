using Yulinti.ImperiumDelegatum.Contractus;

// Abstruct
// Spectans計算のみ行うステート状態の基底クラス。
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
    }
}
