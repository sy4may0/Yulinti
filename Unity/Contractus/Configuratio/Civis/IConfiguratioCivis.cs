namespace Yulinti.Unity.Contractus {
    public interface IConfiguratioCivis {
        IConfiguratioCivisLoci Loci { get; }
        IConfiguratioCivisAnimationis Animatio { get; }
        IConfiguratioCivisGenerator Generator { get; }
        IConfiguratioCivisVisae Visa { get; }
    }
}
