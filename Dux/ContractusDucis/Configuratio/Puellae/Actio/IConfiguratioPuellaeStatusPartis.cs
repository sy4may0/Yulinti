using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.ContractusDucis {
    public interface IConfiguratioPuellaeStatusPartis {
        IDStatusPartis Id { get; set; }
        IDPuellaeAnimationisPartis IdAnimationis { get; set; }
        bool EstLevigatum { get; set; }
    }
}