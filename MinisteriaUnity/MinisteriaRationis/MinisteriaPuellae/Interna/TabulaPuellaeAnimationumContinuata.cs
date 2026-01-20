using Yulinti.Dux.ContractusDucis;
using Yulinti.Nucleus;
using System;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
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

            // IDすべて(Noneを除く)に設定が必要
            for (int i = 1; i < longitudo; i++) {
                if (_animationes[i] == null) {
                    Errorum.Fatal(IDErrorum.TABULAPUELLAEANIMATIONUMCONTINUATA_CONFIG_NOT_FOUND);
                }
            }
        }

        public IAnimatioPuellaeContinuata Lego(IDPuellaeAnimationisContinuata idContinuata) => _animationes[(int)idContinuata];
    }
}

