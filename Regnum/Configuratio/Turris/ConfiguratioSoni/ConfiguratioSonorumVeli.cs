using UnityEngine;
using Yulinti.Unity.Contractus;

namespace Yulinti.Regnum.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioSonorumVeli", menuName = "Yulinti/Rex/ConfiguratioSonorumVeli")]
    public class ConfiguratioSonorumVeli : ScriptableObject, IConfiguratioSonorumVeli {
        [SerializeField] private ConfiguratioSoniVeli[] _sonorumVeli;

        public IConfiguratioSoniVeli[] SonorumVeli => _sonorumVeli;
    }
}