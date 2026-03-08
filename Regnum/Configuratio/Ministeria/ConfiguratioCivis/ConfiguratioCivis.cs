using UnityEngine;
using Yulinti.Unity.Contractus;

namespace Yulinti.Regnum.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioCivis", menuName = "Yulinti/Rex/ConfiguratioCivis")]
    public sealed class ConfiguratioCivis : ScriptableObject, IConfiguratioCivis {
        [SerializeField] private ConfiguratioCivisLoci loci;
        [SerializeField] private ConfiguratioCivisAnimationum animatio;
        [SerializeField] private ConfiguratioCivisGenerator generator;
        [SerializeField] private ConfiguratioCivisVisae visa;

        public IConfiguratioCivisLoci Loci => loci;
        public IConfiguratioCivisAnimationum Animatio => animatio;
        public IConfiguratioCivisGenerator Generator => generator;
        public IConfiguratioCivisVisae Visa => visa;
    }
}
