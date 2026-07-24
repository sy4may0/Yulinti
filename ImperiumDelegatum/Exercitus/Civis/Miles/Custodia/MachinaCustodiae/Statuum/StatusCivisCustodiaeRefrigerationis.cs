using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class StatusCivisCustodiaeRefrigerationis : StatusCivisCustodiaeAttendens {
        private readonly IConfiguratioCivisCustodiaeStatusRefrigerationis _configuratio;

        public StatusCivisCustodiaeRefrigerationis(
            IResFluidaCivisVeletudinisLegibile resFluidaCivisVeletudinis,
            IResFluidaPuellaeVeletudinisLegibile resFluidaPuellaeVeletudinis,
            IOstiumCivisLegibile civis,
            IResFluidaCivisCustodiaeLegibile resFluidaCivisCustodiae,
            IOstiumCarrusCivis carrus,
            IOstiumTemporisLegibile temporis,
            IConfiguratioCivisCustodiaeStatusRefrigerationis configuratio
        ) : base(
            resFluidaCivisVeletudinis,
            resFluidaPuellaeVeletudinis,
            resFluidaCivisCustodiae,
            carrus,
            temporis,
            configuratio
        ) {
            _configuratio = configuratio;
        }

        public override void Initare(int idCivis, AbaciCivisStatus abaciCivisStatus) {
            Carrus.PostulareVeletudinisCondicionis(
                idCivis,
                statusCustodiaeCurrens: IDCivisStatusCustodiae.Refrigeratio
            );
            // Refrigerationis起点
            Carrus.PostulareVeletudinisValoris(
                idCivis,
                dtSuspecta: -ResFluidaCivisVeletudinis.SuspectaMaxima(idCivis),
                dtStudium: ResFluidaCivisVeletudinis.StudiumMaxima(idCivis),
                dtIntentio: -ResFluidaCivisVeletudinis.IntentioMaxima(idCivis)
            );
            abaciCivisStatus.Purgere(idCivis);
        }

        public override void Exire(int idCivis, AbaciCivisStatus abaciCivisStatus) {
        }

        public override void Ordinare(int idCivis, AbaciCivisStatus abaciCivisStatus) {
            base.Ordinare(idCivis, abaciCivisStatus);

            Carrus.PostulareVeletudinisValoris(
                idCivis,
                dtStudium: -_configuratio.DeminutioStudiumAdRefrigerationemSec * Temporis.Intervallum
            );
        }

        public override IDCivisStatusCustodiae MutareStatus(int idCivis) {
            // 距離が上限に達したら解除
            if (ResFluidaCivisCustodiae.DistantiaPuellae(idCivis) > _configuratio.DistantiaRefrigerationis) {
                return IDCivisStatusCustodiae.Circumitus;
            }

            // 一定時間で解除
            if (ResFluidaCivisVeletudinis.Studium(idCivis) <= 0) {
                return IDCivisStatusCustodiae.Circumitus;
            }

            // 再発覚でSequens
            if (ResFluidaCivisVeletudinis.Suspecta(idCivis) >= ResFluidaCivisVeletudinis.SuspectaMaxima(idCivis)) {
                return IDCivisStatusCustodiae.Sequens;
            }

            return IDCivisStatusCustodiae.Nihil;
        }
    }
}
