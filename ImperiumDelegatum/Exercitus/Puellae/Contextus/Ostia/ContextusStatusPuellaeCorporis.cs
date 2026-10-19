using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ContextusStatusPuellaeCorporis {
        private readonly IOstiumCarrusPuellaeAnimationis _carrusAnimationis;
        private readonly IOstiumCarrusPuellaeLoci _carrusLoci;
        private readonly IOstiumCarrusPuellaeVeletudinis _carrusVeletudinis;
        private readonly IOstiumTemporisLegibile _temporis;
        private readonly IOstiumPuellaeLociLegibile _loci;
        private readonly IOstiumCameraLegibile _camera;
        private readonly ITurrisIntroductionis _turrisIntroductionis;

        public ContextusStatusPuellaeCorporis(
            IOstiumCarrusPuellaeAnimationis carrusAnimationis,
            IOstiumCarrusPuellaeLoci carrusLoci,
            IOstiumCarrusPuellaeVeletudinis carrusVeletudinis,
            IOstiumTemporisLegibile temporis,
            IOstiumPuellaeLociLegibile loci,
            IOstiumCameraLegibile camera,
            ITurrisIntroductionis turrisIntroductionis
        ) {
            _carrusAnimationis = carrusAnimationis;
            _carrusLoci = carrusLoci;
            _carrusVeletudinis = carrusVeletudinis;
            _temporis = temporis;
            _loci = loci;
            _camera = camera;
            _turrisIntroductionis = turrisIntroductionis;
        }

        public IOstiumCarrusPuellaeAnimationis CarrusAnimationis => _carrusAnimationis;
        public IOstiumCarrusPuellaeLoci CarrusLoci => _carrusLoci;
        public IOstiumCarrusPuellaeVeletudinis CarrusVeletudinis => _carrusVeletudinis;
        public IOstiumTemporisLegibile Temporis => _temporis;
        public IOstiumPuellaeLociLegibile Loci => _loci;
        public IOstiumCameraLegibile Camera => _camera;
        public ITurrisIntroductionis Introductionis => _turrisIntroductionis;
    }
}