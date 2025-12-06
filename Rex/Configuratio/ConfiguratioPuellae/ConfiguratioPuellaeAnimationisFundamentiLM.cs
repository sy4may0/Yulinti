using Animancer;
using UnityEngine;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;

namespace Yulinti.Rex {
    [CreateAssetMenu(fileName = "ConfiguratioPuellaeAnimationisFundamentiLM", menuName = "Yulinti/Rex/ConfiguratioPuellaeAnimationisFundamentiLM")]
    public sealed class ConfiguratioPuellaeAnimationisFundamentiLM : ScriptableObject, IConfiguratioPuellaeAnimationisFundamenti {
        [SerializeField] private IDPuellaeAnimationisFundamenti _id;
        [SerializeField] private LinearMixerTransition _animatio;
        [SerializeField] private float _tempusEvanescentiae = 0.4f;
        [SerializeField] private Easing.Function _lenitio = Animancer.Easing.Function.Linear;
        [SerializeField] private bool _estSimultaneum = false;
        [SerializeField] private bool _estImpeditivus = false;
        [SerializeField] private bool _estCircularis = true;
        [SerializeField] private bool _estObsignatus = false;

        public IDPuellaeAnimationisFundamenti Id => _id;
        public NihilAut<ITransition> Animatio => new NihilAut<ITransition>(_animatio);
        public float TempusEvanescentiae => _tempusEvanescentiae;
        public Easing.Function Lenitio => _lenitio;
        public bool EstSimultaneum => _estSimultaneum;
        public bool EstImpeditivus => _estImpeditivus;
        public bool EstCircularis => _estCircularis;
        public bool EstObsignatus => _estObsignatus;
    }
}
