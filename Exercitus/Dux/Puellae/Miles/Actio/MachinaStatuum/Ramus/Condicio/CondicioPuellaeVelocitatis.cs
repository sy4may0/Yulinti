using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Dux {
    internal static class CondicioPuellaeVelocitatis {
        // 停止状態である。
        public static bool EstVelocitatisQuietes(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        ) {
            float limenVelocitatisIntransQuietes = contextusOstiorum.Configuratio.Statuum.LimenVelocitatisIntransQuietes;
            return resFluida.Motus.VelocitasActualisHorizontalis < limenVelocitatisIntransQuietes;
        }
    }
}