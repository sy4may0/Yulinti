using System.Collections.Generic;
using Yulinti.Nucleus.Instrumentarium;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class LacusOrdinatioCivisAnimationis {
        private readonly Stack<OrdinatioCivisAnimationis>[] _lacusAnimationis;

        private readonly Ordo<OrdinatioCivisAnimationis>[] _emissioAnimationis;

        public LacusOrdinatioCivisAnimationis(int longitudoCivis) {
            _lacusAnimationis = new Stack<OrdinatioCivisAnimationis>[longitudoCivis];

            _emissioAnimationis = new Ordo<OrdinatioCivisAnimationis>[longitudoCivis];

            for (int i = 0; i < longitudoCivis; i++) {
                _lacusAnimationis[i] = new Stack<OrdinatioCivisAnimationis>(ConstansCivis.LongitudoOrdinatioAnimationis);

                _emissioAnimationis[i] = new Ordo<OrdinatioCivisAnimationis>(ConstansCivis.LongitudoOrdinatioAnimationis);

                for (int j = 0; j < ConstansCivis.LongitudoOrdinatioAnimationis; j++) {
                    _lacusAnimationis[i].Push(new OrdinatioCivisAnimationis(i));
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

        public void ColligereOmnia(int idCivis) {
            ColligereAnimationis(idCivis);
        }
    }
}
