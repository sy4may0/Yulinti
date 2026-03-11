using Yulinti.Nucleus.Contractus;

namespace Yulinti.Auctoritas.Contractus {
    // SenatorはIncipere/Liberareのみ。
    public interface ISenator : IIncipabilis, ILiberabilis {
    }

    public interface ISenatorRadicis : IIncipabilis, ILiberabilis {
    }

}