using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Auctoritas.Contractus;
using Yulinti.Officia.Contractus;
using UnityEngine.UIElements;
using Yulinti.Nucleus.Instrumentarium;

namespace Yulinti.Officia.Velum {
    internal sealed class VelumElementiPortusConstructionisLapsorCorporis : IVelumElementi, IVelumPortusConstructionisLapsorCorporis, IVelumIncipabilis, IVelumLiberabilis, IVelumTerminabilis {
        private readonly IAnchoraVelumConstructionis _anchoraVelumConstructionis;
        private readonly ITurrisInterpretationis _turrisInterpretationis;
        private readonly ApplicatorSoniVeli _applicatorSoniVeli;
        private readonly IOperatioPortusConstructionisLapsorCorporis _operatioPortusConstructionisLapsorCorporis;
        private readonly IResFluidaPuellaeFormaeLegibile _resFluidaPuellaeFormaeLegibile;

        private UIDocument _uiPortusConstructionis;
        private VisualTreeAsset _elementumLapsorCorporis;

        private VisualElement _containerPortusConstructionis;
        private VisualElement _elementum;

        private Label _labelLapsorCorporis;
        private Slider _sliderLapsorCorporis;

        public VelumElementiPortusConstructionisLapsorCorporis(
            IAnchoraVelumConstructionis anchoraVelumConstructionis,
            ITurrisInterpretationis turrisInterpretationis,
            ApplicatorSoniVeli applicatorSoniVeli,
            IOperatioPortusConstructionisLapsorCorporis operatioPortusConstructionisLapsorCorporis,
            IResFluidaPuellaeFormaeLegibile resFluidaPuellaeFormaeLegibile
        ) {
            _anchoraVelumConstructionis = anchoraVelumConstructionis;
            _turrisInterpretationis = turrisInterpretationis;
            _applicatorSoniVeli = applicatorSoniVeli;
            _operatioPortusConstructionisLapsorCorporis = operatioPortusConstructionisLapsorCorporis;
            _resFluidaPuellaeFormaeLegibile = resFluidaPuellaeFormaeLegibile;
        }

        public void Incipere() {
            _uiPortusConstructionis = _anchoraVelumConstructionis.UIDocument;
            _elementumLapsorCorporis = _anchoraVelumConstructionis.ElementumLapsorCorporis;

            _containerPortusConstructionis = _uiPortusConstructionis.rootVisualElement.Q<VisualElement>("constructio-content");

            // 初回CloneTreeしてから非表示にする。
            _elementum = new VisualElement();
            _elementumLapsorCorporis.CloneTree(_elementum);
            _elementum.style.display = DisplayStyle.None;
            _elementum.focusable = true;
            _elementum.tabIndex = 0;
            _elementum.pickingMode = PickingMode.Position;

            _containerPortusConstructionis.Add(_elementum);
            _labelLapsorCorporis = _elementum.Q<Label>("elementum-lapsor-corporis-corporis-title");
            _sliderLapsorCorporis = _elementum.Q<Slider>("elementum-lapsor-corporis-corporis-slider");

            _labelLapsorCorporis.text = _turrisInterpretationis.LegoTextus(IDTextus.PORTUS_CONSTRUCTIONIS_LAPSOR_CORPORIS_LAPSOR_CORPORIS_LABEL);

            ActivareCB();
        }

        public void Activare() {
            _elementum.style.display = DisplayStyle.Flex;
            renovareLapsor();
        }

        public void Deactivare() {
            _elementum.style.display = DisplayStyle.None;
        }

        public void DemittereLapsorCorporis() {
            Activare();
        }

        public void TollereLapsorCorporis() {
            Deactivare();
        }

        public void PonoPermissionemUsus(UsusPortusConstructionisLapsorCorporis usus, bool permissio) {
            if (usus == UsusPortusConstructionisLapsorCorporis.LapsorCorporis) {
                _sliderLapsorCorporis.SetEnabled(permissio);
            }
        }

        private void renovareLapsor() {
            _sliderLapsorCorporis.value = _resFluidaPuellaeFormaeLegibile.RatioActualis(IDPuellaeFormae.Corpus);
        }

        private void premereLapsorCorporis(ChangeEvent<float> evt) {
            float valor = Mathematica.Clamp(
                Corrector.GradareValorem(evt.newValue, 0.05f), _sliderLapsorCorporis.lowValue, _sliderLapsorCorporis.highValue
            );
            _sliderLapsorCorporis.SetValueWithoutNotify(valor);

            _operatioPortusConstructionisLapsorCorporis.Executare(
                UsusPortusConstructionisLapsorCorporis.LapsorCorporis, valor
            );
        }

        private void ActivareCB() {
            _applicatorSoniVeli.Applicare(_elementum);
            _sliderLapsorCorporis.RegisterValueChangedCallback(premereLapsorCorporis);
        }

        private void DeactivareCB() {
            _applicatorSoniVeli.Purgere(_elementum);
            _sliderLapsorCorporis.UnregisterValueChangedCallback(premereLapsorCorporis);
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