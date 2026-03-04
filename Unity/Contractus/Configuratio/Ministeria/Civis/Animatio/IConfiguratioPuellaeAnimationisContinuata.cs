using Yulinti.Exercitus.Contractus;

namespace Yulinti.Unity.Contractus {
    public interface IConfiguratioCivisAnimationisContinuata {
        IDCivisAnimationisStratum Stratum { get; }
        IDCivisAnimationisContinuata Id { get; }
        IConfiguratioCivisAnimationisUnicae[] Animationes { get; }
    }
}