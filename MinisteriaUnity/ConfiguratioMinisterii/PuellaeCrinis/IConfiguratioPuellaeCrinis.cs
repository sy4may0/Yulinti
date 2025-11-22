using UnityEngine;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.ConfiguratioMinisterii {
    public interface IConfiguratioPuellaeCrinis {
        IDPuellaeCrinis IdCrinis { get; }
        GameObject Crinis { get; }
        string IterAdRadicem { get; }
        string NomenAddressables { get; }
    }
}