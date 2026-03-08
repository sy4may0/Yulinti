using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Dux {
    internal sealed class StatusCivisCorporisMotusQuietes : IStatusCivisCorporis {
        private readonly IConfiguratioCivisStatuum _configuratioStatuum;
        private readonly IConfiguratioCivisStatusCorporisMotus _configuratio;

        public StatusCivisCorporisMotusQuietes(
            IConfiguratioCivisStatuum configuratioStatuum,
            IConfiguratioCivisStatusCorporisMotus configuratio
        ) {
            _configuratioStatuum = configuratioStatuum;
            _configuratio = configuratio;
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
            ContextusCivisOstiorumLegibile contextusOstiorum,
            IResFluidaCivisLegibile resFluida
        ) {
            contextusOstiorum.Carrus.PostulareAnimationis(
                idCivis,
                IDCivisAnimationisStratum.Corpus,
                IdAnimationisIntrare
            );
        }

        public void Transere(
            int idCivis,
            ContextusCivisOstiorumLegibile contextusOstiorum,
            IResFluidaCivisLegibile resFluida
        ) {
            contextusOstiorum.Carrus.PostulareAnimationis(
                idCivis,
                IDCivisAnimationisStratum.Corpus,
                IdAnimationisTransere
            );
        }

        public void Exire(
            int idCivis,
            ContextusCivisOstiorumLegibile contextusOstiorum,
            IResFluidaCivisLegibile resFluida
        ) {
            contextusOstiorum.Carrus.PostulareAnimationis(
                idCivis,
                IDCivisAnimationisStratum.Corpus,
                IdAnimationisExire
            );
       }

        public void Ordinare(
            int idCivis,
            ContextusCivisOstiorumLegibile contextusOstiorum,
            IResFluidaCivisLegibile resFluida
        ) {
            contextusOstiorum.Carrus.PostulareMotus(idCivis, 0f, 0f, 0f, 0f);
            contextusOstiorum.Carrus.PostulareVeletudinisValoris(
                idCivis,
                dtVitae: _configuratio.ConsumptioVitae * contextusOstiorum.Temporis.Intervallum,
                dtVisus: _configuratio.Visus,
                dtAuditus: _configuratio.Auditus
            );
        }
    }
}
