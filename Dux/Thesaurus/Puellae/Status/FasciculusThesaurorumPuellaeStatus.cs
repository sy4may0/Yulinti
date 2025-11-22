using Yulinti.MinisteriaUnity.ConfiguratioDucis;

namespace Yulinti.Dux.Thesaurus {
    public sealed class FasciculusThesaurorumPuellaeStatus {
        public ThesaurusPuellaeStatuumGlobalis Globalis { get; set; } = new ThesaurusPuellaeStatuumGlobalis();
        public ThesaurusPuellaeStatusQuietes Quietes { get; set; } = new ThesaurusPuellaeStatusQuietes();
        public ThesaurusPuellaeStatusAmbulationis Ambulationis { get; set; } = new ThesaurusPuellaeStatusAmbulationis();
        public ThesaurusPuellaeStatusCursus Cursus { get; set; } = new ThesaurusPuellaeStatusCursus();
        public ThesaurusPuellaeStatusIncubitus Incubitus { get; set; } = new ThesaurusPuellaeStatusIncubitus();
        public ThesaurusPuellaeStatusIncubitusAmbulationis IncubitusAmbulationem { get; set; } = new ThesaurusPuellaeStatusIncubitusAmbulationis();

        public FasciculusThesaurorumPuellaeStatus() {
        }

        public FasciculusThesaurorumPuellaeStatus(FasciculusConfigurationumPuellaeStatus configuratio) {
            if (configuratio == null) {
                return;
            }

            Globalis = new ThesaurusPuellaeStatuumGlobalis(configuratio.Globalis);
            Quietes = new ThesaurusPuellaeStatusQuietes(configuratio.Quietes);
            Ambulationis = new ThesaurusPuellaeStatusAmbulationis(configuratio.Ambulationis);
            Cursus = new ThesaurusPuellaeStatusCursus(configuratio.Cursus);
            Incubitus = new ThesaurusPuellaeStatusIncubitus(configuratio.Incubitus);
            IncubitusAmbulationem = new ThesaurusPuellaeStatusIncubitusAmbulationis(configuratio.IncubitusAmbulationem);
        }
    }
}
