using Yulinti.Dux.ContractusDucis;
using System;

namespace Yulinti.Dux.Exercitus {
    internal sealed class TabulaPuellaeStatuumCorporis {
        private readonly IStatusPuellaeCorporis[] _statuum;

        public TabulaPuellaeStatuumCorporis(
            IConfiguratioPuellaeStatuum configuratioStatuum,
            IConfiguratioPuellaeStatusCorporis[] configurationemCorporis,
            IOstiumInputMotusLegibile osInputMotusLeg,
            IOstiumTemporisLegibile osTemporisLeg,
            IOstiumCameraLegibile osCameraLeg,
            IOstiumPuellaeAnimationesMutabile osAnimationes
        ) {
            int longitudo = Enum.GetValues(typeof(IDStatusCorporis)).Length;
            _statuum = new IStatusPuellaeCorporis[longitudo];

            foreach (var conf in configurationemCorporis) {
                IOrdinatorPuellaeModi modus = FabricaOrdinatorPuellaeModi.Creare(
                    conf.IdModusMotus,
                    configuratioStatuum,
                    conf,
                    osInputMotusLeg,
                    osCameraLeg,
                    osTemporisLeg
                );
                _statuum[(int)conf.Id] = new StatusPuellaeCorporisMotus(
                    conf.Id,
                    conf.IdAnimationisIntrare,
                    conf.IdAnimationisExire,
                    conf.LudereExire,
                    modus,
                    osAnimationes
                );
            }
        }

        public IStatusPuellaeCorporis Lego(IDStatusCorporis id) {
            return _statuum[(int)id];
        }
    }
}