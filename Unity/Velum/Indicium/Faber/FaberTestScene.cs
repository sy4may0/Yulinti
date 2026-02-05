using VContainer;
using VContainer.Unity;
using Yulinti.Unity.Velum.ContractusVeli;

namespace Yulinti.Unity.Velum.Indicium {
    public static class FaberTestScene {
        public static void Initio(IContainerBuilder builder) {
            builder.Register<IndiciumDepurationis>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();

            builder.Register<IVelumIndicia, VelumIndicia>(Lifetime.Singleton);
        }
    }
}