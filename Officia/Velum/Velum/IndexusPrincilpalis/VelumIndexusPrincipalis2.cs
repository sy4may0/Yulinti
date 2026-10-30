using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Auctoritas.Contractus;
using Yulinti.Officia.Contractus;
using UnityEngine.UIElements;

namespace Yulinti.Officia.Velum {
    internal sealed class VelumIndexusPrincipalis2 {
        private readonly IAnchoraVelumIndexusPrincipalis2 _anchoraVelumIndexusPrincipalis2;
        private readonly ITurrisInterpretationis _turrisInterpretationis;

        private UIDocument _uiIndexusPrincipalis;
        private VisualElement _parensParsPulsabulumIndexusPrincipalis;

        public VelumIndexusPrincipalis2(
            IAnchoraVelumIndexusPrincipalis2 anchoraVelumIndexusPrincipalis2,
            ITurrisInterpretationis turrisInterpretationis
        ) {
            _anchoraVelumIndexusPrincipalis2 = anchoraVelumIndexusPrincipalis2;
            _turrisInterpretationis = turrisInterpretationis;
        }

        public void Incipere() {
            _uiIndexusPrincipalis = _anchoraVelumIndexusPrincipalis2.VelumIndexusPrincipalis;
            _parensParsPulsabulumIndexusPrincipalis = _uiIndexusPrincipalis.rootVisualElement.Q<VisualElement>("indexprincipalis-panel");
        }

        public void Demittere() {
            _parensParsPulsabulumIndexusPrincipalis.style.display = DisplayStyle.Flex;
        }
        
        public void Tollere() {
            _parensParsPulsabulumIndexusPrincipalis.style.display = DisplayStyle.None;
        }
    }
}