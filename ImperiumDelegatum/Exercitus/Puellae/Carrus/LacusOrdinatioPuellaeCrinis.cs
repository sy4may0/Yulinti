using Yulinti.Nucleus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class LacusOrdinatioPuellaeCrinis {
        private readonly Lacus<OrdinatioPuellaeCrinis> _lacusCrinis;

        private readonly Ordo<OrdinatioPuellaeCrinis> _emissioCrinis;

        public LacusOrdinatioPuellaeCrinis() {
            _lacusCrinis = new Lacus<OrdinatioPuellaeCrinis>(
                ConstansPuellae.LongitudoOrdinatioCrinis
            );
            _emissioCrinis = new Ordo<OrdinatioPuellaeCrinis>(
                ConstansPuellae.LongitudoOrdinatioCrinis
            );
        }

        public bool EmittareCrinis(out OrdinatioPuellaeCrinis crinis) {
            if (_lacusCrinis.ConareLego(out var r)) {
                if(_emissioCrinis.ConarePono(r)) {
                    crinis = r;
                    crinis.Initare();
                    return true;
                }
                Notarius.Memorare(LogTextus.LacusOrdinatioPuellae_ORDINATIOPUELLAECRINIS_EMISSIO_QUEUE_FULL);
                crinis = null;
                return false;
            }
            Notarius.Memorare(LogTextus.LacusOrdinatioPuellae_ORDINATIOPUELLAECRINIS_LACUS_EMPTY);
            crinis = null;
            return false;
        }

        public void ColligereCrinis() {
            while(_emissioCrinis.ConareLego(out var r)) {
                if(!_lacusCrinis.ConarePono(r)) {
                    r.Purgere();
                    r.Liberare();
                    Notarius.Memorare(LogTextus.LacusOrdinatioPuellae_ORDINATIOPUELLAECRINIS_LACUS_FULL);
                }
            }
        }

        public void ColligereOmnia() {
            ColligereCrinis();
        }
    }
}
