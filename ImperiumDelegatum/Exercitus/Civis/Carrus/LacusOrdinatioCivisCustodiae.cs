using System.Collections.Generic;
using Yulinti.Nucleus.Instrumentarium;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class LacusOrdinatioCivisCustodiae {
        private readonly Stack<OrdinatioCivisCustodiae>[] _lacusCustodiae;

        private readonly Ordo<OrdinatioCivisCustodiae>[] _emissioCustodiae;

        public LacusOrdinatioCivisCustodiae(int longitudoCivis) {
            _lacusCustodiae = new Stack<OrdinatioCivisCustodiae>[longitudoCivis];

            _emissioCustodiae = new Ordo<OrdinatioCivisCustodiae>[longitudoCivis];

            for (int i = 0; i < longitudoCivis; i++) {
                _lacusCustodiae[i] = new Stack<OrdinatioCivisCustodiae>(ConstansCivis.LongitudoOrdinatioCustodiae);

                _emissioCustodiae[i] = new Ordo<OrdinatioCivisCustodiae>(ConstansCivis.LongitudoOrdinatioCustodiae);

                for (int j = 0; j < ConstansCivis.LongitudoOrdinatioCustodiae; j++) {
                    _lacusCustodiae[i].Push(new OrdinatioCivisCustodiae(i));
                }
            }
        }

        public bool EmittareCustodiae(int idCivis, out OrdinatioCivisCustodiae custodiae) {
            if (_lacusCustodiae[idCivis].Count > 0) {
                var r = _lacusCustodiae[idCivis].Pop();
                if (_emissioCustodiae[idCivis].ConarePono(r)) {
                    custodiae = r;
                    custodiae.Initare();
                    return true;
                }
            }
            custodiae = null;
            return false;
        }

        public void ColligereCustodiae(int idCivis) {
            while (_emissioCustodiae[idCivis].ConareLego(out var r)) {
                if (_lacusCustodiae[idCivis].Count < ConstansCivis.LongitudoOrdinatioCustodiae) {
                    _lacusCustodiae[idCivis].Push(r);
                } else {
                    r.Purgere();
                    r.Liberare();
                }
            }
        }

        public void ColligereOmnia(int idCivis) {
            ColligereCustodiae(idCivis);
        }
    }
}
