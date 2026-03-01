using Yulinti.Exercitus.Contractus;
using Yulinti.Nucleus;
using System;
using Yulinti.Unity.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Unity.Ministeria {
    internal sealed class TabulaPuellaeAnimationumContinuata {
        private readonly IAnimatioPuellaeContinuata[] _animationes;

        public TabulaPuellaeAnimationumContinuata(IConfiguratioPuellaeAnimationisContinuata[] config) {
            int longitudo = Enum.GetValues(typeof(IDPuellaeAnimationisContinuata)).Length;
            _animationes = new IAnimatioPuellaeContinuata[longitudo];

            // NoneのIDだけ特殊で、引数なしコンストラクタで作ったAnimatioPuellaeContinuataを割り当て
            _animationes[(int)IDPuellaeAnimationisContinuata.None] = new AnimatioPuellaeContinuata();

            foreach (IConfiguratioPuellaeAnimationisContinuata c in config) {
                // NoneのIDは既に設定済みなのでスキップ
                if (c.Id == IDPuellaeAnimationisContinuata.None) {
                    continue;
                }
                _animationes[(int)c.Id] = new AnimatioPuellaeContinuata(c);
            }

            // IDすべて(Noneを除く)に設定が必要 <- NG
            // confgのリストで渡されたものだけ初期化されているか確認。それ以外はnullでいい。
            foreach (IConfiguratioPuellaeAnimationisContinuata c in config) {
                int idEnum = (int)c.Id;
                if (_animationes[idEnum] == null) {
                    Carnifex.Intermissio(LogTextus.TabulaPuellaeAnimationumContinuata_TABULAPUELLAEANIMATIONUMCONTINUATA_CONFIG_NOT_FOUND);
                }
            }
        }

        public IAnimatioPuellaeContinuata Lego(IDPuellaeAnimationisContinuata idContinuata) => _animationes[(int)idContinuata];
    }
}

