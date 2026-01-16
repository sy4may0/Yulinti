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

        private DuxQueue<IOrdinatioPuellaeMotus> _queueMotus;
        private DuxQueue<IOrdinatioPuellaeNavmesh> _queueNavmesh;
        private SpeciesPuellaeLoci _speciesActualis;

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

            _queueMotus = new DuxQueue<IOrdinatioPuellaeMotus>(ConstansPuellae.LongitudoOrdinatioMotus);
            _queueNavmesh = new DuxQueue<IOrdinatioPuellaeNavmesh>(ConstansPuellae.LongitudoOrdinatioNavmesh);
            _speciesActualis = SpeciesPuellaeLoci.Nihil;
        }

        public void Primum() {
            _queueMotus.Purgere();
            _queueNavmesh.Purgere();
        }

        public void Executare(
            IOrdinatioPuellaeMotus motus
        ) {
            if (!_queueMotus.ConarePono(motus)) {
                Memorator.MemorareErrorum(IDErrorum.EXECUTORPUELLAELOCI_ORDINATIO_MOTUS_QUEUE_FULL);
                return;
            }
        }

        public void Executare(
            IOrdinatioPuellaeNavmesh navmesh
        ) {
            if (!_queueNavmesh.ConarePono(navmesh)) {
                Memorator.MemorareErrorum(IDErrorum.EXECUTORPUELLAELOCI_ORDINATIO_NAVMESH_QUEUE_FULL);
                return;
            }
        }

        private void ApplicareMotus(
            IOrdinatioPuellaeMotus motus
        ) {
            if (motus == null) {
                Memorator.MemorareErrorum(IDErrorum.EXECUTORPUELLAELOCI_APPLICARE_MOTUS_NULL);
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
                Memorator.MemorareErrorum(IDErrorum.EXECUTORPUELLAELOCI_APPLICARE_NAVMESH_NULL);
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
            if (_queueMotus.Capacitas == 0 && _queueNavmesh.Capacitas == 0) return;
            // Motusを優先する。かつ、Motusは最後に投入されたOrdinatioのみ反映する。
            // 最後に投入されたMotusを取得する。
            IOrdinatioPuellaeMotus motus = null;
            while (_queueMotus.ConareLego(out var m)) {
                motus = m;
            }

            if (motus != null) {
                ApplicareMotus(motus);
            } else {
                // Motusが無い場合、Navmeshをすべて適用する。
                while (_queueNavmesh.ConareLego(out var n)) {
                    ApplicareNavmesh(n);
                }
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

            _queueMotus.Purgere();
            _queueNavmesh.Purgere();
        }

        public void Purgare() {
            _ostiumPuellaeLociMutabile.InitareMigrare();
            _ostiumPuellaeLociMutabile.Transporto(
                new Vector3(0f, 0f, 0f),
                Quaternion.Identity
            );
            _resFluidaMotus.Renovare(0f, 0f, 0f, true);
            _speciesActualis = SpeciesPuellaeLoci.Nihil;
            _queueMotus.Purgere();
            _queueNavmesh.Purgere();
        }
    }
}