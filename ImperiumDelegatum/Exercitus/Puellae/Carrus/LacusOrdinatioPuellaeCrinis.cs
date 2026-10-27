using Yulinti.Nucleus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class LacusOrdinatioPuellaeCrinis {
        private readonly Lacus<OrdinatioPuellaeCrinisCollectionisAnterior> _lacusCrinisAnterior;
        private readonly Lacus<OrdinatioPuellaeCrinisCollectionisPosterior> _lacusCrinisPosterior;

        private readonly Ordo<OrdinatioPuellaeCrinisCollectionisAnterior> _emissioCrinisAnterior;
        private readonly Ordo<OrdinatioPuellaeCrinisCollectionisPosterior> _emissioCrinisPosterior;

        public LacusOrdinatioPuellaeCrinis() {
            _lacusCrinisAnterior = new Lacus<OrdinatioPuellaeCrinisCollectionisAnterior>(
                ConstansPuellae.LongitudoOrdinatioCrinis
            );
            _lacusCrinisPosterior = new Lacus<OrdinatioPuellaeCrinisCollectionisPosterior>(
                ConstansPuellae.LongitudoOrdinatioCrinis
            );
            _emissioCrinisAnterior = new Ordo<OrdinatioPuellaeCrinisCollectionisAnterior>(
                ConstansPuellae.LongitudoOrdinatioCrinis
            );
            _emissioCrinisPosterior = new Ordo<OrdinatioPuellaeCrinisCollectionisPosterior>(
                ConstansPuellae.LongitudoOrdinatioCrinis
            );
        }

        public bool EmittareCrinisAnterior(out OrdinatioPuellaeCrinisCollectionisAnterior crinisAnterior) {
            if (_lacusCrinisAnterior.ConareLego(out var r)) {
                if(_emissioCrinisAnterior.ConarePono(r)) {
                    crinisAnterior = r;
                    crinisAnterior.Initare();
                    return true;
                }
                Notarius.Memorare(LogTextus.LacusOrdinatioPuellae_ORDINATIOPUELLAECRINISANTERIOR_EMISSIO_QUEUE_FULL);
                crinisAnterior = null;
                return false;
            }
            Notarius.Memorare(LogTextus.LacusOrdinatioPuellae_ORDINATIOPUELLAECRINISANTERIOR_LACUS_EMPTY);
            crinisAnterior = null;
            return false;
        }

        public bool EmittareCrinisPosterior(out OrdinatioPuellaeCrinisCollectionisPosterior crinisPosterior) {
            if (_lacusCrinisPosterior.ConareLego(out var r)) {
                if(_emissioCrinisPosterior.ConarePono(r)) {
                    crinisPosterior = r;
                    crinisPosterior.Initare();
                    return true;
                }
                Notarius.Memorare(LogTextus.LacusOrdinatioPuellae_ORDINATIOPUELLAECRINISPOSTERIOR_EMISSIO_QUEUE_FULL);
                crinisPosterior = null;
                return false;
            }
            Notarius.Memorare(LogTextus.LacusOrdinatioPuellae_ORDINATIOPUELLAECRINISPOSTERIOR_LACUS_EMPTY);
            crinisPosterior = null;
            return false;
        }

        public void ColligereCrinisAnterior() {
            while(_emissioCrinisAnterior.ConareLego(out var r)) {
                if(!_lacusCrinisAnterior.ConarePono(r)) {
                    r.Purgere();
                    r.Liberare();
                    Notarius.Memorare(LogTextus.LacusOrdinatioPuellae_ORDINATIOPUELLAECRINISANTERIOR_LACUS_FULL);
                }
            }
        }

        public void ColligereCrinisPosterior() {
            while(_emissioCrinisPosterior.ConareLego(out var r)) {
                if(!_lacusCrinisPosterior.ConarePono(r)) {
                    r.Purgere();
                    r.Liberare();
                    Notarius.Memorare(LogTextus.LacusOrdinatioPuellae_ORDINATIOPUELLAECRINISPOSTERIOR_LACUS_FULL);
                }
            }
        }

        public void ColligereOmnia() {
            ColligereCrinisAnterior();
            ColligereCrinisPosterior();
        }
    }
}
