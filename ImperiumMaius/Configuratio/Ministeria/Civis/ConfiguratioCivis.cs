using UnityEngine;
using Yulinti.Officia.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioCivis", menuName = "Yulinti/Configuratio/Ministeria/Civis/ConfiguratioCivis")]
    public sealed class ConfiguratioCivis : ScriptableObject, IConfiguratioCivis {
        [SerializeField] private ConfiguratioCivisLoci loci;
        [SerializeField] private ConfiguratioCivisAnimationum animatio;
        [SerializeField] private ConfiguratioCivisVisae visa;
        [SerializeField] private ConfiguratioCivisSchemarum schemarum;
        [SerializeField] private ConfiguratioCivisSpectandi spectandi;

        public IConfiguratioCivisLoci Loci => loci;
        public IConfiguratioCivisAnimationum Animatio => animatio;
        public IConfiguratioCivisVisae Visa => visa;
        public IConfiguratioCivisSchemarum Schemarum => schemarum;
        public IConfiguratioCivisSpectandi Spectandi => spectandi;
    }
}
