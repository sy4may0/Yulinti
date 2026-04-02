using System;
using System.Collections.Generic;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;
using Yulinti.Officia.Contractus;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.Officia.Ministeria {
    internal sealed class FormarumPuellae {
        private readonly Dictionary<IDPuellaeFormae, FormaPuellae> _formae;

        public FormarumPuellae(
            TabulaRedittorPuellaeFigurae tabulaFigurae,
            TabulaRedittorPuellaeOssisCorrectorium tabulaOssa,
            IConfiguratioPuellaeFormarum config
        ) {
            _formae = new Dictionary<IDPuellaeFormae, FormaPuellae>();

            foreach (var figurae in config.Figurae) {
                if (!_formae.ContainsKey(figurae.Forma)) {
                    _formae[figurae.Forma] = new FormaPuellae(figurae.Forma);
                }
                _formae[figurae.Forma].AddereFigurae(figurae, tabulaFigurae);
            }

            foreach (var ossis in config.Ossa) {
                if (!_formae.ContainsKey(ossis.Forma)) {
                    _formae[ossis.Forma] = new FormaPuellae(ossis.Forma);
                }
                _formae[ossis.Forma].AddereOssa(ossis, tabulaOssa);
            }

            var nomina = Enum.GetNames(typeof(IDPuellaeFormae));
            for (int i = 1; i < nomina.Length; i++) {
                if (nomina[i] == "Nihil") {
                    continue;
                }
                var forma = (IDPuellaeFormae)i;
                if (!_formae.ContainsKey(forma)) {
                    Carnifex.Error(LogTextus.FormarumPuellae_FORMARUMPUELLAE_FORMA_NOT_FOUND);
                }
            }
        }

        public void Applicare(IDPuellaeFormae forma, float ratio) {
            if (_formae.TryGetValue(forma, out var formaPuellae)) {
                formaPuellae.Applicare(ratio);
            }
        }
    }
}
