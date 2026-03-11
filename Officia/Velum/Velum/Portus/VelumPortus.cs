using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Auctoritas.Contractus;
using Yulinti.Officia.Contractus;
using UnityEngine.UIElements;
using System;

namespace Yulinti.Officia.Velum {
    internal sealed class VelumPortus : IVelum, IVelumPortus, IVelumIncipabilis, IVelumLiberabilis, IVelumTerminabilis {
        private readonly IAnchoraVelumPortus _anchoraVelumPortus;
        private readonly ITurrisInterpretationis _turrisInterpretationis;
        private readonly ApplicatorSoniVeli _applicatorSoniVeli;

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

        private Action _onProfectio;
        private Action _onConstructio;
        private Action _onTaberna;
        private Action _onOptiones;
        private Action _onExi;

        public VelumPortus(
            IAnchoraVelumPortus anchoraVelumPortus,
            ITurrisInterpretationis turrisInterpretationis,
            ApplicatorSoniVeli applicatorSoniVeli
        ) {
            _anchoraVelumPortus = anchoraVelumPortus;
            _turrisInterpretationis = turrisInterpretationis;
            _applicatorSoniVeli = applicatorSoniVeli;

            _onProfectio = null;
            _onConstructio = null;
            _onTaberna = null;
            _onOptiones = null;
            _onExi = null;
        }

        public void Incipere() {
            _containerPortus = _anchoraVelumPortus.UIDocument.rootVisualElement.Q<VisualElement>("portus-root");
            _panelPortus = _anchoraVelumPortus.UIDocument.rootVisualElement.Q<VisualElement>("portus-panel");

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

        public void ActivareButton(ButtonPortus buttonPortus) {
            switch (buttonPortus) {
                case ButtonPortus.Profectio:
                    _buttonProfectio.SetEnabled(true);
                    break;
                case ButtonPortus.Constructio:
                    _buttonConstructio.SetEnabled(true);
                    break;
                case ButtonPortus.Taberna:
                    _buttonTaberna.SetEnabled(true);
                    break;
                case ButtonPortus.Optiones:
                    _buttonOptiones.SetEnabled(true);
                    break;
                case ButtonPortus.Exi:
                    _buttonExi.SetEnabled(true);
                    break;
            }
        }

        public void DeactivareButton(ButtonPortus buttonPortus) {
            switch (buttonPortus) {
                case ButtonPortus.Profectio:
                    _buttonProfectio.SetEnabled(false);
                    break;
                case ButtonPortus.Constructio:
                    _buttonConstructio.SetEnabled(false);
                    break;
                case ButtonPortus.Taberna:
                    _buttonTaberna.SetEnabled(false);
                    break;
                case ButtonPortus.Optiones:
                    _buttonOptiones.SetEnabled(false);
                    break;
                case ButtonPortus.Exi:
                    _buttonExi.SetEnabled(false);
                    break;
            }
        }

        public void AdPremereProfectio(Action ae) {
            _onProfectio = ae;
        }

        public void AdPremereConstructio(Action ae) {
            _onConstructio = ae;
        }

        public void AdPremereTaberna(Action ae) {
            _onTaberna = ae;
        }

        public void AdPremereOptiones(Action ae) {
            _onOptiones = ae;
        }

        public void AdPremereExi(Action ae) {
            _onExi = ae;
        }

        private void premereProfectio() {
            _onProfectio?.Invoke();
        }

        private void premereConstructio() {
            _onConstructio?.Invoke();
        }

        private void premereTaberna() {
            _onTaberna?.Invoke();
        }

        private void premereOptiones() {
            _onOptiones?.Invoke();
        }

        private void premereExi() {
            _onExi?.Invoke();
        }

        public void Liberare() {
            DeactivareCB();
            TollerePortus();
        }

        private void ActivareCB() {
            _applicatorSoniVeli.ApplicareRadix(_anchoraVelumPortus.UIDocument);
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
            _applicatorSoniVeli.PurgereRadix(_anchoraVelumPortus.UIDocument);
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
