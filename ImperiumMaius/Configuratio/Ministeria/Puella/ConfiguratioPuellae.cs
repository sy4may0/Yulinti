using UnityEngine;
using Yulinti.Officia.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioPuellae", menuName = "Yulinti/Configuratio/Ministeria/Puella/ConfiguratioPuellae")]
    public sealed class ConfiguratioPuellae : ScriptableObject, IConfiguratioPuellae {
        [SerializeField] ConfiguratioPuellaeRelationis relatio;
        [SerializeField] ConfiguratioPuellaeFigurae figura;
        [SerializeField] ConfiguratioPuellaeAnimationum animatio;
        [SerializeField] ConfiguratioPuellaeLoci loci;
        [SerializeField] ConfiguratioPuellaeFormarum formae;
        [SerializeField] ConfiguratioPuellaeReferensCapitis referensCapitis;

        public IConfiguratioPuellaeRelationis Relatio => relatio;
        public IConfiguratioPuellaeFigurae Figura => figura;
        public IConfiguratioPuellaeAnimationum Animatio => animatio;
        public IConfiguratioPuellaeLoci Loci => loci;
        public IConfiguratioPuellaeFormarum Formae => formae;
        public IConfiguratioPuellaeReferensCapitis ReferensCapitis => referensCapitis;
    }
}
