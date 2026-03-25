using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;
using System;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class TabulaCivisStatuum {
        private readonly IStatusCivisCorporis[] _statuum;

        public TabulaCivisStatuum(
            IConfiguratioCivisStatuum configuratioStatuum,
            ContextusStatusCivisCorporis contextus
        ) {
            int longitudo = Enum.GetValues(typeof(IDCivisStatusCorporis)).Length;
            _statuum = new IStatusCivisCorporis[longitudo];

            foreach (var conf in configuratioStatuum.StatuumCorporis) {
                _statuum[(int)conf.Id] = FabricaStatusCivisCorporis.Creare(
                    configuratioStatuum,
                    conf,
                    contextus
                );
            }

            _statuum[(int)IDCivisStatusCorporis.Suicidium] = new StatusCivisCorporisSuicidium(contextus);

            for (int i = 0; i < longitudo; i++) {
                IDCivisStatusCorporis id = (IDCivisStatusCorporis)i;
                if (id == IDCivisStatusCorporis.Nihil) continue;
                if (_statuum[i] == null) {
                    Carnifex.Intermissio(LogTextus.MachinaCivisStatuumCorporis_MACHINACIVISSTATUUMCORPORIS_STATUS_MISSING);
                }
            }
        }

        public IStatusCivisCorporis Legere(IDCivisStatusCorporis id) => _statuum[(int)id];
    }
}
