using UnityEngine;
using Yulinti.Officia.Contractus;

namespace Yulinti.Imperium.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioTurris", menuName = "Yulinti/Rex/ConfiguratioTurris")]
    public sealed class ConfiguratioTurris : ScriptableObject, IConfiguratioTurris {
        [SerializeField] private ConfiguratioTurrisPhantasma phantasma;
        [SerializeField] private ConfiguratioSonorumVeli sonorumVeli;

        public IConfiguratioTurrisPhantasma Phantasma => phantasma;
        public IConfiguratioSonorumVeli SonorumVeli => sonorumVeli;
    }
}