using Yulinti.Nucleus.Contractus;

namespace Yulinti.Auctoritas.Senatus {
    public interface IPraeco {
    }

    // 内部Tick
    public interface IPraecoIncipabilis : IIncipabilis {
    }

    public interface IPraecoLiberabilis : ILiberabilis {
    }

    public interface IPraecoPulsabilis : IPulsabilis {
    }

    public interface IPraecoPulsabilisTardus : IPulsabilisTardus {
    }

    // DontDestroyOnLoadのTick
    public interface IPraecoIncipabilisRadicis : IIncipabilis {
    }

    public interface IPraecoLiberabilisRadicis : ILiberabilis {
    }
}