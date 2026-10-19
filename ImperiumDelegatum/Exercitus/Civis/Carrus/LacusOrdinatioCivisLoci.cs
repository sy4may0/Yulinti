using System.Collections.Generic;
using Yulinti.Nucleus.Instrumentarium;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class LacusOrdinatioCivisLoci {
        private readonly Stack<OrdinatioCivisMotus>[] _lacusMotus;
        private readonly Stack<OrdinatioCivisNavmesh>[] _lacusNavmesh;

        private readonly Ordo<OrdinatioCivisMotus>[] _emissioMotus;
        private readonly Ordo<OrdinatioCivisNavmesh>[] _emissioNavmesh;

        public LacusOrdinatioCivisLoci(int longitudoCivis) {
            _lacusMotus = new Stack<OrdinatioCivisMotus>[longitudoCivis];
            _lacusNavmesh = new Stack<OrdinatioCivisNavmesh>[longitudoCivis];

            _emissioMotus = new Ordo<OrdinatioCivisMotus>[longitudoCivis];
            _emissioNavmesh = new Ordo<OrdinatioCivisNavmesh>[longitudoCivis];

            for (int i = 0; i < longitudoCivis; i++) {
                _lacusMotus[i] = new Stack<OrdinatioCivisMotus>(ConstansCivis.LongitudoOrdinatioMotus);
                _lacusNavmesh[i] = new Stack<OrdinatioCivisNavmesh>(ConstansCivis.LongitudoOrdinatioNavmesh);

                _emissioMotus[i] = new Ordo<OrdinatioCivisMotus>(ConstansCivis.LongitudoOrdinatioMotus);
                _emissioNavmesh[i] = new Ordo<OrdinatioCivisNavmesh>(ConstansCivis.LongitudoOrdinatioNavmesh);

                for (int j = 0; j < ConstansCivis.LongitudoOrdinatioMotus; j++) {
                    _lacusMotus[i].Push(new OrdinatioCivisMotus(i));
                }
                for (int j = 0; j < ConstansCivis.LongitudoOrdinatioNavmesh; j++) {
                    _lacusNavmesh[i].Push(new OrdinatioCivisNavmesh(i));
                }
            }
        }

        public bool EmittareMotus(int idCivis, out OrdinatioCivisMotus motus) {
            if (_lacusMotus[idCivis].Count > 0) {
                var r = _lacusMotus[idCivis].Pop();
                if (_emissioMotus[idCivis].ConarePono(r)) {
                    motus = r;
                    motus.Initare();
                    return true;
                }
            }
            motus = null;
            return false;
        }

        public bool EmittareNavmesh(int idCivis, out OrdinatioCivisNavmesh navmesh) {
            if (_lacusNavmesh[idCivis].Count > 0) {
                var r = _lacusNavmesh[idCivis].Pop();
                if (_emissioNavmesh[idCivis].ConarePono(r)) {
                    navmesh = r;
                    navmesh.Initare();
                    return true;
                }
            }
            navmesh = null;
            return false;
        }

        public void ColligereMotus(int idCivis) {
            while (_emissioMotus[idCivis].ConareLego(out var r)) {
                if (_lacusMotus[idCivis].Count < ConstansCivis.LongitudoOrdinatioMotus) {
                    _lacusMotus[idCivis].Push(r);
                } else {
                    r.Purgere();
                    r.Liberare();
                }
            }
        }

        public void ColligereNavmesh(int idCivis) {
            while (_emissioNavmesh[idCivis].ConareLego(out var r)) {
                if (_lacusNavmesh[idCivis].Count < ConstansCivis.LongitudoOrdinatioNavmesh) {
                    _lacusNavmesh[idCivis].Push(r);
                } else {
                    r.Purgere();
                    r.Liberare();
                }
            }
        }

        public void ColligereOmnia(int idCivis) {
            ColligereMotus(idCivis);
            ColligereNavmesh(idCivis);
        }
    }
}
