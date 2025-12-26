using Yulinti.Dux.ContractusDucis;
namespace Yulinti.Dux.Exercitus {
    internal static class CondicioCivisResFluida {
        public static bool EstExhauritaVitae(
            ContextusCivisResFluidaLegibile contextusResFluida,
            ContextusCivisOstiorumLegibile contextusOstiorum
        ) {
            return contextusResFluida.EstExhauritaVitae();
        }
    }
}