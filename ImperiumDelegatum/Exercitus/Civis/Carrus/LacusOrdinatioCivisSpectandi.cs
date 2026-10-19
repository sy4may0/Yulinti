using System.Collections.Generic;
using Yulinti.Nucleus.Instrumentarium;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class LacusOrdinatioCivisSpectandi {
        private readonly Stack<OrdinatioCivisSpectandi>[] _lacusSpectandi;

        private readonly Ordo<OrdinatioCivisSpectandi>[] _emissioSpectandi;

        public LacusOrdinatioCivisSpectandi(int longitudoCivis) {
            _lacusSpectandi = new Stack<OrdinatioCivisSpectandi>[longitudoCivis];

            _emissioSpectandi = new Ordo<OrdinatioCivisSpectandi>[longitudoCivis];

            for (int i = 0; i < longitudoCivis; i++) {
                _lacusSpectandi[i] = new Stack<OrdinatioCivisSpectandi>(ConstansCivis.LongitudoOrdinatioSpectandi);

                _emissioSpectandi[i] = new Ordo<OrdinatioCivisSpectandi>(ConstansCivis.LongitudoOrdinatioSpectandi);

                for (int j = 0; j < ConstansCivis.LongitudoOrdinatioSpectandi; j++) {
                    _lacusSpectandi[i].Push(new OrdinatioCivisSpectandi(i));
                }
            }
        }

        public bool EmittareSpectandi(int idCivis, out OrdinatioCivisSpectandi spectandi) {
            if (_lacusSpectandi[idCivis].Count > 0) {
                var r = _lacusSpectandi[idCivis].Pop();
                if (_emissioSpectandi[idCivis].ConarePono(r)) {
                    spectandi = r;
                    spectandi.Initare();
                    return true;
                }
            }
            spectandi = null;
            return false;
        }

        public void ColligereSpectandi(int idCivis) {
            while (_emissioSpectandi[idCivis].ConareLego(out var r)) {
                if (_lacusSpectandi[idCivis].Count < ConstansCivis.LongitudoOrdinatioSpectandi) {
                    _lacusSpectandi[idCivis].Push(r);
                } else {
                    r.Purgere();
                    r.Liberare();
                }
            }
        }

        public void ColligereOmnia(int idCivis) {
            ColligereSpectandi(idCivis);
        }
    }
}
