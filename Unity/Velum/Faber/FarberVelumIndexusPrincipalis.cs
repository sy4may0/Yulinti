using VContainer;
using VContainer.Unity;
using Yulinti.Exercitus.Contractus;
using Yulinti.Unity.Contractus;

namespace Yulinti.Unity.Velum {
    public static class FarberVelumIndexusPrincipalis {
        public static void Initio(IContainerBuilder builder) {
            builder.Register<VelumIndexusPrincipalis>(Lifetime.Singleton)
                .AsImplementedInterfaces()
                .AsSelf();

            builder.Register<VelumSalsamenti>(Lifetime.Singleton)
                .AsImplementedInterfaces()
                .AsSelf();

            builder.Register<IOrator, Orator>(Lifetime.Singleton);
        }
    }
}