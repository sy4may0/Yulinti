namespace Yulinti.Dux.Exercitus {
    internal interface IOrdinatioPuellaeMotus : IOrdinatioPuellae {
        float VelocitasHorizontalis { get; }
        float TempusLevigatumHorizontalis { get; }
        float RotatioYDeg { get; }
        float TempusLevigatumRotationisYDeg { get; }

        void Pono(
            float velocitasHorizontalis = 0f,
            float tempusLevigatumHorizontalis = 0f,
            float rotatioYDeg = 0f,
            float tempusLevigatumRotationisYDeg = 0f
        );
    }
}