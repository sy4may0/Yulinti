using Yulinti.Exercitus.Contractus;
namespace Yulinti.Exercitus.Dux {
    internal static class CondicioCivisVeletudinis {
        public static bool EstExhauritaVitae(
            int idCivis,
            IResFluidaCivisLegibile resFluida
        ) {
            return resFluida.Veletudinis.EstExhaurita(idCivis);
        }
    }
}