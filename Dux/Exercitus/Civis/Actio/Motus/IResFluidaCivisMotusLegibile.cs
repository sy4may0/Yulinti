namespace Yulinti.Dux.Exercitus {
    internal interface IResFluidaCivisMotusLegibile
    {
        int IDPunctumViaeActualis { get; }
        int IDPunctumViaeProximus { get; }
        float VelocitasActualisHorizontalis { get; }
        float RotatioYActualis { get; }
        bool EstInTerra { get; }
    }
}