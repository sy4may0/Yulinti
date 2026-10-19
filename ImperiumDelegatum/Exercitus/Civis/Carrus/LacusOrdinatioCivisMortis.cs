using System.Collections.Generic;
using Yulinti.Nucleus.Instrumentarium;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class LacusOrdinatioCivisMortis {
        private readonly Stack<OrdinatioCivisMortis>[] _lacusMortis;

        private readonly Ordo<OrdinatioCivisMortis>[] _emissioMortis;

        public LacusOrdinatioCivisMortis(int longitudoCivis) {
            _lacusMortis = new Stack<OrdinatioCivisMortis>[longitudoCivis];

            _emissioMortis = new Ordo<OrdinatioCivisMortis>[longitudoCivis];

            for (int i = 0; i < longitudoCivis; i++) {
                _lacusMortis[i] = new Stack<OrdinatioCivisMortis>(ConstansCivis.LongitudoOrdinatioMortis);

                _emissioMortis[i] = new Ordo<OrdinatioCivisMortis>(ConstansCivis.LongitudoOrdinatioMortis);

                for (int j = 0; j < ConstansCivis.LongitudoOrdinatioMortis; j++) {
                    _lacusMortis[i].Push(new OrdinatioCivisMortis(i));
                }
            }
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
            ColligereMortis(idCivis);
        }
    }
}
