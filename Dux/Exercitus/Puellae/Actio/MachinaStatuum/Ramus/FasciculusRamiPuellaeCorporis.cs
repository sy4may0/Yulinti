using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class FasciculusRamiPuellaeCorporis {
        private readonly IRamusPuellaeStatusCorporis[] _rami;

        public FasciculusRamiPuellaeCorporis(RamiPuellaeCorporis ramiPuellaeCorporis) {
            _rami = new IRamusPuellaeStatusCorporis[] {
                // [Quietes Transitions to Other Statuses]
                // Quietes -> Ambulatio
                new RamusPuellaeStatusCorporis(
                    IDPuellaeStatusCorporis.Quies,
                    IDPuellaeStatusCorporis.Ambulatio,
                    ramiPuellaeCorporis.EstActivumMotus
                ),
                // Quietes -> Incumbo
                new RamusPuellaeStatusCorporis(
                    IDPuellaeStatusCorporis.Quies,
                    IDPuellaeStatusCorporis.Incumbo,
                    ramiPuellaeCorporis.EstActivumIncumbo
                ),

                // [Ambulatio Transitions to Other Statuses]
                // Ambulatio -> Quietes
                new RamusPuellaeStatusCorporis(
                    IDPuellaeStatusCorporis.Ambulatio,
                    IDPuellaeStatusCorporis.Quies,
                    ramiPuellaeCorporis.EstInactivumMotus
                ),
                // Ambulatio -> Cursus
                new RamusPuellaeStatusCorporis(
                    IDPuellaeStatusCorporis.Ambulatio,
                    IDPuellaeStatusCorporis.Cursus,
                    ramiPuellaeCorporis.EstActivumCursus
                ),
                // Ambulatio -> IncumboAmbulationem
                new RamusPuellaeStatusCorporis(
                    IDPuellaeStatusCorporis.Ambulatio,
                    IDPuellaeStatusCorporis.IncumboAmbulationem,
                    ramiPuellaeCorporis.EstActivumIncumbo
                ),

                // [Cursus Transitions to Other Statuses]
                // Cursus -> Ambulatio
                new RamusPuellaeStatusCorporis(
                    IDPuellaeStatusCorporis.Cursus,
                    IDPuellaeStatusCorporis.Ambulatio,
                    ramiPuellaeCorporis.EstInactivumCursus
                ),

                // [Incumbo Transitions to Other Statuses]
                // Incumbo -> Quietes
                new RamusPuellaeStatusCorporis(
                    IDPuellaeStatusCorporis.Incumbo,
                    IDPuellaeStatusCorporis.Quies,
                    ramiPuellaeCorporis.EstInactivumIncumbo
                ),
                // Incumbo -> IncumboAmbulationem
                new RamusPuellaeStatusCorporis(
                    IDPuellaeStatusCorporis.Incumbo,
                    IDPuellaeStatusCorporis.IncumboAmbulationem,
                    ramiPuellaeCorporis.EstActivumIncumboMotus
                ),

                // [IncumboAmbulationem Transitions to Other Statuses]
                // IncumboAmbulationem -> Incumbo
                new RamusPuellaeStatusCorporis(
                    IDPuellaeStatusCorporis.IncumboAmbulationem,
                    IDPuellaeStatusCorporis.Incumbo,
                    ramiPuellaeCorporis.EstInactivumIncumboMotus
                ),
                // IncumboAmbulationem -> Ambulatio
                new RamusPuellaeStatusCorporis(
                    IDPuellaeStatusCorporis.IncumboAmbulationem,
                    IDPuellaeStatusCorporis.Ambulatio,
                    ramiPuellaeCorporis.EstInactivumIncumbo
                )
            };
        }

        public IRamusPuellaeStatusCorporis[] Rami => _rami;
    }
}