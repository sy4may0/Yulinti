using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Auctoritas.Contractus;
using Yulinti.Officia.Contractus;
using UnityEngine.UIElements;
using System;

namespace Yulinti.Officia.Velum {
    internal sealed class VelumConfirmationis : IVelumConfirmationis, IVelum, IVelumLiberabilisRadicis {
        private readonly IAnchoraVelumRadicis _anchoraVelumRadicis;
        private readonly ApplicatorSoniVeli _applicatorSoniVeli;

        private UIDocument _uiConfirmationis;

        private Label _labelTitulus;
        private Label _labelTextus;
        private Button _buttonIta;
        private Button _buttonNon;

        private Action _onIta;
        private Action _onNon;

        public VelumConfirmationis(
            IAnchoraVelumRadicis anchoraVelumRadicis,
            ApplicatorSoniVeli applicatorSoniVeli
        ) {
            _anchoraVelumRadicis = anchoraVelumRadicis;
            _applicatorSoniVeli = applicatorSoniVeli;
        }

        public void Initare() {
            _uiConfirmationis = _anchoraVelumRadicis.UIConfirmationis;
            _labelTitulus = _uiConfirmationis.rootVisualElement.Q<Label>("confirmatio-titulus");
            _labelTextus = _uiConfirmationis.rootVisualElement.Q<Label>("confirmatio-textus");
            _buttonIta = _uiConfirmationis.rootVisualElement.Q<Button>("confirmatio-button-ita");
            _buttonNon = _uiConfirmationis.rootVisualElement.Q<Button>("confirmatio-button-non");

            _onIta = null;
            _onNon = null;
            ActivareCB();
            Deactivare();
        }

        public void Activare() {
            _uiConfirmationis.rootVisualElement.style.display = DisplayStyle.Flex;
            _buttonIta.SetEnabled(true);
            _buttonNon.SetEnabled(true);
            _buttonIta.Focus();
        }

        public void Deactivare() {
            _uiConfirmationis.rootVisualElement.style.display = DisplayStyle.None;
            _buttonIta.SetEnabled(false);
            _buttonNon.SetEnabled(false);
       }

        public void DemittereConfirmationis(
            string titulus,
            string textus,
            string buttonIta,
            string buttonNon,
            Action adPremereIta = null,
            Action adPremereNon = null
        ) {
            _labelTitulus.text = titulus;
            _labelTextus.text = textus;
            _buttonIta.text = buttonIta;
            _buttonNon.text = buttonNon;

            _onIta = adPremereIta;
            _onNon = adPremereNon;
            Activare();
        }

        public void TollereConfirmationis() {
            _onIta = null;
            _onNon = null;
            Deactivare();
        }

        private void ActivareCB() {
            _applicatorSoniVeli.ApplicareRadix(_uiConfirmationis);
            _applicatorSoniVeli.Applicare(_uiConfirmationis.rootVisualElement);
            _buttonIta.clicked -= premereIta;
            _buttonIta.clicked += premereIta;
            _buttonNon.clicked -= premereNon;
            _buttonNon.clicked += premereNon;
        }

        private void DeactivareCB() {
            _applicatorSoniVeli.PurgereRadix(_uiConfirmationis);
            _applicatorSoniVeli.Purgere(_uiConfirmationis.rootVisualElement);
            _buttonIta.clicked -= premereIta;
            _buttonNon.clicked -= premereNon;
        }


        private void premereIta() {
            // まずボタンを全部無効
            _buttonIta.SetEnabled(false);
            _buttonNon.SetEnabled(false);

            _onIta?.Invoke();
 
            // UIを閉じる
            Deactivare();
       }

        private void premereNon() {
            // まずボタンを全部無効
            _buttonIta.SetEnabled(false);
            _buttonNon.SetEnabled(false);
  
            _onNon?.Invoke();

            // UIを閉じる
            Deactivare();
        }

        public void Liberare() {
            DeactivareCB();
            TollereConfirmationis();
        }
    }

}