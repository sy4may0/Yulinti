using Yulinti.Dux.ContractusDucis;
namespace Yulinti.Dux.Exercitus {
    internal sealed class ContextusCivisOstiorumLegibile {
        private readonly IConfiguratioExercitusCivis _configuratio;
        private readonly IOstiumTemporisLegibile _temporis;
        private readonly IOstiumCameraLegibile _camera;
        private readonly IOstiumCivisLegibile _civis;
        private readonly IOstiumCivisLociLegibile _loci;
        private readonly IOstiumPunctumViaeLegibile _punctumViae;

        public ContextusCivisOstiorumLegibile(
            IConfiguratioExercitusCivis configuratio,
            IOstiumTemporisLegibile temporis,
            IOstiumCameraLegibile camera,
            IOstiumCivisLegibile civis,
            IOstiumCivisLociLegibile loci,
            IOstiumPunctumViaeLegibile punctumViae
        ) {
            _configuratio = configuratio;
            _temporis = temporis;
            _camera = camera;
            _civis = civis;
            _loci = loci;
            _punctumViae = punctumViae;
        }

        public IConfiguratioExercitusCivis Configuratio => _configuratio;
        public IOstiumTemporisLegibile Temporis => _temporis;
        public IOstiumCameraLegibile Camera => _camera;
        public IOstiumCivisLegibile Civis => _civis;
        public IOstiumCivisLociLegibile Loci => _loci;
        public IOstiumPunctumViaeLegibile PunctumViae => _punctumViae;
    }
}
