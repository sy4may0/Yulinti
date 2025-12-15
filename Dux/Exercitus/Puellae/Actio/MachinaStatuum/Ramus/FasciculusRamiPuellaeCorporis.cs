using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class FasciculusRamiPuellaeCorporis {
        private readonly IRamusPuellaeStatusCorporis[] _rami;

        public FasciculusRamiPuellaeCorporis(RamiPuellaeCorporis ramiPuellaeCorporis) {
            _rami = new IRamusPuellaeStatusCorporis[] {
                // [Quietes Transitions to Other Statuses]
                // Quietes -> Ambulatio
                new RamusPuellaeStatusCorporis(
                    IDStatusCorporis.Quies,
                    IDStatusCorporis.Ambulatio,
                    ramiPuellaeCorporis.EstActivumMotus
                ),
                // Quietes -> Incumbo
                new RamusPuellaeStatusCorporis(
                    IDStatusCorporis.Quies,
                    IDStatusCorporis.Incumbo,
                    ramiPuellaeCorporis.EstActivumIncumbo
                ),

                // [Ambulatio Transitions to Other Statuses]
                // Ambulatio -> Quietes
                new RamusPuellaeStatusCorporis(
                    IDStatusCorporis.Ambulatio,
                    IDStatusCorporis.Quies,
                    ramiPuellaeCorporis.EstInactivumMotus
                ),
                // Ambulatio -> Cursus
                new RamusPuellaeStatusCorporis(
                    IDStatusCorporis.Ambulatio,
                    IDStatusCorporis.Cursus,
                    ramiPuellaeCorporis.EstActivumCursus
                ),
                // Ambulatio -> IncumboAmbulationem
                new RamusPuellaeStatusCorporis(
                    IDStatusCorporis.Ambulatio,
                    IDStatusCorporis.IncumboAmbulationem,
                    ramiPuellaeCorporis.EstActivumIncumbo
                ),

                // [Cursus Transitions to Other Statuses]
                // Cursus -> Ambulatio
                new RamusPuellaeStatusCorporis(
                    IDStatusCorporis.Cursus,
                    IDStatusCorporis.Ambulatio,
                    ramiPuellaeCorporis.EstInactivumCursus
                ),

                // [Incumbo Transitions to Other Statuses]
                // Incumbo -> Quietes
                new RamusPuellaeStatusCorporis(
                    IDStatusCorporis.Incumbo,
                    IDStatusCorporis.Quies,
                    ramiPuellaeCorporis.EstInactivumIncumbo
                ),
                // Incumbo -> IncumboAmbulationem
                new RamusPuellaeStatusCorporis(
                    IDStatusCorporis.Incumbo,
                    IDStatusCorporis.IncumboAmbulationem,
                    ramiPuellaeCorporis.EstActivumIncumboMotus
                ),

                // [IncumboAmbulationem Transitions to Other Statuses]
                // IncumboAmbulationem -> Incumbo
                new RamusPuellaeStatusCorporis(
                    IDStatusCorporis.IncumboAmbulationem,
                    IDStatusCorporis.Incumbo,
                    ramiPuellaeCorporis.EstInactivumIncumboMotus
                ),
                // IncumboAmbulationem -> Ambulatio
                new RamusPuellaeStatusCorporis(
                    IDStatusCorporis.IncumboAmbulationem,
                    IDStatusCorporis.Ambulatio,
                    ramiPuellaeCorporis.EstInactivumIncumbo
                )
            };
        }

        public IRamusPuellaeStatusCorporis[] Rami => _rami;
    }
}