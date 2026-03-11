using Yulinti.ImperiumDelegatum.Contractus;
namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal static class CondicioCivisVeletudinis {
        public static bool EstExhauritaVitae(
            int idCivis,
            IResFluidaCivisLegibile resFluida
        ) {
            return resFluida.Veletudinis.EstExhaurita(idCivis);
        }
    }
}