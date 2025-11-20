using Yulinti.Nucleus.Interfacies;
using Yulinti.Dux.ConfiguratioDucis;
using Yulinti.Dux.Miles.Puellae.Status;
using Yulinti.Dux.Miles.Puellae.Interna;

namespace Yulinti.Dux {
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