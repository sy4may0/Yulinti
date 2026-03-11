namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal interface IOrdinatioCivisMotus : IOrdinatioCivis {
        float VelocitasHorizontalis { get; }
        float TempusLevigatumHorizontalis { get; }
        float RotatioYDeg { get; }
        float TempusLevigatumRotationisYDeg { get; }
    }
}   