using Yulinti.Nucleus.Contractus;

namespace Yulinti.Unity.Contractus {
    public interface IOrator : IIncipabilis, IPulsabilis, IPulsabilisFixus, IPulsabilisTardus {
    }

    // DontDestroyOnLoadのOrator
    public interface IOratorRadicis : IIncipabilis, IPulsabilis, IPulsabilisFixus, IPulsabilisTardus, ILiberabilis {
    }
}