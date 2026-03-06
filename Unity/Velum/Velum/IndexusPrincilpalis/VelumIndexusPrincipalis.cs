using Yulinti.Exercitus.Contractus;
using Yulinti.Unity.Contractus;
using UnityEngine.UIElements;
using System;

namespace Yulinti.Unity.Velum {
    internal sealed class VelumIndexusPrincipalis : IVelum, IVelumIndexusPrincipalis, IVelumLiberabilis, IVelumTerminabilis {
        private readonly IAnchoraVelumIndexusPrincipalis _anchoraVelumIndexusPrincipalis;
        private readonly ITurrisInterpretationis _turrisInterpretationis;

        private VisualElement _containerIndexusPrincipalis;

        private VisualElement _panelIndexusPrincipalis;

        private Button _buttonLudusNovus;
        private Button _buttonPergeLudum;
        private Button _buttonOneraLudum;
        private Button _buttonOptiones;
        private Button _buttonExi;
        private Label _labelLudusNovus;
        private Label _labelPergeLudum;
        private Label _labelOneraLudum;
        private Label _labelOptiones;
        private Label _labelExi;

        private Action _onLudusNovus;
        private Action _onPergeLudum;
        private Action _onOneraLudum;
        private Action _onOptiones;
        private Action _onExi;

        public VelumIndexusPrincipalis(
            IAnchoraVelumIndexusPrincipalis anchoraVelumIndexusPrincipalis,
            ITurrisInterpretationis turrisInterpretationis
        ) {
            _anchoraVelumIndexusPrincipalis = anchoraVelumIndexusPrincipalis;
            _turrisInterpretationis = turrisInterpretationis;

            _onLudusNovus = null;
            _onPergeLudum = null;
            _onOneraLudum = null;
            _onOptiones = null;
            _onExi = null;
        }

        // 各UI要素を初期化する。
        public void Initare() {
            _containerIndexusPrincipalis = _anchoraVelumIndexusPrincipalis.UIDocument.rootVisualElement.Q<VisualElement>("indexprincipalis-root");
            _panelIndexusPrincipalis = _anchoraVelumIndexusPrincipalis.UIDocument.rootVisualElement.Q<VisualElement>("indexprincipalis-panel");

            _buttonLudusNovus = _panelIndexusPrincipalis.Q<Button>("buttonLudusNovus");
            _buttonPergeLudum = _panelIndexusPrincipalis.Q<Button>("buttonPergeLudum");
            _buttonOneraLudum = _panelIndexusPrincipalis.Q<Button>("buttonOneraLudum");
            _buttonOptiones = _panelIndexusPrincipalis.Q<Button>("buttonOptiones");
            _buttonExi = _panelIndexusPrincipalis.Q<Button>("buttonExi");
            _labelLudusNovus = _panelIndexusPrincipalis.Q<Label>("indexprincipalis-button-ludus-novus-label");
            _labelPergeLudum = _panelIndexusPrincipalis.Q<Label>("indexprincipalis-button-perge-ludum-label");
            _labelOneraLudum = _panelIndexusPrincipalis.Q<Label>("indexprincipalis-button-onera-ludum-label");
            _labelOptiones = _panelIndexusPrincipalis.Q<Label>("indexprincipalis-button-optiones-label");
            _labelExi = _panelIndexusPrincipalis.Q<Label>("indexprincipalis-button-exi-label");

            _labelLudusNovus.text = _turrisInterpretationis.LegoTextus(IDTextus.INDEXUS_PRINCIPALIS_LUDUS_NOVUS);
            _labelPergeLudum.text = _turrisInterpretationis.LegoTextus(IDTextus.INDEXUS_PRINCIPALIS_PERGE_LUDUM);
            _labelOneraLudum.text = _turrisInterpretationis.LegoTextus(IDTextus.INDEXUS_PRINCIPALIS_ONERA_LUDUM);
            _labelOptiones.text = _turrisInterpretationis.LegoTextus(IDTextus.INDEXUS_PRINCIPALIS_OPTIONES);
            _labelExi.text = _turrisInterpretationis.LegoTextus(IDTextus.INDEXUS_PRINCIPALIS_EXIT);
        }

