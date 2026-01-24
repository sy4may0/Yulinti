using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.ContractusDucis {
    public interface IConfiguratioCivisStatusPartis {
        IDPuelleaStatusPartis Id { get; }
        IDCivisAnimationis IdAnimationisIntrare { get; }
        IDCivisAnimationis IdAnimationisExire { get; }
        bool LudereExire { get; }
        bool EstLevigatum { get; }
    }
}