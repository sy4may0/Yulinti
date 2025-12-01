namespace Yulinti.MinisteriaUnity.ContractusMinisterii {
    public interface IConfiguratioPuellaeFigurae {
        IConfiguratioPuellaeFiguraePelvis Pelvis { get; }
        IConfiguratioPuellaeFiguraeGenusSinister GenusSin { get; }
        IConfiguratioPuellaeFiguraeGenusDexter GenusDex { get; }
    }
}
