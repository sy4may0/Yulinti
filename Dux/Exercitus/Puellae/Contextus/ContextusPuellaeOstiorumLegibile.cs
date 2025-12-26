using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class ContextusPuellaeOstiorumLegibile {
        private readonly IConfiguratioPuellaeStatuum _configuratio;
        private readonly IOstiumTemporisLegibile _temporis;
        private readonly IOstiumCameraLegibile _camera;
        private readonly IOstiumInputMotusLegibile _inputMotus;
        private readonly IOstiumPuellaeLociLegibile _puellaeLoci;

        public ContextusPuellaeOstiorumLegibile(
            IConfiguratioPuellaeStatuum configuratio,
            IOstiumTemporisLegibile temporis,
            IOstiumCameraLegibile camera,
            IOstiumInputMotusLegibile inputMotus,
            IOstiumPuellaeLociLegibile puellaeLoci
        ) {
            _configuratio = configuratio;
            _temporis = temporis;
            _camera = camera;
            _inputMotus = inputMotus;
            _puellaeLoci = puellaeLoci;
        }

        public IConfiguratioPuellaeStatuum Configuratio => _configuratio;
        public IOstiumTemporisLegibile Temporis => _temporis;
        public IOstiumCameraLegibile Camera => _camera;
        public IOstiumInputMotusLegibile InputMotus => _inputMotus;
        public IOstiumPuellaeLociLegibile PuellaeLoci => _puellaeLoci;
    }
}