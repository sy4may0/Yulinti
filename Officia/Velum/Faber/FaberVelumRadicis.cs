using VContainer;
using VContainer.Unity;
using Yulinti.Officia.Contractus;

namespace Yulinti.Officia.Velum {
    public static class FaberVelumRadicis {
        public static void Initio(IContainerBuilder builder) {
            builder.Register<ApplicatorSoniVeli>(Lifetime.Singleton)
                .AsImplementedInterfaces()
                .AsSelf();

            builder.Register<VelumConfirmationis>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();
            builder.Register<VelumMonitionis>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();

            builder.Register<IOratorRadicis, OratorRadicis>(Lifetime.Singleton);
        }
    }
}
