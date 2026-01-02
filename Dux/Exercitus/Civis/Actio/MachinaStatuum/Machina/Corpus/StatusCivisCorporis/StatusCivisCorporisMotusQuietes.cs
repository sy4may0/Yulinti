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

        public OrdinatioCivisAnimationis Intrare(
            int idCivis,
            ContextusCivisOstiorumLegibile contextusOstiorum,
            IResFluidaCivisLegibile resFluida,
            Action adInitium
        ) {
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
            if (_configuratio.LudereExire) {
                return new OrdinatioCivisAnimationis(
                    idCivis, true, _configuratio.IdAnimationisExire, null, adFinem
                );
            }
            return new OrdinatioCivisAnimationis(
                idCivis, false, IDCivisAnimationisContinuata.None, null, null
            );
        }

        public OrdinatioCivisActionis OrdinareActionis(
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
            return OrdinatioCivisActionis.FromMotus(
                idCivis,
                new OrdinatioCivisMotus(oh, ov, or)
            );
        }

        public OrdinatioCivisVeletudinis OrdinareVeletudinis(
            int idCivis,
            ContextusCivisOstiorumLegibile contextusOstiorum,
            IResFluidaCivisLegibile resFluida
        ) {
            return new OrdinatioCivisVeletudinis(
                idCivis, -_configuratio.ConsumptioVitae * contextusOstiorum.Temporis.Intervallum
            );
        }
    }
}