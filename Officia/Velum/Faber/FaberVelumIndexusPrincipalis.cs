using VContainer;
using VContainer.Unity;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Officia.Contractus;

namespace Yulinti.Officia.Velum {
    public static class FaberVelumIndexusPrincipalis {
        public static void Initio(IContainerBuilder builder) {
            builder.Register<ApplicatorSoniVeli>(Lifetime.Singleton)
                .AsImplementedInterfaces()
                .AsSelf();

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