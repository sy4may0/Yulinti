using Yulinti.Exercitus.Contractus;
using Yulinti.Unity.Contractus;
using UnityEngine.UIElements;
using System;

namespace Yulinti.Unity.Velum {
    internal sealed class VelumMonitionis : IVelumMonitionis, IVelum, IVelumLiberabilisRadicis {
        private readonly IAnchoraVelumRadicis _anchoraVelumRadicis;

        private UIDocument _uiMonitionis;

        private Label _labelTitulus;
        private Label _labelTextus;
        private Button _buttonIta;

        private Action _onIta;

        public VelumMonitionis(
            IAnchoraVelumRadicis anchoraVelumRadicis
        ) {
            _anchoraVelumRadicis = anchoraVelumRadicis;
        }

        public void Initare() {
            _uiMonitionis = _anchoraVelumRadicis.UIMonitionis;
            _labelTitulus = _uiMonitionis.rootVisualElement.Q<Label>("monitio-titulus");
            _labelTextus = _uiMonitionis.rootVisualElement.Q<Label>("monitio-textus");
            _buttonIta = _uiMonitionis.rootVisualElement.Q<Button>("monitio-button-ita");

            _onIta = null;

            _buttonIta.clicked += premereIta;

            Deactivare();
        }

        public void Activare() {
            _uiMonitionis.rootVisualElement.style.display = DisplayStyle.Flex;
            _buttonIta.SetEnabled(true);
            _buttonIta.Focus();
        }

        public void Deactivare() {
            _uiMonitionis.rootVisualElement.style.display = DisplayStyle.None;
            _buttonIta.SetEnabled(false);
            _onIta = null;
        }

        public void DemittereMonitionis(
            string titulus,
            string textus,
            string buttonIta,
            Action adPremereIta = null
        ) {
            _labelTitulus.text = titulus;
            _labelTextus.text = textus;
            _buttonIta.text = buttonIta;

            _onIta = adPremereIta;

            Activare();
        }

        public void TollereMonitionis() {
            _onIta = null;
            Deactivare();
        }

        private void premereIta() {
            // まずボタンを全部無効
            _buttonIta.SetEnabled(false);
            _onIta?.Invoke();
            Deactivare();
        }

        public void Liberare() {
            TollereMonitionis();
        }
    }
}
