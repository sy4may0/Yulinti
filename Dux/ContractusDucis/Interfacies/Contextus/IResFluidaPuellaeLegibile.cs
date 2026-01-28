namespace Yulinti.Dux.ContractusDucis {
    public interface IResFluidaPuellaeLegibile {
        IResFluidaPuellaeMotusLegibile Motus { get; }
        IResFluidaPuellaeVeletudinisLegibile Veletudinis { get; }
        IResFluidaPuellaePersonaeLegibile Persona { get; }
    }
}