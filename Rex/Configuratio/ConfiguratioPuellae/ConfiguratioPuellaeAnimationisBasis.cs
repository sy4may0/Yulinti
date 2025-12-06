using Animancer;
using UnityEngine;
using Yulinti.MinisteriaUnity.ContractusMinisterii;


namespace Yulinti.Rex {
    public abstract class ConfiguratioPuellaeAnimationisBasis : ScriptableObject, IConfiguratioPuellaeAnimationisUnicae {
        [SerializeField] private IDPuellaeAnimationis _id;
        [SerializeField] private float _tempusEvanescentiae = 0.4f;
        [SerializeField] private Easing.Function _lenitio = Easing.Function.Linear;
        [SerializeField] private bool _estSimultaneum = false;
        [SerializeField] private bool _estImpeditivus = false;
        [SerializeField] private bool _estCircularis = true;
        [SerializeField] private bool _estObsignatus = false;

        public IDPuellaeAnimationis Id => _id;
        public abstract ITransition Animatio { get; }
        public float TempusEvanescentiae => _tempusEvanescentiae;
        public Easing.Function Lenitio => _lenitio;
        public bool EstSimultaneum => _estSimultaneum;
        public bool EstImpeditivus => _estImpeditivus;
        public bool EstCircularis => _estCircularis;
        public bool EstObsignatus => _estObsignatus;
    }
}
