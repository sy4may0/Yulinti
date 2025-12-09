namespace Yulinti.Dux.Exercitus {
    internal interface IResFluidaPuellaeMotusLegibile
    {
        float VelocitasActualisHorizontalis { get; }
        float VelocitasActualisVerticalis { get; }
        float RotatioYActualis { get; }
        bool EstInTerra { get; }
    }
}
