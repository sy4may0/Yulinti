using UnityEngine;
using Yulinti.Dux.ContractusDucis;
using Yulinti.Nucleus;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class MinisteriumPunctumViae {
        private readonly TabulaPunctumViae _tabulaPunctumViae;

        public MinisteriumPunctumViae(IAnchoraPunctumViae[] anchoraPunctumViae, IConfiguratioPunctumViae configuratioPunctumViae) {
            _tabulaPunctumViae = new TabulaPunctumViae(
                anchoraPunctumViae,
                configuratioPunctumViae.Crematorium,
                configuratioPunctumViae.Natorium,
                configuratioPunctumViae.Aditrium
            );
        }

        public void Activare(int id) {
            _tabulaPunctumViae.LegoIndexis(id).Activare();
        }

        public void Deactivare(int id) {
            _tabulaPunctumViae.LegoIndexis(id).Deactivare();
        }

        public PunctumViae LegoTemere() {
            PunctumViae[] punctaViae = _tabulaPunctumViae.LegoAditrium();
            PunctumViae exitus = SelegereCaecus(punctaViae);
            if (exitus == null) {
                return null;
            }
            return exitus;
        }

        public PunctumViae LegoVicinam(Vector3 positio) {
            PunctumViae[] punctaViae = _tabulaPunctumViae.LegoAditrium();
            PunctumViae exitus = SelegereVicinam(punctaViae, positio);
            if (exitus == null) {
                return null;
            }
            return exitus;
        }

        public PunctumViae LegoCrematoriumTemere() {
            PunctumViae[] punctaViae = _tabulaPunctumViae.LegoCrematorium();
            PunctumViae exitus = SelegereCaecus(punctaViae);
            if (exitus == null) {
                return null;
            }
            return exitus;
        }

        public PunctumViae LegoCrematoriumVicinam(Vector3 positio) {
            PunctumViae[] punctaViae = _tabulaPunctumViae.LegoCrematorium();
            PunctumViae exitus = SelegereVicinam(punctaViae, positio);
            if (exitus == null) {
                return null;
            }
            return exitus;
        }

        public PunctumViae LegoNatoriumTemere() {
            PunctumViae[] punctaViae = _tabulaPunctumViae.LegoNatorium();
            PunctumViae exitus = SelegereCaecus(punctaViae);
            if (exitus == null) {
                return null;
            }
            return exitus;
        }

        public PunctumViae LegoNatoriumVicinam(Vector3 positio) {
            PunctumViae[] punctaViae = _tabulaPunctumViae.LegoNatorium();
            PunctumViae exitus = SelegereVicinam(punctaViae, positio);
            if (exitus == null) {
                return null;
            }
            return exitus;
        }

        public PunctumViae LegoTypumTemere(IDPunctumViaeTypi typus) {
            PunctumViae[] punctaViae = _tabulaPunctumViae.Lego(typus);
            PunctumViae exitus = SelegereCaecus(punctaViae);
            if (exitus == null) {
                return null;
            }
            return exitus;
        }

        public PunctumViae LegoTypumVicinam(IDPunctumViaeTypi typus, Vector3 positio) {
            PunctumViae[] punctaViae = _tabulaPunctumViae.Lego(typus);
            PunctumViae exitus = SelegereVicinam(punctaViae, positio);
            if (exitus == null) {
                return null;
            }
            return exitus;
        }

        internal IPunctumViaeLegibile LegoOstium(int indexis) => _tabulaPunctumViae.LegoOstium(indexis);

        private PunctumViae SelegereCaecus(PunctumViae[] punctaViae) {
            int c = 0;
            for (int i = 0; i < punctaViae.Length; i++) {
                if (punctaViae[i].EstActivum) {
                    c++;
                }
            }
            if (c == 0) {
                return null;
            }
            int selectio = Random.Range(0, c);
            for (int i = 0; i < punctaViae.Length; i++) {
                if (punctaViae[i].EstActivum && selectio-- == 0) {
                    return punctaViae[i];
                }
            }
            return null;
        }

        private PunctumViae SelegereVicinam(PunctumViae[] punctaViae, Vector3 positio) {
            PunctumViae exitus = null;
            float maximus = float.MaxValue;
            for (int i = 0; i < punctaViae.Length; i++) {
                float sqr = (punctaViae[i].Positio - positio).sqrMagnitude;
                if (sqr < maximus && punctaViae[i].EstActivum) {
                    maximus = sqr;
                    exitus = punctaViae[i];
                }
            }
            return exitus;
        }
    }
}