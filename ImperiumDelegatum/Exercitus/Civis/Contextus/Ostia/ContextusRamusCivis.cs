using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ContextusRamusCivis {
        private readonly IConfiguratioCivisStatuum _configuratioStatuum;
        private readonly IOstiumCivisLociLegibile _loci;

        public ContextusRamusCivis(
            IConfiguratioCivisStatuum configuratioStatuum,
            IOstiumCivisLociLegibile loci
        ) {
            _configuratioStatuum = configuratioStatuum;
            _loci = loci;
        }

        public IConfiguratioCivisStatuum ConfiguratioStatuum => _configuratioStatuum;
        public IOstiumCivisLociLegibile Loci => _loci;

    }
}