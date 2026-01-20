using Yulinti.Dux.ContractusDucis;
using System;
using Yulinti.Nucleus;

namespace Yulinti.Dux.Exercitus {
    internal sealed class StatusCivisCorporisNavmeshLoci : IStatusCivisCorporis {
        private readonly IConfiguratioCivisStatuum _configuratioStatuum;
        private readonly IConfiguratioCivisStatusCorporisNavmesh _configuratio;

        public StatusCivisCorporisNavmeshLoci(
            IConfiguratioCivisStatuum configuratioStatuum,
            IConfiguratioCivisStatusCorporisNavmesh configuratio
        ) {
            _configuratioStatuum = configuratioStatuum;
            _configuratio = configuratio;
        }

        public IDCivisStatusCorporis Id => _configuratio.Id;
        public IDCivisStatusCorporisModiNavmesh IdModiNavmesh => _configuratio.IdModiNavmesh;
        public IDCivisAnimationisContinuata IdAnimationisIntrare => _configuratio.IdAnimationisIntrare;
        public IDCivisAnimationisContinuata IdAnimationisExire => _configuratio.IdAnimationisExire;

        public void Intrare(
            int idCivis,
            ContextusCivisOstiorumLegibile contextusOstiorum,
            IResFluidaCivisLegibile resFluida,
            Action adInitium
        ) {
            contextusOstiorum.Carrus.PostulareAnimationis(
                idCivis, _configuratio.IdAnimationisIntrare, adInitium, null, false
            );

            ErrorAut<IPunctumViaeLegibile> punctumViae = contextusOstiorum.PunctumViae.LegoTypumTemere(
                _configuratio.TypusPunctumViae
            );
            if (punctumViae.EstError()) {
                contextusOstiorum.Carrus.PostulareMortis(
                    idCivis, SpeciesOrdinationisCivisMortis.Spirituare
                );
            }

            contextusOstiorum.Carrus.PostulareNavmesh(
                idCivis,
                punctumViae.Evolvo().Positio,
                false,
                _configuratio.VelocitasDesiderata,
                _configuratio.Acceleratio,
                _configuratio.VelocitasRotationis,
                _configuratio.DistantiaDeaccelerationis
            );
        }

        public void Exire(
            int idCivis,
            ContextusCivisOstiorumLegibile contextusOstiorum,
            IResFluidaCivisLegibile resFluida,
            Action adFinem
        ) {
            contextusOstiorum.Carrus.PostulareAnimationis(
                idCivis, _configuratio.IdAnimationisExire, null, adFinem, false
            );
        }

        public void Ordinare(
            int idCivis,
            ContextusCivisOstiorumLegibile contextusOstiorum,
            IResFluidaCivisLegibile resFluida
        ) {
            // 直近のTransporto失敗時はNPCを削除する。
            if (contextusOstiorum.Loci.EstErrans(idCivis)) {
                contextusOstiorum.Carrus.PostulareMortis(
                    idCivis, SpeciesOrdinationisCivisMortis.Spirituare
                );
                return;
            }
            contextusOstiorum.Carrus.PostulareVeletudinisValoris(
                idCivis,
                dtVitae: -_configuratio.ConsumptioVitae * contextusOstiorum.Temporis.Intervallum,
                dtVisus: _configuratio.Visus
            );
        }
    }
}