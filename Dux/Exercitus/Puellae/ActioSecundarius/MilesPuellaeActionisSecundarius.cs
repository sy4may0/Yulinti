using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class MilesPuellaeActionisSecundarius {
        private readonly AdiectorPuellaePelvisAltitudinis _adiectorPuellaePelvisAltitudinis;

        public MilesPuellaeActionisSecundarius(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IOstiumPuellaeOssisMutabile osPuellaeOssisMut
        ) {
            _adiectorPuellaePelvisAltitudinis = new AdiectorPuellaePelvisAltitudinis(
                osPuellaeOssisMut,
                contextusOstiorum
            );
        }

        public void ElevoPelvimSequensTerra() {
            _adiectorPuellaePelvisAltitudinis.ElevoPelvis();
        }
    }
}