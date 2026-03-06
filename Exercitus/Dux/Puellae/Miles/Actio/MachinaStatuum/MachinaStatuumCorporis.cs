using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Dux {
    internal sealed class MachinaStatuumCorporis {
        private readonly ContextusPuellaeOstiorumLegibile _contextusOstiorum;
        private readonly IStatusPuellaeCorporis[] _statuum;

        public MachinaStatuumCorporis(
            ContextusPuellaeOstiorumLegibile contextusOstiorum
        ) {
            _contextusOstiorum = contextusOstiorum;
        }
    }
}