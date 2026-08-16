using Yulinti.Nucleus.Contractus;

namespace Yulinti.Auctoritas.Contractus {
    // SenatorはIncipere/Liberareのみ。
    public interface ISenator : IIncipabilis, ILiberabilis, IPulsabilis, IPulsabilisTardus {
    }

    public interface ISenatorRadicis : IIncipabilis, ILiberabilis {
    }

}