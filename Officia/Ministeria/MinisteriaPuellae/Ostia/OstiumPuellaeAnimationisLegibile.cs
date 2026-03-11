using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Officia.Contractus;

namespace Yulinti.Officia.Ministeria {
    public sealed class OstiumPuellaeAnimationisLegibile : IOstiumPuellaeAnimationisLegibile {
        private readonly MinisteriumPuellaeAnimationis _ministeriumPuellaeAnimationis;

        public OstiumPuellaeAnimationisLegibile(MinisteriumPuellaeAnimationis ministeriumPuellaeAnimationis) {
            _ministeriumPuellaeAnimationis = ministeriumPuellaeAnimationis;
        }

        public bool EstExhibens(IDPuellaeAnimationisStratum stratum) {
            return _ministeriumPuellaeAnimationis.EstExhibens(stratum);
        }
        public bool EstDesinens(IDPuellaeAnimationisStratum stratum) {
            return _ministeriumPuellaeAnimationis.EstDesinens(stratum);
        }
        public bool EstExhibensIterans(IDPuellaeAnimationisStratum stratum) {
            return _ministeriumPuellaeAnimationis.EstExhibensIterans(stratum);
        }
    }
}