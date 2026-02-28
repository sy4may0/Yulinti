using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Contractus {
    public interface IConfiguratioCivisStatusPartis {
        IDPuelleaStatusPartis Id { get; }
        IDCivisAnimationis IdAnimationisIntrare { get; }
        IDCivisAnimationis IdAnimationisExire { get; }
        bool LudereExire { get; }
        bool EstLevigatum { get; }
    }
}