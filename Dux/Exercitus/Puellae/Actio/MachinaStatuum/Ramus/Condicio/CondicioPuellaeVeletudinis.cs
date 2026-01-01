using Yulinti.Nucleus;
using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal static class CondicioPuellaeVeletudinis {
        public static bool EstExhauritaVigoris(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        ){
            return resFluida.Veletudinis.Vigor <= Numerus.Epsilon;
        }

        public static bool EstExhauritaPatientiae(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        ){
            return resFluida.Veletudinis.Patientia <= Numerus.Epsilon;
        }
    }
}