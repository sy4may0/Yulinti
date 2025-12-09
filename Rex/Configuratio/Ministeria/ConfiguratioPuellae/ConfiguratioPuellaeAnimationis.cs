using System.Linq;
using UnityEngine;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Rex {
    [System.Serializable]
    public sealed class ConfiguratioPuellaeAnimationis : IConfiguratioPuellaeAnimationis {
        [SerializeField] private ConfiguratioPuellaeAnimationisContinuata[] _animationes;

        public IConfiguratioPuellaeAnimationisContinuata[] Animationes => _animationes;

    }
}
