using Yulinti.Nucleus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class LacusOrdinatioPuellaeFigurae {
        private readonly Lacus<OrdinatioPuellaeFiguraeGenus> _lacusFiguraeGenus;
        private readonly Lacus<OrdinatioPuellaeFiguraePelvis> _lacusFiguraePelvis;

        private readonly Ordo<OrdinatioPuellaeFiguraeGenus> _emissioFiguraeGenus;
        private readonly Ordo<OrdinatioPuellaeFiguraePelvis> _emissioFiguraePelvis;

        public LacusOrdinatioPuellaeFigurae() {
            _lacusFiguraeGenus = new Lacus<OrdinatioPuellaeFiguraeGenus>(
                ConstansPuellae.LongitudoOrdinatioFiguraeGenus
            );
            _lacusFiguraePelvis = new Lacus<OrdinatioPuellaeFiguraePelvis>(
                ConstansPuellae.LongitudoOrdinatioFiguraePelvis
            );
            _emissioFiguraeGenus = new Ordo<OrdinatioPuellaeFiguraeGenus>(
                ConstansPuellae.LongitudoOrdinatioFiguraeGenus
            );
            _emissioFiguraePelvis = new Ordo<OrdinatioPuellaeFiguraePelvis>(
                ConstansPuellae.LongitudoOrdinatioFiguraePelvis
            );
        }

        public bool EmittareFiguraeGenus(out OrdinatioPuellaeFiguraeGenus figuraeGenus) {
            if (_lacusFiguraeGenus.ConareLego(out var r)) {
                if(_emissioFiguraeGenus.ConarePono(r)) {
                    figuraeGenus = r;
                    figuraeGenus.Initare();
                    return true;
                }
                Notarius.Memorare(LogTextus.LacusOrdinatioPuellae_ORDINATIOPUELLAEFIGURAEGENUS_EMISSIO_QUEUE_FULL);
                figuraeGenus = null;
                return false;
            }
            Notarius.Memorare(LogTextus.LacusOrdinatioPuellae_ORDINATIOPUELLAEFIGURAEGENUS_LACUS_EMPTY);
            figuraeGenus = null;
            return false;
        }

        public bool EmittareFiguraePelvis(out OrdinatioPuellaeFiguraePelvis figuraePelvis) {
            if (_lacusFiguraePelvis.ConareLego(out var r)) {
                if(_emissioFiguraePelvis.ConarePono(r)) {
                    figuraePelvis = r;
                    figuraePelvis.Initare();
                    return true;
                }
                Notarius.Memorare(LogTextus.LacusOrdinatioPuellae_ORDINATIOPUELLAEFIGURAEPELVIS_EMISSIO_QUEUE_FULL);
                figuraePelvis = null;
                return false;
            }
            Notarius.Memorare(LogTextus.LacusOrdinatioPuellae_ORDINATIOPUELLAEFIGURAEPELVIS_LACUS_EMPTY);
            figuraePelvis = null;
            return false;
        }

        public void ColligereFiguraeGenus() {
            while(_emissioFiguraeGenus.ConareLego(out var r)) {
                if(!_lacusFiguraeGenus.ConarePono(r)) {
                    r.Purgere();
                    r.Liberare();
                    Notarius.Memorare(LogTextus.LacusOrdinatioPuellae_ORDINATIOPUELLAEFIGURAEGENUS_LACUS_FULL);
                }
            }
        }

        public void ColligereFiguraePelvis() {
            while(_emissioFiguraePelvis.ConareLego(out var r)) {
                if(!_lacusFiguraePelvis.ConarePono(r)) {
                    r.Purgere();
                    r.Liberare();
                    Notarius.Memorare(LogTextus.LacusOrdinatioPuellae_ORDINATIOPUELLAEFIGURAEPELVIS_LACUS_FULL);
                }
            }
        }

        public void ColligereOmnia() {
            ColligereFiguraeGenus();
            ColligereFiguraePelvis();
        }
    }
}
