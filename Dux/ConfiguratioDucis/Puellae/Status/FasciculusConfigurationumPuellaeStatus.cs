using UnityEngine;

namespace Yulinti.Dux.ConfiguratioDucis {
    [System.Serializable]
    public sealed class FasciculusConfigurationumPuellaeStatus {
        [SerializeField] private ConfiguratioPuellaeStatuumGlobalis _configuratioGlobalis;

        [SerializeField] private ConfiguratioPuellaeStatusQuietes _configuratioQuietes;
        [SerializeField] private ConfiguratioPuellaeStatusAmbulationis _configuratioAmbulationis;
        [SerializeField] private ConfiguratioPuellaeStatusCursus _configuratioCursus;

        public ConfiguratioPuellaeStatuumGlobalis Globalis => _configuratioGlobalis;
        public ConfiguratioPuellaeStatusQuietes Quietes => _configuratioQuietes;
        public ConfiguratioPuellaeStatusAmbulationis Ambulationis => _configuratioAmbulationis;
        public ConfiguratioPuellaeStatusCursus Cursus => _configuratioCursus;
    }
}