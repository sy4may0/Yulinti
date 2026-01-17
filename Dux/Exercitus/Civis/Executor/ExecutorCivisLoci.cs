using Yulinti.Dux.ContractusDucis;
using Yulinti.Nucleus;
using System.Numerics;

namespace Yulinti.Dux.Exercitus {
    internal enum SpeciesCivisLoci {
        Nihil,
        Motus,
        Navmesh
    }
    internal sealed class ExecutorCivisLoci : IExecutorCivis {
        private readonly IOstiumCivisLociLegibile _ostiumCivisLociLegibile;
        private readonly IOstiumCivisLociMutabile _ostiumCivisLociMutabile;
        private readonly IOstiumTemporisLegibile _ostiumTemporisLegibile;
        private readonly IOstiumPunctumViaeLegibile _ostiumPunctumViaeLegibile;
        private readonly ResFluidaCivisMotus _resFluidaMotus;

        private DuxQueue<IOrdinatioCivisMotus>[] _queueMotus;
        private DuxQueue<IOrdinatioCivisNavmesh>[] _queueNavmesh;
        private SpeciesCivisLoci[] _speciesActualis;

        public ExecutorCivisLoci(
            IOstiumCivisLegibile ostiumCivisLegibile,
            IOstiumCivisLociLegibile ostiumCivisLociLegibile,
            IOstiumCivisLociMutabile ostiumCivisLociMutabile,
            IOstiumTemporisLegibile ostiumTemporisLegibile,
            IOstiumPunctumViaeLegibile ostiumPunctumViaeLegibile,
            ResFluidaCivisMotus resFluidaMotus
        ) {
            _ostiumCivisLociLegibile = ostiumCivisLociLegibile;
            _ostiumCivisLociMutabile = ostiumCivisLociMutabile;
            _ostiumTemporisLegibile = ostiumTemporisLegibile;
            _ostiumPunctumViaeLegibile = ostiumPunctumViaeLegibile;
            _resFluidaMotus = resFluidaMotus;

            _queueMotus = new DuxQueue<IOrdinatioCivisMotus>[ostiumCivisLegibile.Longitudo];
            _queueNavmesh = new DuxQueue<IOrdinatioCivisNavmesh>[ostiumCivisLegibile.Longitudo];
            _speciesActualis = new SpeciesCivisLoci[ostiumCivisLegibile.Longitudo];

            for (int i = 0; i < ostiumCivisLegibile.Longitudo; i++) {
                _queueMotus[i] = new DuxQueue<IOrdinatioCivisMotus>(ConstansCivis.LongitudoOrdinatioMotus);
                _queueNavmesh[i] = new DuxQueue<IOrdinatioCivisNavmesh>(ConstansCivis.LongitudoOrdinatioNavmesh);
                _speciesActualis[i] = SpeciesCivisLoci.Nihil;
            }
        }

        // Incarnare時にこれを実行する。
        // - resFluida初期化
        // - 初期位置にTransporto
        // - Species初期化
        // - キュー初期化
        public void Initare(int idCivis) {
            _resFluidaMotus.Purgare(idCivis);
            ErrorAut<IPunctumViaeLegibile> punctumViae = _ostiumPunctumViaeLegibile.LegoNatoriumTemere();
            if (punctumViae.EstError()) {
                Memorator.MemorareErrorum(IDErrorum.EXECUTORCIVISLOCI_INITARE_TRANSPORTO_FAILED);
                return;
            }
            _ostiumCivisLociMutabile.InitareMigrare(idCivis);
            _ostiumCivisLociMutabile.Transporto(idCivis, punctumViae.Evolvo().Positio, Quaternion.Identity);
            _speciesActualis[idCivis] = SpeciesCivisLoci.Nihil;
            _queueMotus[idCivis].Purgere();
            _queueNavmesh[idCivis].Purgere();
        }

        public void Primum(int idCivis) {
            _queueMotus[idCivis].Purgere();
            _queueNavmesh[idCivis].Purgere();
        }

        public void Executare(
            int idCivis,
            IOrdinatioCivisMotus motus
        ) {
            if (!_queueMotus[idCivis].ConarePono(motus)) {
                Memorator.MemorareErrorum(IDErrorum.EXECUTORCIVISLOCI_ORDINATIO_MOTUS_QUEUE_FULL);
                return;
            }
        }

        public void Executare(
            int idCivis,
            IOrdinatioCivisNavmesh navmesh
        ) {
            if (!_queueNavmesh[idCivis].ConarePono(navmesh)) {
                Memorator.MemorareErrorum(IDErrorum.EXECUTORCIVISLOCI_ORDINATIO_NAVMESH_QUEUE_FULL);
                return;
            }
        }

