using UnityEngine;
using Yulinti.Officia.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioSonorumVeli", menuName = "Yulinti/Configuratio/Turris/Sonus/ConfiguratioSonorumVeli")]
    public class ConfiguratioSonorumVeli : ScriptableObject, IConfiguratioSonorumVeli {
        [SerializeField] private ConfiguratioSoniVeli[] _sonorumVeli;
        [SerializeField] private int _numerusSonorumVeliMaxima = 5;

        public IConfiguratioSoniVeli[] SonorumVeli => _sonorumVeli;
        public int NumerusSonorumVeliMaxima => _numerusSonorumVeliMaxima;
    }
}