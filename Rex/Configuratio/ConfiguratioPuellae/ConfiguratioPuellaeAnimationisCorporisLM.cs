using UnityEngine;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;
using Animancer;

namespace Yulinti.Rex {
    [CreateAssetMenu(fileName = "ConfiguratioPuellaeAnimationisCorporisLM", menuName = "Yulinti/Rex/ConfiguratioPuellaeAnimationisCorporisLM")]
    public sealed class ConfiguratioPuellaeAnimationisCorporisLM : ScriptableObject, IConfiguratioPuellaeAnimationisCorporis {
        [SerializeField] private IDPuellaeAnimationisCorporis _id;
        [SerializeField] private LinearMixerTransition _animatio;
        [SerializeField] private float _tempusEvanescentiae = 0.4f;
        [SerializeField] private Easing.Function _lenitio = Animancer.Easing.Function.Linear;
        [SerializeField] private bool _estSimultaneum = false;
        [SerializeField] private bool _estImpeditivus = false;
        [SerializeField] private bool _estCircularis = true;
        [SerializeField] private bool _estObsignatus = false;

        public IDPuellaeAnimationisCorporis Id => _id;
        public NihilAut<ITransition> Animatio => new NihilAut<ITransition>(_animatio);
        public float TempusEvanescentiae => _tempusEvanescentiae;
        public Easing.Function Lenitio => _lenitio;
        public bool EstSimultaneum => _estSimultaneum;
        public bool EstImpeditivus => _estImpeditivus;
        public bool EstCircularis => _estCircularis;
        public bool EstObsignatus => _estObsignatus;
    }
}
