using UnityEngine;
using Animancer;
using System;
using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal class LuditorAnimationis : IPulsabilis, ILuditorAnimationis {
        private readonly AnimancerLayer _animancerLayer;
        private readonly int _indexusLuditoris;
        private IStructuraAnimationis _animatioCurrens;
        private IStructuraAnimationis _animatioPostulata;
        private Action _fInvocandaPostulata;
        private bool _estPostulans;
        private bool _estCogens;
        private bool _estDesinens;
        private bool _estObsignatus; 
        private float _tempusSimultaneum;

        private readonly Action _fInvocanda;

        public LuditorAnimationis(AnimancerComponent animancer, int indexusLuditoris) {
            _animancerLayer = animancer.Layers[indexusLuditoris];
            if (_animancerLayer == null) {
                ModeratorErrorum.Fatal($"アニメーションレイヤー{indexusLuditoris}が見つかりません。");
            }
            _indexusLuditoris = indexusLuditoris;
            _animatioCurrens = null;
            _fInvocanda = Invocanda;
        }

        public int IndexusLuditoris => _indexusLuditoris;
        public IStructuraAnimationis AnimatioCurrens => _animatioCurrens;
        public bool EstImpeditivus => AnimatioCurrens?.EstImpeditivus ?? false;

        // EstPostulans: 要求中。
        // EstImpeditivus: 再生Block - 要求はのむが、コールバックを置いてCurrent終了を待つ。
        // EstObsignatus: 要求Block - 要求を拒否する。コールバック設置後にコールバックをロック。
        // EstCogens: 強制、Impeditivus/Obsignatusを無視する。

        private void ExpedirePetitionem(
            IStructuraAnimationis animatio, 
            Action fInvocanda, 
            bool estCogens=false,
            bool estObsignatus=false
        ) {
            if (!estCogens && _estObsignatus) {
                return;
            }
            _estObsignatus = estObsignatus;
            _animatioPostulata = animatio;
            _fInvocandaPostulata = fInvocanda;
            _estPostulans = true;
            _estCogens = estCogens;
        }

        public void Postulare(
            IStructuraAnimationis animatio,
            Action fInvocanda,
            bool estObsignatus=false
        ) {
            ExpedirePetitionem(animatio, fInvocanda, false, estObsignatus);
        }

        public void Cogere(
            IStructuraAnimationis animatio,
            Action fInvocanda,
            bool estObsignatus=false
        ) {
            ExpedirePetitionem(animatio, fInvocanda, true, estObsignatus);
        }

        public void CogereDesinentiam() {
            _estDesinens = true;
        }

        public void InjicereVelocitatem(float vel) {
            if (AnimatioCurrens is IVelocitasInjectibile velInjectable) {
                velInjectable.InjicereVelocitatem(vel);
            }
        }

        public void Pulsus() {
            AdministrarePetitionem();
        }

        public float LegoTempusSimultaneum() {
            return _animancerLayer.CurrentState?.NormalizedTime ?? 0f;
        }

        public void PonoTempusSimultaneum(float tempus) {
            _tempusSimultaneum = tempus;
        }

        // ======= INTERNAL METHODS =======
        private void PurgarePetitionem() {
            _fInvocandaPostulata = null;
            _animatioPostulata = null;
            _estPostulans = false;
            _estCogens = false;
            _estDesinens = false;
            _estObsignatus = false;
        }

        private void PurgareInvocandamCurrens() {
            if (_animancerLayer.CurrentState?.Events(this, out AnimancerEvent.Sequence events) ?? false) {
                events.OnEnd = null;
            }
        }

        private void Temporare(AnimancerState state) {
            if (_animatioCurrens?.EstSimultaneum ?? false) {
                state.NormalizedTime = _tempusSimultaneum;
            }
        }

        private void AdministrarePetitionem() {
            // Requestが無ければ何もしない。
            if (!_estPostulans) {
                return;
            }

            // RequestがCurrentと同じ場合、コールバックを実行してリクエスト処理。
            if (ReferenceEquals(_animatioPostulata, _animatioCurrens)) {
                _fInvocandaPostulata?.Invoke();
                PurgarePetitionem();
                return;
            }

            // 強制Stop要求
            if (_estDesinens) {
                Desinere();
                return;
            }


            // 強制Play要求
            if (_estCogens) {
                TractarePetitionem();
                return;
            }

            // 非強制Play要求かつCurrentがBlocking(Impeditivus)
            if (EstImpeditivus) {
                AnimancerState currentState = _animancerLayer.CurrentState;
                if (currentState == null) {
                    TractarePetitionem();
                    return;
                }
                if (currentState.Events(this, out AnimancerEvent.Sequence events)) {
                    // ループかつBlockingは無いはずだが、念のため。
                    if (!_animatioCurrens.EstCircularis) {
                        events.OnEnd = _fInvocanda;
                    } else {
                        Memorator.MemorareLuditorAnimationisCircularisImpeditivus(_animatioCurrens);
                    }
                }
                return;
            }

            // 非強制PlayかつBlockingでない
            TractarePetitionem();
        }

        private void TractarePetitionem() {
            PurgareInvocandamCurrens();
            // RequestAnimatioが存在しない場合、停止。
            if (_animatioPostulata == null) {
                Desinere();
                return; 
            }
            _animatioCurrens = _animatioPostulata;
            AnimancerState state = _animancerLayer.Play(_animatioCurrens.Animatio, _animatioCurrens.TempusEvanescentiae);
            _animancerLayer.FadeGroup.SetEasing(_animatioCurrens.Lenitio);
            _fInvocandaPostulata?.Invoke();
            Temporare(state);
            PurgarePetitionem();
        }

        private void Desinere() {
            PurgareInvocandamCurrens();
            if (_animatioCurrens == null) {
                PurgarePetitionem();
                return;
            }
            _animancerLayer.StartFade(0f, _animatioCurrens.TempusEvanescentiae);
            _animancerLayer.FadeGroup.SetEasing(_animatioCurrens.Lenitio);
            _fInvocandaPostulata?.Invoke();
            _animatioCurrens = null;
            PurgarePetitionem();
        }

        private void Invocanda() {
            AdministrarePetitionem();
        }
    }
}
