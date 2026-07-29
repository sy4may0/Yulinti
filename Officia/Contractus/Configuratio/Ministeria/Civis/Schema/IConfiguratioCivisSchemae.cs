using UnityEngine.AddressableAssets;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.Officia.Contractus {
    public interface IConfiguratioCivisSchemae {
        IDCivisSchemae IDCivisSchemae { get; }
        AssetReferenceGameObject[] Schemarum { get; }
    }
}