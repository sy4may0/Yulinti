using Yulinti.Dux.ContractusDucis;
using System.Numerics;
using Yulinti.Nucleus;

namespace Yulinti.Dux.Exercitus {

    internal enum SpeciesPuellaeLoci {
        Nihil,
        Motus,
        Navmesh
    }

    internal sealed class ExecutorPuellaeLoci : IExecutorPuellae {
        private readonly IOstiumPuellaeLociLegibile _ostiumPuellaeLociLegibile;
        private readonly IOstiumPuellaeLociMutabile _ostiumPuellaeLociMutabile;
        private readonly IOstiumTemporisLegibile _ostiumTemporisLegibile;
        private readonly ResFluidaPuellaeMotus _resFluidaMotus;

        private IOrdinatioPuellae _ordinatioActualis;

        private SpeciesPuellaeLoci? _speciesActualis = null;

        public ExecutorPuellaeLoci(
            IOstiumPuellaeLociLegibile ostiumPuellaeLociLegibile,
            IOstiumPuellaeLociMutabile ostiumPuellaeLociMutabile,
            IOstiumTemporisLegibile ostiumTemporisLegibile,
            ResFluidaPuellaeMotus resFluidaMotus
        ) {
            _ostiumPuellaeLociLegibile = ostiumPuellaeLociLegibile;
            _ostiumPuellaeLociMutabile = ostiumPuellaeLociMutabile;
            _ostiumTemporisLegibile = ostiumTemporisLegibile;
            _resFluidaMotus = resFluidaMotus;

            _ordinatioActualis = null;
        }

        public void Primum() {
            _ordinatioActualis = null;
        }

        public void Executare(
            IOrdinatioPuellaeMotus motus
        ) {
            if (_ordinatioActualis != null) {
                Memorator.MemorareErrorum(IDErrorum.MINIATERIUMPUELLAELOCI_EXECUTARE_CALLED_MORE_THAN_ONCE);
                return;
            }
            _ordinatioActualis = motus;
        }
        public void Executare(
            IOrdinatioPuellaeNavmesh navmesh
        ) {
            if (_ordinatioActualis != null) {
                Memorator.MemorareErrorum(IDErrorum.MINIATERIUMPUELLAELOCI_EXECUTARE_CALLED_MORE_THAN_ONCE);
                return;
            }
            _ordinatioActualis = navmesh;
        }

        private void ApplicareMotus(
            IOrdinatioPuellaeMotus motus
        ) {
            if (motus == null) {
                Memorator.MemorareErrorum(IDErrorum.MINIATERIUMPUELLAELOCI_APPLICARE_MOTUS_NULL);
                return;
            }
            if (_speciesActualis != SpeciesPuellaeLoci.Motus) {
                _ostiumPuellaeLociMutabile.ActivareMotus();
                _speciesActualis = SpeciesPuellaeLoci.Motus;
            }

            _ostiumPuellaeLociMutabile.Moto(
                motus.VelocitasHorizontalis,
                motus.TempusLevigatumHorizontalis,
                motus.RotatioYDeg,
                motus.TempusLevigatumRotationisYDeg,
                _ostiumTemporisLegibile.Intervallum
            );
        }

        private void ApplicareNavmesh(
            IOrdinatioPuellaeNavmesh navmesh
        ) {
            if (navmesh == null) {
                Memorator.MemorareErrorum(IDErrorum.MINIATERIUMPUELLAELOCI_APPLICARE_NAVMESH_NULL);
                return;
            }
            if (_speciesActualis != SpeciesPuellaeLoci.Navmesh) {
                _ostiumPuellaeLociMutabile.ActivareNavMesh();
                _speciesActualis = SpeciesPuellaeLoci.Navmesh;
            }
            _ostiumPuellaeLociMutabile.IncipereMigrare(navmesh.Positio);
            _ostiumPuellaeLociMutabile.PonoVelocitatem(navmesh.VelocitasDesiderata);
            _ostiumPuellaeLociMutabile.PonoAccelerationem(navmesh.Acceleratio);
            _ostiumPuellaeLociMutabile.PonoVelocitatemRotationis((int)navmesh.VelocitasRotationis);
            _ostiumPuellaeLociMutabile.PonoDistantiaDeaccelerationis(navmesh.DistantiaDeaccelerationis);
        }

        public void Confirmare() {
            if (_ordinatioActualis == null) return;
            switch (_ordinatioActualis.Species) {
                case SpeciesOrdinatioPuellae.ActioMotus:
                    ApplicareMotus(_ordinatioActualis as IOrdinatioPuellaeMotus);
                    break;
                case SpeciesOrdinatioPuellae.ActioNavmesh:
                    ApplicareNavmesh(_ordinatioActualis as IOrdinatioPuellaeNavmesh);
                    break;
            }

            float vhActualis = _ostiumPuellaeLociLegibile.VelocitasHorizontalisActualis();
            float ryActualis = _ostiumPuellaeLociLegibile.RotatioYActualis();

            // 移動はNavmesh平面上のみ実装しているため、垂直は計算しない。
            float vvActualis = -9.81f;
            bool estInTerra = true;
            // 

            _resFluidaMotus.Renovare(
                vhActualis,
                vvActualis,
                ryActualis,
                estInTerra
            );

            _ordinatioActualis = null;
        }

        public void Purgare() {
            _ostiumPuellaeLociMutabile.InitareMigrare();
            _ostiumPuellaeLociMutabile.Transporto(
                new Vector3(0f, 0f, 0f),
                Quaternion.Identity
            );
            _resFluidaMotus.Renovare(0f, 0f, 0f, true);
            _speciesActualis = null;
            _ordinatioActualis = null;
        }
    }
}