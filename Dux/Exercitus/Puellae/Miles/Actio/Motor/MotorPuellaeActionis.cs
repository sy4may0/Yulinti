using Yulinti.Dux.ContractusDucis;
using System.Numerics;

namespace Yulinti.Dux.Exercitus {
    internal sealed class MotorPuellaeActionis {
        private readonly IOstiumPuellaeLociMutabile _ostiumPuellaeLociMutabile;
        private readonly ContextusPuellaeOstiorumLegibile _contextusOstiorum;

        private SpeciesOrdinationisPuellae? _speciesActualis = null;

        private bool _estInNavmesh = true;

        public MotorPuellaeActionis(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IOstiumPuellaeLociMutabile ostiumPuellaeLociMutabile
        ) {
            _ostiumPuellaeLociMutabile = ostiumPuellaeLociMutabile;
            _contextusOstiorum = contextusOstiorum;
        }

        public void ApplicareActionis(
            in OrdinatioPuellaeActionis ordinatio
        ) {
            ordinatio.Match(
                motus => ApplicareMotus(motus),
                navmesh => ApplicareNavmesh(navmesh)
            );
            _speciesActualis = ordinatio.Species;
        }

        // 垂直移動は対象外のため無視する。
        private void ApplicareMotus(
            in OrdinatioPuellaeMotus motus
        ) {
            if (_speciesActualis != SpeciesOrdinationisPuellae.Motus) {
                IntrareMotus();
            }
            _ostiumPuellaeLociMutabile.Moto(
                motus.Horizontalis.Velocitas,
                motus.Horizontalis.TempusLevigatum,
                motus.RotationisY.RotatioY,
                motus.RotationisY.TempusLevigatum,
                _contextusOstiorum.Temporis.Intervallum
            );
            _estInNavmesh = true;
        }

        private void ApplicareNavmesh(
            in OrdinatioPuellaeNavmesh navmesh
        ) {
            if (_speciesActualis != SpeciesOrdinationisPuellae.Navmesh) {
                IntrareNavmesh();
            }
            _ostiumPuellaeLociMutabile.InitareMigrare();
            _ostiumPuellaeLociMutabile.IncipereMigrare(navmesh.Positio);
            _ostiumPuellaeLociMutabile.PonoVelocitatem(navmesh.VelocitasDesiderata);
            _ostiumPuellaeLociMutabile.PonoAccelerationem(navmesh.Acceleratio);
            _ostiumPuellaeLociMutabile.PonoVelocitatemRotationis((int)navmesh.VelocitasRotationis);
            _ostiumPuellaeLociMutabile.PonoDistantiaDeaccelerationis(navmesh.DistantiaDeaccelerationis);
        }

        private void IntrareMotus() {
            _ostiumPuellaeLociMutabile.ActivareMotus();
        }

        private void IntrareNavmesh() {
            _estInNavmesh = _ostiumPuellaeLociMutabile.ActivareNavMesh();
        }

        public bool EstInNavmesh() {
            return _estInNavmesh;
        }

        public float VelocitasHorizontalisActualis() {
            if (_speciesActualis == SpeciesOrdinationisPuellae.Motus) {
                return _contextusOstiorum.Loci.VelocitasHorizontalisActualis();
            }
            if (_speciesActualis == SpeciesOrdinationisPuellae.Navmesh) {
                return _contextusOstiorum.Loci.VelocitasHorizontalisActualis();
            }
            return 0f;
        }

        public float VelocitasVerticalisActualis() {
            if (_speciesActualis == SpeciesOrdinationisPuellae.Motus) {
                return 0f;
            }
            if (_speciesActualis == SpeciesOrdinationisPuellae.Navmesh) {
                return 0f;
            }
            return 0f;
        }

        public float RotatioYActualis() {
            if (_speciesActualis == SpeciesOrdinationisPuellae.Motus) {
                return _contextusOstiorum.Loci.RotatioYActualis();
            }
            if (_speciesActualis == SpeciesOrdinationisPuellae.Navmesh) {
                return _contextusOstiorum.Loci.RotatioYActualis();
            }
            return 0f;
        }

    }
}
