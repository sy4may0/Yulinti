using VContainer;
using VContainer.Unity;
using Yulinti.Velum.ContractusVeli;

namespace Yulinti.Velum.Indicium {
    public static class FaberTestScene {
        public static void Initio(IContainerBuilder builder) {
            builder.Register<IndiciumDepurationis>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();

            builder.Register<IVelumIndicia, VelumIndicia>(Lifetime.Singleton);
        }
    }
}