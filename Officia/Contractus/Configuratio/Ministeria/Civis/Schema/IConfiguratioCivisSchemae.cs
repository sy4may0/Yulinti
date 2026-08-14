using UnityEngine.AddressableAssets;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.Officia.Contractus {
    public interface IConfiguratioCivisSchemae {
        IDCivisPersonae IDCivisPersonae { get; }
        AssetReferenceGameObject[] Schemarum { get; }
    }
}