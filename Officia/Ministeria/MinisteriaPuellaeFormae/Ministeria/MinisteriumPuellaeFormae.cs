using System;
using Yulinti.Officia.Contractus;   
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.Officia.Ministeria {
    internal sealed class MinisteriumPuellaeFormae: IMinisteriumPulsabilisTardus {
        private readonly FormarumPuellae _formarumPuellae;
        private readonly float[] _ratioActualis;

        public MinisteriumPuellaeFormae(
            IConfiguratioPuellaeFormarum config,
            IAnchoraPuellae anchora
        ) {
            _formarumPuellae = new FormarumPuellae(
                new TabulaRedittorPuellaeFigurae(anchora),
                new TabulaRedittorPuellaeOssisCorrectorium(anchora),
                config
            );

            int longitudo = Enum.GetValues(typeof(IDPuellaeFormae)).Length;
            _ratioActualis = new float[longitudo];

            for (int i = 0; i < longitudo; i++) {
                if (i == (int)IDPuellaeFormae.Nihil) {
                    continue;
                }
                _ratioActualis[i] = 0.5f;
            }
        }

        public void Renovare(IDPuellaeFormae forma, float ratio) {
            if (forma == IDPuellaeFormae.Nihil) return;
            _ratioActualis[(int)forma] = ratio;
        }

        public float RatioActualis(IDPuellaeFormae forma) {
            if (forma == IDPuellaeFormae.Nihil) return 0.5f;
            return _ratioActualis[(int)forma];
        }

        public void PulsusTardus() {
            for (int i = 0; i < _ratioActualis.Length; i++) {
                if (i == (int)IDPuellaeFormae.Nihil) continue;
                _formarumPuellae.Applicare((IDPuellaeFormae)i, _ratioActualis[i]);
            }
        }
    }
}