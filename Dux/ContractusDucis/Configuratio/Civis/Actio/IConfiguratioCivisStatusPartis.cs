using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.ContractusDucis {
    public interface IConfiguratioCivisStatusPartis {
        IDStatusPartis Id { get; }
        IDCivisAnimationis IdAnimationisIntrare { get; }
        IDCivisAnimationis IdAnimationisExire { get; }
        bool LudereExire { get; }
        bool EstLevigatum { get; }
    }
}