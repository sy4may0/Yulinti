using Yulinti.Nucleus.Contractus;

namespace Yulinti.Unity.Turris {
    public interface ITurrisIncipabilis : IIncipabilis {
    }

    // TurrisはTardusのみ。
    public interface ITurrisPulsabilisTardus : IPulsabilisTardus {
    }

    public interface ITurrisLiberabilis : ILiberabilis {
    }
}