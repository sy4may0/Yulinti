using UnityEngine;
using Yulinti.Officia.Contractus;

namespace Yulinti.Imperium.Configuratio {
    // PuellaePersonae の Anima から Gradus/Sensus を解決するための設定。
    // ResolutorPuellaePersonae で以下の閾値テーブルを作成して使用する:
    // tabula[i] = (i * i + 4 * i + offsetPuellaePersonaeAnimae) * cofficiensPuellaePersonaeAnimae
    // anima が tabula[i] 以上となる最大の i が、解決される Gradus/Sensus になる。
    [CreateAssetMenu(fileName = "ConfiguratioTurrisPhantasma", menuName = "Yulinti/Rex/ConfiguratioTurrisPhantasma")]
    public sealed class ConfiguratioTurrisPhantasma : ScriptableObject, IConfiguratioTurrisPhantasma {
        // i^2 + 4i + offset の offset。必要 Anima 曲線の定数項を調整する。
        [SerializeField] private int offsetPuellaePersonaeAnimae = 4;
        // Gradus の最大段階。閾値テーブルは 0..gradusPuellaePersonaeMaximus を持つ。
        [SerializeField] private int gradusPuellaePersonaeMaximus = 10;
        // Sensus の最大段階。閾値テーブルは 0..sensusPuellaePersonaeMaximus を持つ。
        [SerializeField] private int sensusPuellaePersonaeMaximus = 10;
        // (i^2 + 4i + offset) に掛ける係数。必要 Anima 全体のスケールを調整する。
        [SerializeField] private int cofficiensPuellaePersonaeAnimae = 100;

        public int OffsetPuellaePersonaeAnimae => offsetPuellaePersonaeAnimae;
        public int GradusPuellaePersonaeMaximus => gradusPuellaePersonaeMaximus;
        public int SensusPuellaePersonaeMaximus => sensusPuellaePersonaeMaximus;
        public int CofficiensPuellaePersonaeAnimae => cofficiensPuellaePersonaeAnimae;
    }
}
