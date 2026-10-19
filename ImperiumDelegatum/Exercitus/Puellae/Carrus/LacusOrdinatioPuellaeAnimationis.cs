using Yulinti.Nucleus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class LacusOrdinatioPuellaeAnimationis {
        private readonly Lacus<OrdinatioPuellaeAnimationis> _lacusAnimationis;

        private readonly Ordo<OrdinatioPuellaeAnimationis> _emissioAnimationis;

        public LacusOrdinatioPuellaeAnimationis() {
            _lacusAnimationis = new Lacus<OrdinatioPuellaeAnimationis>(
                ConstansPuellae.LongitudoOrdinatioAnimationis
            );
            _emissioAnimationis = new Ordo<OrdinatioPuellaeAnimationis>(
                ConstansPuellae.LongitudoOrdinatioAnimationis
            );
        }

        public bool EmittareAnimationis(out OrdinatioPuellaeAnimationis animationis) {
            if (_lacusAnimationis.ConareLego(out var r)) {
                if(_emissioAnimationis.ConarePono(r)) {
                    animationis = r;
                    animationis.Initare();
                    return true;
                }
                Notarius.Memorare(LogTextus.LacusOrdinatioPuellae_ORDINATIOPUELLAEANIMATIONIS_EMISSIO_QUEUE_FULL);
                animationis = null;
                return false;
            }
            Notarius.Memorare(LogTextus.LacusOrdinatioPuellae_ORDINATIOPUELLAEANIMATIONIS_LACUS_EMPTY);
            animationis = null;
            return false;
        }

        public void ColligereAnimationis() {
            while(_emissioAnimationis.ConareLego(out var r)) {
                if(!_lacusAnimationis.ConarePono(r)) {
                    r.Purgere();
                    r.Liberare();
                    Notarius.Memorare(LogTextus.LacusOrdinatioPuellae_ORDINATIOPUELLAEANIMATIONIS_LACUS_FULL);
                }
            }
        }

        public void ColligereOmnia() {
            ColligereAnimationis();
        }
    }
}
