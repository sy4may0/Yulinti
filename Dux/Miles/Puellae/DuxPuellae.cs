using Yulinti.Nucleus;
using Yulinti.Dux.ConfigratioDucis;
using Yulinti.Dux.Miles;

namespace Yulinti.Dux.Miles {
    public sealed class DuxPuellae : IPulsabilis, IPulsabilisFixus, IPulsabilisTardus, IPulsabilisPostRationem {
        private readonly MachinaStatuumPuellae _machinaStatuumPuellae;

        public DuxPuellae(
            FasciculusConfigurationumDucisPuellae configuratioDucisPuellae,
            FasciculusOstiorum ostia
        ) {
            _machinaStatuumPuellae = new MachinaStatuumPuellae(configuratioDucisPuellae.Status, ostia);
        }

        public void Pulsus() {
            _machinaStatuumPuellae.Opero();
        }
        public void PulsusPostRationem() {
            _machinaStatuumPuellae.OperoRelatum();
        }

        public void PulsusFixus() {
        }

        public void PulsusTardus() {
        }
    }
}
