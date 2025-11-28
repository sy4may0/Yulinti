using UnityEngine;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.ConfiguratioMinisterii {
    [System.Serializable]
    public sealed class FasciculusConfiguratioCivis {
        [Header("FasciculusConfiguratioCivis/単体市民設定/ほぼテスト用")]
        [SerializeField] private ConfiguratioCivisSimplicis _configuratioCivisSimplicis;
        [Header("ConfiguratioPunctumViae/使用するWayPointリスト")]
        [SerializeField] private ConfiguratioPunctumViae _configuratioPunctumViae;

        public NihilAut<IConfiguratioCivisOrdinatae> ConfiguratioCivisSimplicis => new NihilAut<IConfiguratioCivisOrdinatae>(_configuratioCivisSimplicis);
        public NihilAut<ConfiguratioPunctumViae> ConfiguratioPunctumViae => new NihilAut<ConfiguratioPunctumViae>(_configuratioPunctumViae);
    }
}