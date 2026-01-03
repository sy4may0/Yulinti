using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
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

        public OrdinatioCivis Intrare(
            int idCivis,
            ContextusCivisOstiorumLegibile contextusOstiorum,
            IResFluidaCivisLegibile resFluida,
            Action adInitium
        ) {
            OrdinatioCivisAnimationis animationis = new OrdinatioCivisAnimationis(
                idCivis, true, _configuratio.IdAnimationisIntrare, adInitium, null
            );

            ErrorAut<IPunctumViaeLegibile> punctumViae = contextusOstiorum.PunctumViae.LegoTypumTemere(
                _configuratio.TypusPunctumViae
            );
            if (punctumViae.EstError()) {
                OrdinatioCivisVeletudinisMortis mortis = new OrdinatioCivisVeletudinisMortis(
                    idCivis, estSpirituare: true
                );
                return new OrdinatioCivis(
                    idCivis, veletudinisMortis: mortis
                );
            }

            OrdinatioCivisActionis navmesh = OrdinatioCivisActionis.FromNavmesh(
                idCivis,
                new OrdinatioCivisNavmesh(
                    punctumViae.Evolvo().Positio,
                    _configuratio.VelocitasDesiderata,
                    _configuratio.Acceleratio,
                    _configuratio.VelocitasRotationis,
                    _configuratio.DistantiaDeaccelerationis
                )
            );

            return new OrdinatioCivis(
                idCivis, animationis: animationis, actionis: navmesh
            );
        }

        public OrdinatioCivis Exire(
            int idCivis,
            ContextusCivisOstiorumLegibile contextusOstiorum,
            IResFluidaCivisLegibile resFluida,
            Action adFinem
        ) {
            OrdinatioCivisAnimationis animationis = new OrdinatioCivisAnimationis(
                idCivis, false, _configuratio.IdAnimationisExire, null, adFinem
            );
            return new OrdinatioCivis(
                idCivis, animationis: animationis
            );
        }

        public OrdinatioCivis Ordinare(
            int idCivis,
            ContextusCivisOstiorumLegibile contextusOstiorum,
            IResFluidaCivisLegibile resFluida
        ) {
            OrdinatioCivisVeletudinisValoris veletudinis = new OrdinatioCivisVeletudinisValoris(
                idCivis,
                -_configuratio.ConsumptioVitae * contextusOstiorum.Temporis.Intervallum
            );
            return new OrdinatioCivis(
                idCivis, veletudinisValoris: veletudinis
            );
        }
    }
}