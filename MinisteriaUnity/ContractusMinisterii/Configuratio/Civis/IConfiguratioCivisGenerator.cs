namespace Yulinti.MinisteriaUnity.ContractusMinisterii {
    public interface IConfiguratioCivisGenerator {
        int PopulatioMaxima { get; }
        int PopulatioInitialis { get; }
        int IntervallumMaximus { get; }
        int IntervallumMinimus { get; }
    }
}