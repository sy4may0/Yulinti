using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Officia.Contractus;

namespace Yulinti.Officia.Ministeria {
    internal sealed class OstiumCivisAnimationesLegibile : IOstiumCivisAnimationesLegibile {
        private readonly MinisteriumCivisAnimationes _miCivisAnimationes;

        public OstiumCivisAnimationesLegibile(MinisteriumCivisAnimationes miCivisAnimationes) {
            _miCivisAnimationes = miCivisAnimationes;
        }

        public bool EstExhibens(int id, IDCivisAnimationisStratum stratum) {
            return _miCivisAnimationes.EstExhibens(id, stratum);
        }

        public bool EstDesinens(int id, IDCivisAnimationisStratum stratum) {
            return _miCivisAnimationes.EstDesinens(id, stratum);
        }
        
        public bool EstExhibensIterans(int id, IDCivisAnimationisStratum stratum) {
            return _miCivisAnimationes.EstExhibensIterans(id, stratum);
        }
    }
}