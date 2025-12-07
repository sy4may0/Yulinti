using Yulinti.Dux.ContractusDucis;
using System;

namespace Yulinti.Dux.Exercitus {
    internal sealed class TabulaPuellaeStatuumCorporis {
        private readonly IStatusPuellaeCorporis[] _statuum;

        public TabulaPuellaeStatuumCorporis(
            TabulaPuellaeThesaurusCorporis tabulaThesauri,
            IContentumOrdinatorPuellaeModi contentum,
            IOstiumPuellaeAnimationesMutabile osAnimationes
        ) {
            int longitudo = Enum.GetValues(typeof(IDStatus)).Length;
            _statuum = new IStatusPuellaeCorporis[longitudo];

            for(int i = 1; i < longitudo; i++) {
                ThesaurusPuellaeStatusCorporis thesaurus = tabulaThesauri.Lego((IDStatus)i);
                IOrdinatorPuellaeModi modus = FabricaOrdinatorPuellaeModi.Creare(
                    thesaurus.IdModusMotus, contentum
                );
                _statuum[i] = new StatusPuellaeCorporisMotus(
                    (IDStatus)i,
                    thesaurus.IdAnimationisIntrare,
                    thesaurus.IdAnimationisExire,
                    thesaurus.LudereExire,
                    modus,
                    osAnimationes
                );
            }
        }

        public IStatusPuellaeCorporis Lego(IDStatus id) {
            return _statuum[(int)id];
        }
    }
}