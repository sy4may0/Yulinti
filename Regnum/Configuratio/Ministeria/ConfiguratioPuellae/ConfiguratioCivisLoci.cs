using UnityEngine;
using Yulinti.Unity.Contractus;

namespace Yulinti.Regnum.Configuratio {
    [System.Serializable]
    public sealed class ConfiguratioPuellaeLoci : IConfiguratioPuellaeLoci {
        [SerializeField] private float distantiaAdPerveni;

        public float DistantiaAdPerveni => distantiaAdPerveni;
    }
}