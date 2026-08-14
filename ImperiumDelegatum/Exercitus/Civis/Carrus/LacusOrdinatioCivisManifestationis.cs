using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class LacusOrdinatioCivisManifestationis {
        private readonly Lacus<OrdinatioCivisManifestationis> _lacus;
        private readonly Ordo<OrdinatioCivisManifestationis> _emissio;

        public LacusOrdinatioCivisManifestationis() {
            _lacus = new Lacus<OrdinatioCivisManifestationis>(
                ConstansCivis.LongitudoOrdinatioManifestationis
            );
            _emissio = new Ordo<OrdinatioCivisManifestationis>(
                ConstansCivis.LongitudoOrdinatioManifestationis
            );
        }

        public bool Emittare(out OrdinatioCivisManifestationis manifestationis) {
            if (_lacus.ConareLego(out var r)) {
                if (_emissio.ConarePono(r)) {
                    manifestationis = r;
                    manifestationis.Initare();
                    return true;
                }
                Notarius.Memorare(LogTextus.LacusOrdinatioCivisManifestationis_ORDINATIOCIVISMANIFESTATIONIS_EMISSIO_QUEUE_FULL);
                manifestationis = null;
                return false;
            }
            Notarius.Memorare(LogTextus.LacusOrdinatioCivisManifestationis_ORDINATIOCIVISMANIFESTATIONIS_LACUS_EMPTY);
            manifestationis = null;
            return false;
        }

        public void Colligere() {
            while (_emissio.ConareLego(out var r)) {
                if (!_lacus.ConarePono(r)) {
                    r.Purgere();
                    r.Liberare();
                    Notarius.Memorare(LogTextus.LacusOrdinatioCivisManifestationis_ORDINATIOCIVISMANIFESTATIONIS_LACUS_FULL);
                }
            }
        }
    }
}
