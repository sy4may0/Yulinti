using Yulinti.Exercitus.Contractus;
using Yulinti.Unity.Contractus;
using UnityEngine.UIElements;

namespace Yulinti.Unity.Velum {
    internal enum StatusIndexusPrincipalis {
        None,
        IndexusPrincipalis,
        SelectorisSalsamenti,
        Optiones,
    }

    internal sealed class VelumIndexusPrincipalis : IVelum, IVelumIndexusPrincipalis, IVelumIncipabilis {
        private readonly IAnchoraVelumIndexusPrincipalis _anchoraVelumIndexusPrincipalis;
        private readonly ILegatusIndexusPrincipalis _legatusIndexusPrincipalis;
        private readonly ITurrisInterpretationis _turrisInterpretationis;
        private StatusIndexusPrincipalis _statusIndexusPrincipalis;

        private VisualElement _containerIndexusPrincipalis;
        private VisualElement _containerSelectorisSalsamenti;
        private VisualElement _containerOptions;

        private VisualElement _panelIndexusPrincipalis;

        private Button _buttonLudusNovus;
        private Button _buttonPergeLudum;
        private Button _buttonOneraLudum;
        private Button _buttonOptiones;
        private Button _buttonExi;

        public VelumIndexusPrincipalis(
            IAnchoraVelumIndexusPrincipalis anchoraVelumIndexusPrincipalis,
            ILegatusIndexusPrincipalis legatusIndexusPrincipalis,
            ITurrisInterpretationis turrisInterpretationis
        ) {
            _anchoraVelumIndexusPrincipalis = anchoraVelumIndexusPrincipalis;
            _legatusIndexusPrincipalis = legatusIndexusPrincipalis;
            _turrisInterpretationis = turrisInterpretationis;
            _statusIndexusPrincipalis = StatusIndexusPrincipalis.None;
        }

        // 各UI要素を初期化する。
        public void Initare() {
            _containerIndexusPrincipalis = _anchoraVelumIndexusPrincipalis.UIDocument.rootVisualElement.Q<VisualElement>("indexprincipalis-root");
            _containerSelectorisSalsamenti = _anchoraVelumIndexusPrincipalis.UIDocument.rootVisualElement.Q<VisualElement>("selectorsalsamenti");
            _containerOptions = _anchoraVelumIndexusPrincipalis.UIDocument.rootVisualElement.Q<VisualElement>("optiones");
            _panelIndexusPrincipalis = _anchoraVelumIndexusPrincipalis.UIDocument.rootVisualElement.Q<VisualElement>("indexprincipalis-panel");

            _buttonLudusNovus = _panelIndexusPrincipalis.Q<Button>("buttonLudusNovus");
            _buttonPergeLudum = _panelIndexusPrincipalis.Q<Button>("buttonPergeLudum");
            _buttonOneraLudum = _panelIndexusPrincipalis.Q<Button>("buttonOneraLudum");
            _buttonOptiones = _panelIndexusPrincipalis.Q<Button>("buttonOptiones");
            _buttonExi = _panelIndexusPrincipalis.Q<Button>("buttonExi");

            _buttonLudusNovus.text = _turrisInterpretationis.LegoTextus(IDTextus.INDEXUS_PRINCIPALIS_LUDUS_NOVUS);
            _buttonPergeLudum.text = _turrisInterpretationis.LegoTextus(IDTextus.INDEXUS_PRINCIPALIS_PERGE_LUDUM);
            _buttonOneraLudum.text = _turrisInterpretationis.LegoTextus(IDTextus.INDEXUS_PRINCIPALIS_ONERA_LUDUM);
            _buttonOptiones.text = _turrisInterpretationis.LegoTextus(IDTextus.INDEXUS_PRINCIPALIS_OPTIONES);
            _buttonExi.text = _turrisInterpretationis.LegoTextus(IDTextus.INDEXUS_PRINCIPALIS_EXIT);

            _buttonLudusNovus.clicked += AdPremereLudusNovus;
            _buttonPergeLudum.clicked += AdPremerePergeLudum;
            _buttonOneraLudum.clicked += AdPremereOneraLudum;
            _buttonOptiones.clicked += AdPremereOptiones;
            _buttonExi.clicked += AdPremereExi;
        }

        public void Incipere() {
            Initare();
            Activare();
        }

        public void Activare() {
            DemittereIndexusPrincipalis();
        }

        public void Deactivare() {
            _containerIndexusPrincipalis.style.display = DisplayStyle.None;
            _containerSelectorisSalsamenti.style.display = DisplayStyle.None;
            _containerOptions.style.display = DisplayStyle.None;
            _statusIndexusPrincipalis = StatusIndexusPrincipalis.None;
        }

        public void DemittereIndexusPrincipalis() {
            Demittere(StatusIndexusPrincipalis.IndexusPrincipalis);
            _buttonLudusNovus.Focus();
        }

        public void DemittereSelectorisSalsamenti() {
            Demittere(StatusIndexusPrincipalis.SelectorisSalsamenti);
        }

        public void DemittereOptiones() {
            Demittere(StatusIndexusPrincipalis.Optiones);
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

        public void DeactivateButton(ButtonIndexusPrincipalis buttonIndexusPrincipalis) {
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

        private void Demittere(StatusIndexusPrincipalis status) {
            if (_statusIndexusPrincipalis == status) {
                return;
            }
            switch (status) {
                case StatusIndexusPrincipalis.IndexusPrincipalis:
                    _containerIndexusPrincipalis.style.display = DisplayStyle.Flex;
                    _containerSelectorisSalsamenti.style.display = DisplayStyle.None;
                    _containerOptions.style.display = DisplayStyle.None;
                    break;
                case StatusIndexusPrincipalis.SelectorisSalsamenti:
                    _containerIndexusPrincipalis.style.display = DisplayStyle.None;
                    _containerSelectorisSalsamenti.style.display = DisplayStyle.Flex;
                    _containerOptions.style.display = DisplayStyle.None;
                    break;
                case StatusIndexusPrincipalis.Optiones:
                    _containerIndexusPrincipalis.style.display = DisplayStyle.None;
                    _containerSelectorisSalsamenti.style.display = DisplayStyle.None;
                    _containerOptions.style.display = DisplayStyle.Flex;
                    break;
                case StatusIndexusPrincipalis.None:
                    _containerIndexusPrincipalis.style.display = DisplayStyle.None;
                    _containerSelectorisSalsamenti.style.display = DisplayStyle.None;
                    _containerOptions.style.display = DisplayStyle.None;
                    break;
            }
            _statusIndexusPrincipalis = status;
        }

        private void AdPremereLudusNovus() {
            _legatusIndexusPrincipalis.PostulareLudusNovus();
        }

        private void AdPremerePergeLudum() {
            _legatusIndexusPrincipalis.PostularePergeLudum();
        }

        private void AdPremereOneraLudum() {
            _legatusIndexusPrincipalis.PostulareOneraLudum();
        }

        private void AdPremereOptiones() {
            _legatusIndexusPrincipalis.PostulareOptiones();
        }

        private void AdPremereExi() {
            _legatusIndexusPrincipalis.PostulareExi();
        }
    }
}