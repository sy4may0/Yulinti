using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal static class FabricaOrdinatorPuellaeModi {
        public static IOrdinatorPuellaeModi Creare(
            IDPuellaeModiMotus modusMotus,
            IConfiguratioPuellaeStatuum configuratioStatuum,
            IConfiguratioPuellaeStatusCorporis configurationemCorporis,
            IOstiumInputMotusLegibile osInputMotusLeg,
            IOstiumCameraLegibile osCameraLeg,
            IOstiumTemporisLegibile osTemporisLeg
        ) {
            switch (modusMotus) {
                case IDPuellaeModiMotus.ModusMotus:
                    return new OrdinatorPuellaeModiMotus(configuratioStatuum, configurationemCorporis, osInputMotusLeg, osCameraLeg, osTemporisLeg);
                case IDPuellaeModiMotus.ModusQuietus:
                    return new OrdinatorPuellaeModiQuietes(configuratioStatuum, configurationemCorporis, osInputMotusLeg, osCameraLeg, osTemporisLeg);
                default:
                    return new OrdinatorPuellaeModiQuietes(configuratioStatuum, configurationemCorporis, osInputMotusLeg, osCameraLeg, osTemporisLeg);
            }
        }
    }
}