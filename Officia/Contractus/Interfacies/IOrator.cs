using Yulinti.Nucleus.Contractus;

namespace Yulinti.Officia.Contractus {
    public interface IOrator : IIncipabilis, IPulsabilis, IPulsabilisFixus, IPulsabilisTardus, ILiberabilis {
    }

    // DontDestroyOnLoadのOrator
    public interface IOratorRadicis : IIncipabilis, IPulsabilis, IPulsabilisFixus, IPulsabilisTardus, ILiberabilis {
    }
}