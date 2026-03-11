using Yulinti.ImperiumDelegatum.Contractus;
using System.Collections.Generic;

// 仮構成。
// 将来的にUnity Localizationを使う。
namespace Yulinti.Officia.Turris {
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

                // タイトル画面確認
                { IDTextus.INDEXUS_PRINCIPALIS_LUDUS_NOVUS_TITULUS, "新規ゲーム" },
                { IDTextus.INDEXUS_PRINCIPALIS_LUDUS_NOVUS_TEXTUS, "新規セーブデータを作成してゲームを開始します。" },
                { IDTextus.INDEXUS_PRINCIPALIS_LUDUS_NOVUS_BUTTON_ITA, "新規ゲーム" },
                { IDTextus.INDEXUS_PRINCIPALIS_LUDUS_NOVUS_BUTTON_NON, "キャンセル" },

                // セーブ画面
                { IDTextus.SALSAMENTUM_HEADER_LABEL, "Save Data" },
                { IDTextus.SALSAMENTUM_BUTTON_ONERA_LUDUM, "LOAD" },
                { IDTextus.SALSAMENTUM_BUTTON_DELETO_LUDUM, "DELETE" },
                { IDTextus.SALSAMENTUM_BUTTON_CANCEL, "CANCEL" },
                { IDTextus.SALSAMENTUM_LIST_MANUALIS_LABEL, "通常セーブ" },
                { IDTextus.SALSAMENTUM_LIST_AUTOMATICUS_LABEL, "オートセーブ" },
                { IDTextus.SALSAMENTUM_LIST_MANUALIS_ITEM_LABEL, "Save Data" },
                { IDTextus.SALSAMENTUM_LIST_AUTOMATICUS_ITEM_LABEL, "Auto Save Data" },

                // セーブ画面確認
                { IDTextus.SALSAMENTUM_DELETO_CONFIRMATIONIS_TITULUS, "セーブデータ削除" },
                { IDTextus.SALSAMENTUM_DELETO_CONFIRMATIONIS_TEXTUS, "選択したセーブデータを削除します。よろしいですか？" },
                { IDTextus.SALSAMENTUM_DELETO_CONFIRMATIONIS_BUTTON_ITA, "削除" },
                { IDTextus.SALSAMENTUM_DELETO_CONFIRMATIONIS_BUTTON_NON, "キャンセル" },

                // 出撃画面
                { IDTextus.PORTUS_BUTTON_PROFECTIO, "しゅつげき!!" },
                { IDTextus.PORTUS_BUTTON_CONSTRUCTIO, "お着替え" },
                { IDTextus.PORTUS_BUTTON_TABERNA, "通販" },
                { IDTextus.PORTUS_BUTTON_OPTIONES, "オプション" },
                { IDTextus.PORTUS_BUTTON_EXI, "ゲーム終了" },

                // Portus:タイトルに戻る確認
                { IDTextus.PORTUS_BUTTON_EXI_TITULUS, "ゲーム終了" },
                { IDTextus.PORTUS_BUTTON_EXI_TEXTUS, "ゲームを終了し、タイトル画面に戻ります。よろしいですか？" },
                { IDTextus.PORTUS_BUTTON_EXI_BUTTON_ITA, "ゲーム終了" },
                { IDTextus.PORTUS_BUTTON_EXI_BUTTON_NON, "キャンセル" },

                // PuellaePersonae
                { IDTextus.PUELLAEPERSONAE_GRADUS_PREFIX, "Level." },
                { IDTextus.PUELLAEPERSONAE_ANIMA_PREFIX, "Exp." },
                { IDTextus.PUELLAEPERSONAE_GRADUS_LUXURIOSUS, "淫乱" },
                { IDTextus.PUELLAEPERSONAE_ANIMA_LUXURIOSUS, "淫乱経験値" },
                { IDTextus.PUELLAEPERSONAE_GRADUS_EXHIBITUS, "露出" },
                { IDTextus.PUELLAEPERSONAE_ANIMA_EXHIBITUS, "露出経験値" },
                { IDTextus.PUELLAEPERSONAE_GRADUS_PERVERSUS, "変態" },
                { IDTextus.PUELLAEPERSONAE_ANIMA_PERVERSUS, "変態経験値" },
                { IDTextus.PUELLAEPERSONAE_GRADUS_QUAERIT_DOLOR, "マゾ" },
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