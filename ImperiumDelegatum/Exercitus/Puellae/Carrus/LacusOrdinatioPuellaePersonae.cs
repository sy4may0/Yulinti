using Yulinti.Nucleus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class LacusOrdinatioPuellaePersonae {
        private readonly Lacus<OrdinatioPuellaePersonae> _lacusPersonae;

        private readonly Ordo<OrdinatioPuellaePersonae> _emissioPersonae;

        public LacusOrdinatioPuellaePersonae() {
            _lacusPersonae = new Lacus<OrdinatioPuellaePersonae>(12);
            _emissioPersonae = new Ordo<OrdinatioPuellaePersonae>(
                ConstansPuellae.LongitudoOrdinatioVeletudinis
            );
        }

        public bool EmittarePersonae(out OrdinatioPuellaePersonae personae) {
            if (_lacusPersonae.ConareLego(out var r)) {
                if(_emissioPersonae.ConarePono(r)) {
                    personae = r;
                    personae.Initare();
                    return true;
                }
                Notarius.Memorare(LogTextus.LacusOrdinatioPuellae_ORDINATIOPUELLAEPERSONAE_EMISSIO_QUEUE_FULL);
                personae = null;
                return false;
            }
            Notarius.Memorare(LogTextus.LacusOrdinatioPuellae_ORDINATIOPUELLAEPERSONAE_LACUS_EMPTY);
            personae = null;
            return false;
        }

        public void ColligerePersonae() {
            while(_emissioPersonae.ConareLego(out var r)) {
                if(!_lacusPersonae.ConarePono(r)) {
                    r.Purgere();
                    r.Liberare();
                    Notarius.Memorare(LogTextus.LacusOrdinatioPuellae_ORDINATIOPUELLAEPERSONAE_LACUS_FULL);
                }
            }
        }

        public void ColligereOmnia() {
            ColligerePersonae();
        }
    }
}
