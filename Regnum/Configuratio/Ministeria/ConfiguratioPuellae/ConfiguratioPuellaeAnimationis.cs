using System.Linq;
using UnityEngine;
using Yulinti.Unity.Contractus;

namespace Yulinti.Regnum.Configuratio {
    [System.Serializable]
    public sealed class ConfiguratioPuellaeAnimationis : IConfiguratioPuellaeAnimationis {
        [SerializeField] private ConfiguratioPuellaeAnimationisContinuata[] _animationes;

        public IConfiguratioPuellaeAnimationisContinuata[] Animationes => _animationes;

    }
}
