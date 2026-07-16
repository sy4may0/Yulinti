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

        protected IResFluidaCivisVeletudinisLegibile ResFluidaCivisVeletudinis => _resFluidaCivisVeletudinis;
        protected IResFluidaPuellaeVeletudinisLegibile ResFluidaPuellaeVeletudinis => _resFluidaPuellaeVeletudinis;
        protected IResolutorCivisIctuumAuditae ResolutorCivisIctuumAuditae => _resolutorCivisIctuumAuditae;
        protected IResolutorCivisIctuumVisae ResolutorCivisIctuumVisae => _resolutorCivisIctuumVisae;
        protected IResolutorCivisDistantia ResolutorCivisDistantia => _resolutorCivisDistantia;
        protected IOstiumCarrusCivis Carrus => _carrus;
        protected IOstiumTemporisLegibile Temporis => _temporis;

        // 後で設定に移行する。
        // Suspecta(疑心度)への上昇量。視覚刺激と聴覚刺激で別レート、視覚のほうが速い。
        private readonly float _augmentumSuspectaeVisaeSec = 0.02f;
        private readonly float _augmentumSuspectaeAuditaeSec = 0.01f;
        private readonly float _deminutioSuspectaeSec = 0.01f;

        protected StatusCivisCustodiaeAttendens(
            IResFluidaCivisVeletudinisLegibile resFluidaCivisVeletudinis,
            IResFluidaPuellaeVeletudinisLegibile resFluidaPuellaeVeletudinis,
            IResolutorCivisIctuumAuditae resolutorCivisIctuumAuditae,
            IResolutorCivisIctuumVisae resolutorCivisIctuumVisae,
            IResolutorCivisDistantia resolutorCivisDistantia,
            IOstiumCarrusCivis carrus,
            IOstiumTemporisLegibile temporis
        ) {
            _resFluidaCivisVeletudinis = resFluidaCivisVeletudinis;
            _resFluidaPuellaeVeletudinis = resFluidaPuellaeVeletudinis;
            _resolutorCivisIctuumAuditae = resolutorCivisIctuumAuditae;
            _resolutorCivisIctuumVisae = resolutorCivisIctuumVisae;
            _resolutorCivisDistantia = resolutorCivisDistantia;
            _carrus = carrus;
            _temporis = temporis;
        }

        public abstract void Initare(int idCivis, AbaciCivisStatus abaciCivisStatus);
        public abstract void Exire(int idCivis, AbaciCivisStatus abaciCivisStatus);

        public virtual void Ordinare(int idCivis, AbaciCivisStatus abaciCivisStatus) {
            Carrus.PostulareVeletudinisValoris(
                idCivis,
                dtSuspecta: ResolvereSuspectam(idCivis, abaciCivisStatus)
            );
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
                        _augmentumSuspectaeVisaeSec,
                        ResolutorCivisIctuumVisae.RatioVisus(idCivis),
                        ResFluidaCivisVeletudinis.RatioVisus(idCivis),
                        ResFluidaPuellaeVeletudinis.RatioClaritas,
                        ResFluidaPuellaeVeletudinis.RatioAnomaliae,
                        abaciCivisStatus.StudiumHabereSuspectae(idCivis),
                        Temporis.Intervallum
                    );
                }

                if (estAugereAuditae) {
                    dtSuspecta += ResolutorCivisStatus.AugereSuspectaeAuditae(
                        _augmentumSuspectaeAuditaeSec,
                        ResFluidaCivisVeletudinis.Auditus(idCivis),
                        ResolutorCivisIctuumAuditae.Audita(idCivis),
                        abaciCivisStatus.StudiumHabereSuspectae(idCivis),
                        Temporis.Intervallum
                    );
                }

                return dtSuspecta;
            }

            return -ResolutorCivisStatus.DeminuereSuspectam(
                _deminutioSuspectaeSec,
                abaciCivisStatus.StudiumAmittereSuspectae(idCivis),
                Temporis.Intervallum
            );
        }
    }
}
