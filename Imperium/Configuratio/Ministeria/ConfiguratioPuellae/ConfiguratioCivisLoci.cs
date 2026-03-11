using UnityEngine;
using Yulinti.Officia.Contractus;

namespace Yulinti.Imperium.Configuratio {
    [System.Serializable]
    public sealed class ConfiguratioPuellaeLoci : IConfiguratioPuellaeLoci {
        [SerializeField] private float distantiaAdPerveni;

        public float DistantiaAdPerveni => distantiaAdPerveni;
    }
}