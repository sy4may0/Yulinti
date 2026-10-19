using Yulinti.Nucleus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class LacusOrdinatioPuellaeLoci {
        private readonly Lacus<OrdinatioPuellaeMotus> _lacusMotus;
        private readonly Lacus<OrdinatioPuellaeNavmesh> _lacusNavmesh;
        private readonly Lacus<OrdinatioPuellaeNavmeshInitii> _lacusNavmeshInitii;

        private readonly Ordo<OrdinatioPuellaeMotus> _emissioMotus;
        private readonly Ordo<OrdinatioPuellaeNavmesh> _emissioNavmesh;
        private readonly Ordo<OrdinatioPuellaeNavmeshInitii> _emissioNavmeshInitii;

        public LacusOrdinatioPuellaeLoci() {
            _lacusMotus = new Lacus<OrdinatioPuellaeMotus>(
                ConstansPuellae.LongitudoOrdinatioMotus
            );
            _lacusNavmesh = new Lacus<OrdinatioPuellaeNavmesh>(
                ConstansPuellae.LongitudoOrdinatioNavmesh
            );
            _lacusNavmeshInitii = new Lacus<OrdinatioPuellaeNavmeshInitii>(
                ConstansPuellae.LongitudoOrdinatioNavmesh
            );
            _emissioMotus = new Ordo<OrdinatioPuellaeMotus>(
                ConstansPuellae.LongitudoOrdinatioMotus
            );
            _emissioNavmesh = new Ordo<OrdinatioPuellaeNavmesh>(
                ConstansPuellae.LongitudoOrdinatioNavmesh
            );
            _emissioNavmeshInitii = new Ordo<OrdinatioPuellaeNavmeshInitii>(
                ConstansPuellae.LongitudoOrdinatioNavmesh
            );
        }

        public bool EmittareMotus(out OrdinatioPuellaeMotus motus) {
            if (_lacusMotus.ConareLego(out var r)) {
                if(_emissioMotus.ConarePono(r)) {
                    motus = r;
                    motus.Initare();
                    return true;
                }
                Notarius.Memorare(LogTextus.LacusOrdinatioPuellae_ORDINATIOPUELLAEMOTUS_EMISSIO_QUEUE_FULL);
                motus = null;
                return false;
            }
            Notarius.Memorare(LogTextus.LacusOrdinatioPuellae_ORDINATIOPUELLAEMOTUS_LACUS_EMPTY);
            motus = null;
            return false;
        }

        public bool EmittareNavmesh(out OrdinatioPuellaeNavmesh navmesh) {
            if (_lacusNavmesh.ConareLego(out var r)) {
                if(_emissioNavmesh.ConarePono(r)) {
                    navmesh = r;
                    navmesh.Initare();
                    return true;
                }
                Notarius.Memorare(LogTextus.LacusOrdinatioPuellae_ORDINATIOPUELLAENAVMESH_EMISSIO_QUEUE_FULL);
                navmesh = null;
                return false;
            }
            Notarius.Memorare(LogTextus.LacusOrdinatioPuellae_ORDINATIOPUELLAENAVMESH_LACUS_EMPTY);
            navmesh = null;
            return false;
        }

        public bool EmittareNavmeshInitii(out OrdinatioPuellaeNavmeshInitii navmeshInitii) {
            if (_lacusNavmeshInitii.ConareLego(out var r)) {
                if(_emissioNavmeshInitii.ConarePono(r)) {
                    navmeshInitii = r;
                    navmeshInitii.Initare();
                    return true;
                }
                Notarius.Memorare(LogTextus.LacusOrdinatioPuellae_ORDINATIOPUELLAENAVMESH_EMISSIO_QUEUE_FULL);
                navmeshInitii = null;
                return false;
            }
            Notarius.Memorare(LogTextus.LacusOrdinatioPuellae_ORDINATIOPUELLAENAVMESH_LACUS_EMPTY);
            navmeshInitii = null;
            return false;
        }

        public void ColligereMotus() {
            while(_emissioMotus.ConareLego(out var r)) {
                if(!_lacusMotus.ConarePono(r)) {
                    r.Purgere();
                    r.Liberare();
                    Notarius.Memorare(LogTextus.LacusOrdinatioPuellae_ORDINATIOPUELLAEMOTUS_LACUS_FULL);
                }
            }
        }

        public void ColligereNavmesh() {
            while(_emissioNavmesh.ConareLego(out var r)) {
                if(!_lacusNavmesh.ConarePono(r)) {
                    r.Purgere();
                    r.Liberare();
                    Notarius.Memorare(LogTextus.LacusOrdinatioPuellae_ORDINATIOPUELLAENAVMESH_LACUS_FULL);
                }
            }
        }

        public void ColligereNavmeshInitii() {
            while(_emissioNavmeshInitii.ConareLego(out var r)) {
                if(!_lacusNavmeshInitii.ConarePono(r)) {
                    r.Purgere();
                    r.Liberare();
                    Notarius.Memorare(LogTextus.LacusOrdinatioPuellae_ORDINATIOPUELLAENAVMESH_LACUS_FULL);
                }
            }
        }

        public void ColligereOmnia() {
            ColligereMotus();
            ColligereNavmesh();
            ColligereNavmeshInitii();
        }
    }
}
