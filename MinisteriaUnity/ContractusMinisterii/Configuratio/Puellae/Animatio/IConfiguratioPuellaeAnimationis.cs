namespace Yulinti.MinisteriaUnity.ContractusMinisterii {
    public interface IConfiguratioPuellaeAnimationis {
        IConfiguratioPuellaeAnimationisFundamenti[] Fundamentum { get; }
        IConfiguratioPuellaeAnimationisCorporis[] Corpus { get; }
        IConfiguratioPuellaeAnimationisPartis[] Pars { get; }
    }
}
