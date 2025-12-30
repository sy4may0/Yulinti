using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.ContractusDucis {
    public interface IConfiguratioPuellaeStatuum {
        float LimenInputQuadratum { get; }
        float TempusLevigatumRotationis { get; }
        float TempusLevigatumMax { get; }
        float TempusLevigatumMin { get; }
        float AcceleratioGravitatis { get; }
        float VelocitasContactus { get; }
        float VelocitasVerticalisMax { get; }
        IDPuellaeAnimationisContinuata IdAnimationisPraedefinitus { get; }
        IConfiguratioPuellaeStatusCorporis[] StatusCorporum { get; }
        IConfiguratioPuellaeStatusPartis[] StatusPartium { get; }
        IConfiguratioPuellaeStatusCorporis2[] StatuumCorporis { get; }
   }
}