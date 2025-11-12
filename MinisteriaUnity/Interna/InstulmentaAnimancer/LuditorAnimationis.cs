using UnityEngine;
using Animancer;
using System;
using Yulinti.MinisteriaUnity.MinisteriaNuclei;

namespace Yulinti.MinisteriaUnity.Interna.InstulmentaAnimancer {
    public class LuditorAnimationis : ILuditorAnimationis {
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
            _animatioCurrens = animatio;
            _fInvocanda = fInvocanda;
            _estPostulans = true;
            _estCogens = estCogens;
        }

        public void Postulare(
            IStructuraAnimationis animatio,
            Action fInvocanda,
            bool estObsignatus=false
        ) {
            TractarePetitionem(animatio, fInvocanda, false, estObsignatus);
        }

        public void Cogere(
            IStructuraAnimationis animatio,
            Action fInvocanda,
            bool estObsignatus=false
        ) {
            TractarePetitionem(animatio, fInvocanda, true, estObsignatus);
        }

        public void CogereDesinentiam() {
            _estDesinens = true;
        }

        public void InjicereVelocitatem(float vel) {
            if (AnimatioCurrens is IStructuraAnimationisVelInjectibile velInjectable) {
                velInjectable.InjicereVelocitatem(vel);
            }
        }

        public void Pulsus() {
            if (_estDesinens) {
                StopLayer();
                return;
            }
            if (_estCogens) {
                TractarePetitionem();
                return;
            }

            if (EstImpeditivus) {
                AnimancerState currentState = _animancerLayer.CurrentState;
                if (currentState == null) {
                    TractarePetitionem();
                    return;
                }
                if (currentState.Events(this, out AnimancerEvent.Sequence events)) {
                    events.OnEnd = _fInvocanda;
                }
                return;
            }

            TractarePetitionem();
        }

        public float LegoTempusSimultaneum() {
            return _animancerLayer.CurrentState?.NormalizedTime ?? 0f;
        }

        public void PonoTempusSimultaneum(float time) {
            _tempusSimultaneum = time;
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

        private void Temporare(AnimancerState state) {
            if (_animatioCurrens?.EstSimultaneum ?? false) {
                state.NormalizedTime = _tempusSimultaneum;
            }
        }

        private void TractarePetitionem() {
            PurgareInvocandamCurrens();
            _animatioCurrens = _animatioPostulata;
            AnimancerState state = _animancerLayer.Play(_animatioCurrens.Animatio, _animatioCurrens.TempusEvanescentiae);
            _animancerLayer.FadeGroup.SetEasing(_animatioCurrens.Lenitio);
            _fInvocandaPostulata?.Invoke();
            Temporare(state);
            PurgarePetitionem();
        }

        private void AdministrarePetitionem() {
            if (!_estPostulans) {
                return;
            }
            if (_animatioPostulata == null) {
                Desinere();
                return; 
            }
            TractarePetitionem();
        }
        private void Invocanda() {
            if (_estPostulans) {
                AdministrarePetitionem();
            } else {
                Desinere();
            }
        }
    }
}
