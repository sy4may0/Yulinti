using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;
using Yulinti.Dux.ContractusDucis;
using System.Numerics;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class OstiumPuellaeResVisaeLegibile : IOstiumPuellaeResVisaeLegibile {
        private readonly MinisteriumPuellaeResVisae _miPuellaeResVisae;
        public OstiumPuellaeResVisaeLegibile(MinisteriumPuellaeResVisae miPuellaeResVisae) {
            _miPuellaeResVisae = miPuellaeResVisae;
        }

        public bool EstActivumCapitis() => _miPuellaeResVisae.EstActivumCapitis();
        public bool EstActivumPectoris() => _miPuellaeResVisae.EstActivumPectoris();
        public bool EstActivumNatium() => _miPuellaeResVisae.EstActivumNatium();
        public bool ConareLegoCapitis(IDPuellaeResVisaeCapitis idCapitis, out Vector3 positionem) {
            if (!_miPuellaeResVisae.EstActivumCapitis()) {
                positionem = default;
                return false;
            }
            positionem = InterpressNumericus.ToNumerics(_miPuellaeResVisae.LegoCapitis(idCapitis));
            return true;
        }
        public bool ConareLegoPectoris(IDPuellaeResVisaePectoris idPectoris, out Vector3 positionem) {
            if (!_miPuellaeResVisae.EstActivumPectoris()) {
                positionem = default;
                return false;
            }
            positionem = InterpressNumericus.ToNumerics(_miPuellaeResVisae.LegoPectoris(idPectoris));
            return true;
        }
        public bool ConareLegoNatium(IDPuellaeResVisaeNatium idNatium, out Vector3 positionem) {
            if (!_miPuellaeResVisae.EstActivumNatium()) {
                positionem = default;
                return false;
            }
            positionem = InterpressNumericus.ToNumerics(_miPuellaeResVisae.LegoNatium(idNatium));
            return true;
        }
        public Vector3 LegoPositionemRadix() {
            return InterpressNumericus.ToNumerics(_miPuellaeResVisae.LegoPositionemRadix());
        }
    }
}