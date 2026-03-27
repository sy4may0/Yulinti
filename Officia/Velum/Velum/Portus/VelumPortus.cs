using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Auctoritas.Contractus;
using Yulinti.Officia.Contractus;
using UnityEngine.UIElements;

namespace Yulinti.Officia.Velum {
    internal sealed class VelumPortus : IVelum, IVelumPortus, IVelumIncipabilis, IVelumLiberabilis, IVelumTerminabilis {
        private readonly IAnchoraVelumPortus _anchoraVelumPortus;
        private readonly ITurrisInterpretationis _turrisInterpretationis;
        private readonly ApplicatorSoniVeli _applicatorSoniVeli;
        private readonly IOperatioPortus _operatioPortus;

        private UIDocument _uiPortus;

        private VisualElement _containerPortus;
        private VisualElement _panelPortus;

        private Button _buttonProfectio;
        private Button _buttonConstructio;
        private Button _buttonTaberna;
        private Button _buttonOptiones;
        private Button _buttonExi;
        private Label _labelProfectio;
        private Label _labelConstructio;
        private Label _labelTaberna;
        private Label _labelOptiones;
        private Label _labelExi;

        public VelumPortus(
            IAnchoraVelumPortus anchoraVelumPortus,
            ITurrisInterpretationis turrisInterpretationis,
            ApplicatorSoniVeli applicatorSoniVeli,
            IOperatioPortus operatioPortus
        ) {
            _anchoraVelumPortus = anchoraVelumPortus;
            _turrisInterpretationis = turrisInterpretationis;
            _applicatorSoniVeli = applicatorSoniVeli;
            _operatioPortus = operatioPortus;

            _uiPortus = _anchoraVelumPortus.UIDocument;
        }

        public void Incipere() {
            _uiPortus = _anchoraVelumPortus.UIDocument;

            _containerPortus = _uiPortus.rootVisualElement.Q<VisualElement>("portus-root");
            _panelPortus = _uiPortus.rootVisualElement.Q<VisualElement>("portus-panel");

            _buttonProfectio = _panelPortus.Q<Button>("portus-button-profectio");
            _buttonConstructio = _panelPortus.Q<Button>("portus-button-constructio");
            _buttonTaberna = _panelPortus.Q<Button>("portus-button-taberna");
            _buttonOptiones = _panelPortus.Q<Button>("portus-button-optiones");
            _buttonExi = _panelPortus.Q<Button>("portus-button-exi");
            _labelProfectio = _panelPortus.Q<Label>("portus-button-profectio-label");
            _labelConstructio = _panelPortus.Q<Label>("portus-button-constructio-label");
            _labelTaberna = _panelPortus.Q<Label>("portus-button-taberna-label");
            _labelOptiones = _panelPortus.Q<Label>("portus-button-optiones-label");
            _labelExi = _panelPortus.Q<Label>("portus-button-exi-label");

            _labelProfectio.text = _turrisInterpretationis.LegoTextus(IDTextus.PORTUS_BUTTON_PROFECTIO);
            _labelConstructio.text = _turrisInterpretationis.LegoTextus(IDTextus.PORTUS_BUTTON_CONSTRUCTIO);
            _labelTaberna.text = _turrisInterpretationis.LegoTextus(IDTextus.PORTUS_BUTTON_TABERNA);
            _labelOptiones.text = _turrisInterpretationis.LegoTextus(IDTextus.PORTUS_BUTTON_OPTIONES);
            _labelExi.text = _turrisInterpretationis.LegoTextus(IDTextus.PORTUS_BUTTON_EXI);

            ActivareCB();
        }

        public void Activare() {
            _containerPortus.style.display = DisplayStyle.Flex;
        }

        public void Deactivare() {
            _containerPortus.style.display = DisplayStyle.None;
        }

        public void DemitterePortus() {
            Activare();
            _buttonProfectio.Focus();
        }

        public void TollerePortus() {
            Deactivare();
        }

        public void PonoPermissionemUsus(UsusPortus usus, bool permissio) {
            if (usus == UsusPortus.Profectio) {
                _buttonProfectio.SetEnabled(permissio);
            } else if (usus == UsusPortus.Constructio) {
                _buttonConstructio.SetEnabled(permissio);
            } else if (usus == UsusPortus.Taberna) {
                _buttonTaberna.SetEnabled(permissio);
            } else if (usus == UsusPortus.Optiones) {
                _buttonOptiones.SetEnabled(permissio);
            } else if (usus == UsusPortus.Exi) {
                _buttonExi.SetEnabled(permissio);
            }
        }

        private void premereProfectio() {
            _operatioPortus.Executare(UsusPortus.Profectio);
        }

        private void premereConstructio() {
            _operatioPortus.Executare(UsusPortus.Constructio);
        }

        private void premereTaberna() {
            _operatioPortus.Executare(UsusPortus.Taberna);
        }

        private void premereOptiones() {
            _operatioPortus.Executare(UsusPortus.Optiones);
        }

        private void premereExi() {
            _operatioPortus.Executare(UsusPortus.Exi);
        }

        public void Liberare() {
            if (_uiPortus == null || _uiPortus.rootVisualElement == null) {
                return;
            }
            DeactivareCB();
            TollerePortus();
        }

        private void ActivareCB() {
            _applicatorSoniVeli.ApplicareRadix(_uiPortus);
            _applicatorSoniVeli.Applicare(_panelPortus);
            _buttonProfectio.clicked -= premereProfectio;
            _buttonProfectio.clicked += premereProfectio;
            _buttonConstructio.clicked -= premereConstructio;
            _buttonConstructio.clicked += premereConstructio;
            _buttonTaberna.clicked -= premereTaberna;
            _buttonTaberna.clicked += premereTaberna;
            _buttonOptiones.clicked -= premereOptiones;
            _buttonOptiones.clicked += premereOptiones;
            _buttonExi.clicked -= premereExi;
            _buttonExi.clicked += premereExi;
        }

        private void DeactivareCB() {
            _applicatorSoniVeli.PurgereRadix(_uiPortus);
            _applicatorSoniVeli.Purgere(_panelPortus);
            _buttonProfectio.clicked -= premereProfectio;
            _buttonConstructio.clicked -= premereConstructio;
            _buttonTaberna.clicked -= premereTaberna;
            _buttonOptiones.clicked -= premereOptiones;
            _buttonExi.clicked -= premereExi;
        }
        
        public void TollereFinem() {
            TollerePortus();
        }
    }
}
