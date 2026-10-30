using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Officia.Contractus;
using Yulinti.Auctoritas.Contractus;
using UnityEngine.UIElements;
using System.Collections.Generic;

namespace Yulinti.Officia.Velum {
    internal sealed class PartesPulsabulumIndexusPrincipalis {
        private Dictionary<UsusIndexusPrincipalis, ParsPulsabulumIndexusPrincipalis> _partes;

        public PartesPulsabulumIndexusPrincipalis(
            IConfiguratioVelumIndexusPrincipalis configuratio,
            ITurrisInterpretationis turrisInterpretationis
        ) {
            _partes = new Dictionary<UsusIndexusPrincipalis, ParsPulsabulumIndexusPrincipalis>();
            foreach (IConfiguratioParsPulsabulumIndexusPrincipalis configuratioParsPulsabulumIndexusPrincipalis in configuratio.ParsPulsabulumIndexusPrincipalis) {
                _partes.Add(configuratioParsPulsabulumIndexusPrincipalis.Usus, new ParsPulsabulumIndexusPrincipalis(configuratioParsPulsabulumIndexusPrincipalis, turrisInterpretationis));
            }
        }

        public void Incipere(VisualElement parens) {
            foreach (ParsPulsabulumIndexusPrincipalis parte in _partes.Values) {
                parte.Incipere(parens);
            }
        }
    }
}