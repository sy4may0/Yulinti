namespace Yulinti.MinisteriaUnity.ContractusMinisterii {
    public interface IConfiguratioCivis {
        IConfiguratioCivisLoci Loci { get; }
        IConfiguratioCivisAnimationis Animatio { get; }
        IConfiguratioCivisGenerator Generator { get; }
        IConfiguratioCivisVisae Visa { get; }
    }
}
