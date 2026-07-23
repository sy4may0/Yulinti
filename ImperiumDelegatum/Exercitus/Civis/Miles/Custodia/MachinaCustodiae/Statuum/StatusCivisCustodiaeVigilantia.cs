using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class StatusCivisCustodiaeVigilantia : IStatusCivisCustodiae {
        private readonly IOstiumCarrusCivis _carrus;
        private readonly IOstiumTemporisLegibile _temporis;
        private readonly IResFluidaCivisVeletudinisLegibile _resFluidaCivisVeletudinis;
        private readonly IConfiguratioCivisStatusCustodiaeVigilantia _configuratio;

        public StatusCivisCustodiaeVigilantia(
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
            _carrus.PostulareVeletudinisCondicionis(
                idCivis,
                statusCustodiaeCurrens: IDCivisStatusCustodiae.Vigilantia
            );
            _carrus.PostulareVeletudinisValoris(
                idCivis,
                dtSuspecta: _resFluidaCivisVeletudinis.SuspectaMaxima(idCivis),
                dtStudium: _resFluidaCivisVeletudinis.StudiumMaxima(idCivis),
                dtIntentio: -_resFluidaCivisVeletudinis.IntentioMaxima(idCivis)
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
                dtSuspecta: _resFluidaCivisVeletudinis.SuspectaMaxima(idCivis),
                dtIntentio: -_resFluidaCivisVeletudinis.IntentioMaxima(idCivis)
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