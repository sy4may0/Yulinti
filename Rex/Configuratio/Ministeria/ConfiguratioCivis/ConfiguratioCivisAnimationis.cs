using UnityEngine;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Rex {
    [System.Serializable]
    public sealed class ConfiguratioCivisAnimationis : IConfiguratioCivisAnimationis {
        [SerializeField] private ConfiguratioCivisAnimationisContinuata[] animationes;

        public IConfiguratioCivisAnimationisContinuata[] Animationes => animationes;
    }
}