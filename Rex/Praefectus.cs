using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.Dux.Exercitus;

namespace Yulinti.Rex {
    public sealed class Praefectus {
        private readonly IMinisteria _ministeria;

        public Praefectus(
            IMinisteria ministeria
        ) {
            _ministeria = ministeria;
        }

        public void Pulsus() {
            _ministeria.Pulsus();
        }

        public void PulsusFixus() {
            _ministeria.PulsusFixus();
        }

        public void PulsusTardus() {
            _ministeria.PulsusTardus();
        }
    }
}
