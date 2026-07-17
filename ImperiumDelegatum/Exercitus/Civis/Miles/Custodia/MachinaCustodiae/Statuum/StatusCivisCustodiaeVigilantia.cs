using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using System;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class StatusCivisCustodiaeVigilantia : IStatusCivisCustodiae {
        private readonly IOstiumCarrusCivis _carrus;
        private readonly IOstiumTemporisLegibile _temporis;
        private readonly IResFluidaCivisVeletudinisLegibile _resFluidaCivisVeletudinis;
        private readonly IConfiguratioCivisStatusCustodiaeVigilantia _configuratio;

        public StatusCivisCustodiaeVigilantia(
            IOstiumCivisLegibile civis,
            IOstiumCarrusCivis carrus,
            IOstiumTemporisLegibile temporis,
            IResFluidaCivisVeletudinisLegibile resFluidaCivisVeletudinis,
            IConfiguratioCivisStatusCustodiaeVigilantia configuratio
        ) {
            _carrus = carrus;
            _temporis = temporis;
            _resFluidaCivisVeletudinis = resFluidaCivisVeletudinis;
            _configuratio = configuratio;
        }

        public void Initare(int idCivis, AbaciCivisStatus abaciCivisStatus) {
            _carrus.PostulareVeletudinisValoris(
                idCivis,
                dtSuspecta: 1.0f,
                dtStudium: 1.0f,
                dtIntentio: -1.0f
            );
            abaciCivisStatus.PurgereIntentionis(idCivis);
            abaciCivisStatus.PurgereStudii(idCivis);
        }

        public void Exire(int idCivis, AbaciCivisStatus abaciCivisStatus) {
        }

        public void Ordinare(int idCivis, AbaciCivisStatus abaciCivisStatus) {
            // Intuitusステートに向かうため、Studiumを減らす。(Studium0でSpectansステートになる)
            // Suspectaは常に1, Intentioは常に-1固定。
            _carrus.PostulareVeletudinisValoris(
                idCivis,
                dtStudium: -_configuratio.DeminutioStudiumAdIntuitusSec * _temporis.Intervallum,
                dtSuspecta: 1.0f,
                dtIntentio: -1.0f
            );
        }

        public IDCivisStatusCustodiae MutareStatus(int idCivis) {
            if (_resFluidaCivisVeletudinis.Studium(idCivis) <= 0.0f) {
                return IDCivisStatusCustodiae.Spectans;
            }
            return IDCivisStatusCustodiae.Nihil;
        }
    } 
}