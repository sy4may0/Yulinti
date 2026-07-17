using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using System;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class StatusCivisCustodiaeSpectans : StatusCivisCustodiaeIntuitus {
        public StatusCivisCustodiaeSpectans(
            IResFluidaCivisVeletudinisLegibile resFluidaCivisVeletudinis,
            IResFluidaPuellaeVeletudinisLegibile resFluidaPuellaeVeletudinis,
            IResolutorCivisIctuumAuditae resolutorCivisIctuumAuditae,
            IResolutorCivisIctuumVisae resolutorCivisIctuumVisae,
            IResolutorCivisDistantia resolutorCivisDistantia,
            IOstiumCarrusCivis carrus,
            IOstiumTemporisLegibile temporis,
            IConfiguratioCivisStatusCustodiaeSpectans configuratio
        ) : base(
            resFluidaCivisVeletudinis,
            resFluidaPuellaeVeletudinis,
            resolutorCivisIctuumAuditae,
            resolutorCivisIctuumVisae,
            resolutorCivisDistantia,
            carrus,
            temporis,
            configuratio
        ) {
        }

        public override void Initare(int idCivis, AbaciCivisStatus abaciCivisStatus) {
            // Intuitus起点
            Carrus.PostulareVeletudinisValoris(
                idCivis,
                dtSuspecta: 1.0f,
                dtStudium: 1.0f,
                dtIntentio: -1.0f
            );
            abaciCivisStatus.PurgereIntentionis(idCivis);
            abaciCivisStatus.PurgereStudii(idCivis);
        }

        public override void Exire(int idCivis, AbaciCivisStatus abaciCivisStatus) {
        }

        public override void Ordinare(int idCivis, AbaciCivisStatus abaciCivisStatus) {
            base.Ordinare(idCivis, abaciCivisStatus);
        }

        public override IDCivisStatusCustodiae MutareStatus(int idCivis) {
            IDCivisStatusCustodiae status = base.MutareStatus(idCivis);
            if (status != IDCivisStatusCustodiae.Nihil) {
                return status;
            }

            if (ResFluidaCivisVeletudinis.Intentio(idCivis) >= 0.5f) {
                return IDCivisStatusCustodiae.Sequens;
            }

            return IDCivisStatusCustodiae.Nihil;
        }
    }
}