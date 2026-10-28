using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Auctoritas.Contractus;
using Yulinti.Officia.Contractus;
using UnityEngine.UIElements;

namespace Yulinti.Officia.Velum {
    internal sealed class VelumParsPortusConstructionisPulsabulumCrinisPosterior : IVelumPars, IVelumLiberabilis, IVelumTerminabilis {
        private readonly IDPuellaeCrinisCollectionisPosterior _id;

        private readonly IOperatioPortusConstructionisPulsabulumCrinisPosterior _operatioPortusConstructionisPulsabulumCrinisPosterior;
        private readonly IConfiguratioVelumPuellaeCrinisPosterior _configuratioVelumPuellaeCrinisPosterior;
        private readonly VisualTreeAsset _examplar;

        private VisualElement _parens;
        private VisualElement _elementum;

        private Button _pulsabulum;
        private Image _imago;

        public VelumParsPortusConstructionisPulsabulumCrinisPosterior(
            IAnchoraVelumConstructionis anchoraVelumConstructionis,
            IConfiguratioVelumPuellaeCrinisPosterior configuratioVelumPuellaeCrinisPosterior,
            IOperatioPortusConstructionisPulsabulumCrinisPosterior operatioPortusConstructionisPulsabulumCrinisPosterior
        ) {
            _id = configuratioVelumPuellaeCrinisPosterior.IDPuellaeCrinisCollectionis;
            _examplar = anchoraVelumConstructionis.ParsPortusConstructionisLapsorFacieiCrinis;
            _configuratioVelumPuellaeCrinisPosterior = configuratioVelumPuellaeCrinisPosterior;
            _operatioPortusConstructionisPulsabulumCrinisPosterior = operatioPortusConstructionisPulsabulumCrinisPosterior;
        }

        public void Incipere(VisualElement parens) {
            _parens = parens;
            _elementum = new VisualElement();
            _examplar.CloneTree(_elementum);
            _parens.Add(_elementum);

            _pulsabulum = _elementum.Q<Button>("pars-portus-constructionis-lapsor-faciei-crinis-button");
            _imago = _elementum.Q<Image>("pars-portus-constructionis-lapsor-faciei-crinis-image");

            _imago.sprite = _configuratioVelumPuellaeCrinisPosterior.ImagoPulsabuli;

            ActivareCB();
        }

        public void Activare() {
            _elementum.style.display = DisplayStyle.Flex;
        }

        public void Deactivare() {
            _elementum.style.display = DisplayStyle.None;
        }

        public void Focus() {
            _elementum.Focus();
        }

        public void PonoPermissiones(bool permissio) {
            _pulsabulum.SetEnabled(permissio);
        }

        private void premerePulsabulum() {
            _operatioPortusConstructionisPulsabulumCrinisPosterior.Executare(_id);
        }

        private void ActivareCB() {
            _pulsabulum.clicked -= premerePulsabulum;
            _pulsabulum.clicked += premerePulsabulum;
        }

        private void DeactivareCB() {
            _pulsabulum.clicked -= premerePulsabulum;
        }

        public void TollereFinem() {
            Deactivare();
        }

        public void Liberare() {
            if (_elementum == null || _elementum.style.display == DisplayStyle.None) {
                return;
            }
            DeactivareCB();
            Deactivare();
        }
    }
}