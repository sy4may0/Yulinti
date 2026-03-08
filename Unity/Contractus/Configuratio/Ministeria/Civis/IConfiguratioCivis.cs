namespace Yulinti.Unity.Contractus {
    public interface IConfiguratioCivis {
        IConfiguratioCivisLoci Loci { get; }
        IConfiguratioCivisAnimationum Animatio { get; }
        IConfiguratioCivisGenerator Generator { get; }
        IConfiguratioCivisVisae Visa { get; }
    }
}
