using System;
using Animancer;
using Yulinti.Dux.ContractusDucis;
using Yulinti.Nucleus;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class MinisteriumCivisAnimationes : IMinisteriumPulsabilis {
        private readonly TabulaCivis _tabulaCivis;
        private readonly TabulaCivisAnimationumContinuata _tabulaContinuata;
        private readonly NewLuditorAnimationis[,] _luditoris;
        private readonly bool[] _estActivum;

        public MinisteriumCivisAnimationes(TabulaCivis tabulaCivis, IConfiguratioCivisAnimationis config) {
            _tabulaCivis = tabulaCivis;

            int longitudo = _tabulaCivis.Longitudo;
            _luditoris = new NewLuditorAnimationis[longitudo, Enum.GetValues(typeof(IDCivisAnimationisStratum)).Length];
            _estActivum = new bool[longitudo];
            _tabulaContinuata = new TabulaCivisAnimationumContinuata(config.Animationes);

            for (int id = 0; id < longitudo; id++) {
                _tabulaCivis.PonoAdInitium(id, (id) => Initio(id));
            }
        }

        private void Initio(int id) {
            NihilAut<IAnchoraCivis> anchora = _tabulaCivis.Lego(id);
            AnimancerComponent animancer = anchora.Evolvo(IDErrorum.MINISTERIUMCIVISANIMATIONES_CONSTUCT_BEFORE_ANCHORA_INITIALIZATION)
                                           .Animancer;

            for (int i = 0; i < Enum.GetValues(typeof(IDCivisAnimationisStratum)).Length; i++) {
                if (i == (int)IDCivisAnimationisStratum.Fundamentum) {
                    // Fundamentum層は永続化する。かつ、Stratum0。
                    _luditoris[id, i] = new NewLuditorAnimationis(animancer, i, true, true);
                } else {
                    _luditoris[id, i] = new NewLuditorAnimationis(animancer, i);
                }
            }
            _estActivum[id] = true;
        }

        public void Purgere(int id) {
            for (int i = 0; i < Enum.GetValues(typeof(IDCivisAnimationisStratum)).Length; i++) {
                _luditoris[id, i].Purgere();
            }
        }

        public int[] IDs => _tabulaCivis.IDs;
        public int Longitudo => _tabulaCivis.Longitudo;

        public bool EstActivum(int id) {
            if (!_tabulaCivis.ConareLego(id, out IAnchoraCivis anchora)) return false;
            if (!anchora.EstActivum) return false;
            return _estActivum[id];
        }

        public void Postulare(
            int id,
            IDCivisAnimationisContinuata idContinuata,
            Action adInitium = null, Action adFinem = null
        ) {
            if (!EstActivum(id)) return;
            IAnimatioCivisContinuata animatio = _tabulaContinuata.Lego(idContinuata);
            animatio.PonoAdInitium(adInitium);
            animatio.PonoAdFinem(adFinem);

            IDCivisAnimationisStratum stratum = animatio.Stratum;
            VasculumAnimationis[] animationes = animatio.Animationes;
            _luditoris[id, (int)stratum].Postulare(animationes);
        }

        public void Cogere(
            int id,
            IDCivisAnimationisContinuata idContinuata,
            Action adInitium = null, Action adFinem = null
        ) {
            if (!EstActivum(id)) return;
            IAnimatioCivisContinuata animatio = _tabulaContinuata.Lego(idContinuata);
            animatio.PonoAdInitium(adInitium);
            animatio.PonoAdFinem(adFinem);

            IDCivisAnimationisStratum stratum = animatio.Stratum;
            VasculumAnimationis[] animationes = animatio.Animationes;
            _luditoris[id, (int)stratum].Cogere(animationes);
        }

        public void InjicereVelocitatem(int id, float vel) {
            if (!EstActivum(id)) return;
            for (int i = 0; i < Enum.GetValues(typeof(IDCivisAnimationisStratum)).Length; i++) {
                _luditoris[id, i].InjicereVelocitatem(vel);
            }
        }

        public void TemporareLuditores(int id) {
            if (!EstActivum(id)) return;
            // ファンダメンタル層は0固定としてくれ。
            float tempusFundamenti = _luditoris[id, 0].LegoTempusSimulataneum();
            for (int i = 1; i < Enum.GetValues(typeof(IDCivisAnimationisStratum)).Length; i++) {
                _luditoris[id, i].PonoTempusSimulataneum(tempusFundamenti);
            }
        }

        public void Pulsus() {
            for (int id = 0; id < _tabulaCivis.Longitudo; id++) { 
                if (!EstActivum(id)) continue;
                // まずFundamentum層のPulsusを実行する。これはTemporareLuditores同期のため。
                _luditoris[id, 0].Pulsus();
                TemporareLuditores(id);
                for (int i = 1; i < Enum.GetValues(typeof(IDCivisAnimationisStratum)).Length; i++) {
                    _luditoris[id, i].Pulsus();
                }
            }
        }
    }
}