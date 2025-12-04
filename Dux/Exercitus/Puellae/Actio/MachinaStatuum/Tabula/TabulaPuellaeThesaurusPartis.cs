using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;
using System;

namespace Yulinti.Dux.Exercitus {
    internal sealed class TabulaPuellaeThesaurusPartis {
        private readonly ThesaurusPuellaeStatusPartis[] _thesauri;
        private readonly IOstiumErrorumLegibile _osErrorumLeg;

        public TabulaPuellaeThesaurusPartis(
            IConfiguratioPuellaeStatusPartis[] configuratioStatusPartium,
            IOstiumErrorumLegibile osErrorumLeg
        ) {
            _osErrorumLeg = osErrorumLeg;

            int longitudo = Enum.GetValues(typeof(IDStatusPartis)).Length;
            _thesauri = new ThesaurusPuellaeStatusPartis[longitudo];

            foreach (IConfiguratioPuellaeStatusPartis conf in configuratioStatusPartium) {
                _thesauri[(int)conf.Id] = new ThesaurusPuellaeStatusPartis(conf);
            }

            for (int i = 1; i < longitudo; i++) {
                if (_thesauri[i] == null) {
                    _osErrorumLeg.Fatal(IDErrorum.TABULASTATUUMPARTIS_CONFIGURATIO_MISSING);
                }
            }
        }
    }
}
