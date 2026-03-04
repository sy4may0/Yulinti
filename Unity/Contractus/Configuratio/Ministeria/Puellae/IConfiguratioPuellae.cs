namespace Yulinti.Unity.Contractus {
    public interface IConfiguratioPuellae {
        IConfiguratioPuellaeRelationis Relatio { get; }
        IConfiguratioPuellaeFigurae Figura { get; }
        IConfiguratioPuellaeAnimationis Animatio { get; }
        IConfiguratioPuellaeLoci Loci { get; }
    }
}
