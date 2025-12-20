using UnityEngine;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Rex {
    [CreateAssetMenu(fileName = "ConfiguratioCivis", menuName = "Yulinti/Rex/ConfiguratioCivis")]
    public sealed class ConfiguratioCivis : ScriptableObject, IConfiguratioCivis {
        [SerializeField] private ConfiguratioCivisLoci loci;
        [SerializeField] private ConfiguratioCivisAnimationis animatio;
        [SerializeField] private ConfiguratioCivisGenerator generator;

        public IConfiguratioCivisLoci Loci => loci;
        public IConfiguratioCivisAnimationis Animatio => animatio;
        public IConfiguratioCivisGenerator Generator => generator;
    }
}
