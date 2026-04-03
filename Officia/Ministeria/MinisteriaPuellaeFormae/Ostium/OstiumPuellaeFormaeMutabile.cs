using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.Officia.Ministeria {
    internal sealed class OstiumPuellaeFormaeMutabile : IOstiumPuellaeFormaeMutabile {
        private readonly MinisteriumPuellaeFormae _ministeriumPuellaeFormae;
        public OstiumPuellaeFormaeMutabile(MinisteriumPuellaeFormae ministeriumPuellaeFormae) {
            _ministeriumPuellaeFormae = ministeriumPuellaeFormae;
        }

        public void PonoRationem(IDPuellaeFormae idFormae, float ratio) {
            _ministeriumPuellaeFormae.Renovare(idFormae, ratio);
        }
    }
}  