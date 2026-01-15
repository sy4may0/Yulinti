using Yulinti.Dux.ContractusDucis;
namespace Yulinti.Dux.Exercitus {
    internal static class CondicioCivisVeletudinis {
        public static bool EstExhauritaVitae(
            int idCivis,
            IResFluidaCivisLegibile resFluida
        ) {
            return resFluida.Veletudinis.EstExhaurita(idCivis);
        }
    }
}