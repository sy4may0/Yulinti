using VContainer;
using VContainer.Unity;
using Yulinti.Exercitus.Contractus;

namespace Yulinti.Unity.Turris {
    public static class FaberTurris {
        public static void Initio(IContainerBuilder builder) {
            builder.Register<ITurrisMundus, TurrisMundus>(Lifetime.Singleton);
            builder.Register<ITurrisIntroductionis, TurrisIntroductionis>(Lifetime.Singleton);
            builder.Register<ITurrisInterpretationis, TurrisInterpretationis>(Lifetime.Singleton);
            builder.Register<ITurrisSalsamenti, TurrisSalsamenti>(Lifetime.Singleton);
        }
    }
}