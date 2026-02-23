using Yulinti.Exercitus.Contractus;
using System.Collections.Generic;

// 仮構成。
// 将来的にUnity Localizationを使う。
namespace Yulinti.Unity.Turris {
    internal sealed class TablaTextus {
        private readonly Dictionary<IDTextus, string> _textus;

        public TablaTextus() {
            _textus = new Dictionary<IDTextus, string> {
                // タイトル画面
                { IDTextus.INDEXUS_PRINCIPALIS_LUDUS_NOVUS, "New Game" },
                { IDTextus.INDEXUS_PRINCIPALIS_PERGE_LUDUM, "Continue" },
                { IDTextus.INDEXUS_PRINCIPALIS_ONERA_LUDUM, "Load Game" },
                { IDTextus.INDEXUS_PRINCIPALIS_OPTIONES, "Options" },
                { IDTextus.INDEXUS_PRINCIPALIS_EXIT, "Exit" },

                // セーブ画面
                { IDTextus.SALSAMENTUM_HEADER_LABEL, "セーブデータ管理" },
                { IDTextus.SALSAMENTUM_BUTTON_ONERA_LUDUM, "ロード" },
                { IDTextus.SALSAMENTUM_BUTTON_DELETO_LUDUM, "削除" },
                { IDTextus.SALSAMENTUM_BUTTON_CANCEL, "キャンセル" },
                { IDTextus.SALSAMENTUM_LIST_MANUALIS_LABEL, "通常セーブ" },
                { IDTextus.SALSAMENTUM_LIST_AUTOMATICUS_LABEL, "オートセーブ" },

                // PuellaePersonae
                { IDTextus.PUELLAEPERSONAE_GRADUS_LUXURIOSUS, "淫乱レベル" },
                { IDTextus.PUELLAEPERSONAE_ANIMA_LUXURIOSUS, "淫乱経験値" },
                { IDTextus.PUELLAEPERSONAE_GRADUS_EXHIBITUS, "露出レベル" },
                { IDTextus.PUELLAEPERSONAE_ANIMA_EXHIBITUS, "露出経験値" },
                { IDTextus.PUELLAEPERSONAE_GRADUS_PERVERSUS, "変態レベル" },
                { IDTextus.PUELLAEPERSONAE_ANIMA_PERVERSUS, "変態経験値" },
                { IDTextus.PUELLAEPERSONAE_GRADUS_QUAERIT_DOLOR, "マゾレベル" },
                { IDTextus.PUELLAEPERSONAE_ANIMA_QUAERIT_DOLOR, "マゾ経験値" },
                { IDTextus.PUELLAEPERSONAE_SENSUS_PAPILLAE, "乳首感度" },
                { IDTextus.PUELLAEPERSONAE_ANIMA_PAPILLAE, "乳首開発" },
                { IDTextus.PUELLAEPERSONAE_SENSUS_LANDICAE, "クリトリス感度" },
                { IDTextus.PUELLAEPERSONAE_ANIMA_LANDICAE, "クリトリス開発" },
                { IDTextus.PUELLAEPERSONAE_SENSUS_VAGINAE, "膣感度" },
                { IDTextus.PUELLAEPERSONAE_ANIMA_VAGINAE, "膣経験値" },
                { IDTextus.PUELLAEPERSONAE_SENSUS_ANI, "肛門感度" },
                { IDTextus.PUELLAEPERSONAE_ANIMA_ANI, "肛門開発" },
                { IDTextus.PUELLAEPERSONAE_SENSUS_AUSCULUM, "口感度" },
                { IDTextus.PUELLAEPERSONAE_ANIMA_AUSCULUM, "口開発" },
                { IDTextus.PUELLAEPERSONAE_SENSUS_CORPORIS, "全身感度" },
                { IDTextus.PUELLAEPERSONAE_ANIMA_CORPORIS, "全身開発" }
            };
        }

        public string LegoTextus(IDTextus idTextus) {
            return _textus[idTextus];
        }
    }
}