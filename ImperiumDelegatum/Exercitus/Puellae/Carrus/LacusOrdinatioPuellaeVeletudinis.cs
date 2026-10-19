using Yulinti.Nucleus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class LacusOrdinatioPuellaeVeletudinis {
        private readonly Lacus<OrdinatioPuellaeVeletudinis> _lacusVeletudinis;
        private readonly Lacus<OrdinatioPuellaeVeletudinisMaxima> _lacusVeletudinisMaxima;
        private readonly Lacus<OrdinatioPuellaeVeletudinisNudi> _lacusVeletudinisNudi;

        private readonly Ordo<OrdinatioPuellaeVeletudinis> _emissioVeletudinis;
        private readonly Ordo<OrdinatioPuellaeVeletudinisMaxima> _emissioVeletudinisMaxima;
        private readonly Ordo<OrdinatioPuellaeVeletudinisNudi> _emissioVeletudinisNudi;

        public LacusOrdinatioPuellaeVeletudinis() {
            _lacusVeletudinis = new Lacus<OrdinatioPuellaeVeletudinis>(
                ConstansPuellae.LongitudoOrdinatioVeletudinis
            );
            _lacusVeletudinisMaxima = new Lacus<OrdinatioPuellaeVeletudinisMaxima>(
                ConstansPuellae.LongitudoOrdinatioVeletudinisMaxima
            );
            _lacusVeletudinisNudi = new Lacus<OrdinatioPuellaeVeletudinisNudi>(
                ConstansPuellae.LongitudoOrdinatioVeletudinisNudi
            );
            _emissioVeletudinis = new Ordo<OrdinatioPuellaeVeletudinis>(
                ConstansPuellae.LongitudoOrdinatioVeletudinis
            );
            _emissioVeletudinisMaxima = new Ordo<OrdinatioPuellaeVeletudinisMaxima>(
                ConstansPuellae.LongitudoOrdinatioVeletudinisMaxima
            );
            _emissioVeletudinisNudi = new Ordo<OrdinatioPuellaeVeletudinisNudi>(
                ConstansPuellae.LongitudoOrdinatioVeletudinisNudi
            );
        }

        public bool EmittareVeletudinis(out OrdinatioPuellaeVeletudinis veletudinis) {
            if (_lacusVeletudinis.ConareLego(out var r)) {
                if(_emissioVeletudinis.ConarePono(r)) {
                    veletudinis = r;
                    veletudinis.Initare();
                    return true;
                }
                Notarius.Memorare(LogTextus.LacusOrdinatioPuellae_ORDINATIOPUELLAEVELETUDINIS_EMISSIO_QUEUE_FULL);
                veletudinis = null;
                return false;
            }
            Notarius.Memorare(LogTextus.LacusOrdinatioPuellae_ORDINATIOPUELLAEVELETUDINIS_LACUS_EMPTY);
            veletudinis = null;
            return false;
        }

        public bool EmittareVeletudinisMaxima(out OrdinatioPuellaeVeletudinisMaxima veletudinisMaxima) {
            if (_lacusVeletudinisMaxima.ConareLego(out var r)) {
                if(_emissioVeletudinisMaxima.ConarePono(r)) {
                    veletudinisMaxima = r;
                    veletudinisMaxima.Initare();
                    return true;
                }
                Notarius.Memorare(LogTextus.LacusOrdinatioPuellae_ORDINATIOPUELLAEVELETUDINISMAXIMA_EMISSIO_QUEUE_FULL);
                veletudinisMaxima = null;
                return false;
            }
            Notarius.Memorare(LogTextus.LacusOrdinatioPuellae_ORDINATIOPUELLAEVELETUDINISMAXIMA_LACUS_EMPTY);
            veletudinisMaxima = null;
            return false;
        }

        public bool EmittareVeletudinisNudi(out OrdinatioPuellaeVeletudinisNudi veletudinisNudi) {
            if (_lacusVeletudinisNudi.ConareLego(out var r)) {
                if(_emissioVeletudinisNudi.ConarePono(r)) {
                    veletudinisNudi = r;
                    veletudinisNudi.Initare();
                    return true;
                }
                Notarius.Memorare(LogTextus.LacusOrdinatioPuellae_ORDINATIOPUELLAEVELETUDINISNUDI_EMISSIO_QUEUE_FULL);
                veletudinisNudi = null;
                return false;
            }
            Notarius.Memorare(LogTextus.LacusOrdinatioPuellae_ORDINATIOPUELLAEVELETUDINISNUDI_LACUS_EMPTY);
            veletudinisNudi = null;
            return false;
        }

        public void ColligereVeletudinis() {
            while(_emissioVeletudinis.ConareLego(out var r)) {
                if(!_lacusVeletudinis.ConarePono(r)) {
                    r.Purgere();
                    r.Liberare();
                    Notarius.Memorare(LogTextus.LacusOrdinatioPuellae_ORDINATIOPUELLAEVELETUDINIS_LACUS_FULL);
                }
            }
        }

        public void ColligereVeletudinisMaxima() {
            while(_emissioVeletudinisMaxima.ConareLego(out var r)) {
                if(!_lacusVeletudinisMaxima.ConarePono(r)) {
                    r.Purgere();
                    r.Liberare();
                    Notarius.Memorare(LogTextus.LacusOrdinatioPuellae_ORDINATIOPUELLAEVELETUDINISMAXIMA_LACUS_FULL);
                }
            }
        }

        public void ColligereVeletudinisNudi() {
            while(_emissioVeletudinisNudi.ConareLego(out var r)) {
                if(!_lacusVeletudinisNudi.ConarePono(r)) {
                    r.Purgere();
                    r.Liberare();
                    Notarius.Memorare(LogTextus.LacusOrdinatioPuellae_ORDINATIOPUELLAEVELETUDINISNUDI_LACUS_FULL);
                }
            }
        }

        public void ColligereOmnia() {
            ColligereVeletudinis();
            ColligereVeletudinisMaxima();
            ColligereVeletudinisNudi();
        }
    }
}
