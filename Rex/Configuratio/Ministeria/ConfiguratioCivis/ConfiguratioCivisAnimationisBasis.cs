using UnityEngine;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Animancer;

namespace Yulinti.Rex {
    public abstract class ConfiguratioCivisAnimationisBasis : ScriptableObject, IConfiguratioCivisAnimationisUnicae {
        [SerializeField] private IDCivisAnimationis id;
        [SerializeField] private float tempusEvanescentiae = 0.4f;
        [SerializeField] private Easing.Function lenitio = Easing.Function.Linear;
        [SerializeField] private bool estSimultaneum = false;
        [SerializeField] private bool estImpeditivus = false;
        [SerializeField] private bool estCircularis = true;
        [SerializeField] private bool estObsignatus = false;
        [SerializeField] private bool estTerminare = false;

        public IDCivisAnimationis Id => id;
        public abstract ITransition Animatio { get; }
        public float TempusEvanescentiae => tempusEvanescentiae;
        public Easing.Function Lenitio => lenitio;
        public bool EstSimultaneum => estSimultaneum;
        public bool EstImpeditivus => estImpeditivus;
        public bool EstCircularis => estCircularis;
        public bool EstObsignatus => estObsignatus;
        public bool EstTerminare => estTerminare;
    }
}