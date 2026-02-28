using UnityEngine;
using Yulinti.Unity.Contractus;

namespace Yulinti.Regnum.Configuratio {
    [System.Serializable]
    public sealed class ConfiguratioCivisLoci : IConfiguratioCivisLoci {
        [SerializeField] private float distantiaAdPerveni;

        public float DistantiaAdPerveni => distantiaAdPerveni;
    }
}