namespace Yulinti.Dux.ContractusDucis {
    public interface IConfiguratioCivisCustodiae {
        float DistantiaCustodiae { get; }
        float DistantiaCustodiaeMaxima { get; }
        float LimenVigilantia { get; }
        float LimenDetectio { get; }
        float ConsumptioVisaeVigilantiaSec { get; }
        float ConsumptioVisaeSec { get; }
    }
}