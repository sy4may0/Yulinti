using UnityEngine;
using UnityEngine.AddressableAssets;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Officia.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(
        fileName = "ConfiguratioCivisSchemae",
        menuName = "Yulinti/Configuratio/Ministeria/Civis/Schema/CivisSchemae")]
    public sealed class ConfiguratioCivisSchemae : ScriptableObject, IConfiguratioCivisSchemae {
        [Header("SchemaID")]
        [SerializeField] private IDCivisSchemae idCivisSchemae;
        [Header("Prefabセット")]
        [SerializeField] private AssetReferenceGameObject[] schemarum;

        public IDCivisSchemae IDCivisSchemae => idCivisSchemae;
        public AssetReferenceGameObject[] Schemarum => schemarum;
    }
}