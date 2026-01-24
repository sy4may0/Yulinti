using Yulinti.Dux.ContractusDucis;

namespace Yulinti.MinisteriaUnity.ContractusMinisterii {
    public interface IConfiguratioPuellaeAnimationisContinuata {
        IDPuellaeAnimationisStratum Stratum { get; }
        IDPuellaeAnimationisContinuata Id { get; }
        IConfiguratioPuellaeAnimationisUnicae[] Animationes { get; }
    }
}