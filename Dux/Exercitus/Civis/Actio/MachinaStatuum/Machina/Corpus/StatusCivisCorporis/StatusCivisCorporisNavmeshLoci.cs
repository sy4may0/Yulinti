using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using System;
using Yulinti.Nucleus;

namespace Yulinti.Dux.Exercitus {
    internal sealed class StatusCivisCorporisNavmeshLoci : IStatusCivisCorporis {
        private readonly IConfiguratioCivisStatuum _configuratioStatuum;
        private readonly IConfiguratioCivisStatusCorporisNavmesh _configuratio;

        private bool _estMigrare;

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

        public OrdinatioCivisAnimationis Intrare(
            int idCivis,
            ContextusCivisOstiorumLegibile contextusOstiorum,
            IResFluidaCivisLegibile resFluida,
            Action adInitium
        ) {
            _estMigrare = false;
            return new OrdinatioCivisAnimationis(
                idCivis, true, _configuratio.IdAnimationisIntrare, adInitium, null
            );
        }

        public OrdinatioCivisAnimationis Exire(
            int idCivis,
            ContextusCivisOstiorumLegibile contextusOstiorum,
            IResFluidaCivisLegibile resFluida,
            Action adFinem
        ) {
            _estMigrare = false;
            return new OrdinatioCivisAnimationis(
                idCivis, true, _configuratio.IdAnimationisExire, null, adFinem
            );
        }

        public OrdinatioCivisActionis OrdinareActionis(
            int idCivis,
            ContextusCivisOstiorumLegibile contextusOstiorum,
            IResFluidaCivisLegibile resFluida
        ) {
            if (_estMigrare) {
                return OrdinatioCivisActionis.Nihil(idCivis);
            }

            ErrorAut<IPunctumViaeLegibile> punctumViae = contextusOstiorum.PunctumViae.LegoTypumTemere(
                _configuratio.TypusPunctumViae
            );
            if (punctumViae.EstError()) {
                return OrdinatioCivisActionis.Error(idCivis);
            }

            _estMigrare = true;
            return OrdinatioCivisActionis.FromNavmesh(
                idCivis,
                new OrdinatioCivisNavmesh(
                    punctumViae.Evolvo().Positio,
                    _configuratio.VelocitasDesiderata,
                    _configuratio.Acceleratio,
                    _configuratio.VelocitasRotationis,
                    _configuratio.DistantiaDeaccelerationis
                )
            );

        }
        public OrdinatioCivisVeletudinis OrdinareVeletudinis(
            int idCivis,
            ContextusCivisOstiorumLegibile contextusOstiorum,
            IResFluidaCivisLegibile resFluida
        ) {
            return new OrdinatioCivisVeletudinis(
                idCivis,
                -_configuratio.ConsumptioVitae * contextusOstiorum.Temporis.Intervallum
            );
        }
    }
}