using UnityEngine;
using Yulinti.Officia.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(
        fileName = "ConfiguratioCivisSchemarum",
        menuName = "Yulinti/Configuratio/Ministeria/Civis/ConfiguratioCivisSchemarum")]
    public sealed class ConfiguratioCivisSchemarum : ScriptableObject, IConfiguratioCivisSchemarum {
        [Header("Schemaセット")]
        [SerializeField] private ConfiguratioCivisSchemae[] schemarum;

        public IConfiguratioCivisSchemae[] Schemarum => schemarum;
    }
}