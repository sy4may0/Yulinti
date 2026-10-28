using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Auctoritas.Contractus;
using Yulinti.Officia.Contractus;
using UnityEngine.UIElements;

namespace Yulinti.Officia.Velum {
    internal sealed class VelumElementiPortusConstructionisSalsamenti : IVelumElementi, IVelumPortusConstructionisSalsamenti, IVelumIncipabilis, IVelumLiberabilis, IVelumTerminabilis {
        private readonly IAnchoraVelumConstructionis _anchoraVelumConstructionis;
        private readonly ITurrisInterpretationis _turrisInterpretationis;
        private readonly ApplicatorSoniVeli _applicatorSoniVeli;
        private readonly IOperatioPortusConstructionisSalsamenti _operatioPortusConstructionisSalsamenti;

        private UIDocument _uiPortusConstructionis;
        private VisualTreeAsset _elementumSalsamenti;

        private VisualElement _containerPortusConstructionis;
        private VisualElement _elementum;

        public VelumElementiPortusConstructionisSalsamenti(
            IAnchoraVelumConstructionis anchoraVelumConstructionis,
            ITurrisInterpretationis turrisInterpretationis,
            ApplicatorSoniVeli applicatorSoniVeli,
            IOperatioPortusConstructionisSalsamenti operatioPortusConstructionisSalsamenti
        ) {
            _anchoraVelumConstructionis = anchoraVelumConstructionis;
            _turrisInterpretationis = turrisInterpretationis;
            _applicatorSoniVeli = applicatorSoniVeli;
            _operatioPortusConstructionisSalsamenti = operatioPortusConstructionisSalsamenti;
        }

        public void Incipere() {
            _uiPortusConstructionis = _anchoraVelumConstructionis.UIDocument;
            _elementumSalsamenti = _anchoraVelumConstructionis.ElementumSalsamenti;

            _containerPortusConstructionis = _uiPortusConstructionis.rootVisualElement.Q<VisualElement>("constructio-content");

            // 初回CloneTreeしてから非表示にする。
            _elementum = new VisualElement();
            _elementumSalsamenti.CloneTree(_elementum);
            _elementum.style.display = DisplayStyle.None;
            _elementum.focusable = true;
            _elementum.tabIndex = 0;
            _elementum.pickingMode = PickingMode.Position;

            _containerPortusConstructionis.Add(_elementum);

            ActivareCB();
        }

        public void Activare() {
            _elementum.style.display = DisplayStyle.Flex;
        }

        public void Deactivare() {
            _elementum.style.display = DisplayStyle.None;
        }

        public void DemittereSalsamenti() {
            Activare();
        }

        public void TollereSalsamenti() {
            Deactivare();
        }

        public void PonoPermissionemUsus(UsusPortusConstructionisSalsamenti usus, bool permissio) {
        }

        private void ActivareCB() {
            _applicatorSoniVeli.Applicare(_elementum);
        }

        private void DeactivareCB() {
            _applicatorSoniVeli.Purgere(_elementum);
        }

        public void TollereFinem() {
            Deactivare();
        }

        public void Liberare() {
            if (
                _uiPortusConstructionis == null || 
                _uiPortusConstructionis.rootVisualElement == null ||
                _elementum == null  
            ) {
                return;
            }
            DeactivareCB();
            Deactivare();
        }
        
    }
}
