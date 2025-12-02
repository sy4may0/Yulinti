using Yulinti.Dux.ContractusDucis;
using Yulinti.Dux.Thesaurus;

namespace Yulinti.Dux.Exercitus {
    internal sealed class MilesPuellaeActionisSecundarius : IMilesPuellaeActionisSecundarius {
        private AdiectorPuellaePelvisAltitudinis _adiectorPuellaePelvisAltitudinis;

        public MilesPuellaeActionisSecundarius(
            IOstiumPuellaeRelationisTerraeLegibile osPuellaeRelationisTerraeLeg,
            IOstiumPuellaeOssisMutabile osPuellaeOssisMut,
            IOstiumPuellaeOssisLegibile osPuellaeOssisLeg,
            ThesaurusPuellaeInTerrae thesaurusPuellaeInTerrae
        ) {
            _adiectorPuellaePelvisAltitudinis = new AdiectorPuellaePelvisAltitudinis(
                osPuellaeRelationisTerraeLeg,
                osPuellaeOssisMut,
                osPuellaeOssisLeg,
                thesaurusPuellaeInTerrae
            );
        }

        public void ElevoPelvimSequensTerra() {
            _adiectorPuellaePelvisAltitudinis.ElevoPelvis();
        }
    }
}