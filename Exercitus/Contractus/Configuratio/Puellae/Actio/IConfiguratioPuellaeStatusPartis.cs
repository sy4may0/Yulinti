using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Contractus {
    public interface IConfiguratioPuellaeStatusPartis {
        IDPuelleaStatusPartis Id { get; }
        IDPuellaeAnimationis IdAnimationisIntrare { get; }
        IDPuellaeAnimationis IdAnimationis { get; }
        IDPuellaeAnimationis IdAnimationisExire { get; }
        bool EstLevigatum { get; }
    }
}