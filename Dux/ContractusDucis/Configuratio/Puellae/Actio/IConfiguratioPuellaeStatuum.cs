using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.ContractusDucis {
    public interface IConfiguratioPuellaeStatuum {
        float TempusLevigatumMax { get; }
        float TempusLevigatumMin { get; }
        float AcceleratioGravitatis { get; }
        float VelocitasContactus { get; }
        float VelocitasVerticalisMax { get; }
        IDPuellaeAnimationisContinuata IdAnimationisPraedefinitus { get; }
        IConfiguratioPuellaeStatusCorporis[] StatusCorporum { get; }
        IConfiguratioPuellaeStatusPartis[] StatusPartium { get; }

        float LimenInputQuadratum { get; set; }
        float TempusLevigatumRotationis { get; set; }
    }
}