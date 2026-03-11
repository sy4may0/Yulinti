namespace Yulinti.Officia.Contractus {
    public interface IConfiguratioPuellaeFigurae {
        IConfiguratioPuellaeFiguraePelvis Pelvis { get; }
        IConfiguratioPuellaeFiguraeGenusSinister GenusSin { get; }
        IConfiguratioPuellaeFiguraeGenusDexter GenusDex { get; }
    }
}
