namespace Yulinti.Officia.Contractus {
    public interface IConfiguratioCivis {
        IConfiguratioCivisLoci Loci { get; }
        IConfiguratioCivisAnimationum Animatio { get; }
        IConfiguratioCivisVisae Visa { get; }
    }
}
