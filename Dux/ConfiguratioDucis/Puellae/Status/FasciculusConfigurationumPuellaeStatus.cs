using UnityEngine;

namespace Yulinti.Dux.ConfigratioDucis {
    [System.Serializable]
    public sealed class FasciculusConfigurationumPuellaeStatus {
        [SerializeField] private ConfiguratioPuellaeStatuumGlobalis _configuratioGlobalis;

        [SerializeField] private ConfiguratioPuellaeStatusQuietes _configuratioQuietes;
        [SerializeField] private ConfiguratioPuellaeStatusAmbulationis _configuratioAmbulationis;
        [SerializeField] private ConfiguratioPuellaeStatusCursus _configuratioCursus;
        [SerializeField] private ConfiguratioPuellaeStatusIncubitus _configuratioIncubitus;
        [SerializeField] private ConfiguratioPuellaeStatusIncubitusAmbulationem _configuratioIncubitusAmbulationem;

        public ConfiguratioPuellaeStatuumGlobalis Globalis => _configuratioGlobalis;
        public ConfiguratioPuellaeStatusQuietes Quietes => _configuratioQuietes;
        public ConfiguratioPuellaeStatusAmbulationis Ambulationis => _configuratioAmbulationis;
        public ConfiguratioPuellaeStatusCursus Cursus => _configuratioCursus;
        public ConfiguratioPuellaeStatusIncubitus Incubitus => _configuratioIncubitus;
        public ConfiguratioPuellaeStatusIncubitusAmbulationem IncubitusAmbulationem => _configuratioIncubitusAmbulationem;
    }
}