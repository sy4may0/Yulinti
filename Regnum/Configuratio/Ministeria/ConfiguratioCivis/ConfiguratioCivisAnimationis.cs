using UnityEngine;
using Yulinti.Unity.Contractus;

namespace Yulinti.Regnum.Configuratio {
    [System.Serializable]
    public sealed class ConfiguratioCivisAnimationis : IConfiguratioCivisAnimationis {
        [SerializeField] private ConfiguratioCivisAnimationisContinuata[] animationes;

        public IConfiguratioCivisAnimationisContinuata[] Animationes => animationes;
    }
}