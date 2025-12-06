using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;
using System;

namespace Yulinti.Dux.Exercitus {
    internal sealed class TabulaPuellaeThesaurusCorporis {
        private readonly ThesaurusPuellaeStatusCorporis[] _thesauri;
        private readonly IOstiumErrorumLegibile _osErrorumLeg;

        public TabulaPuellaeThesaurusCorporis (
            IConfiguratioPuellaeStatusCorporis[] configuratioStatusCorporum,
            IOstiumErrorumLegibile osErrorumLeg
        ) {
            _osErrorumLeg = osErrorumLeg;

            int longitudo = Enum.GetValues(typeof(IDStatus)).Length;
            _thesauri = new ThesaurusPuellaeStatusCorporis[longitudo];

            foreach (IConfiguratioPuellaeStatusCorporis conf in configuratioStatusCorporum) {
                _thesauri[(int)conf.Id] = new ThesaurusPuellaeStatusCorporis(conf);
            }

            for (int i = 1; i < longitudo; i++) {
                if (_thesauri[i] == null) {
                    _osErrorumLeg.Fatal(IDErrorum.TABULASTATUUMCORPORIS_CONFIGURATIO_MISSING);
                }
            }
        }

        public ThesaurusPuellaeStatusCorporis Lego(IDStatus id) => _thesauri[(int)id];
    }
}