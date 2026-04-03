using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.Officia.Ministeria {
    internal sealed class OstiumPuellaeFormaeLegibile : IOstiumPuellaeFormaeLegibile {
        private readonly MinisteriumPuellaeFormae _ministeriumPuellaeFormae;

        public OstiumPuellaeFormaeLegibile(MinisteriumPuellaeFormae ministeriumPuellaeFormae) {
            _ministeriumPuellaeFormae = ministeriumPuellaeFormae;
        }

        public float LegoRationem(IDPuellaeFormae idFormae) {
            return _ministeriumPuellaeFormae.RatioActualis(idFormae);
        }
    }
}