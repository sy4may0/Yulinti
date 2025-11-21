using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class FasciculusOstiorumRationis : IPulsabilis {
        private readonly FasciculusOstiorumNuclei _nuclei;
        private readonly FasciculusOstiorumInput _input;
        private readonly FasciculusOstiorumCamera _camera;
        private readonly FasciculusOstiorumPuellae _puellae;

        public FasciculusOstiorumRationis(FasciculusConfigurationum configurationum, ITemporis temporis) {
            _nuclei = new FasciculusOstiorumNuclei(temporis);
            _input = new FasciculusOstiorumInput(configurationum.Input);
            _camera = new FasciculusOstiorumCamera(configurationum.Camera);
            _puellae = new FasciculusOstiorumPuellae(configurationum.Puellae, temporis);
        }

        public FasciculusOstiorumNuclei Nuclei => _nuclei;
        public FasciculusOstiorumInput Input => _input;
        public FasciculusOstiorumCamera Camera => _camera;
        public FasciculusOstiorumPuellae Puellae => _puellae;

        public void Pulsus() {
            _puellae.Pulsus();
        }

        public void PulsusFixus() {
        }

        public void PulsusTardus() {
        }
    }
}
        
