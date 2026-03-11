using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    public interface IPraeco {
    }

    // 内部Tick
    public interface IPraecoIncipabilis : IIncipabilis {
    }

    public interface IPraecoPulsabilis : IPulsabilis {
    }

    public interface IPraecoLiberabilis : ILiberabilis {
    }

    // DontDestroyOnLoadのTick
    public interface IPraecoIncipabilisRadicis : IIncipabilis {
    }

    public interface IPraecoPulsabilisRadicis : IPulsabilis {
    }

    public interface IPraecoLiberabilisRadicis : ILiberabilis {
    }
}