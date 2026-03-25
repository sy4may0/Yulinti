using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ContextusStatusCivisCorporis {
        private readonly IOstiumTemporisLegibile _temporis;
        private readonly IOstiumCivisLociLegibile _loci;
        private readonly IOstiumPunctumViaeLegibile _punctumViae;
        private readonly IOstiumCarrusCivis _carrus;

        public ContextusStatusCivisCorporis(
            IOstiumTemporisLegibile temporis,
            IOstiumCivisLociLegibile loci,
            IOstiumPunctumViaeLegibile punctumViae,
            IOstiumCarrusCivis carrus
        ) {
            _temporis = temporis;
            _loci = loci;
            _punctumViae = punctumViae;
            _carrus = carrus;
        }

        public IOstiumTemporisLegibile Temporis => _temporis;
        public IOstiumCivisLociLegibile Loci => _loci;
        public IOstiumPunctumViaeLegibile PunctumViae => _punctumViae;
        public IOstiumCarrusCivis Carrus => _carrus;
    }
}