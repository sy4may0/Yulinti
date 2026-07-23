using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal abstract class StatusCivisCustodiaeAttendens : IStatusCivisCustodiae {
        private readonly IResFluidaCivisVeletudinisLegibile _resFluidaCivisVeletudinis;
        private readonly IResFluidaPuellaeVeletudinisLegibile _resFluidaPuellaeVeletudinis;
        private readonly IResolutorCivisIctuumAuditae _resolutorCivisIctuumAuditae;
        private readonly IResolutorCivisIctuumVisae _resolutorCivisIctuumVisae;
        private readonly IResolutorCivisDistantia _resolutorCivisDistantia;
        private readonly IOstiumCarrusCivis _carrus;
        private readonly IOstiumTemporisLegibile _temporis;
        private readonly IConfiguratioCivisStatusCustodiaeAttendens _configuratio;

        protected IResFluidaCivisVeletudinisLegibile ResFluidaCivisVeletudinis => _resFluidaCivisVeletudinis;
        protected IResFluidaPuellaeVeletudinisLegibile ResFluidaPuellaeVeletudinis => _resFluidaPuellaeVeletudinis;
        protected IResolutorCivisIctuumAuditae ResolutorCivisIctuumAuditae => _resolutorCivisIctuumAuditae;
        protected IResolutorCivisIctuumVisae ResolutorCivisIctuumVisae => _resolutorCivisIctuumVisae;
        protected IResolutorCivisDistantia ResolutorCivisDistantia => _resolutorCivisDistantia;
        protected IOstiumCarrusCivis Carrus => _carrus;
        protected IOstiumTemporisLegibile Temporis => _temporis;
        protected IConfiguratioCivisStatusCustodiaeAttendens ConfiguratioAttendens => _configuratio;

        protected StatusCivisCustodiaeAttendens(
            IResFluidaCivisVeletudinisLegibile resFluidaCivisVeletudinis,
            IResFluidaPuellaeVeletudinisLegibile resFluidaPuellaeVeletudinis,
            IResolutorCivisIctuumAuditae resolutorCivisIctuumAuditae,
            IResolutorCivisIctuumVisae resolutorCivisIctuumVisae,
            IResolutorCivisDistantia resolutorCivisDistantia,
            IOstiumCarrusCivis carrus,
            IOstiumTemporisLegibile temporis,
            IConfiguratioCivisStatusCustodiaeAttendens configuratio
        ) {
            _resFluidaCivisVeletudinis = resFluidaCivisVeletudinis;
            _resFluidaPuellaeVeletudinis = resFluidaPuellaeVeletudinis;
            _resolutorCivisIctuumAuditae = resolutorCivisIctuumAuditae;
            _resolutorCivisIctuumVisae = resolutorCivisIctuumVisae;
            _resolutorCivisDistantia = resolutorCivisDistantia;
            _carrus = carrus;
            _temporis = temporis;
            _configuratio = configuratio;
        }

        public abstract void Initare(int idCivis, AbaciCivisStatus abaciCivisStatus);
        public abstract void Exire(int idCivis, AbaciCivisStatus abaciCivisStatus);

        public virtual void Ordinare(int idCivis, AbaciCivisStatus abaciCivisStatus) {
            float dtSuspecta = ResolvereSuspectam(idCivis, abaciCivisStatus);
            Carrus.PostulareVeletudinisValoris(
                idCivis,
                dtSuspecta: RestringereSuspectam(idCivis, dtSuspecta)
            );
        }
        
        protected float RestringereSuspectam(int idCivis, float dtSuspecta) {
            float rs = ResFluidaCivisVeletudinis.Suspecta(idCivis) + dtSuspecta;
            float anomalia = ResolutorCivisStatus.CorrigereAnomaliae(
                ResFluidaPuellaeVeletudinis,
                ResFluidaCivisVeletudinis,
                idCivis
            );

            if (dtSuspecta <= 0) {
                return dtSuspecta;
            }

            // Nihil Anomariae
            if (anomalia <= 0) {
                if (rs > _configuratio.SuspectaMaximaNihilAnomaliae) {
                    return _configuratio.SuspectaMaximaNihilAnomaliae - ResFluidaCivisVeletudinis.Suspecta(idCivis);
                }
            }

            // Auditae Solus
            if (!ResolutorCivisDistantia.EstCustodiaeVisae(idCivis) || !ResolutorCivisIctuumVisae.EstVisa(idCivis)) {
                if (rs > _configuratio.SuspectaMaximaAuditaeSolus) {
                    return _configuratio.SuspectaMaximaAuditaeSolus - ResFluidaCivisVeletudinis.Suspecta(idCivis);
                }
            }

            // Anomaliae Deest
            if (anomalia <= _configuratio.AnomaliaeMinimaAdVigilantiam) {
                if (rs > _configuratio.SuspectaMaximaAnomaliaeDeest) {
                    return _configuratio.SuspectaMaximaAnomaliaeDeest - ResFluidaCivisVeletudinis.Suspecta(idCivis);
                }
            }

            return dtSuspecta;
        }

        // Visa/Auditaを統合したSuspecta(疑心度)の増減を解決する。
        // 視覚刺激・聴覚刺激のいずれかがあれば上昇し、両方無ければ減衰する。
        // 「音か視覚か」「振り向くか注視か」はSuspecta値と瞬間の視認boolで判断するため、
        // ここでは蓄積は単一のSuspectaに集約する。
        protected float ResolvereSuspectam(int idCivis, AbaciCivisStatus abaciCivisStatus) {
            bool estAugereVisae = (
                ResolutorCivisDistantia.EstCustodiaeVisae(idCivis) &&
                ResolutorCivisIctuumVisae.EstVisa(idCivis)
            );
            bool estAugereAuditae = (
                ResolutorCivisDistantia.EstCustodiaeAuditae(idCivis) &&
                ResolutorCivisIctuumAuditae.EstAudita(idCivis)
            );
            bool estAugere = estAugereVisae || estAugereAuditae;

            abaciCivisStatus.ResolvereDirectionemSuspectae(idCivis, estAugere, Temporis.Intervallum);

            if (estAugere) {
                float dtSuspecta = 0f;

                if (estAugereVisae) {
                    dtSuspecta += ResolutorCivisStatus.AugereSuspectaeVisae(
                        _configuratio.AugmentumSuspectaeVisaeSec,
                        ResolutorCivisIctuumVisae.RatioVisus(idCivis),
                        ResFluidaCivisVeletudinis.RatioVisus(idCivis),
                        ResFluidaPuellaeVeletudinis.RatioClaritas,
                        abaciCivisStatus.StudiumHabereSuspectae(idCivis),
                        Temporis.Intervallum
                    );
                }

                if (estAugereAuditae) {
                    dtSuspecta += ResolutorCivisStatus.AugereSuspectaeAuditae(
                        _configuratio.AugmentumSuspectaeAuditaeSec,
                        ResFluidaCivisVeletudinis.Auditus(idCivis),
                        ResolutorCivisIctuumAuditae.Audita(idCivis),
                        abaciCivisStatus.StudiumHabereSuspectae(idCivis),
                        Temporis.Intervallum
                    );
                }

                return dtSuspecta;
            }

            return -ResolutorCivisStatus.DeminuereSuspectam(
                _configuratio.DeminutioSuspectaeSec,
                abaciCivisStatus.StudiumAmittereSuspectae(idCivis),
                Temporis.Intervallum
            );
        }

        public abstract IDCivisStatusCustodiae MutareStatus(int idCivis);
    }
}
