using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Dux {
    internal static class CondicioPuellaeInput {
        // 移動E力があるかどうを判定すめ
        public static bool EstMotus(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        ) {
            float limenInputQuadratum = contextusOstiorum.Configuratio.Statuum.LimenInputQuadratum;
            return contextusOstiorum.Introductionis.LegoMotus.LengthSquared() >= limenInputQuadratum;
        }

        // Incumboが押されていかどうを判定すめ
        public static bool EstIncumbo(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        ) {
            return contextusOstiorum.Introductionis.LegoIncumbo;
        }

        // Cursusが押されていかどうを判定すめ
        public static bool EstCursus(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        ) {
            return contextusOstiorum.Introductionis.LegoCursus;
        }
    }
}
