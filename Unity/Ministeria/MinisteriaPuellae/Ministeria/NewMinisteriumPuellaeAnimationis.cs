using System;
using Yulinti.Exercitus.Contractus;
using Yulinti.Unity.Contractus;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;

namespace Yulinti.Unity.Ministeria {
    public sealed class NewMinisteriumPuellaeAnimationis : IMinisteriumPulsabilis {
        private readonly NewTabulaPuellaeAnimationum _tabulaPuellaeAnimationum;
        private readonly LusorAnimationis[] _lusoris;
        private readonly int _longitudoStratum;

        public NewMinisteriumPuellaeAnimationis(
            NewIConfiguratioPuellaeAnimationum config,
            IAnchoraPuellae anchora
        ) {
            _tabulaPuellaeAnimationum = new NewTabulaPuellaeAnimationum(config.Animationes);
            _longitudoStratum = Enum.GetValues(typeof(IDPuellaeAnimationisStratum)).Length;
            _lusoris = new LusorAnimationis[_longitudoStratum];

            for (int i = 0; i < _longitudoStratum; i++) {
                if (i == (int)IDPuellaeAnimationisStratum.Fundamentum) {
                    // Fundamentum層は永続化する。
                    _lusoris[i] = new LusorAnimationis(anchora.Animancer, i, true);
                } else {
                    _lusoris[i] = new LusorAnimationis(anchora.Animancer, i);
                }
            }
        }

        public bool EstExhibens(IDPuellaeAnimationisStratum stratum) {
            return _lusoris[(int)stratum].StatusLusoris != IDStatusLusoris.Nihil;
        }
        public bool EstDesinens(IDPuellaeAnimationisStratum stratum) {
            return _lusoris[(int)stratum].StatusLusoris == IDStatusLusoris.Nihil;
        }
        public bool EstExhibensIterans(IDPuellaeAnimationisStratum stratum) {
            return _lusoris[(int)stratum].StatusLusoris == IDStatusLusoris.Iterans;
        }

        public void Exhibere(IDPuellaeAnimationisStratum stratum, NewIDPuellaeAnimationis id) {
            // Nihilはアニメーション無し指定とする仕様。(Desinereと同義)
            if (id == NewIDPuellaeAnimationis.Nihil) {
                Desinere(stratum);
                return;
            }

            OnusAnimationis onusAnimationis = 
                _tabulaPuellaeAnimationum.Legere(id);

            if (onusAnimationis == null) {
                Notarius.Memorare(LogTextus.MinisteriumPuellaeAnimationes_MINISTERIUMPUELLAEANIMATIONES_ANIMATION_NOT_SET);
                return;
            }

            _lusoris[(int)stratum].Exhibere(
                onusAnimationis
            );
        }

        public void Desinere(IDPuellaeAnimationisStratum stratum) {
            _lusoris[(int)stratum].Desinere();
        }

        public void InjicereVelocitatem(float vel) {
            foreach (LusorAnimationis lusor in _lusoris) {
                lusor.InjicereVelocitatem(vel);
            }
        }

        public void Purgere(IDPuellaeAnimationisStratum stratum) {
            _lusoris[(int)stratum].Purgere();
        }

        // Pulsusで時刻同期を実行する。
        public void Pulsus() {
            float tempusFundamenti = _lusoris[
                (int)IDPuellaeAnimationisStratum.Fundamentum
            ].LegereSimulataneum();

            for (int i = 0; i < _longitudoStratum; i++) {
                if (i == (int)IDPuellaeAnimationisStratum.Fundamentum) continue;
                _lusoris[i].ContemporareLusor(tempusFundamenti);
            }
        }
    }
}