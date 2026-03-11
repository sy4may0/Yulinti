using VContainer.Unity;
using System;
using Yulinti.Officia.Contractus;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Auctoritas.Contractus;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Imperium.Praefectus {
    public sealed class PraefectusPraetorioRadicis: IStartable, ITickable, ILateTickable, IDisposable {
        // Root Orchestrator
        // 実行順は以下を守ること。
        // 1. MonsAltus
        // 2. Orator
        // 3. Senator

        private IOratorRadicis _orator;
        private IMonsAltus _monsAltus;
        private ISenatorRadicis _senator;

        public PraefectusPraetorioRadicis(
            IOratorRadicis orator,
            IMonsAltus monsAltus,
            ISenatorRadicis senator
        ) {
            _orator = orator;
            _monsAltus = monsAltus;
            _senator = senator;
        }

        public void Start() {
            _monsAltus.Incipere();
            _orator.Incipere();
            _senator.Incipere();
        }

        public void Tick() {
            _monsAltus.Pulsus();
        }

        public void FixedTick() {
            _monsAltus.PulsusFixus();
        }

        public void LateTick() {
            _monsAltus.PulsusTardus();
        }

        // _monsAltusは最優先のため、Disposeでは最後に呼ぶ。
        public void Dispose() {
            _orator.Liberare();
            _senator.Liberare();
            _monsAltus.Liberare();
        }
    }
}