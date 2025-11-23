using UnityEngine;
using Animancer;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.ConfiguratioMinisterii {
    [CreateAssetMenu(menuName = "Ministeria/ConfiguratioPuellaeAnimationisIncubitus")]
    public class ConfiguratioPuellaeAnimationisIncubitus : ScriptableObject, IConfiguratioPuellaeAnimationisSectionis {
        [Header("ConfiguratioPuellaeAnimationisIncubitus/Incubitusアニメーション")]
        [SerializeField] private LinearMixerTransition _animatio;
        [SerializeField] private float _tempusEvanescentiae = 0.4f;
        [SerializeField] private Easing.Function _lenitio = Animancer.Easing.Function.Linear;
        [SerializeField] private bool _estSimultaneum = false;
        [SerializeField] private bool _estImpeditivus = false;
        [SerializeField] private bool _estCircularis = true;

        public NihilAut<ITransition> Animatio => new NihilAut<ITransition>(_animatio);
        public float TempusEvanescentiae => _tempusEvanescentiae;
        public Easing.Function Lenitio => _lenitio;
        public bool EstSimultaneum => _estSimultaneum;
        public bool EstImpeditivus => _estImpeditivus;
        public bool EstCircularis => _estCircularis;
    }
}
