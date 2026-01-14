using Yulinti.Dux.ContractusDucis;
using Yulinti.Nucleus;


namespace Yulinti.Dux.Exercitus {
    internal sealed class ExecutorPuellaeFigurae : IExecutorPuellae {
        private readonly ContextusPuellaeOstiorumLegibile _contextusOstiorum;
        private readonly IOstiumPuellaeFiguraeGenusMutabile _ostiumPuellaeFiguraeGenusMutabile;
        private readonly IOstiumPuellaeFiguraePelvisMutabile _ostiumPuellaeFiguraePelvisMutabile;

        private DuxQueue<IOrdinatioPuellaeFiguraeGenus> _queueFiguraeGenus;
        private DuxQueue<IOrdinatioPuellaeFiguraePelvis> _queueFiguraePelvis;

        private const int _queueGenusMaxima = 24;
        private const int _queuePelvisMaxima = 12;

        public ExecutorPuellaeFigurae(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IOstiumPuellaeFiguraeGenusMutabile ostiumPuellaeFiguraeGenusMutabile,
            IOstiumPuellaeFiguraePelvisMutabile ostiumPuellaeFiguraePelvisMutabile
        ) {
            _contextusOstiorum = contextusOstiorum;
            _ostiumPuellaeFiguraeGenusMutabile = ostiumPuellaeFiguraeGenusMutabile;
            _ostiumPuellaeFiguraePelvisMutabile = ostiumPuellaeFiguraePelvisMutabile;
            _queueFiguraeGenus = new DuxQueue<IOrdinatioPuellaeFiguraeGenus>(_queueGenusMaxima);
            _queueFiguraePelvis = new DuxQueue<IOrdinatioPuellaeFiguraePelvis>(_queuePelvisMaxima);
        }

        public void Primum() {
            _queueFiguraeGenus.Purgere();
            _queueFiguraePelvis.Purgere();
        }

        public void Executare(
            IOrdinatioPuellaeFiguraeGenus genus
        ) {
            if (!_queueFiguraeGenus.ConarePono(genus)) {
                Memorator.MemorareErrorum(IDErrorum.MINIATERIUMPUELLAEFIGURA_GENUS_ORDINATIO_QUEUE_FULL);
                return;
            }
        }
        public void Executare(
            IOrdinatioPuellaeFiguraePelvis pelvis
        ) {
            if (!_queueFiguraePelvis.ConarePono(pelvis)) {
                Memorator.MemorareErrorum(IDErrorum.MINIATERIUMPUELLAEFIGURA_PELVIS_ORDINATIO_QUEUE_FULL);
                return;
            }
        }

        private void ApplicareGenus() {
            while (_queueFiguraeGenus.ConareLego(out IOrdinatioPuellaeFiguraeGenus genus)) {
                if (genus.Latus == LatusPuellaeGenus.Sinistra) {
                    _ostiumPuellaeFiguraeGenusMutabile.PonoPondusSinister(genus.IdFiguraeGenus, genus.Pondus);
                } else {
                    _ostiumPuellaeFiguraeGenusMutabile.PonoPondusDexter(genus.IdFiguraeGenus, genus.Pondus);
                }
            }
        }

        private void ApplicarePelvis() {
            while (_queueFiguraePelvis.ConareLego(out IOrdinatioPuellaeFiguraePelvis pelvis)) {
                _ostiumPuellaeFiguraePelvisMutabile.PonoPondus(pelvis.IdFiguraePelvis, pelvis.Pondus);
            }
        }

        public void Confirmare() {
            ApplicareGenus();
            ApplicarePelvis();
        }

        public void Purgare() {
            _queueFiguraeGenus.Purgere();
            _queueFiguraePelvis.Purgere();
        }
    }
}