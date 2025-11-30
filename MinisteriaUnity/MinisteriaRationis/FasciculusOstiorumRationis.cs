using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class FasciculusOstiorumRationis : IPulsabilis {
        private readonly FasciculusOstiorumNuclei _nuclei;
        private readonly FasciculusOstiorumInput _input;
        private readonly FasciculusOstiorumCamera _camera;
        private readonly FasciculusOstiorumPuellae _puellae;
        private readonly FasciculusOstiorumPuellaeCrinis _puellaeCrinis;

        public FasciculusOstiorumRationis(IVasculumMinisterii vasculumMinisterii, ITemporis temporis) {
            _nuclei = new FasciculusOstiorumNuclei(temporis);

            // Input
            if (vasculumMinisterii.Input != null && vasculumMinisterii.Input.EstActivum) {
                _input = new FasciculusOstiorumInput(vasculumMinisterii.Input);
            } else {
                _input = null;
            }

            // Camera
            if (vasculumMinisterii.Camera != null && vasculumMinisterii.Camera.EstActivum) {
                _camera = new FasciculusOstiorumCamera(vasculumMinisterii.Camera.AnchoraCamera);
            } else {
                _camera = null;
            }

            // Puellae (uses config + anchora via Vasculum)
            if (vasculumMinisterii.Puellae != null && vasculumMinisterii.Puellae.EstActivum) {
                _puellae = new FasciculusOstiorumPuellae(temporis, vasculumMinisterii.Puellae);
            } else {
                _puellae = null;
            }

            // PuellaeCrinis (uses anchora array + puellae anchora)
            if (vasculumMinisterii.PuellaeCrinis != null && vasculumMinisterii.PuellaeCrinis.EstActivum) {
                _puellaeCrinis = new FasciculusOstiorumPuellaeCrinis(
                    vasculumMinisterii.PuellaeCrinis.AnchoraPuellaeCrinum,
                    vasculumMinisterii.PuellaeCrinis.AnchoraPuellae
                );
            } else {
                _puellaeCrinis = null;
            }
        }

        public FasciculusOstiorumNuclei Nuclei => _nuclei;
        public FasciculusOstiorumInput Input => _input;
        public FasciculusOstiorumCamera Camera => _camera;
        public FasciculusOstiorumPuellae Puellae => _puellae;
        public FasciculusOstiorumPuellaeCrinis PuellaeCrinis => _puellaeCrinis;

        public void Pulsus() {
            _puellae?.Pulsus();
        }

        public void PulsusFixus() {
        }

        public void PulsusTardus() {
        }
    }
}
        



