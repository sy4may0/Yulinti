using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;
using Yulinti.MinisteriaUnity.Anchora;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public interface IVasculumMinisterii {
        public IVasculumMinisteriumCamera Camera { get; }
        public IVasculumMinisteriumInput Input { get; }
        public IVasculumMinisteriumPuellae Puellae { get; }
        public IVasculumMinisteriumPuellaeCrinis PuellaeCrinis { get; }
        public IVasculumMinisteriumCivis Civis { get; }
    }

    public interface IVasculumMinisteriumCamera {
        public AnchoraCamera AnchoraCamera { get; }
        public bool EstActivum { get; }
    }

    public interface IVasculumMinisteriumInput {
        public AnchoraInput AnchoraInput { get; }
        public bool EstActivum { get; }
    }

    public interface IVasculumMinisteriumPuellae {
        public FasciculusConfigurationumPuellae Config { get; }
        public AnchoraPuellae AnchoraPuellae { get; }
        public bool EstActivum { get; }

    }

    public interface IVasculumMinisteriumPuellaeCrinis {
        public AnchoraPuellaeCrinis[] AnchoraPuellaeCrinum { get; }
        public AnchoraPuellae AnchoraPuellae { get; }
        public bool EstActivum { get; }
    }

    public interface IVasculumMinisteriumCivis {
        public AnchoraCivis[] AnchoraCivis { get; }
        public AnchoraPunctumViae[] AnchoraPunctumViae { get; }
        public bool EstActivum { get; }
    }
}