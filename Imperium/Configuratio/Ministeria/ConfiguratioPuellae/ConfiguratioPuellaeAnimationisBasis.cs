using Animancer;
using UnityEngine;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Officia.Contractus;

namespace Yulinti.Imperium.Configuratio {
    public abstract class ConfiguratioPuellaeAnimationisBasis : ScriptableObject, IConfiguratioPuellaeAnimationis {
        [SerializeField] private IDPuellaeAnimationis id;
        [SerializeField] private float tempusEvanescentiae;
        [SerializeField] private Easing.Function lenitio;
        [SerializeField] private bool estSimulataneum;
        [SerializeField] private bool estIterans;

        public IDPuellaeAnimationis Id => id;
        public abstract ITransition Animatio { get; }
        public float TempusEvanescentiae => tempusEvanescentiae;
        public Easing.Function Lenitio => lenitio;
        public bool EstSimulataneum => estSimulataneum;
        public bool EstIterans => estIterans;
    }
}