using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ContextusStatusCivisCorporis {
        private readonly IOstiumTemporisLegibile _temporis;
        private readonly IOstiumCivisLociLegibile _loci;
        private readonly IOstiumPunctumViaeLegibile _punctumViae;
        private readonly IOstiumCarrusCivisAnimationis _carrusAnimationis;
        private readonly IOstiumCarrusCivisLoci _carrusLoci;
        private readonly IOstiumCarrusCivisVeletudinis _carrusVeletudinis;
        private readonly IOstiumCarrusCivisMortis _carrusMortis;

        public ContextusStatusCivisCorporis(
            IOstiumTemporisLegibile temporis,
            IOstiumCivisLociLegibile loci,
            IOstiumPunctumViaeLegibile punctumViae,
            IOstiumCarrusCivisAnimationis carrusAnimationis,
            IOstiumCarrusCivisLoci carrusLoci,
            IOstiumCarrusCivisVeletudinis carrusVeletudinis,
            IOstiumCarrusCivisMortis carrusMortis
        ) {
            _temporis = temporis;
            _loci = loci;
            _punctumViae = punctumViae;
            _carrusAnimationis = carrusAnimationis;
            _carrusLoci = carrusLoci;
            _carrusVeletudinis = carrusVeletudinis;
            _carrusMortis = carrusMortis;
        }

        public IOstiumTemporisLegibile Temporis => _temporis;
        public IOstiumCivisLociLegibile Loci => _loci;
        public IOstiumPunctumViaeLegibile PunctumViae => _punctumViae;
        public IOstiumCarrusCivisAnimationis CarrusAnimationis => _carrusAnimationis;
        public IOstiumCarrusCivisLoci CarrusLoci => _carrusLoci;
        public IOstiumCarrusCivisVeletudinis CarrusVeletudinis => _carrusVeletudinis;
        public IOstiumCarrusCivisMortis CarrusMortis => _carrusMortis;
    }
}