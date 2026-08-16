using VContainer;
using VContainer.Unity;
using Yulinti.Officia.Contractus;

namespace Yulinti.Officia.Velum {
    public static class FaberVelumTestScene {
        public static void Initio(IContainerBuilder builder) {
            // Velum
            builder.Register<VelumSpatiiPuellaeVeletudinis>(Lifetime.Singleton)
                .AsImplementedInterfaces()
                .AsSelf();
            builder.Register<VelumSpatiiCivisVeletudinis>(Lifetime.Singleton)
                .AsImplementedInterfaces()
                .AsSelf();

            // Operatio
            builder.Register<OperatioAnchoraCivisVelum>(Lifetime.Singleton)
                .AsImplementedInterfaces()
                .AsSelf();

            builder.Register<IOrator, Orator>(Lifetime.Singleton);
        }
    }
}