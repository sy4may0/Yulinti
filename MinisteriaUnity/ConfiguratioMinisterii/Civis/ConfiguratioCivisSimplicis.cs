using UnityEngine;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.ConfiguratioMinisterii {
    [CreateAssetMenu(menuName = "Ministeria/ConfiguratioCivisSimplicis")]
    public sealed class ConfiguratioCivisSimplicis : ScriptableObject, IConfiguratioCivisOrdinatae {
        [Header("ConfiguratioCivisSimplicis/市民プレハブ")]
        [SerializeField] private GameObject _civisPrefab;

        public NihilAut<GameObject> CivisPrefab => new NihilAut<GameObject>(_civisPrefab);
    }
}