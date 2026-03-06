using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Dux {
    internal enum PhasisMachinaPuellaeStatusCorporis {
        // 初期位置
        Incipalis,
        // 開始アニメーション再生中
        Intrans,
        // アニメーション再生中
        Iterans,
        // 無アニメーション再生中(これはLusorがアニメーション無しを返すため少し状態が違う

        IteransDesinere,
        // 終了ニメーション再生中
        Exiens
    }

    internal sealed class MachinaPuellaeStatusCorporis {
        private PhasisMachinaPuellaeStatusCorporis _phasisActualis;

        private IDPuellaeStatusCorporis _idStatusActualis;
        private IDPuellaeStatusCorporis _idStatusProximus;

        public MachinaPuellaeStatusCorporis(IConfiguratioPuellaeStatuum configuratioStatuum) {
            _phasisActualis = PhasisMachinaPuellaeStatusCorporis.Incipalis;
            _idStatusActualis = IDPuellaeStatusCorporis.Nihil;
            _idStatusProximus = IDPuellaeStatusCorporis.Nihil;
        }

        private void Intrare() {
        }

        private void MutareIntrans() {

        }
    }
}
