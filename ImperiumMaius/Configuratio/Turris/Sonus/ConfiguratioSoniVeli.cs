using UnityEngine;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Officia.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioSoniVeli", menuName = "Yulinti/Configuratio/Turris/Sonus/ConfiguratioSoniVeli")]
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