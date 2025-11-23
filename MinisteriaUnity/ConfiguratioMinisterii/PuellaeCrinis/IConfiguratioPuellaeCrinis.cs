using UnityEngine;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.ConfiguratioMinisterii {
    public interface IConfiguratioPuellaeCrinis {
        IDPuellaeCrinis IdCrinis { get; }
        NihilAut<GameObject> Crinis { get; }
        string IterAdRadicem { get; }
        string NomenAddressables { get; }
    }
}
