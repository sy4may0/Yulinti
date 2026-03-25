using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class StatusCivisCorporisNavmeshLoci : IStatusCivisCorporis {
        private readonly IConfiguratioCivisStatuum _configuratioStatuum;
        private readonly IConfiguratioCivisStatusCorporisNavmesh _configuratio;
        private readonly ContextusStatusCivisCorporis _contextus;

        public StatusCivisCorporisNavmeshLoci(
            IConfiguratioCivisStatuum configuratioStatuum,
            IConfiguratioCivisStatusCorporisNavmesh configuratio,
            ContextusStatusCivisCorporis contextus

        ) {
            _configuratioStatuum = configuratioStatuum;
            _configuratio = configuratio;
            _contextus = contextus;
        }

        public IDCivisStatusCorporis Id => _configuratio.Id;
        public IDCivisStatusCorporisModiNavmesh IdModiNavmesh => _configuratio.IdModiNavmesh;
        public IDCivisAnimationis IdAnimationisIntrare => _configuratio.IdAnimationisIntrare;
        public IDCivisAnimationis IdAnimationisTransere => _configuratio.IdAnimationisTransere;
        public IDCivisAnimationis IdAnimationisExire => _configuratio.IdAnimationisExire;

        public bool EstInterdictaIntrare => _configuratio.EstInterdictaIntrare;
        public bool EstInterdictaTransere => _configuratio.EstInterdictaTransere;
        public bool EstInterdictaExire => _configuratio.EstInterdictaExire;

        public IDCivisStatusCorporis IDStatusProximusAutomaticus => _configuratio.IDStatusProximusAutomaticus;

        public void Intrare(
            int idCivis,
            IResFluidaCivisLegibile resFluida
        ) {
            _contextus.Carrus.PostulareAnimationis(
                idCivis,
                IDCivisAnimationisStratum.Corpus,
                IdAnimationisIntrare
            );

            if (
                !_contextus.PunctumViae.ConareLegoTypumTemere(
                    _configuratio.TypusPunctumViae,
                    out IPunctumViaeLegibile punctumViae
                )
            ) {
                _contextus.Carrus.PostulareMortis(
                    idCivis,
                    SpeciesOrdinationisCivisMortis.Spirituare
                );
                return;
            }

            _contextus.Carrus.PostulareNavmesh(
                idCivis,
                punctumViae.Positio,
                false,
                _configuratio.VelocitasDesiderata,
                _configuratio.Acceleratio,
                _configuratio.VelocitasRotationis,
                _configuratio.DistantiaDeaccelerationis
            );
        }

        public void Transere(
            int idCivis,
            IResFluidaCivisLegibile resFluida
        ) {
            _contextus.Carrus.PostulareAnimationis(
                idCivis,
                IDCivisAnimationisStratum.Corpus,
                IdAnimationisTransere
            );
        }

        public void Exire(
            int idCivis,
            IResFluidaCivisLegibile resFluida
        ) {
            _contextus.Carrus.PostulareAnimationis(
                idCivis,
                IDCivisAnimationisStratum.Corpus,
                IdAnimationisExire
            );
        }

        public void Ordinare(
            int idCivis,
            IResFluidaCivisLegibile resFluida
        ) {
            // 直近のTransporto失敗時はNPCを削除する。
            if (_contextus.Loci.EstErrans(idCivis)) {
                _contextus.Carrus.PostulareMortis(
                    idCivis, SpeciesOrdinationisCivisMortis.Spirituare
                );
                return;
            }
            _contextus.Carrus.PostulareVeletudinisValoris(
                idCivis,
                dtVitae: _configuratio.ConsumptioVitae * _contextus.Temporis.Intervallum,
                dtVisus: _configuratio.Visus,
                dtAuditus: _configuratio.Auditus
            );
        }
    }
}
