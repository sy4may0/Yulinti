using Yulinti.Exercitus.Contractus;
using System.Numerics;
using Yulinti.Nucleus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Exercitus.Dux {

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

        private Ordo<IOrdinatioPuellaeMotus> _queueMotus;
        private Ordo<IOrdinatioPuellaeNavmesh> _queueNavmesh;
        private Ordo<IOrdinatioPuellaeNavmeshInitii> _queueNavmeshInitii;
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

            _queueMotus = new Ordo<IOrdinatioPuellaeMotus>(ConstansPuellae.LongitudoOrdinatioMotus);
            _queueNavmesh = new Ordo<IOrdinatioPuellaeNavmesh>(ConstansPuellae.LongitudoOrdinatioNavmesh);
            _queueNavmeshInitii = new Ordo<IOrdinatioPuellaeNavmeshInitii>(ConstansPuellae.LongitudoOrdinatioNavmesh);
            _speciesActualis = SpeciesPuellaeLoci.Nihil;
        }

        public void Initare() {
            _ostiumPuellaeLociMutabile.InitareMigrare();
            _ostiumPuellaeLociMutabile.Transporto(
                new Vector3(0f, 0f, 0f),
                Quaternion.Identity
            );
            _resFluidaMotus.Purgare();
            _speciesActualis = SpeciesPuellaeLoci.Nihil;
            _queueMotus.Purgere();
            _queueNavmesh.Purgere();
            _queueNavmeshInitii.Purgere();
        }

        public void Primum() {
            _queueMotus.Purgere();
            _queueNavmesh.Purgere();
            _queueNavmeshInitii.Purgere();
        }

        public void Executare(
            IOrdinatioPuellaeMotus motus
        ) {
            if (!_queueMotus.ConarePono(motus)) {
                Notarius.Memorare(LogTextus.ExecutorPuellaeLoci_EXECUTORPUELLAELOCI_ORDINATIO_MOTUS_QUEUE_FULL);
                return;
            }
        }

        public void Executare(
            IOrdinatioPuellaeNavmesh navmesh
        ) {
            if (!_queueNavmesh.ConarePono(navmesh)) {
                Notarius.Memorare(LogTextus.ExecutorPuellaeLoci_EXECUTORPUELLAELOCI_ORDINATIO_NAVMESH_QUEUE_FULL);
                return;
            }
        }

        public void Executare(
            IOrdinatioPuellaeNavmeshInitii navmeshInitii
        ) {
            if (!_queueNavmeshInitii.ConarePono(navmeshInitii)) {
                Notarius.Memorare(LogTextus.ExecutorPuellaeLoci_EXECUTORPUELLAELOCI_ORDINATIO_NAVMESH_QUEUE_FULL);
                return;
            }
        }

        private void ApplicareMotus(
            IOrdinatioPuellaeMotus motus
        ) {
            if (motus == null) {
                Notarius.Memorare(LogTextus.ExecutorPuellaeLoci_EXECUTORPUELLAELOCI_APPLICARE_MOTUS_NULL);
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
                Notarius.Memorare(LogTextus.ExecutorPuellaeLoci_EXECUTORPUELLAELOCI_APPLICARE_NAVMESH_NULL);
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

        private void ApplicareNavmeshInitii(
            IOrdinatioPuellaeNavmeshInitii navmeshInitii
        ) {
            if (navmeshInitii == null) {
                Notarius.Memorare(LogTextus.ExecutorPuellaeLoci_EXECUTORPUELLAELOCI_APPLICARE_NAVMESH_NULL);
                return;
            }
            if (_speciesActualis != SpeciesPuellaeLoci.Navmesh) {
                _ostiumPuellaeLociMutabile.ActivareNavMesh();
                _speciesActualis = SpeciesPuellaeLoci.Navmesh;
            }
            // OrdinatioのPositioにWarpする。
            _ostiumPuellaeLociMutabile.Transporto(navmeshInitii.Positio, navmeshInitii.Rotatio);
        }

        public void Confirmare() {
            if (_queueMotus.Capacitas == 0 && _queueNavmesh.Capacitas == 0 && _queueNavmeshInitii.Capacitas == 0) return;

            while (_queueNavmeshInitii.ConareLego(out var ni)) {
                ApplicareNavmeshInitii(ni);
            }

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

            _resFluidaMotus.Renovare(
                vhActualis,
                ryActualis,
                true
            );

            _queueMotus.Purgere();
            _queueNavmesh.Purgere();
            _queueNavmeshInitii.Purgere();
        }

        public void Purgare() {
            _ostiumPuellaeLociMutabile.InitareMigrare();
            _ostiumPuellaeLociMutabile.Transporto(
                new Vector3(0f, 0f, 0f),
                Quaternion.Identity
            );
            _resFluidaMotus.Purgare();
            _speciesActualis = SpeciesPuellaeLoci.Nihil;
            _queueMotus.Purgere();
            _queueNavmesh.Purgere();
            _queueNavmeshInitii.Purgere();
        }
    }
}
