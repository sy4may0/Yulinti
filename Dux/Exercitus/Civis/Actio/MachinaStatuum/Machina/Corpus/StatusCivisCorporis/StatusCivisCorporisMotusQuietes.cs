using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using System;

namespace Yulinti.Dux.Exercitus {
    internal sealed class StatusCivisCorporisMotusQuietes : IStatusCivisCorporis {
        private readonly IConfiguratioCivisStatuum _configuratioStatuum;
        private readonly IConfiguratioCivisStatusCorporisMotus _configuratio;

        public StatusCivisCorporisMotusQuietes(
            IConfiguratioCivisStatuum configuratioStatuum,
            IConfiguratioCivisStatusCorporisMotus configuratio
        ) {
            _configuratioStatuum = configuratioStatuum;
            _configuratio = configuratio;
        }

        public IDCivisStatusCorporis Id => _configuratio.Id;
        public IDCivisStatusCorporisModiMotus IdModiMotus => _configuratio.IdModiMotus;
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
            return new OrdinatioCivis(
                idCivis, animationis: animationis
            );
        }

        public OrdinatioCivis Exire(
            int idCivis,
            ContextusCivisOstiorumLegibile contextusOstiorum,
            IResFluidaCivisLegibile resFluida,
            Action adFinem
        ) {
            OrdinatioCivisAnimationis animationis = new OrdinatioCivisAnimationis(
                idCivis, false, IDCivisAnimationisContinuata.None, null, null
            );
            if (_configuratio.LudereExire) {
                animationis = new OrdinatioCivisAnimationis(
                    idCivis, true, _configuratio.IdAnimationisExire, null, adFinem
                );
            }
            return new OrdinatioCivis(
                idCivis, animationis: animationis
            );
       }

        public OrdinatioCivis Ordinare(
            int idCivis,
            ContextusCivisOstiorumLegibile contextusOstiorum,
            IResFluidaCivisLegibile resFluida
        ) {
            OrdinatioCivisMotusHorizontalis oh = new OrdinatioCivisMotusHorizontalis(
                0f,
                0f
            );
            OrdinatioCivisMotusVerticalis ov = new OrdinatioCivisMotusVerticalis(
                0f,
                0f
            );
            OrdinatioCivisMotusRotationisY or = new OrdinatioCivisMotusRotationisY(
                resFluida.Motus.RotatioYActualis(idCivis),
                0f
            );
            OrdinatioCivisActionis motus = OrdinatioCivisActionis.FromMotus(
                idCivis,
                new OrdinatioCivisMotus(oh, ov, or)
            );
            OrdinatioCivisVeletudinisValoris veletudinis = new OrdinatioCivisVeletudinisValoris(
                idCivis, -_configuratio.ConsumptioVitae * contextusOstiorum.Temporis.Intervallum
            );
            return new OrdinatioCivis(
                idCivis, actionis: motus, veletudinisValoris: veletudinis
            );
        }
    }
}