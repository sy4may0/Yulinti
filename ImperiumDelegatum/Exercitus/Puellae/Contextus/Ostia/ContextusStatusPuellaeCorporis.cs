using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ContextusStatusPuellaeCorporis {
        private readonly IOstiumCarrusPuellae _carrus;
        private readonly IOstiumTemporisLegibile _temporis;
        private readonly IOstiumPuellaeLociLegibile _loci;
        private readonly IOstiumCameraLegibile _camera;
        private readonly ITurrisIntroductionis _turrisIntroductionis;

        public ContextusStatusPuellaeCorporis(
            IOstiumCarrusPuellae carrus,
            IOstiumTemporisLegibile temporis,
            IOstiumPuellaeLociLegibile loci,
            IOstiumCameraLegibile camera,
            ITurrisIntroductionis turrisIntroductionis
        ) {
            _carrus = carrus;
            _temporis = temporis;
            _loci = loci;
            _camera = camera;
            _turrisIntroductionis = turrisIntroductionis;
        }

        public IOstiumCarrusPuellae Carrus => _carrus;
        public IOstiumTemporisLegibile Temporis => _temporis;
        public IOstiumPuellaeLociLegibile Loci => _loci;
        public IOstiumCameraLegibile Camera => _camera;
        public ITurrisIntroductionis Introductionis => _turrisIntroductionis;
    }
}