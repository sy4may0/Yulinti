using Yulinti.Exercitus.Contractus;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Exercitus.Dux {
    public interface ILegatus {
    }

    // 内部Tick
    public interface ILegatusIncipabilis : IIncipabilis {
    }

    public interface ILegatusPulsabilis : IPulsabilis {
    }

    public interface ILegatusLiberabilis : ILiberabilis {
    }

    // DontDestroyOnLoadのTick
    public interface ILegatusIncipabilisRadicis : IIncipabilis {
    }

    public interface ILegatusPulsabilisRadicis : IPulsabilis {
    }

    public interface ILegatusLiberabilisRadicis : ILiberabilis {
    }
}