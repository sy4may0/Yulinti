using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Contractus {
    public interface IConfiguratioPuellaeStatusPartis {
        IDPuelleaStatusPartis Id { get; }
        IDPuellaeAnimationisContinuata IdAnimationisIntrare { get; }
        IDPuellaeAnimationisContinuata IdAnimationisExire { get; }
        bool LudereExire { get; }
        bool EstLevigatum { get; }
    }
}