using UnityEngine;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.ConfiguratioMinisterii {
    [CreateAssetMenu(menuName = "Ministeria/ConfiguratioPuellaeCrinis")]
    public sealed class ConfiguratioPuellaeCrinis : ScriptableObject, IConfiguratioPuellaeCrinis {
        [Header("ConfiguratioPuellaeCrinis/髪設定")]
        [SerializeField] private IDPuellaeCrinis _idCrinis;
        [SerializeField] private GameObject _crinis;
        [SerializeField] private string _iterAdRadicem;
        [SerializeField] private string _nomenAddressables;

        public IDPuellaeCrinis IdCrinis => _idCrinis;
        public GameObject Crinis => _crinis;
        public string IterAdRadicem => _iterAdRadicem;
        public string NomenAddressables => _nomenAddressables;
    }
}