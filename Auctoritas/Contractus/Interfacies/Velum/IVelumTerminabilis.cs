// このIFを実装すると、Legatusから終了時とかに全クローズ対象となる。
namespace Yulinti.Auctoritas.Contractus {
    public interface IVelumTerminabilis {
        void TollereFinem();
    }
}