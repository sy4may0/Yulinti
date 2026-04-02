using UnityEngine;
using Yulinti.Officia.Contractus;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioPuellaeFormaeOssis", menuName = "Yulinti/Configuratio/Ministeria/Puella/ConfiguratioPuellaeFormaeOssis")]
    public sealed class ConfiguratioPuellaeFormaeOssis : ScriptableObject, IConfiguratioPuellaeFormaeOssis {
        [SerializeField] private IDPuellaeFormae _forma;
        [SerializeField] private IDRedittorPuellaeOssisCorrectorium[] _scopus;
        [SerializeField] private Vector3 _magnitudoMaxima;
        [SerializeField] private Vector3 _magnitudoMedia;
        [SerializeField] private Vector3 _magnitudoMinima;

        public IDPuellaeFormae Forma => _forma;
        public IDRedittorPuellaeOssisCorrectorium[] Scopus => _scopus;
        public Vector3 MagnitudoMaxima => _magnitudoMaxima;
        public Vector3 MagnitudoMedia => _magnitudoMedia;
        public Vector3 MagnitudoMinima => _magnitudoMinima;
    }
}