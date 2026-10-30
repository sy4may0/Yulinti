using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Auctoritas.Contractus;
using Yulinti.Officia.Contractus;
using UnityEngine.UIElements;

namespace Yulinti.Officia.Velum {
    internal sealed class ParsPulsabulumIndexusPrincipalis {
        private readonly UsusIndexusPrincipalis _usus;
        private readonly IConfiguratioParsPulsabulumIndexusPrincipalis _configuratioParsPulsabulumIndexusPrincipalis;
        private readonly ITurrisInterpretationis _turrisInterpretationis;

        private VisualElement _elementum;
        private VisualElement _parens;
        private Button _pulsabulum;
        private Label _textus;

        public ParsPulsabulumIndexusPrincipalis(
            IConfiguratioParsPulsabulumIndexusPrincipalis configuratioParsPulsabulumIndexusPrincipalis,
            ITurrisInterpretationis turrisInterpretationis
        ) {
            _configuratioParsPulsabulumIndexusPrincipalis = configuratioParsPulsabulumIndexusPrincipalis;
            _turrisInterpretationis = turrisInterpretationis;
            _usus = _configuratioParsPulsabulumIndexusPrincipalis.Usus;
        }

        public void Incipere(VisualElement parens) {
            _parens = parens;
            _elementum = new VisualElement();
            _configuratioParsPulsabulumIndexusPrincipalis.Examplar.CloneTree(_elementum);
            _parens.Add(_elementum);

            _pulsabulum = _parens.Q<Button>("pars-pulsabulum-indexus-principalis-button");
            _textus = _pulsabulum.Q<Label>("pars-pulsabulum-indexus-principalis-label");
            _textus.text = _turrisInterpretationis.LegoTextus(_configuratioParsPulsabulumIndexusPrincipalis.Textus);
            _textus.style.fontSize = _configuratioParsPulsabulumIndexusPrincipalis.MagnitudoLitterarum;
        }
    }
}
