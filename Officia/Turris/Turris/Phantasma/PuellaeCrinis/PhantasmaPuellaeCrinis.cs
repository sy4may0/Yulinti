using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Officia.Contractus;

namespace Yulinti.Officia.Turris {
    internal sealed class PhantasmaPuellaeCrinis : IPhantasmaPuellaeCrinisLegibile, IPhantasmaSalsamenti {
        private readonly IConfiguratioTurrisPhantasmaeInitialis _configuratioTurrisPhantasmaeInitialis;

        private IDPuellaeCrinisCollectionisAnterior _crinisAnterior;
        private IDPuellaeCrinisCollectionisPosterior _crinisPosterior;

        public PhantasmaPuellaeCrinis(
            IConfiguratioTurrisPhantasmaeInitialis configuratioTurrisPhantasmaeInitialis
        ) {
            _configuratioTurrisPhantasmaeInitialis = configuratioTurrisPhantasmaeInitialis;
            _crinisAnterior = IDPuellaeCrinisCollectionisAnterior.Nihil;
            _crinisPosterior = IDPuellaeCrinisCollectionisPosterior.Nihil;
        }

        public IDPuellaeCrinisCollectionisAnterior CrinisAnterior { get => _crinisAnterior; }
        public IDPuellaeCrinisCollectionisPosterior CrinisPosterior { get => _crinisPosterior; }

        internal void PonoCrinisAnterior(IDPuellaeCrinisCollectionisAnterior crinisAnterior) {
            _crinisAnterior = crinisAnterior;
        }

        internal void PonoCrinisPosterior(IDPuellaeCrinisCollectionisPosterior crinisPosterior) {
            _crinisPosterior = crinisPosterior;
        }

        public void Renovare(SalsamentumDto dto) {
            _crinisAnterior = dto.PuellaeCrinis.CrinisAnterior;
            _crinisPosterior = dto.PuellaeCrinis.CrinisPosterior;
        }

        public void Imple(SalsamentumDto dto) {
            dto.PuellaeCrinis.CrinisAnterior = _crinisAnterior;
            dto.PuellaeCrinis.CrinisPosterior = _crinisPosterior;
        }

        public void Purgare() {
            _crinisAnterior = _configuratioTurrisPhantasmaeInitialis.CrinisAnteriorInitialis;
            _crinisPosterior = _configuratioTurrisPhantasmaeInitialis.CrinisPosteriorInitialis;
        }
    }
}