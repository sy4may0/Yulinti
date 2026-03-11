using VContainer;
using VContainer.Unity;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Officia.Contractus;

namespace Yulinti.Officia.Velum {
    public static class FaberVelumPortus {
        public static void Initio(IContainerBuilder builder) {
            builder.Register<ApplicatorSoniVeli>(Lifetime.Singleton)
                .AsImplementedInterfaces()
                .AsSelf();

            builder.Register<VelumPortus>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();

            builder.Register<IOrator, Orator>(Lifetime.Singleton);
        }

    }
}