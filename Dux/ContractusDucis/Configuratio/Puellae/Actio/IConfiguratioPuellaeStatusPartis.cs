using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.ContractusDucis {
    public interface IConfiguratioPuellaeStatusPartis {
        IDPuelleaStatusPartis Id { get; }
        IDPuellaeAnimationisContinuata IdAnimationisIntrare { get; }
        IDPuellaeAnimationisContinuata IdAnimationisExire { get; }
        bool LudereExire { get; }
        bool EstLevigatum { get; }
    }
}