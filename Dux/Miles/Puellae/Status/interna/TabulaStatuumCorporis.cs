using Yulinti.Dux.ConfiguratioDucis;
using Yulinti.Dux.ContructusDucis;
using Yulinti.Dux.Miles.Puellae.Status;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.MinisteriaUnity.MinisteriaRationis;

namespace Yulinti.Dux.Miles.Puellae.Interna {
    public sealed class TabulaStatuumCorporis {
        private readonly IStatusCorporis[] _status;
        private readonly IOstiumErrorumLegibile _osErrorumLeg;

        public TabulaStatuumCorporis(
            FasciculusConfigurationumPuellaeStatus configuratioPuellaeStatus,
            FasciculusOstiorum ostia
        ) {
            _osErrorumLeg = ostia.ErrorumLeg;

            int longitudo = (int)IDStatus.Count;
            _status = new IStatusCorporis[longitudo];

            // Quies
            _status[(int)IDStatus.Quies] = new StatusQuietes(
                configuratioPuellaeStatus.Globalis,
                configuratioPuellaeStatus.Quietes,
                ostia.InputMotusLeg,
                ostia.TemporisLeg
            );

            // Ambulatio
            _status[(int)IDStatus.Ambulatio] = new StatusAmbulationis(
                configuratioPuellaeStatus.Globalis,
                configuratioPuellaeStatus.Ambulationis,
                ostia.InputMotusLeg,
                ostia.TemporisLeg,
                ostia.CameraPriLeg
            );

            // Cursus
            _status[(int)IDStatus.Cursus] = new StatusCursus(
                configuratioPuellaeStatus.Globalis,
                configuratioPuellaeStatus.Cursus,
                ostia.InputMotusLeg,
                ostia.TemporisLeg,
                ostia.CameraPriLeg
            );

            // Incumbo
            _status[(int)IDStatus.Incumbo] = new StatusIncubitus(
                configuratioPuellaeStatus.Globalis,
                configuratioPuellaeStatus.Incubitus,
                ostia.InputMotusLeg,
                ostia.TemporisLeg
            );

            // IncumboAmbulationem
            _status[(int)IDStatus.IncumboAmbulationem] = new StatusIncubitusAmbulationis(
                configuratioPuellaeStatus.Globalis,
                configuratioPuellaeStatus.IncubitusAmbulationem,
                ostia.InputMotusLeg,
                ostia.TemporisLeg,
                ostia.CameraPriLeg
            );

            for (int i = 0; i < longitudo; i++) {
                if (_status[i] == null) {
                    _osErrorumLeg.Fatal($"IDStatus {(IDStatus)i} の状態が見つかりません。FasciculusConfiguratioPuellaeStatusの設定を確認してください。");
                }
                if (_status[i].Id != (IDStatus)i) {
                    _osErrorumLeg.Fatal($"IDStatus {(IDStatus)i} の状態が一致しません。FasciculusConfiguratioPuellaeStatusの設定を確認してください。");
                }
            }
        }

        public IStatusCorporis Lego(IDStatus idStatus) => _status[(int)idStatus];
    }
}
