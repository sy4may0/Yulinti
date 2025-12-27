using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class MotorPuellaeActionis {
        private readonly IOstiumPuellaeLociMutabile _ostiumPuellaeLociMutabile;
        private readonly ContextusPuellaeOstiorumLegibile _contextusOstiorum;

        private SpeciesOrdinationisPuellae? _speciesPrioris = null;

        // IOstiumPuellaeNavmeshMutabileを追加
        // IOstiumPuellaeNavmeshLegibileを追加


        public MotorPuellaeActionis(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IOstiumPuellaeLociMutabile ostiumPuellaeLociMutabile
        ) {
            _ostiumPuellaeLociMutabile = ostiumPuellaeLociMutabile;
            _contextusOstiorum = contextusOstiorum;
        }

        public void ApplicareActionis(
            OrdinatioPuellaeActionis ordinatio
        ) {
            ordinatio.Match(
                ApplicareMotus,
                ApplicareNavmesh
            );
            _speciesPrioris = ordinatio.Species;
        }

        private void ApplicareMotus(
            OrdinatioPuellaeMotus2 motus
        ) {
            if (_speciesPrioris != SpeciesOrdinationisPuellae.Motus) {
                IntrareMotus();
            }
            _ostiumPuellaeLociMutabile.Moto(
                motus.Horizontalis.Velocitas,
                motus.Horizontalis.TempusLevigatum,
                motus.Verticalis.Velocitas,
                motus.Verticalis.TempusLevigatum,
                motus.RotationisY.RotatioY,
                motus.RotationisY.TempusLevigatum,
                _contextusOstiorum.Temporis.Intervallum
            );
        }

        private void ApplicareNavmesh(
            OrdinatioPuellaeNavmesh navmesh
        ) {
            if (_speciesPrioris != SpeciesOrdinationisPuellae.Navmesh) {
                IntrareNavmesh();
            }
            // OstiumPuellaeNavmesh実装後に追加。
        }

        private void IntrareMotus() {
            // Ostium側未実装
        }

        private void IntrareNavmesh() {
            // Ostium側未実装
        }
    }
}