using Animancer;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using System;

namespace Yulinti.Officia.Ministeria {
    public enum IDStatusLusoris {
        Semel, // 1回再生中
        Iterans, // ループ再生中
        Nihil, // 再生中ではない
    }


    public interface IOnusAnimationis {
        public ITransition Animatio { get; }
        public float TempusEvanescentiae { get; }
        public Easing.Function Lenitio { get; }
        public bool EstIterans { get; }
        public bool EstSimulataneum { get; }
    }
    

    public class OnusAnimationis : IOnusAnimationis {
        private readonly ITransition _animatio;
        // フェード時間
        private readonly float _tempusEvanescentiae;
        private readonly Easing.Function _lenitio;
        // ループ再生するかどうか
        private readonly bool _estIterans;
        // BasisStratumから時刻を同期するか。
        private readonly bool _estSimulataneum;

        public OnusAnimationis(
            ITransition animatio,
            float tempusEvanescentiae,
            Easing.Function lenitio,
            bool estIterans,
            bool estSimulataneum
        ) {
            _animatio = animatio;
            _tempusEvanescentiae = tempusEvanescentiae;
            _lenitio = lenitio;
            _estIterans = estIterans;
            _estSimulataneum = estSimulataneum;
        }

        public ITransition Animatio => _animatio;
        public float TempusEvanescentiae => _tempusEvanescentiae;
        public Easing.Function Lenitio => _lenitio;
        public bool EstIterans => _estIterans;
        public bool EstSimulataneum => _estSimulataneum;
    }


    internal sealed class LusorAnimationis {
        private readonly AnimancerLayer _layer;
        // Animancerのレイヤー番号
        private readonly int _indexusLusoris;

        // 時刻同期のソースレイヤーか
        private readonly bool _simulatrumBasis;

        // 現在再生中のアニメーション
        private IOnusAnimationis _animatioCurrens;
        // 現在再生中のアニメーションのAnimancerState
        private AnimancerState _statusCurrens;
        // AnimancerStateだと速度注入できないため、ITransitionがLinearMixerならこれでキャッシュしておく。
        private LinearMixerState _linearMixerStateC;
        // 現在の再生状態
        private IDStatusLusoris _statusLusoris;
        
        // 同期用時刻（アニメーションの再生位置を同期するため）
        private float _tempusSimulataneum;

        // アニメーション終了時のコールバック
        private readonly Action _adFinem;

        public LusorAnimationis(
            AnimancerComponent animancer,
            int indexusLusoris,
            bool simulatrumBasis = false
        ) {
            if (animancer == null) {
                Carnifex.Intermissio(LogTextus.LusorAnimationis_LUSORANIMATIONIS_ANIMANCER_NULL);
            }
            if (indexusLusoris < 0) {
                Carnifex.Intermissio(LogTextus.LusorAnimationis_LUSORANIMATIONIS_INDEXUS_LUSORIS_OUT_OF_RANGE);
            }
            _layer = animancer.Layers[indexusLusoris];
            _indexusLusoris = indexusLusoris;

            _animatioCurrens = null;
            _statusCurrens = null;
            _linearMixerStateC = null;
            _tempusSimulataneum = 0f;
            _simulatrumBasis = simulatrumBasis;

            _statusLusoris = IDStatusLusoris.Nihil;

            // ループでないアニメーション終了時に_statusCurrensをnullにする。
            _adFinem = AdAnimationemFinem;
        }


        public int IndexusLusoris => _indexusLusoris;
        public IDStatusLusoris StatusLusoris => _statusLusoris;
        public bool SimulatrumBasis => _simulatrumBasis;

        public void Purgere() {
            PurgereOnEnd();
            _layer.Stop();
            _animatioCurrens = null;
            _statusCurrens = null;
            _linearMixerStateC = null;
            _tempusSimulataneum = 0f;
            _statusLusoris = IDStatusLusoris.Nihil;
        }

