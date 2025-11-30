using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public interface IVasculumMinisterii {
        public IVasculumMinisteriumCamera Camera { get; }
        public IVasculumMinisteriumInput Input { get; }
        public IVasculumMinisteriumPuellae Puellae { get; }
        public IVasculumMinisteriumPuellaeCrinis PuellaeCrinis { get; }
        public IVasculumMinisteriumCivis Civis { get; }
    }

    public interface IVasculumMinisteriumCamera {
        public IAnchoraCamera AnchoraCamera { get; }
        public bool EstActivum { get; }
    }

    public interface IVasculumMinisteriumInput {
        public IAnchoraInput AnchoraInput { get; }
        public bool EstActivum { get; }
    }

    public interface IVasculumMinisteriumPuellae {
        public IConfiguratioPuellae Configuratio { get; }
        public IAnchoraPuellae AnchoraPuellae { get; }
        public bool EstActivum { get; }

    }

    public interface IVasculumMinisteriumPuellaeCrinis {
        public IAnchoraPuellaeCrinis[] AnchoraPuellaeCrinum { get; }
        public IAnchoraPuellae AnchoraPuellae { get; }
        public bool EstActivum { get; }
    }

    public interface IVasculumMinisteriumCivis {
        public IConfiguratioCivis Config { get; }
        public IAnchoraCivis[] AnchoraCivis { get; }
        public IAnchoraPunctumViae[] AnchoraPunctumViae { get; }
        public bool EstActivum { get; }
    }
}


