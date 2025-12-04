using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.ContractusDucis {
    public interface IConfiguratioPuellaeStatuum {
        float LimenInputQuadratum { get; set; }
        float TempusLevigatumMax { get; set; }
        float TempusLevigatumMin { get; set; }
        float TempusLevigatumRotationis { get; set; }
        float AcceleratioGravitatis { get; set; }
        float VelocitasContactus { get; set; }
        float VelocitasVerticalisMax { get; set; }
        IDPuellaeAnimationisFundamenti IdAnimationisPraedefinitus { get; }
        IConfiguratioPuellaeStatusCorporis[] StatusCorporum { get; }
        IConfiguratioPuellaeStatusPartis[] StatusPartium { get; }
    }
}