        public void Exhibere(
            IOnusAnimationis onus
        ) {
            if (onus == null) {
                Notarius.Memorare(LogTextus.LusorAnimationis_LUSORANIMATIONIS_ONUS_NULL);
                return;
            }
            // 同じITransitionがすでに再生中なら、何もしない。
            if (
                _animatioCurrens != null && 
                ReferenceEquals(_animatioCurrens.Animatio, onus.Animatio)
            ) {
                return;
            }

            PurgereOnEnd();

            _animatioCurrens = onus;

            _statusCurrens = _layer.Play(_animatioCurrens.Animatio, onus.TempusEvanescentiae);
            if (_statusCurrens == null) {
                Notarius.Memorare(LogTextus.LusorAnimationis_LUSORANIMATIONIS_PLAY_ANIMATION_FAILED);
                Purgere();
                return;
            }
            _layer.FadeGroup.SetEasing(onus.Lenitio);
            if (onus.EstSimulataneum) {
                Temporare();
            }
            ServareLinierMixerC();

            if (onus.EstIterans) {
                _statusLusoris = IDStatusLusoris.Iterans;
            } else {
                if (_statusCurrens.Events(this, out AnimancerEvent.Sequence events)) {
                    events.Add(
                        Animancer.AnimancerEvent.AlmostOne,
                        _adFinem
                    );
                }
                _statusLusoris = IDStatusLusoris.Semel;
            }
        }

        public void Desinere() {
            // _adFinemが動いた場合再生あり(アニメーションの終了フレームが再生状態)で_statusCurrensがnullになる。
            // だからここで_statusCurrensがnullであることをガードすると、_adFinemの最終フレーム再生を止められない。
            // よって、ここではガードしないでそのまんまStartFadeを呼ぶ。おそらくこのメソッドは冪等だから大丈夫だろ。
            // ガードするならLayerからステートを再取得して、アニメーションが存在しないか確認する。やり方は知らねぇよ。
            float tempusEvanescentiae = 0.3f;
            Easing.Function lenitio = Easing.Function.CubicInOut;

            if (_animatioCurrens != null) {
                tempusEvanescentiae = _animatioCurrens.TempusEvanescentiae;
                lenitio = _animatioCurrens.Lenitio;
            }

            // Basisは停止できない。
            if (_simulatrumBasis) {
                Notarius.Memorare(LogTextus.LusorAnimationis_LUSORANIMATIONIS_BASE_STOP_NOT_ALLOWED);
                return;
            }

            PurgereOnEnd();

            _layer.StartFade(0f, tempusEvanescentiae);
            _layer.FadeGroup.SetEasing(lenitio);

            _animatioCurrens = null;
            _statusCurrens = null;
            _linearMixerStateC = null;

            _statusLusoris = IDStatusLusoris.Nihil;
        }

        private void Temporare() {
            // Basisは_statusCurrens.NormalizeTimeを変更しない。
            if (_statusCurrens != null && !_simulatrumBasis) {
                _statusCurrens.NormalizedTime = _tempusSimulataneum;
            }
        }

        // LinierMixerのキャッシュを更新する。
        private void ServareLinierMixerC() {
            if (_statusCurrens != null && _statusCurrens is LinearMixerState linearMixerState) {
                _linearMixerStateC = linearMixerState;
            } else {
                _linearMixerStateC = null;
            }
        }

        public void InjicereVelocitatem(float velocitas) {
            if (_linearMixerStateC != null) {
                _linearMixerStateC.Parameter = velocitas;
            }
        }

        public void ContemporareLusor(float tempus) {
            if (_simulatrumBasis) {
                Notarius.Memorare(LogTextus.LusorAnimationis_LUSORANIMATIONIS_BASE_CONTEMPORARE_NOT_ALLOWED);
                return;
            }
            _tempusSimulataneum = tempus;
        }

        public float LegereSimulataneum() {
            if (!_simulatrumBasis) {
                Notarius.Memorare(LogTextus.LusorAnimationis_LUSORANIMATIONIS_LEGERE_SIMULATANEUM_ALLOWED_ONLY_BASE);
                return 0f;
            }
            return _statusCurrens?.NormalizedTime ?? 0f;
        }

        private void AdAnimationemFinem() {
            PurgereOnEnd();
            _animatioCurrens = null;
            _statusCurrens = null;
            _linearMixerStateC = null;
            _statusLusoris = IDStatusLusoris.Nihil;
        }

        private void PurgereOnEnd() {
            if (_statusCurrens != null && _statusCurrens.Events(this, out AnimancerEvent.Sequence events)) {
                if (events.OnEnd == _adFinem) {
                    events.OnEnd = null;
                }
            }
        }
    }
}