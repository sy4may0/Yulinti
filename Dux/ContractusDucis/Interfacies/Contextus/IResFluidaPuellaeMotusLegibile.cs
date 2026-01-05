namespace Yulinti.Dux.ContractusDucis {
    public interface IResFluidaPuellaeMotusLegibile {
        float VelocitasActualisHorizontalis { get; }
        float VelocitasActualisVerticalis { get; }
        float RotatioYActualis { get; }
        bool EstInTerra { get; }
    }
}