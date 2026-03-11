using UnityEngine;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.Imperium.Configuratio {
    [System.Serializable]
    public sealed class ConfiguratioPuellaePersonae : IConfiguratioPuellaePersonae {
        [Header("経験値倍率の初期値(Lv0での倍率)")]
        [SerializeField] private int offsetAnimae = 4;
        [Header("最大レベル")]
        [SerializeField] private int gradusMaximus = 10;
        [Header("最大感度レベル")]
        [SerializeField] private int sensusMaximus = 10;
        [Header("必要経験値係数")]
        [SerializeField] private int cofficiensAnimae = 100;

        public int OffsetAnimae => offsetAnimae;
        public int GradusMaximus => gradusMaximus;
        public int SensusMaximus => sensusMaximus;
        public int CofficiensAnimae => cofficiensAnimae;
    }
}