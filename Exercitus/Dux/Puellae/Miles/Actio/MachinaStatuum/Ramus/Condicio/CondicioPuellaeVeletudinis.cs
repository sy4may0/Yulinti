using Yulinti.Nucleus;
using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Dux {
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
