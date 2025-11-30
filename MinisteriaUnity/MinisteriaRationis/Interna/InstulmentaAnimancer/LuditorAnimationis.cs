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
                Errorum.Fatal(IDErrorum.LUDITORANIMATIONIS_LAYER_NOT_FOUND);
            }
            _indexusLuditoris = indexusLuditoris;
            _animatioCurrens = null;
            _fInvocanda = Invocanda;
        }

        public int IndexusLuditoris => _indexusLuditoris;
        public IStructuraAnimationis AnimatioCurrens => _animatioCurrens;
        public bool EstImpeditivus => AnimatioCurrens?.EstImpeditivus ?? false;

        // EstPostulans: 隕∵ｱゆｸｭ縲・
        // EstImpeditivus: 蜀咲函Block - 隕∵ｱゅ・縺ｮ繧縺後√さ繝ｼ繝ｫ繝舌ャ繧ｯ繧堤ｽｮ縺・※Current邨ゆｺ・ｒ蠕・▽縲・
        // EstObsignatus: 隕∵ｱ・lock - 隕∵ｱゅｒ諡貞凄縺吶ｋ縲ゅさ繝ｼ繝ｫ繝舌ャ繧ｯ險ｭ鄂ｮ蠕後↓繧ｳ繝ｼ繝ｫ繝舌ャ繧ｯ繧偵Ο繝・け縲・
        // EstCogens: 蠑ｷ蛻ｶ縲！mpeditivus/Obsignatus繧堤┌隕悶☆繧九・

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
            // Request縺檎┌縺代ｌ縺ｰ菴輔ｂ縺励↑縺・・
            if (!_estPostulans) {
                return;
            }

            // Request縺靴urrent縺ｨ蜷後§蝣ｴ蜷医√さ繝ｼ繝ｫ繝舌ャ繧ｯ繧貞ｮ溯｡後＠縺ｦ繝ｪ繧ｯ繧ｨ繧ｹ繝亥・逅・・
            if (ReferenceEquals(_animatioPostulata, _animatioCurrens)) {
                _fInvocandaPostulata?.Invoke();
                PurgarePetitionem();
                return;
            }

            // 蠑ｷ蛻ｶStop隕∵ｱ・
            if (_estDesinens) {
                Desinere();
                return;
            }


            // 蠑ｷ蛻ｶPlay隕∵ｱ・
            if (_estCogens) {
                TractarePetitionem();
                return;
            }

            // 髱槫ｼｷ蛻ｶPlay隕∵ｱゅ°縺､Current縺沓locking(Impeditivus)
            if (EstImpeditivus) {
                AnimancerState currentState = _animancerLayer.CurrentState;
                if (currentState == null) {
                    TractarePetitionem();
                    return;
                }
                if (currentState.Events(this, out AnimancerEvent.Sequence events)) {
                    // 繝ｫ繝ｼ繝励°縺､Blocking縺ｯ辟｡縺・・縺壹□縺後∝ｿｵ縺ｮ縺溘ａ縲・
                    if (!_animatioCurrens.EstCircularis) {
                        events.OnEnd = _fInvocanda;
                    } else {
                        Memorator.MemorareErrorum(IDErrorum.LUDITORANIMATIONIS_FOUND_BLOCKING_AND_LOOPING);
                    }
                }
                return;
            }

            // 髱槫ｼｷ蛻ｶPlay縺九▽Blocking縺ｧ縺ｪ縺・
            TractarePetitionem();
        }

        private void TractarePetitionem() {
            PurgareInvocandamCurrens();
            // RequestAnimatio縺悟ｭ伜惠縺励↑縺・ｴ蜷医∝●豁｢縲・
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


