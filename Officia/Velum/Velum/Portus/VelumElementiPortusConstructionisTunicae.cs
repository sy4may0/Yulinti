using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Auctoritas.Contractus;
using Yulinti.Officia.Contractus;
using UnityEngine.UIElements;

namespace Yulinti.Officia.Velum {
    internal sealed class VelumElementiPortusConstructionisTunicae : IVelumElementi, IVelumPortusConstructionisTunicae, IVelumIncipabilis, IVelumLiberabilis, IVelumTerminabilis {
        private readonly IAnchoraVelumConstructionis _anchoraVelumConstructionis;
        private readonly ITurrisInterpretationis _turrisInterpretationis;
        private readonly ApplicatorSoniVeli _applicatorSoniVeli;
        private readonly IOperatioPortusConstructionisTunicae _operatioPortusConstructionisTunicae;

        private UIDocument _uiPortusConstructionis;
        private VisualTreeAsset _elementumTunicae;

        private VisualElement _containerPortusConstructionis;
        private VisualElement _elementum;

        public VelumElementiPortusConstructionisTunicae(
            IAnchoraVelumConstructionis anchoraVelumConstructionis,
            ITurrisInterpretationis turrisInterpretationis,
            ApplicatorSoniVeli applicatorSoniVeli,
            IOperatioPortusConstructionisTunicae operatioPortusConstructionisTunicae
        ) {
            _anchoraVelumConstructionis = anchoraVelumConstructionis;
            _turrisInterpretationis = turrisInterpretationis;
            _applicatorSoniVeli = applicatorSoniVeli;
            _operatioPortusConstructionisTunicae = operatioPortusConstructionisTunicae;
        }

        public void Incipere() {
            _uiPortusConstructionis = _anchoraVelumConstructionis.UIDocument;
            _elementumTunicae = _anchoraVelumConstructionis.ElementumTunicae;

            _containerPortusConstructionis = _uiPortusConstructionis.rootVisualElement.Q<VisualElement>("constructio-content");

            // 初回CloneTreeしてから非表示にする。
            _elementum = new VisualElement();
            _elementumTunicae.CloneTree(_elementum);
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

        public void DemittereTunicae() {
            Activare();
        }

        public void TollereTunicae() {
            Deactivare();
        }

        public void PonoPermissionemUsus(UsusPortusConstructionisTunicae usus, bool permissio) {
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
