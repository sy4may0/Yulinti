using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Dux {
    internal static class CondicioPuellaeInput {
        // 移動入力があるかどうかを判定する
        public static bool EstMotus(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        ) {
            float limenInputQuadratum = contextusOstiorum.Configuratio.Statuum.LimenInputQuadratum;
            return contextusOstiorum.Introductionis.LegoMotus.LengthSquared() >= limenInputQuadratum;
        }

        // Incumboが押されているかどうかを判定する
        public static bool EstIncumbo(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        ) {
            return contextusOstiorum.Introductionis.LegoIncumbo;
        }

        // Cursusが押されているかどうかを判定する
        public static bool EstCursus(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        ) {
            return contextusOstiorum.Introductionis.LegoCursus;
        }
    }
}