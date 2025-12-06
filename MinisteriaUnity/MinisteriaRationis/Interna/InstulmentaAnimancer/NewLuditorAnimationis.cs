using System.Collections.Generic;
using Animancer;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using UnityEngine;
using Yulinti.Nucleus;
using System;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class NewLuditorAnimationis : IPulsabilis {
        private readonly AnimancerLayer _layer;
        private readonly int _indexusLuditoris;
        private VasculumAnimationis _animatioCurrens;
        private Queue<VasculumAnimationis> _animationesPostulata;
        private AnimancerState _statusCurrens;
        // 同期用時刻（アニメーションの再生位置を同期するため）
        private float _tempusSimulataneum;
        // LinearMixerTransition用速度パラメータ。
        private float _velocitas;

        public NewLuditorAnimationis(AnimancerComponent animancer, int indexusLuditoris)
        {
            _layer = animancer.Layers[indexusLuditoris];
            if (_layer == null)
            {
                Errorum.Fatal(IDErrorum.LUDITORANIMATIONIS_LAYER_NOT_FOUND);
            }
            _indexusLuditoris = indexusLuditoris;
            _animatioCurrens = null;
            // [TODO] 設定もしくはどっかのconstにする。
            _animationesPostulata = new Queue<VasculumAnimationis>(5); // Assuming a reasonable capacity
        }

        public int IndexusLuditoris => _indexusLuditoris;
        public VasculumAnimationis AnimatioCurrens => _animatioCurrens;

        // request
        public void Postulare(VasculumAnimationis[] animationes, bool estPurgare = true)
        {
            if (
                animationes == null || 
                animationes.Length == 0 ||
                (_animatioCurrens != null && _animatioCurrens.EstObsignatus)
            ) return;

            if (estPurgare) _animationesPostulata.Clear();

            if (_animationesPostulata.Count + animationes.Length >= 5) {
                return;
            }

            foreach (VasculumAnimationis anim in animationes)
            {
                _animationesPostulata.Enqueue(anim);
            }
        }

        // forceRequest
        public void Cogere(VasculumAnimationis[] animationes)
        {
            _animatioCurrens = null;
            _statusCurrens = null;
            Postulare(animationes, true);
        }

        public void PonoVelocitatem(float velocitas)
        {
            _velocitas = velocitas;
        }

        public void PonoTempusSimulataneum(float tempus)
        {
            _tempusSimulataneum = tempus;
        }

        public float LegoTempusSimulataneum() => _tempusSimulataneum;

        public void Pulsus() {
            // キューが空なら何もしない
            if (_animationesPostulata.Count == 0) {
                return;
            }

            // 現在のアニメがObsignatusなら何もしない（ロック中）
            if (_animatioCurrens != null && _animatioCurrens.EstObsignatus) {
                return;
            }

            bool deberetLudere = false;

            if (_animatioCurrens == null) {
                // 現在再生中のアニメがない → 再生開始
                deberetLudere = true;
            } else if (!_animatioCurrens.EstImpeditivus) {
                // 現在のアニメがブロッキングでない → 即座に次へ遷移可能
                deberetLudere = true;
            } else {
                // 現在のアニメがブロッキング → 再生完了を待つ
                // NormalizedTime >= 1.0 で完了とみなす（ループでない前提）
                if (_statusCurrens != null && _statusCurrens.NormalizedTime >= 1.0f) {
                    deberetLudere = true;
                }
            }

            if (deberetLudere) {
                Ludere();
            }
            InjicereVelocitatem();
            Temporare();
        }

        private void Ludere() {
            _animatioCurrens = _animationesPostulata.Dequeue();
            _animatioCurrens.AdInitium?.Invoke();
            if (_animatioCurrens.Animatio == null ) {
                Desinere();
                return;
            }
            _statusCurrens = _layer.Play(_animatioCurrens.Animatio, _animatioCurrens.TempusEvanescentiae);
            _layer.FadeGroup.SetEasing(_animatioCurrens.Lenitio);

            if (_statusCurrens.Events(this, out AnimancerEvent.Sequence events)) {
                events.OnEnd = _animatioCurrens.AdFinem;
            }

            if (_animatioCurrens.EstSimulataneum) {
                _statusCurrens.NormalizedTime = _tempusSimulataneum;
            }
        }

        private void Desinere() {
            if (_animatioCurrens != null) {
                _layer.StartFade(0f, _animatioCurrens.TempusEvanescentiae);
                _layer.FadeGroup.SetEasing(_animatioCurrens.Lenitio);
                _animatioCurrens.AdFinem?.Invoke();
            }
            _animatioCurrens = null;
            _statusCurrens = null;
        }

        private void Temporare() {
            if (_statusCurrens != null) {
                _tempusSimulataneum = _statusCurrens.NormalizedTime;
            }
        }

        private void InjicereVelocitatem() {
            if (_animatioCurrens?.Animatio is LinearMixerTransition mixer) {
                mixer.State.Parameter = _velocitas;
            }
        }
    }
}