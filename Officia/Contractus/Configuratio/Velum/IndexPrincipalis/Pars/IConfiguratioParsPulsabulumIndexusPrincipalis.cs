using Yulinti.Auctoritas.Contractus;
using Yulinti.ImperiumDelegatum.Contractus;
using UnityEngine.UIElements;

namespace Yulinti.Officia.Contractus {
    public interface IConfiguratioParsPulsabulumIndexusPrincipalis {
        UsusIndexusPrincipalis Usus { get; }
        int MagnitudoLitterarum { get; }
        IDTextus Textus { get; }
        VisualTreeAsset Examplar { get; }
    }
}