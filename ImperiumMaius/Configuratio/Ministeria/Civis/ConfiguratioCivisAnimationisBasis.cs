using UnityEngine;
using Yulinti.Officia.Contractus;
using Animancer;

using Yulinti.ImperiumDelegatum.Contractus;
namespace Yulinti.ImperiumMaius.Configuratio {
    public abstract class ConfiguratioCivisAnimationisBasis :
        ScriptableObject,
        IConfiguratioCivisAnimationis {
        [SerializeField] private IDCivisAnimationis id;
        [SerializeField] private float tempusEvanescentiae = 0.4f;
        [SerializeField] private Easing.Function lenitio = Easing.Function.Linear;
        [SerializeField] private bool estSimulataneum = false;
        [SerializeField] private bool estIterans = false;

        public IDCivisAnimationis Id => id;
        public abstract ITransition Animatio { get; }
        public float TempusEvanescentiae => tempusEvanescentiae;
        public Easing.Function Lenitio => lenitio;
        public bool EstSimulataneum => estSimulataneum;
        public bool EstIterans => estIterans;
    }
}
