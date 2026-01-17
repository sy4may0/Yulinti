using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class ContextusPuellaeOstiorumLegibile {
        private readonly IConfiguratioExercitusPuellae _configuratio;
        private readonly IOstiumTemporisLegibile _temporis;
        private readonly IOstiumCameraLegibile _camera;
        private readonly IOstiumInputMotusLegibile _inputMotus;
        private readonly IOstiumPuellaeLociLegibile _loci;
        private readonly IOstiumPuellaeRelationisTerraeLegibile _relationisTerrae;
        private readonly IOstiumPuellaeOssisLegibile _ossis;
        private readonly IOstiumCarrusPuellae _carrus;

        public ContextusPuellaeOstiorumLegibile(
            IConfiguratioExercitusPuellae configuratio,
            IOstiumTemporisLegibile temporis,
            IOstiumCameraLegibile camera,
            IOstiumInputMotusLegibile inputMotus,
            IOstiumPuellaeLociLegibile loci,
            IOstiumPuellaeRelationisTerraeLegibile relationisTerrae,
            IOstiumPuellaeOssisLegibile ossis,
            IOstiumCarrusPuellae carrus
        ) {
            _configuratio = configuratio;
            _temporis = temporis;
            _camera = camera;
            _inputMotus = inputMotus;
            _loci = loci;
            _relationisTerrae = relationisTerrae;
            _ossis = ossis;
            _carrus = carrus;
        }

        public IConfiguratioExercitusPuellae Configuratio => _configuratio;
        public IOstiumTemporisLegibile Temporis => _temporis;
        public IOstiumCameraLegibile Camera => _camera;
        public IOstiumInputMotusLegibile InputMotus => _inputMotus;
        public IOstiumPuellaeLociLegibile Loci => _loci;
        public IOstiumPuellaeRelationisTerraeLegibile RelationisTerrae => _relationisTerrae;
        public IOstiumPuellaeOssisLegibile Ossis => _ossis;
        public IOstiumCarrusPuellae Carrus => _carrus;
    }
}
