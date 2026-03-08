namespace Yulinti.Exercitus.Contractus {
    public interface IResFluidaPuellaeLegibile {
        IResFluidaPuellaeMotusLegibile Motus { get; }
        IResFluidaPuellaeVeletudinisLegibile Veletudinis { get; }
        IResFluidaPuellaeSpectaculiLegibile Spectaculum { get; }
    }
}
