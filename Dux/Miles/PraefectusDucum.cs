using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.Dux.Thesaurus;
using Yulinti.Nucleus;

namespace Yulinti.Dux.Miles {
    public sealed class PraefectusDucum : IPulsabilis,  IPulsabilisFixus, IPulsabilisTardus {
        private readonly DuxPuellae _duxPuellae;
        private readonly FasciculusOstiorumPuellae _ostiorumPuellae;

        public PraefectusDucum(
            FasciculusThesaurorum thesaurorum,
            FasciculusOstiorumRationis ostiorumRationis
        ) {
            _ostiorumPuellae = new FasciculusOstiorumPuellae(ostiorumRationis);
            _duxPuellae = new DuxPuellae(thesaurorum.Puellae, _ostiorumPuellae);
        }

        public void Pulsus() {
            _duxPuellae.Pulsus();
        }

        public void PulsusFixus() {
            _duxPuellae.PulsusFixus();
        }

        public void PulsusTardus() {
            _duxPuellae.PulsusTardus();
        }
    }
}
