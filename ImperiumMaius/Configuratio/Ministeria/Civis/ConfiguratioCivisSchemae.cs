using UnityEngine;
using UnityEngine.AddressableAssets;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Officia.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(
        fileName = "ConfiguratioCivisSchemae",
        menuName = "Yulinti/Configuratio/Ministeria/Civis/Schema/CivisSchemae")]
    public sealed class ConfiguratioCivisSchemae : ScriptableObject, IConfiguratioCivisSchemae {
        [Header("PersonaID")]
        [SerializeField] private IDCivisPersonae idCivisPersonae;
        [Header("Prefabセット")]
        [SerializeField] private AssetReferenceGameObject[] schemarum;

        public IDCivisPersonae IDCivisPersonae => idCivisPersonae;
        public AssetReferenceGameObject[] Schemarum => schemarum;
    }
}