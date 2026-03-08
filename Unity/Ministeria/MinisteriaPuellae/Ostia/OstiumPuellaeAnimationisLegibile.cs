using Yulinti.Exercitus.Contractus;
using Yulinti.Unity.Contractus;

namespace Yulinti.Unity.Ministeria {
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