using UnityEngine;
using Yulinti.Officia.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioPuellaeLoci", menuName = "Yulinti/Configuratio/Ministeria/Puella/ConfiguratioPuellaeLoci")]
    public sealed class ConfiguratioPuellaeLoci : ScriptableObject, IConfiguratioPuellaeLoci {
        [SerializeField] private float distantiaAdPerveni;

        public float DistantiaAdPerveni => distantiaAdPerveni;
    }
}