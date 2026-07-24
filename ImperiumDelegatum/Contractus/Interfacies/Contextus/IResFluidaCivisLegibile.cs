namespace Yulinti.ImperiumDelegatum.Contractus {
    public interface IResFluidaCivisLegibile {
        IResFluidaCivisMotusLegibile Motus { get; }
        IResFluidaCivisVeletudinisLegibile Veletudinis { get; }
        IResFluidaCivisCustodiaeLegibile Custodiae { get; }
    }
}