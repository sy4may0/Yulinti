using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;


namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ExecutorPuellaeFigurae : IExecutorPuellae {
        private readonly IOstiumPuellaeFiguraeGenusMutabile _ostiumPuellaeFiguraeGenusMutabile;
        private readonly IOstiumPuellaeFiguraePelvisMutabile _ostiumPuellaeFiguraePelvisMutabile;

        private Ordo<IOrdinatioPuellaeFiguraeGenus> _queueFiguraeGenus;
        private Ordo<IOrdinatioPuellaeFiguraePelvis> _queueFiguraePelvis;

        public ExecutorPuellaeFigurae(
            IOstiumPuellaeFiguraeGenusMutabile ostiumPuellaeFiguraeGenusMutabile,
            IOstiumPuellaeFiguraePelvisMutabile ostiumPuellaeFiguraePelvisMutabile
        ) {
            _ostiumPuellaeFiguraeGenusMutabile = ostiumPuellaeFiguraeGenusMutabile;
            _ostiumPuellaeFiguraePelvisMutabile = ostiumPuellaeFiguraePelvisMutabile;
            _queueFiguraeGenus = new Ordo<IOrdinatioPuellaeFiguraeGenus>(
                ConstansPuellae.LongitudoOrdinatioFiguraeGenus
            );
            _queueFiguraePelvis = new Ordo<IOrdinatioPuellaeFiguraePelvis>(
                ConstansPuellae.LongitudoOrdinatioFiguraePelvis
            );
        }

        public void Initare() {
            _queueFiguraeGenus.Purgere();
            _queueFiguraePelvis.Purgere();
        }

        public void Primum() {
            _queueFiguraeGenus.Purgere();
            _queueFiguraePelvis.Purgere();
        }

        public void Executare(
            IOrdinatioPuellaeFiguraeGenus genus
        ) {
            if (!_queueFiguraeGenus.ConarePono(genus)) {
                Notarius.Memorare(LogTextus.ExecutorPuellaeFigurae_MINIATERIUMPUELLAEFIGURA_GENUS_ORDINATIO_QUEUE_FULL);
                return;
            }
        }
        public void Executare(
            IOrdinatioPuellaeFiguraePelvis pelvis
        ) {
            if (!_queueFiguraePelvis.ConarePono(pelvis)) {
                Notarius.Memorare(LogTextus.ExecutorPuellaeFigurae_MINIATERIUMPUELLAEFIGURA_PELVIS_ORDINATIO_QUEUE_FULL);
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