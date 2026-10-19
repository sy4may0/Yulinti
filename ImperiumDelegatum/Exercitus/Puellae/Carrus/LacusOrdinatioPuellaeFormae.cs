using Yulinti.Nucleus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class LacusOrdinatioPuellaeFormae {
        private readonly Lacus<OrdinatioPuellaeFormae> _lacusFormae;

        private readonly Ordo<OrdinatioPuellaeFormae> _emissioFormae;

        public LacusOrdinatioPuellaeFormae() {
            _lacusFormae = new Lacus<OrdinatioPuellaeFormae>(
                ConstansPuellae.LongitudoOrdinatioFormae
            );
            _emissioFormae = new Ordo<OrdinatioPuellaeFormae>(
                ConstansPuellae.LongitudoOrdinatioFormae
            );
        }

        public bool EmittareFormae(out OrdinatioPuellaeFormae formae) {
            if (_lacusFormae.ConareLego(out var r)) {
                if(_emissioFormae.ConarePono(r)) {
                    formae = r;
                    formae.Initare();
                    return true;
                }
                Notarius.Memorare(LogTextus.LacusOrdinatioPuellae_ORDINATIOPUELLAEFORMAE_EMISSIO_QUEUE_FULL);
                formae = null;
                return false;
            }
            Notarius.Memorare(LogTextus.LacusOrdinatioPuellae_ORDINATIOPUELLAEFORMAE_LACUS_EMPTY);
            formae = null;
            return false;
        }

        public void ColligereFormae() {
            while(_emissioFormae.ConareLego(out var r)) {
                if(!_lacusFormae.ConarePono(r)) {
                    r.Purgere();
                    r.Liberare();
                    Notarius.Memorare(LogTextus.LacusOrdinatioPuellae_ORDINATIOPUELLAEFORMAE_LACUS_FULL);
                }
            }
        }

        public void ColligereOmnia() {
            ColligereFormae();
        }
    }
}
