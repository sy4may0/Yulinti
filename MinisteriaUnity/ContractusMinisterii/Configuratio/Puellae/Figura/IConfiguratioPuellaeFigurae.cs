namespace Yulinti.MinisteriaUnity.ContractusMinisterii {
    public interface IConfiguratioPuellaeFigurae {
        IConfiguratioPuellaeFiguraePelvis Pelvis { get; }
        IConfiguratioPuellaeFiguraeGenus GenusDex { get; }
        IConfiguratioPuellaeFiguraeGenus GenusSin { get; }
    }
}
