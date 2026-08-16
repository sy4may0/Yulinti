using Yulinti.Officia.Contractus;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.Officia.Turris {
    internal sealed class TurrisCorrectrix : ITurrisCorrectrix {
        private readonly IConfiguratioCorrectrix _configuratioCorrectrix;

        public TurrisCorrectrix(IConfiguratioCorrectrix configuratioCorrectrix) {
            _configuratioCorrectrix = configuratioCorrectrix;
        }

        public bool EstCorrigere() {
            return _configuratioCorrectrix.EstCorrigere;
        }
    }
}