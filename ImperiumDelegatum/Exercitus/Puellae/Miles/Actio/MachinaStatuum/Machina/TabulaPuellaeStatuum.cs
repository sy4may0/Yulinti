using Yulinti.ImperiumDelegatum.Contractus;
using System;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class TabulaPuellaeStatuum {
        private readonly IStatusPuellaeCorporis[] _statuum;

        public TabulaPuellaeStatuum(
            IConfiguratioPuellaeStatuum configuratioStatuum
        ) {
            int longitudo = Enum.GetValues(typeof(IDPuellaeStatusCorporis)).Length;
            _statuum = new IStatusPuellaeCorporis[longitudo];

            foreach (var conf in configuratioStatuum.StatuumCorporis) {
                _statuum[(int)conf.Id] = FabricaStatusPuellaeCorporis.Creare(
                    configuratioStatuum,
                    conf
                );
            }
        }

        public IStatusPuellaeCorporis Legere(IDPuellaeStatusCorporis id) => _statuum[(int)id];
    }
}
