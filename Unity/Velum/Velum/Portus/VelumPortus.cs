using Yulinti.Exercitus.Contractus;
using Yulinti.Unity.Contractus;
using UnityEngine.UIElements;
using System;

namespace Yulinti.Unity.Velum {
    internal sealed class VelumPortus : IVelum, IVelumPortus, IVelumLiberabilis, IVelumTerminabilis {
        private readonly IAnchoraVelumPortus _anchoraVelumPortus;
        private readonly ITurrisInterpretationis _turrisInterpretationis;

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
            ITurrisInterpretationis turrisInterpretationis
        ) {
            _anchoraVelumPortus = anchoraVelumPortus;
            _turrisInterpretationis = turrisInterpretationis;

            _onProfectio = null;
            _onConstructio = null;
            _onTaberna = null;
            _onOptiones = null;
            _onExi = null;
        }

        public void Initare() {
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
        }

        public void Activare() {
            _containerPortus.style.display = DisplayStyle.Flex;
        }

        public void Deactivare() {
            _containerPortus.style.display = DisplayStyle.None;
        }

        public void DemitterePortus() {
            ExuereCallbacks();
            Activare();
            _buttonProfectio.Focus();
        }

        public void TollerePortus() {
            ExuereCallbacks();
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
            if (_onProfectio != null) _buttonProfectio.clicked -= _onProfectio;
            _onProfectio = ae;
            if (_onProfectio != null) _buttonProfectio.clicked += _onProfectio;
        }

        public void AdPremereConstructio(Action ae) {
            if (_onConstructio != null) _buttonConstructio.clicked -= _onConstructio;
            _onConstructio = ae;
            if (_onConstructio != null) _buttonConstructio.clicked += _onConstructio;
        }

        public void AdPremereTaberna(Action ae) {
            if (_onTaberna != null) _buttonTaberna.clicked -= _onTaberna;
            _onTaberna = ae;
            if (_onTaberna != null) _buttonTaberna.clicked += _onTaberna;
        }

        public void AdPremereOptiones(Action ae) {
            if (_onOptiones != null) _buttonOptiones.clicked -= _onOptiones;
            _onOptiones = ae;
            if (_onOptiones != null) _buttonOptiones.clicked += _onOptiones;
        }

        public void AdPremereExi(Action ae) {
            if (_onExi != null) _buttonExi.clicked -= _onExi;
            _onExi = ae;
            if (_onExi != null) _buttonExi.clicked += _onExi;
        }

        public void Liberare() {
            TollerePortus();
        }

        private void ExuereCallbacks() {
            if (_onProfectio != null) {
                _buttonProfectio.clicked -= _onProfectio;
            }
            _onProfectio = null;
            if (_onConstructio != null) {
                _buttonConstructio.clicked -= _onConstructio;
            }
            _onConstructio = null;
            if (_onTaberna != null) {
                _buttonTaberna.clicked -= _onTaberna;
            }
            _onTaberna = null;
            if (_onOptiones != null) {
                _buttonOptiones.clicked -= _onOptiones;
            }
            _onOptiones = null;
            if (_onExi != null) {
                _buttonExi.clicked -= _onExi;
            }
            _onExi = null;
        }
        
        public void TollereFinem() {
            TollerePortus();
        }
    }
}