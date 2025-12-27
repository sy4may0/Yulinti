using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class MilesPuellaeActionisSecundarius : IMilesPuellaeActionisSecundarius {
        private readonly ContextusPuellaeOstiorumLegibile _contextusOstiorum;
        private readonly AdiectorPuellaePelvisAltitudinis _adiectorPuellaePelvisAltitudinis;
        private readonly ThesaurusPuellaeActionisSecundarius _thsaurus;

        public MilesPuellaeActionisSecundarius(
            IConfiguratioPuellaeActionisSecundarius configuratio,
            IOstiumPuellaeOssisMutabile osPuellaeOssisMut
        ) {
            _thsaurus = new ThesaurusPuellaeActionisSecundarius(configuratio);
            _adiectorPuellaePelvisAltitudinis = new AdiectorPuellaePelvisAltitudinis(
                osPuellaeOssisMut,
                _thsaurus
            );
        }

        public void ElevoPelvimSequensTerra(
            ContextusPuellaeOstiorumLegibile contextusOstiorum
        ) {
            _adiectorPuellaePelvisAltitudinis.ElevoPelvis(
                contextusOstiorum
            );
        }
    }
}