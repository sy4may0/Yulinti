using System;
using Yulinti.Officia.Contractus;   
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.Officia.Ministeria {
    internal sealed class MinisteriumPuellaeFormae  {
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
                _ratioActualis[i] = -1f;
            }
        }

        public void Renovare(IDPuellaeFormae forma, float ratio) {
            if (forma == IDPuellaeFormae.Nihil) return;
            _ratioActualis[(int)forma] = ratio;
            _formarumPuellae.Applicare(forma, ratio);
        }

        public float RatioActualis(IDPuellaeFormae forma) {
            if (forma == IDPuellaeFormae.Nihil) return 0.5f;
            return _ratioActualis[(int)forma];
        }
    }
}