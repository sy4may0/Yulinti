using VContainer.Unity;
using System;
using Yulinti.Officia.Contractus;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Auctoritas.Contractus;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;

namespace Yulinti.ImperiumMaius.Praefectus {
    public sealed class PraefectusPraetorio : IStartable, ITickable, IFixedTickable, ILateTickable, IDisposable {
        // 統括Orchestrator
        // 実行順は以下を守ること。
        // 1. Orator
        // 2. Legatus
        // 3. Ministeria
        // 4. Senator
        private IOrator _orator;
        private IMinisteria _ministeria;
        private ILegatus _legatus;
        private ISenator _senator;

        public PraefectusPraetorio(
            IOrator orator,
            IMinisteria ministeria,
            ILegatus legatus,
            ISenator senator
        ) {
            _orator = orator;
            _ministeria = ministeria;
            _legatus = legatus;
            _senator = senator;
        }

        public void Start() {
            _orator.Incipere();
            _legatus.Incipere();
            _ministeria.Incipere();
            _senator.Incipere();
        }

        public void Tick() {
            _legatus.PulsusPrimum();
            _ministeria.PulsusPrimum();
            _legatus.Pulsus();
            _ministeria.Pulsus();
        }

        public void FixedTick() {
            _legatus.PulsusFixusPrimum();
            _ministeria.PulsusFixusPrimum();
            _legatus.PulsusFixus();
            _ministeria.PulsusFixus();
        }

        public void LateTick() {
            _legatus.PulsusTardusPrimum();
            _ministeria.PulsusTardusPrimum();
            _legatus.PulsusTardus();
            _ministeria.PulsusTardus();
        }

        public void Dispose() {
            try {   
                _orator.Liberare();
            } catch (Exception e) {
                Carnifex.Error(e);
            }
            try {
                _senator.Liberare();
            } catch (Exception e) {
                Carnifex.Error(e);
            }
            try {
                _legatus.Liberare();
            } catch (Exception e) {
                Carnifex.Error(e);
            }
            try {
                _ministeria.Liberare();
            } catch (Exception e) {
                Carnifex.Error(e);
            }
        }
    }
}