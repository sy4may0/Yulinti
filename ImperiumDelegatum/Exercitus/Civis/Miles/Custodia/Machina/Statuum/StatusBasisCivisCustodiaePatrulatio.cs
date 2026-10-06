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

        public abstract IDCivisStatusCustodiae Id { get; }

        protected StatusBasisCivisCustodiaePatrulatio(
            IConfiguratioCivisCustodiaeStatuum configuratio,
            IResFluidaCivisVeletudinisLegibile resFluidaCivisVeletudinis,
            IResFluidaCivisCustodiaeLegibile resFluidaCivisCustodiae,
            IResFluidaPuellaeVeletudinisLegibile resFluidaPuellaeVeletudinis,
            HorologiaCivisStatuumCustodiae horologiaCivisStatuumCustodiae,
            IOstiumCarrusCivis ostiumCarrusCivis
        ) {
            Configuratio = configuratio;
            ResFluidaCivisVeletudinis = resFluidaCivisVeletudinis;
            ResFluidaCivisCustodiae = resFluidaCivisCustodiae;
            ResFluidaPuellaeVeletudinis = resFluidaPuellaeVeletudinis;
            Horologia = horologiaCivisStatuumCustodiae;
            Carrus = ostiumCarrusCivis;
        }

        public abstract void Intrare(int idCivis);

        public abstract void Exire(int idCivis);
        
        
        public virtual void Ordinare(int idCivis) {
            if (!ResFluidaCivisCustodiae.EstVisa(idCivis) && !ResFluidaCivisCustodiae.EstAudita(idCivis)) {
                return;
            }

            float dtSuspecta = InstrumentaCivisSuspectae.ComputareIncrementumSuspectae(
                idCivis,
                Configuratio.IncrementumSuspectaeBasis,
                Configuratio.ConsumptioSuspectaeBasis,
                ResFluidaPuellaeVeletudinis,
                ResFluidaCivisVeletudinis,
                ResFluidaCivisCustodiae,
                Configuratio.LimenAnomaliaeSuspectaeNonNudus
            );

            dtSuspecta = InstrumentaCivisSuspectae.LimitareSuspectae(
                idCivis,
                dtSuspecta,
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