using System.Collections.Generic;

namespace Yulinti.Dux.Exercitus {
    internal sealed class LacusOrdinatioCivis {
        private readonly Stack<OrdinatioCivisAnimationis>[] _lacusAnimationis;
        private readonly Stack<OrdinatioCivisMotus>[] _lacusMotus;
        private readonly Stack<OrdinatioCivisNavmesh>[] _lacusNavmesh;
        private readonly Stack<OrdinatioCivisVeletudinisValoris>[] _lacusVeletudinisValoris;
        private readonly Stack<OrdinatioCivisMortis>[] _lacusMortis;

        private readonly DuxQueue<OrdinatioCivisAnimationis>[] _emissioAnimationis;
        private readonly DuxQueue<OrdinatioCivisMotus>[] _emissioMotus;
        private readonly DuxQueue<OrdinatioCivisNavmesh>[] _emissioNavmesh;
        private readonly DuxQueue<OrdinatioCivisVeletudinisValoris>[] _emissioVeletudinisValoris;
        private readonly DuxQueue<OrdinatioCivisMortis>[] _emissioMortis;

        public LacusOrdinatioCivis(int longitudoCivis) {
            _lacusAnimationis = new Stack<OrdinatioCivisAnimationis>[longitudoCivis];
            _lacusMotus = new Stack<OrdinatioCivisMotus>[longitudoCivis];
            _lacusNavmesh = new Stack<OrdinatioCivisNavmesh>[longitudoCivis];
            _lacusVeletudinisValoris = new Stack<OrdinatioCivisVeletudinisValoris>[longitudoCivis];
            _lacusMortis = new Stack<OrdinatioCivisMortis>[longitudoCivis];

            _emissioAnimationis = new DuxQueue<OrdinatioCivisAnimationis>[longitudoCivis];
            _emissioMotus = new DuxQueue<OrdinatioCivisMotus>[longitudoCivis];
            _emissioNavmesh = new DuxQueue<OrdinatioCivisNavmesh>[longitudoCivis];
            _emissioVeletudinisValoris = new DuxQueue<OrdinatioCivisVeletudinisValoris>[longitudoCivis];
            _emissioMortis = new DuxQueue<OrdinatioCivisMortis>[longitudoCivis];

            for (int i = 0; i < longitudoCivis; i++) {
                _lacusAnimationis[i] = new Stack<OrdinatioCivisAnimationis>(ConstansCivis.LongitudoOrdinatioAnimationis);
                _lacusMotus[i] = new Stack<OrdinatioCivisMotus>(ConstansCivis.LongitudoOrdinatioMotus);
                _lacusNavmesh[i] = new Stack<OrdinatioCivisNavmesh>(ConstansCivis.LongitudoOrdinatioNavmesh);
                _lacusVeletudinisValoris[i] = new Stack<OrdinatioCivisVeletudinisValoris>(ConstansCivis.LongitudoOrdinatioVeletudinisValoris);
                _lacusMortis[i] = new Stack<OrdinatioCivisMortis>(ConstansCivis.LongitudoOrdinatioMortis);

                _emissioAnimationis[i] = new DuxQueue<OrdinatioCivisAnimationis>(ConstansCivis.LongitudoOrdinatioAnimationis);
                _emissioMotus[i] = new DuxQueue<OrdinatioCivisMotus>(ConstansCivis.LongitudoOrdinatioMotus);
                _emissioNavmesh[i] = new DuxQueue<OrdinatioCivisNavmesh>(ConstansCivis.LongitudoOrdinatioNavmesh);
                _emissioVeletudinisValoris[i] = new DuxQueue<OrdinatioCivisVeletudinisValoris>(ConstansCivis.LongitudoOrdinatioVeletudinisValoris);
                _emissioMortis[i] = new DuxQueue<OrdinatioCivisMortis>(ConstansCivis.LongitudoOrdinatioMortis);

                for (int j = 0; j < ConstansCivis.LongitudoOrdinatioAnimationis; j++) {
                    _lacusAnimationis[i].Push(new OrdinatioCivisAnimationis(i));
                }
                for (int j = 0; j < ConstansCivis.LongitudoOrdinatioMotus; j++) {
                    _lacusMotus[i].Push(new OrdinatioCivisMotus(i));
                }
                for (int j = 0; j < ConstansCivis.LongitudoOrdinatioNavmesh; j++) {
                    _lacusNavmesh[i].Push(new OrdinatioCivisNavmesh(i));
                }
                for (int j = 0; j < ConstansCivis.LongitudoOrdinatioVeletudinisValoris; j++) {
                    _lacusVeletudinisValoris[i].Push(new OrdinatioCivisVeletudinisValoris(i));
                }
                for (int j = 0; j < ConstansCivis.LongitudoOrdinatioMortis; j++) {
                    _lacusMortis[i].Push(new OrdinatioCivisMortis(i));
                }
            }
        }

        public bool EmittareAnimationis(int idCivis, out OrdinatioCivisAnimationis animationis) {
            if (_lacusAnimationis[idCivis].Count > 0) {
                var r = _lacusAnimationis[idCivis].Pop();
                if (_emissioAnimationis[idCivis].ConarePono(r)) {
                    animationis = r;
                    animationis.Initare();
                    return true;
                }
            }
            animationis = null;
            return false;
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

        public bool EmittareVeletudinisValoris(int idCivis, out OrdinatioCivisVeletudinisValoris veletudinisValoris) {
            if (_lacusVeletudinisValoris[idCivis].Count > 0) {
                var r = _lacusVeletudinisValoris[idCivis].Pop();
                if (_emissioVeletudinisValoris[idCivis].ConarePono(r)) {
                    veletudinisValoris = r;
                    veletudinisValoris.Initare();
                    return true;
                }
            }
            veletudinisValoris = null;
            return false;
        }

        public bool EmittareMortis(int idCivis, out OrdinatioCivisMortis mortis) {
            if (_lacusMortis[idCivis].Count > 0) {
                var r = _lacusMortis[idCivis].Pop();
                if (_emissioMortis[idCivis].ConarePono(r)) {
                    mortis = r;
                    mortis.Initare();
                    return true;
                }
            }
            mortis = null;
            return false;
        }

        public void ColligereAnimationis(int idCivis) {
            while (_emissioAnimationis[idCivis].ConareLego(out var r)) {
                if (_lacusAnimationis[idCivis].Count < ConstansCivis.LongitudoOrdinatioAnimationis) {
                    _lacusAnimationis[idCivis].Push(r);
                } else {
                    r.Purgere();
                    r.Liberare();
                }
            }
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

        public void ColligereVeletudinisValoris(int idCivis) {
            while (_emissioVeletudinisValoris[idCivis].ConareLego(out var r)) {
                if (_lacusVeletudinisValoris[idCivis].Count < ConstansCivis.LongitudoOrdinatioVeletudinisValoris) {
                    _lacusVeletudinisValoris[idCivis].Push(r);
                } else {
                    r.Purgere();
                    r.Liberare();
                }
            }
        }

        public void ColligereMortis(int idCivis) {
            while (_emissioMortis[idCivis].ConareLego(out var r)) {
                if (_lacusMortis[idCivis].Count < ConstansCivis.LongitudoOrdinatioMortis) {
                    _lacusMortis[idCivis].Push(r);
                } else {
                    r.Purgere();
                    r.Liberare();
                }
            }
        }

        public void ColligereOmnia(int idCivis) {
            ColligereAnimationis(idCivis);
            ColligereMotus(idCivis);
            ColligereNavmesh(idCivis);
            ColligereVeletudinisValoris(idCivis);
            ColligereMortis(idCivis);
        }
    }
}
