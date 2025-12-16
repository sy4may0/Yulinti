using System;
using Animancer;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class MinisteriumCivisAnimationes : IMinisteriumPulsabilis {
        private readonly TabulaCivisAnimationumContinuata _tabulaContinuata;
        private readonly NewLuditorAnimationis[] _luditoris;

        public MinisteriumCivisAnimationes(IConfiguratioCivisAnimationis config, IAnchoraCivis anchora) {
            AnimancerComponent animancer = anchora.Animancer;
            _tabulaContinuata = new TabulaCivisAnimationumContinuata(config.Animationes);
            _luditoris = new NewLuditorAnimationis[Enum.GetValues(typeof(IDCivisAnimationisStratum)).Length];
            for (int i = 0; i < Enum.GetValues(typeof(IDCivisAnimationisStratum)).Length; i++) {
                if (i == (int)IDCivisAnimationisStratum.Fundamentum) {
                    // Fundamentum層は永続化する。かつ、Stratum0。
                    _luditoris[i] = new NewLuditorAnimationis(animancer, i, true, true);
                } else {
                    _luditoris[i] = new NewLuditorAnimationis(animancer, i);
                }
            }
        }

        public void Postulare(
            IDCivisAnimationisContinuata idContinuata,
            Action adInitium = null, Action adFinem = null
        ) {
            IAnimatioCivisContinuata animatio = _tabulaContinuata.Lego(idContinuata);
            animatio.PonoAdInitium(adInitium);
            animatio.PonoAdFinem(adFinem);

            IDCivisAnimationisStratum stratum = animatio.Stratum;
            VasculumAnimationis[] animationes = animatio.Animationes;
            _luditoris[(int)stratum].Postulare(animationes);
        }

        public void Cogere(
            IDCivisAnimationisContinuata idContinuata,
            Action adInitium = null, Action adFinem = null
        ) {
            IAnimatioCivisContinuata animatio = _tabulaContinuata.Lego(idContinuata);
            animatio.PonoAdInitium(adInitium);
            animatio.PonoAdFinem(adFinem);

            IDCivisAnimationisStratum stratum = animatio.Stratum;
            VasculumAnimationis[] animationes = animatio.Animationes;
            _luditoris[(int)stratum].Cogere(animationes);
        }

        public void InjicereVelocitatem(float vel) {
            foreach (NewLuditorAnimationis luditor in _luditoris) {
                luditor.InjicereVelocitatem(vel);
            }
        }

        public void TemporareLuditores() {
            // ファンダメンタル層は0固定としてくれ。
            float tempusFundamenti = _luditoris[0].LegoTempusSimulataneum();
            for (int i = 1; i < Enum.GetValues(typeof(IDCivisAnimationisStratum)).Length; i++) {
                _luditoris[i].PonoTempusSimulataneum(tempusFundamenti);
            }
        }

        public void Pulsus() {
            // まずFundamentum層のPulsusを実行する。これはTemporareLuditores同期のため。
            _luditoris[0].Pulsus();
            TemporareLuditores();
            for (int i = 1; i < Enum.GetValues(typeof(IDCivisAnimationisStratum)).Length; i++) {
                _luditoris[i].Pulsus();
            }
        }
    }
}