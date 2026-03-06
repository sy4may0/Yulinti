using Yulinti.Nucleus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Exercitus.Dux {
    internal sealed class LacusOrdinatioPuellae {
        private readonly Lacus<OrdinatioPuellaeAnimationis> _lacusAnimationis;
        private readonly Lacus<OrdinatioPuellaeCrinis> _lacusCrinis;
        private readonly Lacus<OrdinatioPuellaeFiguraeGenus> _lacusFiguraeGenus;
        private readonly Lacus<OrdinatioPuellaeFiguraePelvis> _lacusFiguraePelvis;
        private readonly Lacus<OrdinatioPuellaeMotus> _lacusMotus;
        private readonly Lacus<OrdinatioPuellaeNavmesh> _lacusNavmesh;
        private readonly Lacus<OrdinatioPuellaeNavmeshInitii> _lacusNavmeshInitii;
        private readonly Lacus<OrdinatioPuellaeVeletudinis> _lacusVeletudinis;
        private readonly Lacus<OrdinatioPuellaeVeletudinisNudi> _lacusVeletudinisNudi;
        private readonly Lacus<OrdinatioPuellaePersonae> _lacusPersonae;

        private readonly DuxQueue<OrdinatioPuellaeAnimationis> _emissioAnimationis;
        private readonly DuxQueue<OrdinatioPuellaeCrinis> _emissioCrinis;
        private readonly DuxQueue<OrdinatioPuellaeFiguraeGenus> _emissioFiguraeGenus;
        private readonly DuxQueue<OrdinatioPuellaeFiguraePelvis> _emissioFiguraePelvis;
        private readonly DuxQueue<OrdinatioPuellaeMotus> _emissioMotus;
        private readonly DuxQueue<OrdinatioPuellaeNavmesh> _emissioNavmesh;
        private readonly DuxQueue<OrdinatioPuellaeNavmeshInitii> _emissioNavmeshInitii;
        private readonly DuxQueue<OrdinatioPuellaeVeletudinis> _emissioVeletudinis;
        private readonly DuxQueue<OrdinatioPuellaeVeletudinisNudi> _emissioVeletudinisNudi;
        private readonly DuxQueue<OrdinatioPuellaePersonae> _emissioPersonae;

        public LacusOrdinatioPuellae() {
            _lacusAnimationis = new Lacus<OrdinatioPuellaeAnimationis>(
                ConstansPuellae.LongitudoOrdinatioAnimationis
            );
            _lacusCrinis = new Lacus<OrdinatioPuellaeCrinis>(
                ConstansPuellae.LongitudoOrdinatioCrinis
            );
            _lacusFiguraeGenus = new Lacus<OrdinatioPuellaeFiguraeGenus>(
                ConstansPuellae.LongitudoOrdinatioFiguraeGenus
            );
            _lacusFiguraePelvis = new Lacus<OrdinatioPuellaeFiguraePelvis>(
                ConstansPuellae.LongitudoOrdinatioFiguraePelvis
            );
            _lacusMotus = new Lacus<OrdinatioPuellaeMotus>(
                ConstansPuellae.LongitudoOrdinatioMotus
            );
            _lacusNavmesh = new Lacus<OrdinatioPuellaeNavmesh>(
                ConstansPuellae.LongitudoOrdinatioNavmesh
            );
            _lacusNavmeshInitii = new Lacus<OrdinatioPuellaeNavmeshInitii>(
                ConstansPuellae.LongitudoOrdinatioNavmesh
            );
            _lacusVeletudinis = new Lacus<OrdinatioPuellaeVeletudinis>(
                ConstansPuellae.LongitudoOrdinatioVeletudinis
            );
            _lacusVeletudinisNudi = new Lacus<OrdinatioPuellaeVeletudinisNudi>(
                ConstansPuellae.LongitudoOrdinatioVeletudinisNudi
            );
            _lacusPersonae = new Lacus<OrdinatioPuellaePersonae>(12);

            _emissioAnimationis = new DuxQueue<OrdinatioPuellaeAnimationis>(
                ConstansPuellae.LongitudoOrdinatioAnimationis
            );
            _emissioCrinis = new DuxQueue<OrdinatioPuellaeCrinis>(
                ConstansPuellae.LongitudoOrdinatioCrinis
            );
            _emissioFiguraeGenus = new DuxQueue<OrdinatioPuellaeFiguraeGenus>(
                ConstansPuellae.LongitudoOrdinatioFiguraeGenus
            );
            _emissioFiguraePelvis = new DuxQueue<OrdinatioPuellaeFiguraePelvis>(
                ConstansPuellae.LongitudoOrdinatioFiguraePelvis
            );
            _emissioMotus = new DuxQueue<OrdinatioPuellaeMotus>(
                ConstansPuellae.LongitudoOrdinatioMotus
            );
            _emissioNavmesh = new DuxQueue<OrdinatioPuellaeNavmesh>(
                ConstansPuellae.LongitudoOrdinatioNavmesh
            );
            _emissioNavmeshInitii = new DuxQueue<OrdinatioPuellaeNavmeshInitii>(
                ConstansPuellae.LongitudoOrdinatioNavmesh
            );
            _emissioVeletudinis = new DuxQueue<OrdinatioPuellaeVeletudinis>(
                ConstansPuellae.LongitudoOrdinatioVeletudinis
            );
            _emissioVeletudinisNudi = new DuxQueue<OrdinatioPuellaeVeletudinisNudi>(
                ConstansPuellae.LongitudoOrdinatioVeletudinisNudi
            );
            _emissioPersonae = new DuxQueue<OrdinatioPuellaePersonae>(
                ConstansPuellae.LongitudoOrdinatioVeletudinis
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

        public void ColligereAnimationis() {
            while(_emissioAnimationis.ConareLego(out var r)) {
                if(!_lacusAnimationis.ConarePono(r)) {
                    r.Purgere();
                    r.Liberare();
                    Notarius.Memorare(LogTextus.LacusOrdinatioPuellae_ORDINATIOPUELLAEANIMATIONIS_LACUS_FULL);
                }
            }
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

        public void ColligereVeletudinis() {
            while(_emissioVeletudinis.ConareLego(out var r)) {
                if(!_lacusVeletudinis.ConarePono(r)) {
                    r.Purgere();
                    r.Liberare();
                    Notarius.Memorare(LogTextus.LacusOrdinatioPuellae_ORDINATIOPUELLAEVELETUDINIS_LACUS_FULL);
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
            ColligereAnimationis();
            ColligereCrinis();
            ColligereFiguraeGenus();
            ColligereFiguraePelvis();
            ColligereMotus();
            ColligereNavmesh();
            ColligereNavmeshInitii();
            ColligereVeletudinis();
            ColligereVeletudinisNudi();
            ColligerePersonae();
        }
    }
}
