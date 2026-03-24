using Yulinti.Nucleus;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal static class CondicioPuellaeVeletudinis {
        public static bool EstExhauritaVigoris(
            ContextusRamusPuellae contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        ){
            return resFluida.Veletudinis.EstExhauritaVigoris;
        }

        public static bool EstExhauritaPatientiae(
            ContextusRamusPuellae contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        ){
            return resFluida.Veletudinis.EstExhauritaPatientiae;
        }
    }
}
