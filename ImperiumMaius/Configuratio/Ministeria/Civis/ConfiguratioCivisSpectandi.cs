using UnityEngine;
using Yulinti.Officia.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioCivisSpectandi", menuName = "Yulinti/Configuratio/Ministeria/Civis/ConfiguratioCivisSpectandi")]
    public sealed class ConfiguratioCivisSpectandi : ScriptableObject, IConfiguratioCivisSpectandi {
        [SerializeField] private float tempusLevigatum = 0.3f;
        [SerializeField] private float epsilonPonderis = 0.001f;

        public float TempusLevigatum => tempusLevigatum;
        public float EpsilonPonderis => epsilonPonderis;
    }
}
