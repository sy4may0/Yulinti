using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class ResolutorCivisVeletudinis {
        private readonly ContextusCivisOstiorumLegibile _contextus;
        private readonly IOstiumCivisMutabile _ostiumCivisMut;
        private float[] _phantasmaVitae;

        public ResolutorCivisVeletudinis(
            ContextusCivisOstiorumLegibile contextus,
            IOstiumCivisMutabile ostiumCivisMut
        ) {
            _contextus = contextus;
            _ostiumCivisMut = ostiumCivisMut;
            _phantasmaVitae = new float[contextus.Civis.Longitudo];
        }


        public void InitarePhantasma(ResFluidaCivisVeletudinis resFluida) {
            for (int i = 0; i < _contextus.Civis.Longitudo; i++) {
                if (resFluida.EstDominare(i)) {
                    _phantasmaVitae[i] = resFluida.Vitae(i);
                }
            }
        }

        public void Addo(OrdinatioCivisVeletudinisValoris ordinatio) {
            _phantasmaVitae[ordinatio.IdCivis] += ordinatio.DtVitae;
        }

        // 寿命の適用
        public void Applicare(ResFluidaCivisVeletudinis resFluida) {
            for (int i = 0; i < _contextus.Civis.Longitudo; i++) {
                if (resFluida.EstDominare(i)) {
                    resFluida.RenovareVitae(i, DuxMath.Clamp(_phantasmaVitae[i], 0, 100));
                }
            }
            PurgareAll();
        }

        public void PurgareAll() {
            for (int i = 0; i < _contextus.Civis.Longitudo; i++) {
                Purgare(i);
            }
        }

        private void Purgare(int id) {
            _phantasmaVitae[id] = 100;
        }

        public void Incarnare(int id) {
            _ostiumCivisMut.Incarnare(id);
        }
        public void Spirituare(int id) {
            _ostiumCivisMut.Spirituare(id);
        }

        // Dominare/Liberareは自動的に適用される。
        public void RenovereDomina(
            ResFluidaCivisVeletudinis resFluida
        ) {
            // リカバリとして60フレームごとに1回チェックする。
            if (_contextus.Civis.EstServam || _contextus.Temporis.PulsusElapsus % 60 != 0) return;
            // ResFluidaのDominareとOstiumCivisのEstActivumを一致させる。
            for (int i = 0; i < _contextus.Civis.Longitudo; i++) {
                bool estDom = resFluida.EstDominare(i);
                bool estAct = _contextus.Civis.EstActivum(i);
                if (estDom == estAct) continue;

                if (estAct) {
                    UnityEngine.Debug.Log($"Dominare: {i}");
                    resFluida.Dominare(i);
                    Purgare(i);
                } else {
                    UnityEngine.Debug.Log($"Liberare: {i}");
                    resFluida.Liberare(i);
                    Purgare(i);
                }
            }
            _ostiumCivisMut.Servare();
        }

        public void ApplicareMors(
            OrdinatioCivisVeletudinisMortis ordinatio,
            ResFluidaCivisVeletudinis resFluida
        ) {
            if (ordinatio.EstIncarnere) {
                Incarnare(ordinatio.IdCivis);
            } else if (ordinatio.EstSpirituare) {
                Spirituare(ordinatio.IdCivis);
            }

            if (ordinatio.EstMotus) {
                resFluida.ServereMotus(ordinatio.IdCivis);
            }
        }

        public void LiberareServatum(int id, ResFluidaCivisVeletudinis resFluida) {
            resFluida.LiberareServatum(id);
        }
    }
}