namespace Yulinti.Unity.Contractus {
    public interface IConfiguratioPuellae {
        IConfiguratioPuellaeRelationis Relatio { get; }
        IConfiguratioPuellaeFigurae Figura { get; }
        IConfiguratioPuellaeAnimationum Animatio { get; }
        IConfiguratioPuellaeLoci Loci { get; }
    }
}
