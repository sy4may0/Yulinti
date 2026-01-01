using Yulinti.Dux.ContractusDucis;
using System.Numerics;

namespace Yulinti.Dux.Exercitus {
    internal sealed class MotorPuellaeActionis {
        private readonly IOstiumPuellaeLociMutabile _ostiumPuellaeLociMutabile;
        private readonly IOstiumPuellaeLociNavmeshMutabile _ostiumPuellaeLociNavmeshMutabile;
        private readonly ContextusPuellaeOstiorumLegibile _contextusOstiorum;

        private SpeciesOrdinationisPuellae? _speciesActualis = null;

        // IOstiumPuellaeNavmeshMutabileを追加
        // IOstiumPuellaeNavmeshLegibileを追加


        public MotorPuellaeActionis(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IOstiumPuellaeLociMutabile ostiumPuellaeLociMutabile,
            IOstiumPuellaeLociNavmeshMutabile ostiumPuellaeLociNavmeshMutabile
        ) {
            _ostiumPuellaeLociMutabile = ostiumPuellaeLociMutabile;
            _ostiumPuellaeLociNavmeshMutabile = ostiumPuellaeLociNavmeshMutabile;
            _contextusOstiorum = contextusOstiorum;
        }

        public void ApplicareActionis(
            OrdinatioPuellaeActionis ordinatio
        ) {
            ordinatio.Match(
                ApplicareMotus,
                ApplicareNavmesh
            );
            _speciesActualis = ordinatio.Species;
        }

        private void ApplicareMotus(
            OrdinatioPuellaeMotus motus
        ) {
            if (_speciesActualis != SpeciesOrdinationisPuellae.Motus) {
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
            if (_speciesActualis != SpeciesOrdinationisPuellae.Navmesh) {
                IntrareNavmesh();
            }
            // OstiumPuellaeNavmesh実装後に追加。
        }

        private void IntrareMotus() {
            Vector3 positio = _contextusOstiorum.LociNavmesh.Positio();
            Quaternion rotatio = _contextusOstiorum.LociNavmesh.Rotatio();

            _ostiumPuellaeLociNavmeshMutabile.Deactivare();
            _ostiumPuellaeLociMutabile.Activare();

            _ostiumPuellaeLociMutabile.PonoPositionemCoacte(positio);
            _ostiumPuellaeLociMutabile.PonoRotationemCoacte(rotatio);
        }

        private void IntrareNavmesh() {
            Vector3 positio = _contextusOstiorum.Loci.Positio;
            Quaternion rotatio = _contextusOstiorum.Loci.Rotatio;
            _ostiumPuellaeLociMutabile.Deactivare();
            _ostiumPuellaeLociNavmeshMutabile.Activare();
            _ostiumPuellaeLociNavmeshMutabile.Transporto(positio, rotatio);
        }

        public float VelocitasHorizontalisActualis() {
            if (_speciesActualis == SpeciesOrdinationisPuellae.Motus) {
                return _contextusOstiorum.Loci.VelHorizontalisActualis;
            }
            if (_speciesActualis == SpeciesOrdinationisPuellae.Navmesh) {
                return _contextusOstiorum.LociNavmesh.VelocitasHorizontalisActualis();
            }
            return 0f;
        }

        public float VelocitasVerticalisActualis() {
            if (_speciesActualis == SpeciesOrdinationisPuellae.Motus) {
                return _contextusOstiorum.Loci.VelVerticalisActualis;
            }
            if (_speciesActualis == SpeciesOrdinationisPuellae.Navmesh) {
                return _contextusOstiorum.LociNavmesh.VelocitasVerticalisActualis();
            }
            return 0f;
        }

        public float RotatioYActualis() {
            if (_speciesActualis == SpeciesOrdinationisPuellae.Motus) {
                return _contextusOstiorum.Loci.RotatioYActualis;
            }
            if (_speciesActualis == SpeciesOrdinationisPuellae.Navmesh) {
                return _contextusOstiorum.LociNavmesh.RotatioYActualis();
            }
            return 0f;
        }
    }
}