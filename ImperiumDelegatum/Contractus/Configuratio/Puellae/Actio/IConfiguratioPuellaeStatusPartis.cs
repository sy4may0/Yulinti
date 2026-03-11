using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Contractus {
    public interface IConfiguratioPuellaeStatusPartis {
        IDPuelleaStatusPartis Id { get; }
        IDPuellaeAnimationis IdAnimationisIntrare { get; }
        IDPuellaeAnimationis IdAnimationis { get; }
        IDPuellaeAnimationis IdAnimationisExire { get; }
        bool EstLevigatum { get; }
    }
}