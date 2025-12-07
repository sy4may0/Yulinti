using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class FasciculusRamiPuellaeCorporis {
        private readonly IRamusPuellaeStatusCorporis[] _rami;

        public FasciculusRamiPuellaeCorporis(RamiPuellaeCorporis ramiPuellaeCorporis) {
            _rami = new IRamusPuellaeStatusCorporis[] {
                // [Quietes Transitions to Other Statuses]
                // Quietes -> Ambulatio
                new RamusPuellaeStatusCorporis(
                    IDStatus.Quies,
                    IDStatus.Ambulatio,
                    ramiPuellaeCorporis.EstActivumMotus
                ),
                // Quietes -> Incumbo
                new RamusPuellaeStatusCorporis(
                    IDStatus.Quies,
                    IDStatus.Incumbo,
                    ramiPuellaeCorporis.EstActivumIncumbo
                ),

                // [Ambulatio Transitions to Other Statuses]
                // Ambulatio -> Quietes
                new RamusPuellaeStatusCorporis(
                    IDStatus.Ambulatio,
                    IDStatus.Quies,
                    ramiPuellaeCorporis.EstInactivumMotus
                ),
                // Ambulatio -> Cursus
                new RamusPuellaeStatusCorporis(
                    IDStatus.Ambulatio,
                    IDStatus.Cursus,
                    ramiPuellaeCorporis.EstActivumCursus
                ),
                // Ambulatio -> IncumboAmbulationem
                new RamusPuellaeStatusCorporis(
                    IDStatus.Ambulatio,
                    IDStatus.IncumboAmbulationem,
                    ramiPuellaeCorporis.EstActivumIncumbo
                ),

                // [Cursus Transitions to Other Statuses]
                // Cursus -> Ambulatio
                new RamusPuellaeStatusCorporis(
                    IDStatus.Cursus,
                    IDStatus.Ambulatio,
                    ramiPuellaeCorporis.EstInactivumCursus
                ),

                // [Incumbo Transitions to Other Statuses]
                // Incumbo -> Quietes
                new RamusPuellaeStatusCorporis(
                    IDStatus.Incumbo,
                    IDStatus.Quies,
                    ramiPuellaeCorporis.EstInactivumIncumbo
                ),
                // Incumbo -> IncumboAmbulationem
                new RamusPuellaeStatusCorporis(
                    IDStatus.Incumbo,
                    IDStatus.IncumboAmbulationem,
                    ramiPuellaeCorporis.EstActivumIncumboMotus
                ),

                // [IncumboAmbulationem Transitions to Other Statuses]
                // IncumboAmbulationem -> Incumbo
                new RamusPuellaeStatusCorporis(
                    IDStatus.IncumboAmbulationem,
                    IDStatus.Incumbo,
                    ramiPuellaeCorporis.EstInactivumIncumboMotus
                ),
                // IncumboAmbulationem -> Ambulatio
                new RamusPuellaeStatusCorporis(
                    IDStatus.IncumboAmbulationem,
                    IDStatus.Ambulatio,
                    ramiPuellaeCorporis.EstInactivumIncumbo
                )
            };
        }

        public IRamusPuellaeStatusCorporis[] Rami => _rami;
    }
}