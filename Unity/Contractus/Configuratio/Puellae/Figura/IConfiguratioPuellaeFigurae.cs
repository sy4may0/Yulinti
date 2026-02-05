namespace Yulinti.Unity.Contractus {
    public interface IConfiguratioPuellaeFigurae {
        IConfiguratioPuellaeFiguraePelvis Pelvis { get; }
        IConfiguratioPuellaeFiguraeGenusSinister GenusSin { get; }
        IConfiguratioPuellaeFiguraeGenusDexter GenusDex { get; }
    }
}
