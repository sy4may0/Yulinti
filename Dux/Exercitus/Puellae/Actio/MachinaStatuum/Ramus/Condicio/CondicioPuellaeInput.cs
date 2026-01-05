using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal static class CondicioPuellaeInput {
        // 移動入力があるかどうかを判定する
        public static bool EstMotus(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        ) {
            float limenInputQuadratum = contextusOstiorum.Configuratio.Statuum.LimenInputQuadratum;
            IOstiumInputMotusLegibile inputMotus = contextusOstiorum.InputMotus;

            return inputMotus.LegoMotus.LengthSquared() >= limenInputQuadratum;
        }

        // Incumboが押されているかどうかを判定する
        public static bool EstIncumbo(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        ) {
            return contextusOstiorum.InputMotus.LegoIncumbo;
        }

        // Cursusが押されているかどうかを判定する
        public static bool EstCursus(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        ) {
            return contextusOstiorum.InputMotus.LegoCursus;
        }
    }
}