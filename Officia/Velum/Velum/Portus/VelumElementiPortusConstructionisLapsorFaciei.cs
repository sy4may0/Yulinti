using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Auctoritas.Contractus;
using Yulinti.Officia.Contractus;
using UnityEngine.UIElements;

namespace Yulinti.Officia.Velum {
    internal sealed class VelumElementiPortusConstructionisLapsorFaciei : IVelumElementi, IVelumPortusConstructionisLapsorFaciei, IVelumIncipabilis, IVelumLiberabilis, IVelumTerminabilis {
        private readonly IAnchoraVelumConstructionis _anchoraVelumConstructionis;
        private readonly ITurrisInterpretationis _turrisInterpretationis;
        private readonly ApplicatorSoniVeli _applicatorSoniVeli;
        private readonly IOperatioPortusConstructionisLapsorFaciei _operatioPortusConstructionisLapsorFaciei;

        private UIDocument _uiPortusConstructionis;
        private VisualTreeAsset _elementumLapsorFaciei;

        private VisualElement _containerPortusConstructionis;
        private VisualElement _elementum;

        public VelumElementiPortusConstructionisLapsorFaciei(
            IAnchoraVelumConstructionis anchoraVelumConstructionis,
            ITurrisInterpretationis turrisInterpretationis,
            ApplicatorSoniVeli applicatorSoniVeli,
            IOperatioPortusConstructionisLapsorFaciei operatioPortusConstructionisLapsorFaciei
        ) {
            _anchoraVelumConstructionis = anchoraVelumConstructionis;
            _turrisInterpretationis = turrisInterpretationis;
            _applicatorSoniVeli = applicatorSoniVeli;
            _operatioPortusConstructionisLapsorFaciei = operatioPortusConstructionisLapsorFaciei;
        }

        public void Incipere() {
            _uiPortusConstructionis = _anchoraVelumConstructionis.UIDocument;
            _elementumLapsorFaciei = _anchoraVelumConstructionis.ElementumLapsorFaciei;

            _containerPortusConstructionis = _uiPortusConstructionis.rootVisualElement.Q<VisualElement>("constructio-content");

            // 初回CloneTreeしてから非表示にする。
            _elementum = new VisualElement();
            _elementumLapsorFaciei.CloneTree(_elementum);
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

        public void DemittereLapsorFaciei() {
            Activare();
        }

        public void TollereLapsorFaciei() {
            Deactivare();
        }

        public void PonoPermissionemUsus(UsusPortusConstructionisLapsorFaciei usus, bool permissio) {
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
