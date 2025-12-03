using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class MilesPuellaeActionisSecundarius : IMilesPuellaeActionisSecundarius {
        private AdiectorPuellaePelvisAltitudinis _adiectorPuellaePelvisAltitudinis;
        private ThesaurusPuellaeActionisSecundarius _thsaurus;

        public MilesPuellaeActionisSecundarius(
            IOstiumPuellaeRelationisTerraeLegibile osPuellaeRelationisTerraeLeg,
            IOstiumPuellaeOssisMutabile osPuellaeOssisMut,
            IOstiumPuellaeOssisLegibile osPuellaeOssisLeg,
            IConfiguratioPuellaeActionisSecundarius configuratio
        ) {
            _thsaurus = new ThesaurusPuellaeActionisSecundarius(configuratio);
            _adiectorPuellaePelvisAltitudinis = new AdiectorPuellaePelvisAltitudinis(
                osPuellaeRelationisTerraeLeg,
                osPuellaeOssisMut,
                osPuellaeOssisLeg,
                _thsaurus
            );
        }

        public void ElevoPelvimSequensTerra() {
            _adiectorPuellaePelvisAltitudinis.ElevoPelvis();
        }
    }
}