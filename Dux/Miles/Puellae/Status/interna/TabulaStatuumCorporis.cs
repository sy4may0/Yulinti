using Yulinti.Dux.Thesaurus;
using Yulinti.Dux.ContractusDucis;
using Yulinti.Dux.Miles;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.MinisteriaUnity.MinisteriaRationis;



namespace Yulinti.Dux.Miles {
    internal sealed class TabulaStatuumCorporis {
        private readonly IStatusCorporis[] _status;
        private readonly IOstiumErrorumLegibile _osErrorumLeg;

        public TabulaStatuumCorporis(
            FasciculusThesaurorumPuellaeStatus thesauriPuellaeStatus,
            IOstiumInputMotusLegibile osInputMotusLeg,
            IOstiumTemporisLegibile osTemporisLeg,
            IOstiumCameraLegibile osCameraLeg,
            IOstiumErrorumLegibile osErrorumLeg
        ) {
            _osErrorumLeg = osErrorumLeg;

            int longitudo = (int)IDStatus.Count;
            _status = new IStatusCorporis[longitudo];
            _status[(int)IDStatus.Quies] = new StatusQuietes(
                thesauriPuellaeStatus.Globalis,
                thesauriPuellaeStatus.Quietes,
                osInputMotusLeg,
                osTemporisLeg
            );

            _status[(int)IDStatus.Ambulatio] = new StatusAmbulationis(
                thesauriPuellaeStatus.Globalis,
                thesauriPuellaeStatus.Ambulationis,
                osInputMotusLeg,
                osTemporisLeg,
                osCameraLeg
            );

            _status[(int)IDStatus.Cursus] = new StatusCursus(
                thesauriPuellaeStatus.Globalis,
                thesauriPuellaeStatus.Cursus,
                osInputMotusLeg,
                osTemporisLeg,
                osCameraLeg
            );

            _status[(int)IDStatus.Incumbo] = new StatusIncubitus(
                thesauriPuellaeStatus.Globalis,
                thesauriPuellaeStatus.Incubitus,
                osInputMotusLeg,
                osTemporisLeg
            );

            _status[(int)IDStatus.IncumboAmbulationem] = new StatusIncubitusAmbulationis(
                thesauriPuellaeStatus.Globalis,
                thesauriPuellaeStatus.IncubitusAmbulationem,
                osInputMotusLeg,
                osTemporisLeg,
                osCameraLeg
            );

            for (int i = 1; i < longitudo; i++) {
                if (_status[i] == null) {
                    _osErrorumLeg.Fatal($"IDStatus {(IDStatus)i} is missing. Check FasciculusThesaurorumPuellaeStatus.");
                }

                if (_status[i].Id != (IDStatus)i) {
                    _osErrorumLeg.Fatal($"IDStatus {(IDStatus)i} mismatch. Check FasciculusThesaurorumPuellaeStatus.");
                }
            }
        }

        public IStatusCorporis Lego(IDStatus idStatus) => _status[(int)idStatus];
    }
}
