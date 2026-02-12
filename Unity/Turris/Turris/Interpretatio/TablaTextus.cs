using Yulinti.Exercitus.Contractus;
using System.Collections.Generic;

// 仮構成。
// 将来的にUnity Localizationを使う。
namespace Yulinti.Unity.Turris {
    internal sealed class TablaTextus {
        private readonly Dictionary<IDTextus, string> _textus;

        public TablaTextus() {
            _textus = new Dictionary<IDTextus, string> {
                { IDTextus.INDEXUS_PRINCIPALIS_LUDUS_NOVUS, "New Game" },
                { IDTextus.INDEXUS_PRINCIPALIS_PERGE_LUDUM, "Continue" },
                { IDTextus.INDEXUS_PRINCIPALIS_ONERA_LUDUM, "Load Game" },
                { IDTextus.INDEXUS_PRINCIPALIS_OPTIONES, "Options" },
                { IDTextus.INDEXUS_PRINCIPALIS_EXIT, "Exit" }
            };
        }

        public string LegoTextus(IDTextus idTextus) {
            return _textus[idTextus];
        }
    }
}