using UnityEngine;
using Yulinti.Unity.Contractus;

namespace Yulinti.Regnum.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioTurrisPhantasma", menuName = "Yulinti/Rex/ConfiguratioTurrisPhantasma")]
    public sealed class ConfiguratioTurrisPhantasma : ScriptableObject, IConfiguratioTurrisPhantasma {
        [SerializeField] private int offsetPuellaePersonaeAnimae = 4;
        [SerializeField] private int gradusPuellaePersonaeMaximus = 10;
        [SerializeField] private int sensusPuellaePersonaeMaximus = 10;
        [SerializeField] private int cofficiensPuellaePersonaeAnimae = 100;

        public int OffsetPuellaePersonaeAnimae => offsetPuellaePersonaeAnimae;
        public int GradusPuellaePersonaeMaximus => gradusPuellaePersonaeMaximus;
        public int SensusPuellaePersonaeMaximus => sensusPuellaePersonaeMaximus;
        public int CofficiensPuellaePersonaeAnimae => cofficiensPuellaePersonaeAnimae;
    }
}