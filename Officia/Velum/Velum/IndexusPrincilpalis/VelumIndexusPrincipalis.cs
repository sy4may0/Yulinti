using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Auctoritas.Contractus;
using Yulinti.Officia.Contractus;
using UnityEngine.UIElements;

namespace Yulinti.Officia.Velum {
    internal sealed class VelumIndexusPrincipalis : IVelum, IVelumIndexusPrincipalis, IVelumIncipabilis, IVelumLiberabilis, IVelumTerminabilis {
        private readonly IAnchoraVelumIndexusPrincipalis _anchoraVelumIndexusPrincipalis;
        private readonly ITurrisInterpretationis _turrisInterpretationis;
        private readonly ApplicatorSoniVeli _applicatorSoniVeli;
        private readonly IOperatioIndexusPrincipalis _operatioIndexusPrincipalis;

        private UIDocument _uiIndexusPrincipalis;

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

        public VelumIndexusPrincipalis(
            IAnchoraVelumIndexusPrincipalis anchoraVelumIndexusPrincipalis,
            ITurrisInterpretationis turrisInterpretationis,
            ApplicatorSoniVeli applicatorSoniVeli,
            IOperatioIndexusPrincipalis operatioIndexusPrincipalis
        ) {
            _anchoraVelumIndexusPrincipalis = anchoraVelumIndexusPrincipalis;
            _turrisInterpretationis = turrisInterpretationis;
            _applicatorSoniVeli = applicatorSoniVeli;
            _operatioIndexusPrincipalis = operatioIndexusPrincipalis;
        }

        // 各UI要素を初期化する。
        public void Incipere() {
            _uiIndexusPrincipalis = _anchoraVelumIndexusPrincipalis.UIDocument;
            _containerIndexusPrincipalis = _uiIndexusPrincipalis.rootVisualElement.Q<VisualElement>("indexprincipalis-root");
            _panelIndexusPrincipalis = _uiIndexusPrincipalis.rootVisualElement.Q<VisualElement>("indexprincipalis-panel");

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

            ActivareCB();
        }

        public void Activare() {
            _containerIndexusPrincipalis.style.display = DisplayStyle.Flex;
            _buttonLudusNovus.Focus();
        }

        public void Deactivare() {
            _containerIndexusPrincipalis.style.display = DisplayStyle.None;
        }

        public void DemittereIndexusPrincipalis() {
            Activare();
        }

        public void TollereIndexusPrincipalis() {
            Deactivare();
        }

        public void ActivareUsus(UsusIndexusPrincipalis usus) {
            if (usus == UsusIndexusPrincipalis.LudusNovus) {
                _buttonLudusNovus.SetEnabled(true);
            } else if (usus == UsusIndexusPrincipalis.PergeLudum) {
                _buttonPergeLudum.SetEnabled(true);
            } else if (usus == UsusIndexusPrincipalis.OneraLudum) {
                _buttonOneraLudum.SetEnabled(true);
            } else if (usus == UsusIndexusPrincipalis.Optiones) {
                _buttonOptiones.SetEnabled(true);
            } else if (usus == UsusIndexusPrincipalis.Exi) {
                _buttonExi.SetEnabled(true);
            }
        }

        public void DeactivareUsus(UsusIndexusPrincipalis usus) {
            if (usus == UsusIndexusPrincipalis.LudusNovus) {
                _buttonLudusNovus.SetEnabled(false);
            } else if (usus == UsusIndexusPrincipalis.PergeLudum) {
                _buttonPergeLudum.SetEnabled(false);
            } else if (usus == UsusIndexusPrincipalis.OneraLudum) {
                _buttonOneraLudum.SetEnabled(false);
            } else if (usus == UsusIndexusPrincipalis.Optiones) {
                _buttonOptiones.SetEnabled(false);
            } else if (usus == UsusIndexusPrincipalis.Exi) {
                _buttonExi.SetEnabled(false);
            }
        }

        private void premereLudusNovus() {
            _operatioIndexusPrincipalis.Executare(UsusIndexusPrincipalis.LudusNovus);
        }

        private void premerePergeLudum() {
            _operatioIndexusPrincipalis.Executare(UsusIndexusPrincipalis.PergeLudum);
        }

        private void premereOneraLudum() {
            _operatioIndexusPrincipalis.Executare(UsusIndexusPrincipalis.OneraLudum);
        }

        private void premereOptiones() {
            _operatioIndexusPrincipalis.Executare(UsusIndexusPrincipalis.Optiones);
        }

        private void premereExi() {
            _operatioIndexusPrincipalis.Executare(UsusIndexusPrincipalis.Exi);
        }

        public void Liberare() {
            if (_uiIndexusPrincipalis == null || _uiIndexusPrincipalis.rootVisualElement == null) {
                return;
            }
            DeactivareCB();
            TollereIndexusPrincipalis();
        }

        private void ActivareCB() {
            _applicatorSoniVeli.ApplicareRadix(_uiIndexusPrincipalis);
            _applicatorSoniVeli.Applicare(_panelIndexusPrincipalis);
            _buttonLudusNovus.clicked -= premereLudusNovus;
            _buttonLudusNovus.clicked += premereLudusNovus;
            _buttonPergeLudum.clicked -= premerePergeLudum;
            _buttonPergeLudum.clicked += premerePergeLudum;
            _buttonOneraLudum.clicked -= premereOneraLudum;
            _buttonOneraLudum.clicked += premereOneraLudum;
            _buttonOptiones.clicked -= premereOptiones;
            _buttonOptiones.clicked += premereOptiones;
            _buttonExi.clicked -= premereExi;
            _buttonExi.clicked += premereExi;
        }

        private void DeactivareCB() {
            _applicatorSoniVeli.PurgereRadix(_uiIndexusPrincipalis);
            _applicatorSoniVeli.Purgere(_panelIndexusPrincipalis);
            _buttonLudusNovus.clicked -= premereLudusNovus;
            _buttonPergeLudum.clicked -= premerePergeLudum;
            _buttonOneraLudum.clicked -= premereOneraLudum;
            _buttonOptiones.clicked -= premereOptiones;
            _buttonExi.clicked -= premereExi;
        }

        public void TollereFinem() {
            TollereIndexusPrincipalis();
        }
    }
}
