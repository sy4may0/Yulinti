using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class FasciculusRamiCivisCorporis {
        private readonly IRamusCivisStatusCorporis[] _rami;

        public FasciculusRamiCivisCorporis(RamiCivisCorporis ramiCivisCorporis) {
            _rami = new IRamusCivisStatusCorporis[] {
                // MigrareAmbrationem -> Suicidium
                new RamusCivisStatusCorporis(
                    IDCivisStatusCorporis.MigrareAmbrationem,
                    IDCivisStatusCorporis.Suicidium,
                    (idCivis, resFuluidaMotus) => ramiCivisCorporis.EstExhauritaVitae(idCivis, resFuluidaMotus)
                ),
                // MigrareAmbrationem -> MigrareAmbrationem
                // このステートは連続して遷移する。(毎度別WayPointを選択する)
                new RamusCivisStatusCorporis(
                    IDCivisStatusCorporis.MigrareAmbrationem,
                    IDCivisStatusCorporis.MigrareAmbrationem,
                    (idCivis, resFuluidaMotus) => ramiCivisCorporis.EstAdPerveni(idCivis, resFuluidaMotus)
                )
            };
        }

        public IRamusCivisStatusCorporis[] Rami => _rami;
    }
}