        public void Activare() {
            _containerIndexusPrincipalis.style.display = DisplayStyle.Flex;
        }

        public void Deactivare() {
            _containerIndexusPrincipalis.style.display = DisplayStyle.None;
        }

        public void DemittereIndexusPrincipalis() {
            ExuereCallbacks();
            Activare();
            _buttonLudusNovus.Focus();
        }

        public void TollereIndexusPrincipalis() {
            ExuereCallbacks();
            Deactivare();
        }

        public void ActivareButton(ButtonIndexusPrincipalis buttonIndexusPrincipalis) {
            switch (buttonIndexusPrincipalis) {
                case ButtonIndexusPrincipalis.LudusNovus:
                    _buttonLudusNovus.SetEnabled(true);
                    break;
                case ButtonIndexusPrincipalis.PergeLudum:
                    _buttonPergeLudum.SetEnabled(true);
                    break;
                case ButtonIndexusPrincipalis.OneraLudum:
                    _buttonOneraLudum.SetEnabled(true);
                    break;
                case ButtonIndexusPrincipalis.Optiones:
                    _buttonOptiones.SetEnabled(true);
                    break;
                case ButtonIndexusPrincipalis.Exi:
                    _buttonExi.SetEnabled(true);
                    break;
            }
        }

        public void DeactivareButton(ButtonIndexusPrincipalis buttonIndexusPrincipalis) {
            switch (buttonIndexusPrincipalis) {
                case ButtonIndexusPrincipalis.LudusNovus:
                    _buttonLudusNovus.SetEnabled(false);
                    break;
                case ButtonIndexusPrincipalis.PergeLudum:
                    _buttonPergeLudum.SetEnabled(false);
                    break;
                case ButtonIndexusPrincipalis.OneraLudum:
                    _buttonOneraLudum.SetEnabled(false);
                    break;
                case ButtonIndexusPrincipalis.Optiones:
                    _buttonOptiones.SetEnabled(false);
                    break;
                case ButtonIndexusPrincipalis.Exi:
                    _buttonExi.SetEnabled(false);
                    break;
            }
        }

        public void AdPremereLudusNovus(Action ae) {
            if (_onLudusNovus != null) _buttonLudusNovus.clicked -= _onLudusNovus;
            _onLudusNovus = ae;
            if (_onLudusNovus != null) _buttonLudusNovus.clicked += _onLudusNovus;
        }

        public void AdPremerePergeLudum(Action ae) {
            if (_onPergeLudum != null) _buttonPergeLudum.clicked -= _onPergeLudum;
            _onPergeLudum = ae;
            if (_onPergeLudum != null) _buttonPergeLudum.clicked += _onPergeLudum;
        }

        public void AdPremereOneraLudum(Action ae) {
            if (_onOneraLudum != null) _buttonOneraLudum.clicked -= _onOneraLudum;
            _onOneraLudum = ae;
            if (_onOneraLudum != null) _buttonOneraLudum.clicked += _onOneraLudum;
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
            TollereIndexusPrincipalis();
        }

        private void ExuereCallbacks() {
            if (_onLudusNovus != null) {
                _buttonLudusNovus.clicked -= _onLudusNovus;
            }
            _onLudusNovus = null;

            if (_onPergeLudum != null) {
                _buttonPergeLudum.clicked -= _onPergeLudum;
            }
            _onPergeLudum = null;

            if (_onOneraLudum != null) {
                _buttonOneraLudum.clicked -= _onOneraLudum;
            }
            _onOneraLudum = null;

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
            TollereIndexusPrincipalis();
        }
    }
}
