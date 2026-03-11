using UnityEngine;
using Yulinti.Officia.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [System.Serializable]
    public sealed class ConfiguratioTurris {
        [SerializeField] private ConfiguratioTurrisPhantasma phantasma;
        [SerializeField] private ConfiguratioSonorumVeli sonorumVeli;

        public IConfiguratioTurrisPhantasma Phantasma => phantasma;
        public IConfiguratioSonorumVeli SonorumVeli => sonorumVeli;
    }
}