namespace Yulinti.Officia.Contractus {
    public interface IConfiguratioCivisGenerator {
        int PopulatioMaxima { get; }
        int PopulatioInitialis { get; }
        int IntervallumMaximus { get; }
        int IntervallumMinimus { get; }
    }
}