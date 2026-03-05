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

        // 初期位置設定
        System.Numerics.Vector3 PositioIncipalis { get; }
        System.Numerics.Quaternion RotatioIncipalis { get; }

        // 初期ステート
        IDPuellaeStatusCorporis IDStatusCorporisIncipalis { get; }
   }
}