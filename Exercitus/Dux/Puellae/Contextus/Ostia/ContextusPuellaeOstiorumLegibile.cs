using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Dux {
    internal sealed class ContextusPuellaeOstiorumLegibile {
        private readonly IConfiguratioExercitusPuellae _configuratio;
        private readonly ITurrisIntroductionis _turrisIntroductionis;
        private readonly ITurrisSalsamentiLegibile _turrisSalsamenti;
        private readonly IOstiumTemporisLegibile _temporis;
        private readonly IOstiumCameraLegibile _camera;
        private readonly IOstiumPuellaeLociLegibile _loci;
        private readonly IOstiumPuellaeAnimationisLegibile _animationis;
        private readonly IOstiumPuellaeRelationisTerraeLegibile _relationisTerrae;
        private readonly IOstiumPuellaeOssisLegibile _ossis;
        private readonly IResFluidaCivisLegibile _resFCivis;
        private readonly IOstiumCarrusPuellae _carrus;

        public ContextusPuellaeOstiorumLegibile(
            IConfiguratioExercitusPuellae configuratio,
            ITurrisIntroductionis turrisIntroductionis,
            ITurrisSalsamentiLegibile turrisSalsamenti,
            IOstiumTemporisLegibile temporis,
            IOstiumCameraLegibile camera,
            IOstiumPuellaeLociLegibile loci,
            IOstiumPuellaeAnimationisLegibile animationis,
            IOstiumPuellaeRelationisTerraeLegibile relationisTerrae,
            IOstiumPuellaeOssisLegibile ossis,
            IResFluidaCivisLegibile resFCivis,
            IOstiumCarrusPuellae carrus
        ) {
            _configuratio = configuratio;
            _turrisIntroductionis = turrisIntroductionis;
            _turrisSalsamenti = turrisSalsamenti;
            _temporis = temporis;
            _camera = camera;
            _animationis = animationis;
            _loci = loci;
            _relationisTerrae = relationisTerrae;
            _ossis = ossis;
            _resFCivis = resFCivis;
            _carrus = carrus;
        }

        public IConfiguratioExercitusPuellae Configuratio => _configuratio;
        public ITurrisIntroductionis Introductionis => _turrisIntroductionis;
        public ITurrisSalsamentiLegibile Salsamentum => _turrisSalsamenti;
        public IOstiumTemporisLegibile Temporis => _temporis;
        public IOstiumCameraLegibile Camera => _camera;
        public IOstiumPuellaeLociLegibile Loci => _loci;
        public IOstiumPuellaeAnimationisLegibile Animationis => _animationis;
        public IOstiumPuellaeRelationisTerraeLegibile RelationisTerrae => _relationisTerrae;
        public IOstiumPuellaeOssisLegibile Ossis => _ossis;
        public IResFluidaCivisLegibile ResFCivis => _resFCivis;
        public IOstiumCarrusPuellae Carrus => _carrus;
    }
}
