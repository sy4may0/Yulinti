using System.Numerics;
using Yulinti.Exercitus.Contractus;
using Yulinti.Nucleus;
using Yulinti.Unity.Contractus;
using Yulinti.Unity.Instrumentarium;

namespace Yulinti.Unity.Ministeria {
    internal sealed class OstiumPunctumViaeLegibile : IOstiumPunctumViaeLegibile {
        private readonly MinisteriumPunctumViae _miPunctumViae;

        public OstiumPunctumViaeLegibile(MinisteriumPunctumViae miPunctumViae) {
            _miPunctumViae = miPunctumViae;
        }

        public bool ConareLegoTemere(out IPunctumViaeLegibile punctumViae) {
            punctumViae = _miPunctumViae.LegoTemere();
            if (punctumViae == null) {
                return false;
            }
            return true;
        }

        public bool ConareLegoVicinam(Vector3 positio, out IPunctumViaeLegibile punctumViae) {
            punctumViae = _miPunctumViae.LegoVicinam(InterpresNumeri.ToUnity(positio));
            if (punctumViae == null) {
                return false;
            }
            return true;
        }

        public bool ConareLegoCrematoriumTemere(out IPunctumViaeLegibile punctumViae) {
            punctumViae = _miPunctumViae.LegoCrematoriumTemere();
            if (punctumViae == null) {
                return false;
            }
            return true;
        }

        public bool ConareLegoCrematoriumVicinam(Vector3 positio, out IPunctumViaeLegibile punctumViae) {
            punctumViae = _miPunctumViae.LegoCrematoriumVicinam(InterpresNumeri.ToUnity(positio));
            if (punctumViae == null) {
                return false;
            }
            return true;
        }

        public bool ConareLegoNatoriumTemere(out IPunctumViaeLegibile punctumViae) {
            punctumViae = _miPunctumViae.LegoNatoriumTemere();
            if (punctumViae == null) {
                return false;
            }
            return true;
        }

        public bool ConareLegoNatoriumVicinam(Vector3 positio, out IPunctumViaeLegibile punctumViae) {
            punctumViae = _miPunctumViae.LegoNatoriumVicinam(InterpresNumeri.ToUnity(positio));
            if (punctumViae == null) {
                return false;
            }
            return true;
        }

        public bool ConareLegoTypumTemere(IDPunctumViaeTypi typus, out IPunctumViaeLegibile punctumViae) {
            punctumViae = _miPunctumViae.LegoTypumTemere(typus);
            if (punctumViae == null) {
                return false;
            }
            return true;
        }

        public bool ConareLegoTypumVicinam(IDPunctumViaeTypi typus, Vector3 positio, out IPunctumViaeLegibile punctumViae) {
            punctumViae = _miPunctumViae.LegoTypumVicinam(typus, InterpresNumeri.ToUnity(positio));
            if (punctumViae == null) {
                return false;
            }
            return true;
        }
    }
}
