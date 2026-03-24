using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ContextusRamusPuellae {
        public ContextusRamusPuellae(
            IConfiguratioPuellaeStatuum configuratioStatuum,
            ITurrisIntroductionis introductionis
        ) {
            ConfiguratioStatuum = configuratioStatuum;
            Introductionis = introductionis;
        }

        public IConfiguratioPuellaeStatuum ConfiguratioStatuum { get; }
        public ITurrisIntroductionis Introductionis { get; }
    }
}
