using Animancer;

namespace Yulinti.MinisteriaUnity.Interna.InstulmentaAnimancer {
    public static class FabricaStructuraeAnimationis {
        public static IStructuraAnimationis Create(
            ITransition animatio, 
            float tempusEvanescentiae, 
            Easing.Function lenitio, 
            bool estSimultaneum = false, 
            bool estImpeditivus = false
        ) {
            return animatio switch {
                LinearMixerTransition lmt => new StructuraAnimationisVelInjectibile(
                    animatio as LinearMixerTransition, 
                    tempusEvanescentiae, lenitio, 
                    estSimultaneum, estImpeditivus
                ),
                _ => new StructuraAnimationis(
                    animatio, tempusEvanescentiae, lenitio, 
                    estSimultaneum, estImpeditivus
                )
            };
        }
    }
}