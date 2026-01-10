using Yulinti.Dux.ContractusDucis;
namespace Yulinti.Dux.Exercitus {
    internal sealed class ContextusCivisOstiorumLegibile {
        private readonly IConfiguratioExercitusCivis _configuratio;
        private readonly IOstiumTemporisLegibile _temporis;
        private readonly IOstiumCameraLegibile _camera;
        private readonly IOstiumCivisLegibile _civis;
        private readonly IOstiumCivisLociLegibile _loci;
        private readonly IOstiumPunctumViaeLegibile _punctumViae;
        private readonly IOstiumCivisVisaeLegibile _visa;
        private readonly IOstiumPuellaeResVisaeLegibile _puellaeResVisae;
        private readonly IResFluidaPuellaeLegibile _resFPuellae;

        public ContextusCivisOstiorumLegibile(
            IConfiguratioExercitusCivis configuratio,
            IOstiumTemporisLegibile temporis,
            IOstiumCameraLegibile camera,
            IOstiumCivisLegibile civis,
            IOstiumCivisLociLegibile loci,
            IOstiumPunctumViaeLegibile punctumViae,
            IOstiumCivisVisaeLegibile visa,
            IOstiumPuellaeResVisaeLegibile puellaeResVisae,
            IResFluidaPuellaeLegibile resFPuellae
        ) {
            _configuratio = configuratio;
            _temporis = temporis;
            _camera = camera;
            _civis = civis;
            _loci = loci;
            _punctumViae = punctumViae;
            _visa = visa;
            _puellaeResVisae = puellaeResVisae;
            _resFPuellae = resFPuellae;
        }

        public IConfiguratioExercitusCivis Configuratio => _configuratio;
        public IOstiumTemporisLegibile Temporis => _temporis;
        public IOstiumCameraLegibile Camera => _camera;
        public IOstiumCivisLegibile Civis => _civis;
        public IOstiumCivisLociLegibile Loci => _loci;
        public IOstiumPunctumViaeLegibile PunctumViae => _punctumViae;
        public IOstiumCivisVisaeLegibile Visa => _visa;
        public IOstiumPuellaeResVisaeLegibile PuellaeResVisae => _puellaeResVisae;
        public IResFluidaPuellaeLegibile ResFPuellae => _resFPuellae;
    }
}
