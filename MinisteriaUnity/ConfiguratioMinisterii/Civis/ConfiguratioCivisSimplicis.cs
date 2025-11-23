using UnityEngine;

namespace Yulinti.MinisteriaUnity.ConfiguratioMinisterii {
    [System.Serializable]
    public sealed class ConfiguratioCivisSimplicis {
        [SerializeField] private GameObject _civisPrefab;
        [SerializeField] private string  _iterAdCapitis;

        public GameObject CivisPrefab => _civisPrefab;
        public string IterAdCapitis => _iterAdCapitis;
    }
}