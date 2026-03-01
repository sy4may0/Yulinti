using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Contractus {
    public interface IConfiguratioPuellaeStatuum {
        float LimenInputQuadratum { get; }
        float TempusLevigatumRotationis { get; }
        float TempusLevigatumMax { get; }
        float TempusLevigatumMin { get; }
        float AcceleratioGravitatis { get; }
        float VelocitasContactus { get; }
        float VelocitasVerticalisMax { get; }
        IDPuellaeAnimationisContinuata IdAnimationisPraedefinitus { get; }
        IConfiguratioPuellaeStatusCorporis[] StatuumCorporis { get; }
        IConfiguratioPuellaeStatusPartis[] StatuumPartium { get; }

        // 初期地点X,Z YはNavmeshから取得する。
        float XIncipalis { get; }
        float ZIncipalis { get; }
   }
}