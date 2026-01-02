using Yulinti.Nucleus;
using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal static class CondicioPuellaeVeletudinis {
        public static bool EstExhauritaVigoris(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        ){
            return resFluida.Veletudinis.EstExhauritaVigoris;
        }

        public static bool EstExhauritaPatientiae(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        ){
            return resFluida.Veletudinis.EstExhauritaPatientiae;
        }
    }
}