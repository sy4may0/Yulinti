using Yulinti.Nucleus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class LacusOrdinatioPuellaeCrinis {
        private readonly Lacus<OrdinatioPuellaeCrinisBasis> _lacusCrinisBasis;
        private readonly Lacus<OrdinatioPuellaeCrinisAnterior> _lacusCrinisAnterior;
        private readonly Lacus<OrdinatioPuellaeCrinisPosterior> _lacusCrinisPosterior;

        private readonly Ordo<OrdinatioPuellaeCrinisBasis> _emissioCrinisBasis;
        private readonly Ordo<OrdinatioPuellaeCrinisAnterior> _emissioCrinisAnterior;
        private readonly Ordo<OrdinatioPuellaeCrinisPosterior> _emissioCrinisPosterior;

        public LacusOrdinatioPuellaeCrinis() {
            _lacusCrinisBasis = new Lacus<OrdinatioPuellaeCrinisBasis>(
                ConstansPuellae.LongitudoOrdinatioCrinis
            );
            _lacusCrinisAnterior = new Lacus<OrdinatioPuellaeCrinisAnterior>(
                ConstansPuellae.LongitudoOrdinatioCrinis
            );
            _lacusCrinisPosterior = new Lacus<OrdinatioPuellaeCrinisPosterior>(
                ConstansPuellae.LongitudoOrdinatioCrinis
            );
            _emissioCrinisBasis = new Ordo<OrdinatioPuellaeCrinisBasis>(
                ConstansPuellae.LongitudoOrdinatioCrinis
            );
            _emissioCrinisAnterior = new Ordo<OrdinatioPuellaeCrinisAnterior>(
                ConstansPuellae.LongitudoOrdinatioCrinis
            );
            _emissioCrinisPosterior = new Ordo<OrdinatioPuellaeCrinisPosterior>(
                ConstansPuellae.LongitudoOrdinatioCrinis
            );
        }

        public bool EmittareCrinisBasis(out OrdinatioPuellaeCrinisBasis crinisBasis) {
            if (_lacusCrinisBasis.ConareLego(out var r)) {
                if(_emissioCrinisBasis.ConarePono(r)) {
                    crinisBasis = r;
                    crinisBasis.Initare();
                    return true;
                }
                Notarius.Memorare(LogTextus.LacusOrdinatioPuellae_ORDINATIOPUELLAECRINISBASIS_EMISSIO_QUEUE_FULL);
                crinisBasis = null;
                return false;
            }
            Notarius.Memorare(LogTextus.LacusOrdinatioPuellae_ORDINATIOPUELLAECRINISBASIS_LACUS_EMPTY);
            crinisBasis = null;
            return false;
        }

        public bool EmittareCrinisAnterior(out OrdinatioPuellaeCrinisAnterior crinisAnterior) {
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

        public bool EmittareCrinisPosterior(out OrdinatioPuellaeCrinisPosterior crinisPosterior) {
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

        public void ColligereCrinisBasis() {
            while(_emissioCrinisBasis.ConareLego(out var r)) {
                if(!_lacusCrinisBasis.ConarePono(r)) {
                    r.Purgere();
                    r.Liberare();
                    Notarius.Memorare(LogTextus.LacusOrdinatioPuellae_ORDINATIOPUELLAECRINISBASIS_LACUS_FULL);
                }
            }
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
            ColligereCrinisBasis();
            ColligereCrinisAnterior();
            ColligereCrinisPosterior();
        }
    }
}
