using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class StatusCivisCorporisMotusQuietes : IStatusCivisCorporis {
        private readonly IConfiguratioCivisStatuum _configuratioStatuum;
        private readonly IConfiguratioCivisStatusCorporisMotus _configuratio;
        private readonly ContextusStatusCivisCorporis _contextus;

        public StatusCivisCorporisMotusQuietes(
            IConfiguratioCivisStatuum configuratioStatuum,
            IConfiguratioCivisStatusCorporisMotus configuratio,
            ContextusStatusCivisCorporis contextus
        ) {
            _configuratioStatuum = configuratioStatuum;
            _configuratio = configuratio;
            _contextus = contextus;
        }

        public IDCivisStatusCorporis Id => _configuratio.Id;
        public IDCivisStatusCorporisModiMotus IdModiMotus => _configuratio.IdModiMotus;
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
            _contextus.Carrus.PostulareMotus(idCivis, 0f, 0f, 0f, 0f);
            _contextus.Carrus.PostulareVeletudinisValoris(
                idCivis,
                dtVitae: _configuratio.ConsumptioVitae * _contextus.Temporis.Intervallum,
                dtVisus: _configuratio.Visus,
                dtAuditus: _configuratio.Auditus
            );
        }
    }
}
