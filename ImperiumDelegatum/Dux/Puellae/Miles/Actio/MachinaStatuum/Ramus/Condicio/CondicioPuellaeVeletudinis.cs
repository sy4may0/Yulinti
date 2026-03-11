using Yulinti.Nucleus;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
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
