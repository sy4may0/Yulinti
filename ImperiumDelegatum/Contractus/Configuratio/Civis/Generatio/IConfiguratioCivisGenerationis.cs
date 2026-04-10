namespace Yulinti.ImperiumDelegatum.Contractus {
    public interface IConfiguratioCivisGenerationis {
        int PopulatioMaxima { get; }
        int PopulatioInitialis { get; }
        int IntervallumMaximus { get; }
        int IntervallumMinimus { get; }
    }
}