using VContainer;
using VContainer.Unity;
using Yulinti.Exercitus.Contractus;

namespace Yulinti.Unity.Deus {
    public static class FaberRadicis {
        public static void Initio(IContainerBuilder builder) {
            builder.RegisterInstance<ITurrisMundus>(new TurrisMundus());
            builder.RegisterInstance<ITurrisSalsamenti>(new TurrisSalsamenti());
        }
    }
}