using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Auctoritas.Contractus;
using Yulinti.Officia.Contractus;
using UnityEngine.UIElements;

namespace Yulinti.Officia.Velum {
    internal sealed class VelumPortusConstructionis : IVelum, IVelumPortusConstructionis, IVelumIncipabilis, IVelumLiberabilis, IVelumTerminabilis {
        private const string ClassisNavbarButtonSelectus = "constructio-navbar-button--selectus";

        private readonly IAnchoraVelumConstructionis _anchoraVelumConstructionis;
        private readonly ITurrisInterpretationis _turrisInterpretationis;
        private readonly ApplicatorSoniVeli _applicatorSoniVeli;
        private readonly IOperatioPortusConstructionis _operatioPortusConstructionis;

        private UIDocument _uiPortusConstructionis;

        private VisualElement _containerPortusConstructionis;

        private Button _buttonLapsorCorporis;
        private Button _buttonLapsorFaciei;
        private Button _buttonSubligaculum;
        private Button _buttonTunica;
        private Button _buttonOrnamentum;
        private Button _buttonSalsamentum;
        private Button _buttonExi;

        private Label _labelConstructionis;

        public VelumPortusConstructionis(
            IAnchoraVelumConstructionis anchoraVelumConstructionis,
            ITurrisInterpretationis turrisInterpretationis,
            ApplicatorSoniVeli applicatorSoniVeli,
            IOperatioPortusConstructionis operatioPortusConstructionis
        ) {
            _anchoraVelumConstructionis = anchoraVelumConstructionis;
            _turrisInterpretationis = turrisInterpretationis;
            _applicatorSoniVeli = applicatorSoniVeli;
            _operatioPortusConstructionis = operatioPortusConstructionis;
        }

        public void Incipere() {
            _uiPortusConstructionis = _anchoraVelumConstructionis.UIDocument;

            _containerPortusConstructionis = _uiPortusConstructionis.rootVisualElement.Q<VisualElement>("constructio-root");
            _buttonLapsorCorporis = _containerPortusConstructionis.Q<Button>("constructio-navbar-button-lapsorcorporis");
            _buttonLapsorFaciei = _containerPortusConstructionis.Q<Button>("constructio-navbar-button-lapsorfaciei");
            _buttonSubligaculum = _containerPortusConstructionis.Q<Button>("constructio-navbar-button-subligaculum");
            _buttonTunica = _containerPortusConstructionis.Q<Button>("constructio-navbar-button-tunica");
            _buttonOrnamentum = _containerPortusConstructionis.Q<Button>("constructio-navbar-button-ornamentum");
            _buttonSalsamentum = _containerPortusConstructionis.Q<Button>("constructio-navbar-button-salsamentum");
            _buttonExi = _containerPortusConstructionis.Q<Button>("constructio-button-exi");
            _labelConstructionis = _containerPortusConstructionis.Q<Label>("constructio-title");

            _buttonExi.text = _turrisInterpretationis.LegoTextus(IDTextus.PORTUS_CONSTRUCTIONIS_BUTTON_EXI);
            _labelConstructionis.text = _turrisInterpretationis.LegoTextus(IDTextus.PORTUS_CONSTRUCTIONIS_LABEL);

            ActivareCB();
        }

        public void Activare() {
            _containerPortusConstructionis.style.display = DisplayStyle.Flex;
        }

        public void Deactivare() {
            _containerPortusConstructionis.style.display = DisplayStyle.None;
        }

        public void DemittereConstructionis() {
            Activare();
            SeligereTab(_buttonLapsorCorporis);
            _buttonLapsorCorporis.Focus();
        }

        // タブ選択の維持.
        private void SeligereTab(Button button) {
            _buttonLapsorCorporis.RemoveFromClassList(ClassisNavbarButtonSelectus);
            _buttonLapsorFaciei.RemoveFromClassList(ClassisNavbarButtonSelectus);
            _buttonSubligaculum.RemoveFromClassList(ClassisNavbarButtonSelectus);
            _buttonTunica.RemoveFromClassList(ClassisNavbarButtonSelectus);
            _buttonOrnamentum.RemoveFromClassList(ClassisNavbarButtonSelectus);
            _buttonSalsamentum.RemoveFromClassList(ClassisNavbarButtonSelectus);
            button.AddToClassList(ClassisNavbarButtonSelectus);
        }

