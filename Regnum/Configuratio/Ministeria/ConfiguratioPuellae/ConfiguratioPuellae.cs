using UnityEngine;
using Yulinti.Unity.Contractus;

namespace Yulinti.Regnum.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioPuellae", menuName = "Yulinti/Rex/ConfiguratioPuellae")]
    public sealed class ConfiguratioPuellae : ScriptableObject, IConfiguratioPuellae {
        [SerializeField] ConfiguratioPuellaeRelationis relatio;
        [SerializeField] ConfiguratioPuellaeFigurae figura;
        [SerializeField] ConfiguratioPuellaeAnimationum animatio;
        [SerializeField] ConfiguratioPuellaeLoci loci;

        public IConfiguratioPuellaeRelationis Relatio => relatio;
        public IConfiguratioPuellaeFigurae Figura => figura;
        public IConfiguratioPuellaeAnimationum Animatio => animatio;
        public IConfiguratioPuellaeLoci Loci => loci;
    }
}
