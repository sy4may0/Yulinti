using UnityEngine;
using Yulinti.Officia.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioCivisLoci", menuName = "Yulinti/Configuratio/Ministeria/Civis/ConfiguratioCivisLoci")]
    public sealed class ConfiguratioCivisLoci : ScriptableObject, IConfiguratioCivisLoci {
        [SerializeField] private float distantiaAdPerveni;

        public float DistantiaAdPerveni => distantiaAdPerveni;
    }
}