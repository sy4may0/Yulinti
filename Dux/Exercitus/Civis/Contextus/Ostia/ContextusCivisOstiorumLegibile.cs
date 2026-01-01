using Yulinti.Dux.ContractusDucis;
namespace Yulinti.Dux.Exercitus {
    internal sealed class ContextusCivisOstiorumLegibile {
        private readonly IOstiumTemporisLegibile _temporis;
        private readonly IOstiumCameraLegibile _camera;
        private readonly IOstiumCivisLegibile _ostiumCivis;
        private readonly IOstiumCivisLociNavmeshLegibile _civisLoci;

        public ContextusCivisOstiorumLegibile(
            IOstiumTemporisLegibile temporis,
            IOstiumCameraLegibile camera,
            IOstiumCivisLegibile ostiumCivis,
            IOstiumCivisLociNavmeshLegibile civisLoci
        ) {
            _temporis = temporis;
            _camera = camera;
            _ostiumCivis = ostiumCivis;
            _civisLoci = civisLoci;
        }

        public IOstiumTemporisLegibile Temporis => _temporis;
        public IOstiumCameraLegibile Camera => _camera;
        public IOstiumCivisLegibile OstiumCivis => _ostiumCivis;
        public IOstiumCivisLociNavmeshLegibile CivisLoci => _civisLoci;
    }
}