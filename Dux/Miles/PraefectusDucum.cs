using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.Dux.ConfigratioDucis;
using Yulinti.Nucleus;

namespace Yulinti.Dux.Miles {
    public sealed class PraefectusDucum : IPulsabilis, IPulsabilisPostRationem, IPulsabilisFixus, IPulsabilisTardus {
        private readonly DuxPuellae _duxPuellae;
        private readonly FasciculusOstiorum _ostiorumPuellae;

        public PraefectusDucum(
            FasciculusConfigurationumDucis configurationumDucis,
            FasciculusOstiorumRationis ostiorumRationis
        ) {
            _ostiorumPuellae = new FasciculusOstiorum(ostiorumRationis);
            _duxPuellae = new DuxPuellae(configurationumDucis.Puellae, _ostiorumPuellae);
        }

        public void Pulsus() {
            _duxPuellae.Pulsus();
        }

        public void PulsusPostRationem() {
            _duxPuellae.PulsusPostRationem();
        }

        public void PulsusFixus() {
            _duxPuellae.PulsusFixus();
        }

        public void PulsusTardus() {
            _duxPuellae.PulsusTardus();
        }
    }
}
