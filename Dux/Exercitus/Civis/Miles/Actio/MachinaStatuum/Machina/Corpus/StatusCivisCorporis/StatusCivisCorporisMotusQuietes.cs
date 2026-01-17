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

        public void Intrare(
            int idCivis,
            ContextusCivisOstiorumLegibile contextusOstiorum,
            IResFluidaCivisLegibile resFluida,
            Action adInitium
        ) {
            contextusOstiorum.Carrus.ExecutareAnimationis(
                idCivis, _configuratio.IdAnimationisIntrare, adInitium, null, false
            );
        }

        public void Exire(
            int idCivis,
            ContextusCivisOstiorumLegibile contextusOstiorum,
            IResFluidaCivisLegibile resFluida,
            Action adFinem
        ) {
            if (_configuratio.LudereExire) {
                contextusOstiorum.Carrus.ExecutareAnimationis(
                    idCivis, _configuratio.IdAnimationisExire, null, adFinem, false
                );
            }
       }

        public void Ordinare(
            int idCivis,
            ContextusCivisOstiorumLegibile contextusOstiorum,
            IResFluidaCivisLegibile resFluida
        ) {
            contextusOstiorum.Carrus.ExecutareMotus(idCivis, 0f, 0f, 0f, 0f);
            contextusOstiorum.Carrus.ExecutareVeletudinisValoris(
                idCivis,
                dtVitae: -_configuratio.ConsumptioVitae * contextusOstiorum.Temporis.Intervallum,
                dtVisus: _configuratio.Visus
            );
        }
    }
}