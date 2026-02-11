using Yulinti.Exercitus.Contractus;
using Yulinti.Nucleus;
using System;
using Yulinti.Unity.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Unity.Ministeria {
    internal sealed class TabulaCivisAnimationumContinuata {
        private readonly IAnimatioCivisContinuata[] _animationes;

        public TabulaCivisAnimationumContinuata(IConfiguratioCivisAnimationisContinuata[] config) {
            int longitudo = Enum.GetValues(typeof(IDCivisAnimationisContinuata)).Length;
            _animationes = new IAnimatioCivisContinuata[longitudo];

            // NoneのIDだけ特殊で、引数なしコンストラクタで作ったAnimatioCivisContinuataを割り当て
            // Noneは使われない想定。
            _animationes[(int)IDCivisAnimationisContinuata.None] = new AnimatioCivisContinuata();

            foreach (IConfiguratioCivisAnimationisContinuata c in config) {
                // NoneのIDは既に設定済みなのでスキップ
                if (c.Id == IDCivisAnimationisContinuata.None) {
                    continue;
                }
                _animationes[(int)c.Id] = new AnimatioCivisContinuata(c);
            }

            // IDすべて(Noneを除く)に設定が必要
            for (int i = 1; i < longitudo; i++) {
                if (_animationes[i] == null) {
                    Carnifex.Intermissio(LogTextus.TabulaCivisAnimationumContinuata_TABULACIVISANIMATIONUMCONTINUATA_CONFIG_NOT_FOUND);
                }
            }
        }

        public IAnimatioCivisContinuata Lego(IDCivisAnimationisContinuata idContinuata) => _animationes[(int)idContinuata];
    }
}