        public void TollereConstructionis() {
            Deactivare();
        }

        public void PonoPermissionemUsus(UsusPortusConstructionis usus, bool permissio) {
            if (usus == UsusPortusConstructionis.LapsorCorporis) {
                _buttonLapsorCorporis.SetEnabled(permissio);
            } else if (usus == UsusPortusConstructionis.LapsorFaciei) {
                _buttonLapsorFaciei.SetEnabled(permissio);
            } else if (usus == UsusPortusConstructionis.Subligaculum) {
                _buttonSubligaculum.SetEnabled(permissio);
            } else if (usus == UsusPortusConstructionis.Tunica) {
                _buttonTunica.SetEnabled(permissio);
            } else if (usus == UsusPortusConstructionis.Ornamentum) {
                _buttonOrnamentum.SetEnabled(permissio);
            } else if (usus == UsusPortusConstructionis.Salsamentum) {
                _buttonSalsamentum.SetEnabled(permissio);
            } else if (usus == UsusPortusConstructionis.Exi) {
                _buttonExi.SetEnabled(permissio);
            }
        }

        private void premereLapsorCorporis() {
            SeligereTab(_buttonLapsorCorporis);
            _operatioPortusConstructionis.Executare(UsusPortusConstructionis.LapsorCorporis);
        }

        private void premereLapsorFaciei() {
            SeligereTab(_buttonLapsorFaciei);
            _operatioPortusConstructionis.Executare(UsusPortusConstructionis.LapsorFaciei);
        }

        private void premereSubligaculum() {
            SeligereTab(_buttonSubligaculum);
            _operatioPortusConstructionis.Executare(UsusPortusConstructionis.Subligaculum);
        }

        private void premereTunica() {
            SeligereTab(_buttonTunica);
            _operatioPortusConstructionis.Executare(UsusPortusConstructionis.Tunica);
        }

        private void premereOrnamentum() {
            SeligereTab(_buttonOrnamentum);
            _operatioPortusConstructionis.Executare(UsusPortusConstructionis.Ornamentum);
        }

        private void premereSalsamentum() {
            SeligereTab(_buttonSalsamentum);
            _operatioPortusConstructionis.Executare(UsusPortusConstructionis.Salsamentum);
        }

        private void premereExi() {
            _operatioPortusConstructionis.Executare(UsusPortusConstructionis.Exi);
        }

        private void ActivareCB() {
            _applicatorSoniVeli.ApplicareRadix(_uiPortusConstructionis);
            _applicatorSoniVeli.Applicare(_containerPortusConstructionis);
            _buttonLapsorCorporis.clicked -= premereLapsorCorporis;
            _buttonLapsorCorporis.clicked += premereLapsorCorporis;
            _buttonLapsorFaciei.clicked -= premereLapsorFaciei;
            _buttonLapsorFaciei.clicked += premereLapsorFaciei;
            _buttonSubligaculum.clicked -= premereSubligaculum;
            _buttonSubligaculum.clicked += premereSubligaculum;
            _buttonTunica.clicked -= premereTunica;
            _buttonTunica.clicked += premereTunica;
            _buttonOrnamentum.clicked -= premereOrnamentum;
            _buttonOrnamentum.clicked += premereOrnamentum;
            _buttonSalsamentum.clicked -= premereSalsamentum;
            _buttonSalsamentum.clicked += premereSalsamentum;
            _buttonExi.clicked -= premereExi;
            _buttonExi.clicked += premereExi;
        }

        private void DeactivareCB() {
            _applicatorSoniVeli.PurgereRadix(_uiPortusConstructionis);
            _applicatorSoniVeli.Purgere(_containerPortusConstructionis);
            _buttonLapsorCorporis.clicked -= premereLapsorCorporis;
            _buttonLapsorFaciei.clicked -= premereLapsorFaciei;
            _buttonSubligaculum.clicked -= premereSubligaculum;
            _buttonTunica.clicked -= premereTunica;
            _buttonOrnamentum.clicked -= premereOrnamentum;
            _buttonSalsamentum.clicked -= premereSalsamentum;
            _buttonExi.clicked -= premereExi;
        }

        public void TollereFinem() {
            TollereConstructionis();
        }

        public void Liberare() {
            if (_uiPortusConstructionis == null || _uiPortusConstructionis.rootVisualElement == null) {
                return;
            }
            DeactivareCB();
            TollereConstructionis();
        }
    }
}