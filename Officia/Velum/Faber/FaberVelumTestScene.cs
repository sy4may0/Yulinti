using VContainer;
using VContainer.Unity;
using Yulinti.Officia.Contractus;

namespace Yulinti.Officia.Velum {
    public static class FaberVelumTestScene {
        public static void Initio(IContainerBuilder builder) {
            // 未

            builder.Register<IOrator, Orator>(Lifetime.Singleton);
        }
    }
}