using Yulinti.Nucleus.Contractus;

namespace Yulinti.Officia.Contractus {
    public interface IOrator : IIncipabilis, ILiberabilis {
    }

    // DontDestroyOnLoadのOrator
    public interface IOratorRadicis : IIncipabilis, ILiberabilis {
    }
}