using Yulinti.Exercitus.Contractus;

namespace Yulinti.Unity.Contractus {
    public interface IConfiguratioPuellaeAnimationisContinuata {
        IDPuellaeAnimationisStratum Stratum { get; }
        IDPuellaeAnimationisContinuata Id { get; }
        IConfiguratioPuellaeAnimationisUnicae[] Animationes { get; }
    }
}