        private void ApplicareMotus(
            int idCivis,
            IOrdinatioCivisMotus motus
        ) {
            if (motus == null) {
                Memorator.MemorareErrorum(IDErrorum.EXECUTORCIVISLOCI_APPLICARE_MOTUS_NULL);
                return;
            }
            if (_speciesActualis[idCivis] != SpeciesCivisLoci.Motus) {
                _ostiumCivisLociMutabile.ActivareMotus(idCivis);
                _speciesActualis[idCivis] = SpeciesCivisLoci.Motus;
            }
            _ostiumCivisLociMutabile.Moto(
                idCivis,
                motus.VelocitasHorizontalis,
                motus.TempusLevigatumHorizontalis,
                motus.RotatioYDeg,
                motus.TempusLevigatumRotationisYDeg,
                _ostiumTemporisLegibile.Intervallum
            );
        }

        private void ApplicareNavmesh(
            int idCivis,
            IOrdinatioCivisNavmesh navmesh
        ) {
            if (navmesh == null) {
                Memorator.MemorareErrorum(IDErrorum.EXECUTORCIVISLOCI_APPLICARE_NAVMESH_NULL);
                return;
            }
            if (_speciesActualis[idCivis] != SpeciesCivisLoci.Navmesh) {
                _ostiumCivisLociMutabile.ActivareNavMesh(idCivis);
                _speciesActualis[idCivis] = SpeciesCivisLoci.Navmesh;
            }
            UnityEngine.Debug.Log("IncipereMigrare: " + navmesh.Positio);
            _ostiumCivisLociMutabile.IncipereMigrare(idCivis, navmesh.Positio);
            _ostiumCivisLociMutabile.PonoVelocitatem(idCivis, navmesh.VelocitasDesiderata);
            _ostiumCivisLociMutabile.PonoAccelerationem(idCivis, navmesh.Acceleratio);
            _ostiumCivisLociMutabile.PonoVelocitatemRotationis(idCivis, (int)navmesh.VelocitasRotationis);
            _ostiumCivisLociMutabile.PonoDistantiaDeaccelerationis(idCivis, navmesh.DistantiaDeaccelerationis);
        }

        public void Confirmare(int idCivis) {
            if (_queueMotus[idCivis].Capacitas == 0 && 
                _queueNavmesh[idCivis].Capacitas == 0) return;
            // Motusを優先する。かつ、Motusは最後に投入されたOrdinatioのみ反映する。
            // 最後に投入されたMotusを取得する。
            IOrdinatioCivisMotus motus = null;
            while (_queueMotus[idCivis].ConareLego(out var m)) {
                motus = m;
            }

            if (motus != null) {
                ApplicareMotus(idCivis, motus);
            } else {
                // Motusが無い場合、Navmeshをすべて適用する。
                while (_queueNavmesh[idCivis].ConareLego(out var n)) {
                    ApplicareNavmesh(idCivis, n);
                }
            }

            float vhActualis = _ostiumCivisLociLegibile.VelocitasHorizontalisActualis(idCivis);
            float ryActualis = _ostiumCivisLociLegibile.RotatioYActualis(idCivis);

            // 移動はNavmesh平面上のみ実装しているため、垂直は計算しない。
            float vvActualis = -9.81f;
            bool estInTerra = true;
            // 

            _resFluidaMotus.Renovare(
                idCivis,
                vhActualis,
                vvActualis,
                ryActualis,
                estInTerra
            );

            _queueMotus[idCivis].Purgere();
            _queueNavmesh[idCivis].Purgere();
        }

        // Spirituare時にこれを実行する。
        // - 初期位置にTransporto(エラーの場合は0,0,0にTransporto)
        // - resFluida初期化
        // - Species初期化
        // - キュー初期化
        public void Purgare(int idCivis) {
            _ostiumCivisLociMutabile.InitareMigrare(idCivis);
            ErrorAut<IPunctumViaeLegibile> punctumViae = _ostiumPunctumViaeLegibile.LegoCrematoriumTemere();
            if (punctumViae.EstError()) {
                Memorator.MemorareErrorum(IDErrorum.EXECUTORCIVISLOCI_PURGARE_TRANSPORTO_FAILED);
                _ostiumCivisLociMutabile.Transporto(idCivis, new Vector3(0f, 0f, 0f), Quaternion.Identity);
            } else {
                _ostiumCivisLociMutabile.Transporto(idCivis, punctumViae.Evolvo().Positio, Quaternion.Identity);
            }
            _resFluidaMotus.Purgare(idCivis);
            _speciesActualis[idCivis] = SpeciesCivisLoci.Nihil;
            _queueMotus[idCivis].Purgere();
            _queueNavmesh[idCivis].Purgere();
        }
    }
}