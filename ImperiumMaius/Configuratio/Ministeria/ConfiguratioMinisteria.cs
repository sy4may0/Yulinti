using UnityEngine;
using Yulinti.Officia.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [System.Serializable]
    public sealed class ConfiguratioMinisteria {
        [SerializeField] private ConfiguratioCivis ministeriaCivis;
        [SerializeField] private ConfiguratioPuellae ministeriaPuellae;
        [SerializeField] private ConfiguratioPunctumViae ministeriaPunctumViae;

        public IConfiguratioCivis Civis => ministeriaCivis;
        public IConfiguratioPuellae Puellae => ministeriaPuellae;
        public IConfiguratioPunctumViae PunctumViae => ministeriaPunctumViae;
    }
}