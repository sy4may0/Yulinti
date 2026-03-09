using UnityEngine;
using Yulinti.Unity.Contractus;

namespace Yulinti.Regnum.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioSoniVeli", menuName = "Yulinti/Rex/ConfiguratioSoniVeli")]
    public class ConfiguratioSoniVeli : ScriptableObject, IConfiguratioSoniVeli {
        [SerializeField] private AudioClip _sonus;
        [SerializeField] private float _visSoniBasis;
        [SerializeField] private float _tempusRefrigerationis;

        public AudioClip Sonus => _sonus;
        public float VisSoniBasis => _visSoniBasis;
        public float TempusRefrigerationis => _tempusRefrigerationis;
    }
}