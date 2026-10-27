using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus;
using System;
using Yulinti.Officia.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Officia.Ministeria {
    internal sealed class TabulaPuellaeCrinisCollectionis {
        private readonly IConfiguratioPuellaeCrinisCollectionisAnterior[] _anterior;
        private readonly IConfiguratioPuellaeCrinisCollectionisPosterior[] _posterior;

        public TabulaPuellaeCrinisCollectionis(IConfiguratioPuellaeCrinisCollectionis configuratio) {
            int longitudoAnterior = Enum.GetValues(typeof(IDPuellaeCrinisCollectionisAnterior)).Length;
            _anterior = new IConfiguratioPuellaeCrinisCollectionisAnterior[longitudoAnterior];

            IConfiguratioPuellaeCrinisCollectionisAnterior[] anterior = configuratio.Anterior;
            for (int i = 0; i < anterior.Length; i++) {
                IConfiguratioPuellaeCrinisCollectionisAnterior c = anterior[i];
                if (c == null) {
                    Carnifex.Intermissio(LogTextus.TabulaPuellaeCrinisCollectionis_TABULAPUELLAECRINISCOLLECTIONIS_ID_NOT_FOUND);
                }
                _anterior[(int)c.IDPuellaeCrinisCollectionisAnterior] = c;
            }

            for (int i = 0; i < longitudoAnterior; i++) {
                if ((IDPuellaeCrinisCollectionisAnterior)i == IDPuellaeCrinisCollectionisAnterior.Nihil) {
                    continue;
                }
                if (_anterior[i] == null) {
                    Carnifex.Intermissio(LogTextus.TabulaPuellaeCrinisCollectionis_TABULAPUELLAECRINISCOLLECTIONIS_ID_NOT_FOUND);
                }
            }

            int longitudoPosterior = Enum.GetValues(typeof(IDPuellaeCrinisCollectionisPosterior)).Length;
            _posterior = new IConfiguratioPuellaeCrinisCollectionisPosterior[longitudoPosterior];

            IConfiguratioPuellaeCrinisCollectionisPosterior[] posterior = configuratio.Posterior;
            for (int i = 0; i < posterior.Length; i++) {
                IConfiguratioPuellaeCrinisCollectionisPosterior c = posterior[i];
                if (c == null) {
                    Carnifex.Intermissio(LogTextus.TabulaPuellaeCrinisCollectionis_TABULAPUELLAECRINISCOLLECTIONIS_ID_NOT_FOUND);
                }
                _posterior[(int)c.IDPuellaeCrinisCollectionisPosterior] = c;
            }

            for (int i = 0; i < longitudoPosterior; i++) {
                if ((IDPuellaeCrinisCollectionisPosterior)i == IDPuellaeCrinisCollectionisPosterior.Nihil) {
                    continue;
                }
                if (_posterior[i] == null) {
                    Carnifex.Intermissio(LogTextus.TabulaPuellaeCrinisCollectionis_TABULAPUELLAECRINISCOLLECTIONIS_ID_NOT_FOUND);
                }
            }
        }

        public IConfiguratioPuellaeCrinisCollectionisAnterior Lego(IDPuellaeCrinisCollectionisAnterior idCrinis) => _anterior[(int)idCrinis];

        public IConfiguratioPuellaeCrinisCollectionisPosterior Lego(IDPuellaeCrinisCollectionisPosterior idCrinis) => _posterior[(int)idCrinis];
    }
}
