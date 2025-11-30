using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Rex {
    internal sealed class VasculumMinisteriiTestScene : IVasculumMinisterii {
        private readonly IVasculumMinisteriumCamera _vasculumMinisteriumCamera;
        private readonly IVasculumMinisteriumInput _vasculumMinisteriumInput;
        private readonly IVasculumMinisteriumPuellae _vasculumMinisteriumPuellae;
        private readonly IVasculumMinisteriumPuellaeCrinis _vasculumMinisteriumPuellaeCrinis;
        private readonly IVasculumMinisteriumCivis _vasculumMinisteriumCivis;

        public VasculumMinisteriiTestScene(
            IAnchoraPuellae anchoraPuellae,
            IAnchoraCamera anchoraCamera,
            IAnchoraInput anchoraInput,
            IAnchoraPuellaeCrinis[] anchoraPuellaeCrinis,
            IAnchoraCivis[] anchoraCivis,
            IAnchoraPunctumViae[] anchoraPunctumViae,
            IConfiguratioCivis configCivis,
            IConfiguratioPuellae configPuellae
        ) {
            _vasculumMinisteriumCamera = new VasculumMinisteriiCameraTestScene(anchoraCamera);
            _vasculumMinisteriumInput = new VasculumMinisteriiInputTestScene(anchoraInput);
            _vasculumMinisteriumPuellae = new VasculumMinisteriiPuellaeTestScene(anchoraPuellae, configPuellae);
            _vasculumMinisteriumPuellaeCrinis = new VasculumMinisteriiPuellaeCrinisTestScene(anchoraPuellaeCrinis, anchoraPuellae);
            _vasculumMinisteriumCivis = new VasculumMinisteriiCivisTestScene(configCivis, anchoraCivis, anchoraPunctumViae);
        }

        public IVasculumMinisteriumCamera Camera => _vasculumMinisteriumCamera;
        public IVasculumMinisteriumInput Input => _vasculumMinisteriumInput;
        public IVasculumMinisteriumPuellae Puellae => _vasculumMinisteriumPuellae;
        public IVasculumMinisteriumPuellaeCrinis PuellaeCrinis => _vasculumMinisteriumPuellaeCrinis;
        public IVasculumMinisteriumCivis Civis => _vasculumMinisteriumCivis;
    }

    internal sealed class VasculumMinisteriiCameraTestScene : IVasculumMinisteriumCamera {
        private readonly IAnchoraCamera _anchoraCamera;
        private readonly bool _estActivum;

        public VasculumMinisteriiCameraTestScene(IAnchoraCamera anchoraCamera) {
            _anchoraCamera = anchoraCamera;
            _estActivum = true;
        }

        public IAnchoraCamera AnchoraCamera => _anchoraCamera;
        public bool EstActivum => _estActivum;
    }

    internal sealed class VasculumMinisteriiInputTestScene : IVasculumMinisteriumInput {
        private readonly IAnchoraInput _anchoraInput;
        private readonly bool _estActivum;

        public VasculumMinisteriiInputTestScene(IAnchoraInput anchoraInput) {
            _anchoraInput = anchoraInput;
            _estActivum = true;
        }

        public IAnchoraInput AnchoraInput => _anchoraInput;
        public bool EstActivum => _estActivum;
    }

    internal sealed class VasculumMinisteriiPuellaeTestScene : IVasculumMinisteriumPuellae {
        private readonly IAnchoraPuellae _anchoraPuellae;
        private readonly IConfiguratioPuellae _configuratio;
        private readonly bool _estActivum;

        public VasculumMinisteriiPuellaeTestScene(IAnchoraPuellae anchoraPuellae, IConfiguratioPuellae configuratio) {
            _anchoraPuellae = anchoraPuellae;
            _estActivum = true;
            _configuratio = configuratio;
        }

        public IAnchoraPuellae AnchoraPuellae => _anchoraPuellae;
        public IConfiguratioPuellae Configuratio => _configuratio;
        public bool EstActivum => _estActivum;
    }

    internal sealed class VasculumMinisteriiPuellaeCrinisTestScene : IVasculumMinisteriumPuellaeCrinis {
        private readonly IAnchoraPuellaeCrinis[] _anchoraPuellaeCrinum;
        private readonly IAnchoraPuellae _anchoraPuellae;
        private readonly bool _estActivum;

        public VasculumMinisteriiPuellaeCrinisTestScene(IAnchoraPuellaeCrinis[] anchoraPuellaeCrinum, IAnchoraPuellae anchoraPuellae) {
            _anchoraPuellaeCrinum = anchoraPuellaeCrinum;
            _anchoraPuellae = anchoraPuellae;
            _estActivum = true;
        }

        public IAnchoraPuellaeCrinis[] AnchoraPuellaeCrinum => _anchoraPuellaeCrinum;
        public IAnchoraPuellae AnchoraPuellae => _anchoraPuellae;
        public bool EstActivum => _estActivum;
    }

    internal sealed class VasculumMinisteriiCivisTestScene : IVasculumMinisteriumCivis {
        private readonly IConfiguratioCivis _config;
        private readonly IAnchoraCivis[] _anchoraCivis;
        private readonly IAnchoraPunctumViae[] _anchoraPunctumViae;
        private readonly bool _estActivum;

        public VasculumMinisteriiCivisTestScene(IConfiguratioCivis config, IAnchoraCivis[] anchoraCivis, IAnchoraPunctumViae[] anchoraPunctumViae) {
            _config = config;
            _anchoraCivis = anchoraCivis;
            _anchoraPunctumViae = anchoraPunctumViae;
            _estActivum = true;
        }

        public IConfiguratioCivis Config => _config;
        public IAnchoraCivis[] AnchoraCivis => _anchoraCivis;
        public IAnchoraPunctumViae[] AnchoraPunctumViae => _anchoraPunctumViae;
        public bool EstActivum => _estActivum;
    }
}




