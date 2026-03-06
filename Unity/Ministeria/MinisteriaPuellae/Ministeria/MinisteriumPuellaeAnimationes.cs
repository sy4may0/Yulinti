using System;
using Animancer;
using Yulinti.Exercitus.Contractus;
using Yulinti.Nucleus;
using Yulinti.Unity.Contractus;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;

namespace Yulinti.Unity.Ministeria {
    internal sealed class MinisteriumPuellaeAnimationes : IMinisteriumPulsabilis {
        private readonly TabulaPuellaeAnimationumContinuata _tabulaContinuata;
        private readonly NewLuditorAnimationis[] _luditoris;

        public MinisteriumPuellaeAnimationes(IConfiguratioPuellaeAnimationis config, IAnchoraPuellae anchora) {
            AnimancerComponent animancer = anchora.Animancer;
            _tabulaContinuata = new TabulaPuellaeAnimationumContinuata(config.Animationes);
            _luditoris = new NewLuditorAnimationis[Enum.GetValues(typeof(IDPuellaeAnimationisStratum)).Length];
            for (int i = 0; i < Enum.GetValues(typeof(IDPuellaeAnimationisStratum)).Length; i++) {
                if (i == (int)IDPuellaeAnimationisStratum.Fundamentum) {
                    // Fundamentum層は永続化する。かつ、Stratum0。
                    _luditoris[i] = new NewLuditorAnimationis(animancer, i, true, true);
                } else {
                    _luditoris[i] = new NewLuditorAnimationis(animancer, i);
                }
            }
        }

        public void Postulare(
            IDPuellaeAnimationisContinuata idContinuata,
            Action adInitium = null, Action adFinem = null
        ) {
            UnityEngine.Debug.Log($"Postulare: {idContinuata}");
            IAnimatioPuellaeContinuata animatio = _tabulaContinuata.Lego(idContinuata);
            if (animatio == null) {
                Carnifex.Error(LogTextus.MinisteriumPuellaeAnimationes_MINISTERIUMPUELLAEANIMATIONES_ANIMATION_NOT_SET);
                return;
            }
            animatio.PonoAdInitium(adInitium);
            animatio.PonoAdFinem(adFinem);

            IDPuellaeAnimationisStratum stratum = animatio.Stratum;
            VasculumAnimationis[] animationes = animatio.Animationes;
            _luditoris[(int)stratum].Postulare(animationes);
        }

        public void Cogere(
            IDPuellaeAnimationisContinuata idContinuata,
            Action adInitium = null, Action adFinem = null
        ) {
            IAnimatioPuellaeContinuata animatio = _tabulaContinuata.Lego(idContinuata);
            animatio.PonoAdInitium(adInitium);
            animatio.PonoAdFinem(adFinem);

            IDPuellaeAnimationisStratum stratum = animatio.Stratum;
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
            for (int i = 1; i < Enum.GetValues(typeof(IDPuellaeAnimationisStratum)).Length; i++) {
                _luditoris[i].PonoTempusSimulataneum(tempusFundamenti);
            }
        }

        public void Pulsus() {
            _luditoris[0].Pulsus();
            TemporareLuditores();
            for (int i = 1; i < Enum.GetValues(typeof(IDPuellaeAnimationisStratum)).Length; i++) {
                // その他の層のPulsusを実行する。
                _luditoris[i].Pulsus();
            }
        }

        public void Purgere() {
            foreach (NewLuditorAnimationis luditor in _luditoris) {
                luditor.Purgere();
            }
        }
    }
}


