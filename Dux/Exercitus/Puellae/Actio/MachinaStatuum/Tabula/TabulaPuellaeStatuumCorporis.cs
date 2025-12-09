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
            int longitudo = Enum.GetValues(typeof(IDStatus)).Length;
            _statuum = new IStatusPuellaeCorporis[longitudo];

            for(int i = 1; i < longitudo; i++) {
                IOrdinatorPuellaeModi modus = FabricaOrdinatorPuellaeModi.Creare(
                    configurationemCorporis[(int)i].IdModusMotus,
                    configuratioStatuum,
                    configurationemCorporis[(int)i],
                    osInputMotusLeg,
                    osCameraLeg,
                    osTemporisLeg
                );
                _statuum[i] = new StatusPuellaeCorporisMotus(
                    configurationemCorporis[(int)i].Id,
                    configurationemCorporis[(int)i].IdAnimationisIntrare,
                    configurationemCorporis[(int)i].IdAnimationisExire,
                    configurationemCorporis[(int)i].LudereExire,
                    modus,
                    osAnimationes
                );
            }
        }

        public IStatusPuellaeCorporis Lego(IDStatus id) {
            return _statuum[(int)id];
        }
    }
}