using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Contractus {
    public interface ITurrisInterpretationis {
        // テキストを取得。
        string LegoTextus(IDTextus idTextus);
    }
}