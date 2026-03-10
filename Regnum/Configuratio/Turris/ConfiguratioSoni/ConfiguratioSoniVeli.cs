using UnityEngine;
using Yulinti.Exercitus.Contractus;
using Yulinti.Unity.Contractus;

namespace Yulinti.Regnum.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioSoniVeli", menuName = "Yulinti/Rex/ConfiguratioSoniVeli")]
    public class ConfiguratioSoniVeli : ScriptableObject, IConfiguratioSoniVeli {
        [SerializeField] private IDSonusVeli id;
        [SerializeField] private AudioClip _sonus;
        [SerializeField] private float _visSoniBasis;
        [SerializeField] private float _tempusRefrigerationis;
        [SerializeField] private int _prioritas = 0;

        public IDSonusVeli Id => id;
        public AudioClip Sonus => _sonus;
        public float VisSoniBasis => _visSoniBasis;
        public float TempusRefrigerationis => _tempusRefrigerationis;
        public int Prioritas => _prioritas;
    }
}