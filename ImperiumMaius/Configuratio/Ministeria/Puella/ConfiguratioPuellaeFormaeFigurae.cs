using UnityEngine;
using Yulinti.Officia.Contractus;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioPuellaeFormaeFigurae", menuName = "Yulinti/Configuratio/Ministeria/Puella/ConfiguratioPuellaeFormaeFigurae")]
    public sealed class ConfiguratioPuellaeFormaeFigurae : ScriptableObject, IConfiguratioPuellaeFormaeFigurae {

        [SerializeField] private IDPuellaeFormae _forma;
        [SerializeField] private IDRedittorPuellaeFigurae[] _scopus;
        [SerializeField] private string _nomenFigurae;

        public IDPuellaeFormae Forma => _forma;
        public IDRedittorPuellaeFigurae[] Scopus => _scopus;
        public string NomenFigurae => _nomenFigurae;
    }
}