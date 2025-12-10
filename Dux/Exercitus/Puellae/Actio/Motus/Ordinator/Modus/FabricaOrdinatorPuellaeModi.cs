using Yulinti.Dux.ContractusDucis;
using Yulinti.Nucleus;

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
                    Errorum.Fatal(IDErrorum.FABRICAPUELLAEORDDINATORMODI_MODUS_NOT_FOUND);
                    return null;
            }
        }
    }
}