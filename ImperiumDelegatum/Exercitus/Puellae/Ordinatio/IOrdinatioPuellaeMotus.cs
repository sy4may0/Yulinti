namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal interface IOrdinatioPuellaeMotus : IOrdinatioPuellae {
        float VelocitasHorizontalis { get; }
        float TempusLevigatumHorizontalis { get; }
        float RotatioYDeg { get; }
        float TempusLevigatumRotationisYDeg { get; }
    }
}