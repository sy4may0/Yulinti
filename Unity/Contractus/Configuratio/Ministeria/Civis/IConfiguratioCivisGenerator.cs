namespace Yulinti.Unity.Contractus {
    public interface IConfiguratioCivisGenerator {
        int PopulatioMaxima { get; }
        int PopulatioInitialis { get; }
        int IntervallumMaximus { get; }
        int IntervallumMinimus { get; }
    }
}