using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;
using Yulinti.MinisteriaUnity.Anchora;

namespace Yulinti.Rex {
    internal sealed class VasculumMinisteriiTestScene : IVasculumMinisterii {
        private readonly IVasculumMinisteriumCamera _vasculumMinisteriumCamera;
        private readonly IVasculumMinisteriumInput _vasculumMinisteriumInput;
        private readonly IVasculumMinisteriumPuellae _vasculumMinisteriumPuellae;
        private readonly IVasculumMinisteriumPuellaeCrinis _vasculumMinisteriumPuellaeCrinis;
        private readonly IVasculumMinisteriumCivis _vasculumMinisteriumCivis;

        public VasculumMinisteriiTestScene(
            FasciculusConfigurationum config,
            AnchoraPuellae anchoraPuellae,
            AnchoraCamera anchoraCamera,
            AnchoraInput anchoraInput,
            AnchoraPuellaeCrinis[] anchoraPuellaeCrinis,
            AnchoraCivis[] anchoraCivis,
            AnchoraPunctumViae[] anchoraPunctumViae
        ) {
            _vasculumMinisteriumCamera = new VasculumMinisteriiCameraTestScene(anchoraCamera);
            _vasculumMinisteriumInput = new VasculumMinisteriiInputTestScene(anchoraInput);
            _vasculumMinisteriumPuellae = new VasculumMinisteriiPuellaeTestScene(config.Puellae, anchoraPuellae);
            _vasculumMinisteriumPuellaeCrinis = new VasculumMinisteriiPuellaeCrinisTestScene(anchoraPuellaeCrinis, anchoraPuellae);
            _vasculumMinisteriumCivis = new VasculumMinisteriiCivisTestScene(anchoraCivis, anchoraPunctumViae);
        }

        public IVasculumMinisteriumCamera Camera => _vasculumMinisteriumCamera;
        public IVasculumMinisteriumInput Input => _vasculumMinisteriumInput;
        public IVasculumMinisteriumPuellae Puellae => _vasculumMinisteriumPuellae;
        public IVasculumMinisteriumPuellaeCrinis PuellaeCrinis => _vasculumMinisteriumPuellaeCrinis;
        public IVasculumMinisteriumCivis Civis => _vasculumMinisteriumCivis;
    }

    internal sealed class VasculumMinisteriiCameraTestScene : IVasculumMinisteriumCamera {
        private readonly AnchoraCamera _anchoraCamera;
        private readonly bool _estActivum;

        public VasculumMinisteriiCameraTestScene(AnchoraCamera anchoraCamera) {
            _anchoraCamera = anchoraCamera;
            _estActivum = true;
        }

        public AnchoraCamera AnchoraCamera => _anchoraCamera;
        public bool EstActivum => _estActivum;
    }

    internal sealed class VasculumMinisteriiInputTestScene : IVasculumMinisteriumInput {
        private readonly AnchoraInput _anchoraInput;
        private readonly bool _estActivum;

        public VasculumMinisteriiInputTestScene(AnchoraInput anchoraInput) {
            _anchoraInput = anchoraInput;
            _estActivum = true;
        }

        public AnchoraInput AnchoraInput => _anchoraInput;
        public bool EstActivum => _estActivum;
    }

    internal sealed class VasculumMinisteriiPuellaeTestScene : IVasculumMinisteriumPuellae {
        private readonly FasciculusConfigurationumPuellae _config;
        private readonly AnchoraPuellae _anchoraPuellae;
        private readonly bool _estActivum;

        public VasculumMinisteriiPuellaeTestScene(FasciculusConfigurationumPuellae config, AnchoraPuellae anchoraPuellae) {
            _config = config;
            _anchoraPuellae = anchoraPuellae;
            _estActivum = true;
        }

        public FasciculusConfigurationumPuellae Config => _config;
        public AnchoraPuellae AnchoraPuellae => _anchoraPuellae;
        public bool EstActivum => _estActivum;
    }

    internal sealed class VasculumMinisteriiPuellaeCrinisTestScene : IVasculumMinisteriumPuellaeCrinis {
        private readonly AnchoraPuellaeCrinis[] _anchoraPuellaeCrinum;
        private readonly AnchoraPuellae _anchoraPuellae;
        private readonly bool _estActivum;

        public VasculumMinisteriiPuellaeCrinisTestScene(AnchoraPuellaeCrinis[] anchoraPuellaeCrinum, AnchoraPuellae anchoraPuellae) {
            _anchoraPuellaeCrinum = anchoraPuellaeCrinum;
            _anchoraPuellae = anchoraPuellae;
            _estActivum = true;
        }

        public AnchoraPuellaeCrinis[] AnchoraPuellaeCrinum => _anchoraPuellaeCrinum;
        public AnchoraPuellae AnchoraPuellae => _anchoraPuellae;
        public bool EstActivum => _estActivum;
    }

    internal sealed class VasculumMinisteriiCivisTestScene : IVasculumMinisteriumCivis {
        private readonly AnchoraCivis[] _anchoraCivis;
        private readonly AnchoraPunctumViae[] _anchoraPunctumViae;
        private readonly bool _estActivum;

        public VasculumMinisteriiCivisTestScene(AnchoraCivis[] anchoraCivis, AnchoraPunctumViae[] anchoraPunctumViae) {
            _anchoraCivis = anchoraCivis;
            _anchoraPunctumViae = anchoraPunctumViae;
            _estActivum = true;
        }

        public AnchoraCivis[] AnchoraCivis => _anchoraCivis;
        public AnchoraPunctumViae[] AnchoraPunctumViae => _anchoraPunctumViae;
        public bool EstActivum => _estActivum;
    }
}