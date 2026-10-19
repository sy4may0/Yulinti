using System.Collections.Generic;
using Yulinti.Nucleus.Instrumentarium;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class LacusOrdinatioCivisVeletudinis {
        private readonly Stack<OrdinatioCivisVeletudinisValoris>[] _lacusVeletudinisValoris;
        private readonly Stack<OrdinatioCivisVeletudinisMaxima>[] _lacusVeletudinisMaxima;
        private readonly Stack<OrdinatioCivisVeletudinisCondicionis>[] _lacusVeletudinisCondicionis;

        private readonly Ordo<OrdinatioCivisVeletudinisValoris>[] _emissioVeletudinisValoris;
        private readonly Ordo<OrdinatioCivisVeletudinisMaxima>[] _emissioVeletudinisMaxima;
        private readonly Ordo<OrdinatioCivisVeletudinisCondicionis>[] _emissioVeletudinisCondicionis;

        public LacusOrdinatioCivisVeletudinis(int longitudoCivis) {
            _lacusVeletudinisValoris = new Stack<OrdinatioCivisVeletudinisValoris>[longitudoCivis];
            _lacusVeletudinisMaxima = new Stack<OrdinatioCivisVeletudinisMaxima>[longitudoCivis];
            _lacusVeletudinisCondicionis = new Stack<OrdinatioCivisVeletudinisCondicionis>[longitudoCivis];

            _emissioVeletudinisValoris = new Ordo<OrdinatioCivisVeletudinisValoris>[longitudoCivis];
            _emissioVeletudinisMaxima = new Ordo<OrdinatioCivisVeletudinisMaxima>[longitudoCivis];
            _emissioVeletudinisCondicionis = new Ordo<OrdinatioCivisVeletudinisCondicionis>[longitudoCivis];

            for (int i = 0; i < longitudoCivis; i++) {
                _lacusVeletudinisValoris[i] = new Stack<OrdinatioCivisVeletudinisValoris>(ConstansCivis.LongitudoOrdinatioVeletudinisValoris);
                _lacusVeletudinisMaxima[i] = new Stack<OrdinatioCivisVeletudinisMaxima>(ConstansCivis.LongitudoOrdinatioVeletudinisMaxima);
                _lacusVeletudinisCondicionis[i] = new Stack<OrdinatioCivisVeletudinisCondicionis>(ConstansCivis.LongitudoOrdinatioVeletudinisCondicionis);

                _emissioVeletudinisValoris[i] = new Ordo<OrdinatioCivisVeletudinisValoris>(ConstansCivis.LongitudoOrdinatioVeletudinisValoris);
                _emissioVeletudinisMaxima[i] = new Ordo<OrdinatioCivisVeletudinisMaxima>(ConstansCivis.LongitudoOrdinatioVeletudinisMaxima);
                _emissioVeletudinisCondicionis[i] = new Ordo<OrdinatioCivisVeletudinisCondicionis>(ConstansCivis.LongitudoOrdinatioVeletudinisCondicionis);

                for (int j = 0; j < ConstansCivis.LongitudoOrdinatioVeletudinisValoris; j++) {
                    _lacusVeletudinisValoris[i].Push(new OrdinatioCivisVeletudinisValoris(i));
                }
                for (int j = 0; j < ConstansCivis.LongitudoOrdinatioVeletudinisMaxima; j++) {
                    _lacusVeletudinisMaxima[i].Push(new OrdinatioCivisVeletudinisMaxima(i));
                }
                for (int j = 0; j < ConstansCivis.LongitudoOrdinatioVeletudinisCondicionis; j++) {
                    _lacusVeletudinisCondicionis[i].Push(new OrdinatioCivisVeletudinisCondicionis(i));
                }
            }
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

        public bool EmittareVeletudinisMaxima(int idCivis, out OrdinatioCivisVeletudinisMaxima veletudinisMaxima) {
            if (_lacusVeletudinisMaxima[idCivis].Count > 0) {
                var r = _lacusVeletudinisMaxima[idCivis].Pop();
                if (_emissioVeletudinisMaxima[idCivis].ConarePono(r)) {
                    veletudinisMaxima = r;
                    veletudinisMaxima.Initare();
                    return true;
                }
            }
            veletudinisMaxima = null;
            return false;
        }

        public bool EmittareVeletudinisCondicionis(int idCivis, out OrdinatioCivisVeletudinisCondicionis veletudinisCondicionis) {
            if (_lacusVeletudinisCondicionis[idCivis].Count > 0) {
                var r = _lacusVeletudinisCondicionis[idCivis].Pop();
                if (_emissioVeletudinisCondicionis[idCivis].ConarePono(r)) {
                    veletudinisCondicionis = r;
                    veletudinisCondicionis.Initare();
                    return true;
                }
            }
            veletudinisCondicionis = null;
            return false;
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

        public void ColligereVeletudinisMaxima(int idCivis) {
            while (_emissioVeletudinisMaxima[idCivis].ConareLego(out var r)) {
                if (_lacusVeletudinisMaxima[idCivis].Count < ConstansCivis.LongitudoOrdinatioVeletudinisMaxima) {
                    _lacusVeletudinisMaxima[idCivis].Push(r);
                } else {
                    r.Purgere();
                    r.Liberare();
                }
            }
        }

        public void ColligereVeletudinisCondicionis(int idCivis) {
            while (_emissioVeletudinisCondicionis[idCivis].ConareLego(out var r)) {
                if (_lacusVeletudinisCondicionis[idCivis].Count < ConstansCivis.LongitudoOrdinatioVeletudinisCondicionis) {
                    _lacusVeletudinisCondicionis[idCivis].Push(r);
                } else {
                    r.Purgere();
                    r.Liberare();
                }
            }
        }

        public void ColligereOmnia(int idCivis) {
            ColligereVeletudinisValoris(idCivis);
            ColligereVeletudinisMaxima(idCivis);
            ColligereVeletudinisCondicionis(idCivis);
        }
    }
}
