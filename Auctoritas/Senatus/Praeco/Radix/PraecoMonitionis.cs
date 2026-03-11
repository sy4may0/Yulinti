using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Auctoritas.Contractus;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal class OnusMonitionis {
        public string Titulus { get; }
        public string Textus { get; }
        public string ButtonIta { get; }
        public IDSonusVeli SonusIta { get; }
        public Action AdPremereIta { get; }
        public TaskCompletionSource<bool> Tcs { get; }
        public CancellationToken Ct { get; }

        public OnusMonitionis(
            string titulus,
            string textus,
            string buttonIta,
            Action adPremereIta,
            IDSonusVeli sonusIta,
            TaskCompletionSource<bool> tcs,
            CancellationToken ct
        ) {
            Titulus = titulus;
            Textus = textus;
            ButtonIta = buttonIta;
            AdPremereIta = adPremereIta;
            SonusIta = sonusIta;
            Tcs = tcs;
            Ct = ct;
        }
    }

    internal sealed class PraecoMonitionis : IPraeco, IPraecoMonitionis, IPraecoIncipabilisRadicis, IPraecoLiberabilisRadicis {
        private readonly IVelumMonitionis _velumMonitionis;
        private readonly ITurrisSoniVeli _turrisSoniVeli;

        private readonly ConcurrentQueue<OnusMonitionis> _queueMonitionis;
        private readonly SemaphoreSlim _semaphoreMonitionis;

        // ワーカー起動済みかガード
        private int _istOperariusMonitionis;

        private readonly CancellationTokenSource _cancellationTokenSource;

        // 現在ワーカーが扱っている onus（任意：ログ等に使う）
        private OnusMonitionis _onusOperarius;

        internal PraecoMonitionis(
            IVelumMonitionis velumMonitionis,
            ITurrisSoniVeli turrisSoniVeli
        ) {
            _velumMonitionis = velumMonitionis;
            _turrisSoniVeli = turrisSoniVeli;

            _queueMonitionis = new ConcurrentQueue<OnusMonitionis>();

            // キューに積まれた回数だけ起こせるように maxCount は大きく（or 省略）
            _semaphoreMonitionis = new SemaphoreSlim(0, int.MaxValue);

            _istOperariusMonitionis = 0;

            _cancellationTokenSource = new CancellationTokenSource();
            _onusOperarius = null;
        }

        public void Incipere() {
            _velumMonitionis.Initare();
            IncipereOperariusMonitionis(); // 常駐ワーカー起動
        }

        private void IncipereOperariusMonitionis() {
            if (Interlocked.CompareExchange(ref _istOperariusMonitionis, 1, 0) != 0) {
                return;
            }

            _ = IterareOperariusMonitionis(_cancellationTokenSource.Token);
        }

        private async Task IterareOperariusMonitionis(CancellationToken cancellationToken) {
            try {
                while (!cancellationToken.IsCancellationRequested) {
                    // キューが空なら完全に寝る
                    await _semaphoreMonitionis.WaitAsync(cancellationToken);

                    // 1回起きたら1件だけ処理（await で直列化されるので同時表示しない）
                    if (_queueMonitionis.TryDequeue(out OnusMonitionis onus)) {
                        await DemittereMonitionis(onus);
                    }
                }
            } catch (OperationCanceledException) {
                // キャンセルで終了
            } catch (ObjectDisposedException) {
                // Liberareが呼ばれた
            } catch (Exception e) {
                Carnifex.Intermissio(e);
            } finally {
                Interlocked.Exchange(ref _istOperariusMonitionis, 0);
            }
        }

        /// <summary>
        /// UI を表示し、ボタン押下で閉じるまで待つ。
        /// “閉じ待ち” は Semaphore ではなく TaskCompletionSource で行う。
        /// </summary>
        private async Task DemittereMonitionis(OnusMonitionis onus) {
            // ここで「閉じた」(= ボタンが押された) を待つ
            TaskCompletionSource<bool> tcs = onus.Tcs;
            using var reg = onus.Ct.Register(() => tcs.TrySetCanceled(onus.Ct));

            _onusOperarius = onus;
            int istPremere = 0;
            try {
                // ボタン押下時：ユーザーコールバックを呼んでから “閉じた” を通知
                void AdPremereItaInvolutus() {
                    if (Interlocked.Exchange(ref istPremere, 1) != 0) return;
                    try { 
                        _turrisSoniVeli.Sonare(onus.SonusIta);
                        onus.AdPremereIta?.Invoke();
                    }
                    finally { tcs.TrySetResult(true); }
                }

                // UI表示（UIスレッド制約があるなら IVelumMonitionis 側で吸収する想定）
                _velumMonitionis.DemittereMonitionis(
                    onus.Titulus, onus.Textus, onus.ButtonIta,
                    AdPremereItaInvolutus
                );

                // UIが閉じる（= 押される）まで待つ
                await tcs.Task;

            } catch (OperationCanceledException) {
                // キャンセルで終了してOK
            } catch (ObjectDisposedException) {
                // Liberareが呼ばれた
            } catch (Exception e) {
                Carnifex.Error(e);
            } finally {
                _onusOperarius = null;
                try {
                    _velumMonitionis.TollereMonitionis();
                } catch (Exception e) {
                    Carnifex.Error(e);
                }
            }
        }

        public void Demittere(
            string titulus,
            string textus,
            string buttonIta,
            IDSonusVeli sonusIta = IDSonusVeli.Submittere,
            Action adPremereIta = null
        ) {
            _ = DemittereAsync(titulus, textus, buttonIta, adPremereIta, sonusIta);
        }

        public Task DemittereAsync(
            string titulus,
            string textus,
            string buttonIta,
            Action adPremereIta = null,
            IDSonusVeli sonusIta = IDSonusVeli.Submittere,
            CancellationToken cancellationToken = default
        ) {
            // 遅延起動（Incipere を呼び忘れても動くように）
            IncipereOperariusMonitionis();

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            OnusMonitionis onus = new OnusMonitionis(
                titulus, textus, buttonIta, adPremereIta, sonusIta, tcs, cancellationToken
            );
            _queueMonitionis.Enqueue(onus);
            _semaphoreMonitionis.Release();

            return tcs.Task;
        }

        public void Liberare() {
            _cancellationTokenSource.Cancel();
            _onusOperarius?.Tcs.TrySetCanceled(_cancellationTokenSource.Token);

            while (_queueMonitionis.TryDequeue(out OnusMonitionis onus)) {
                onus.Tcs.TrySetCanceled(_cancellationTokenSource.Token);
            }
            // SemaphoreSlim は Dispose しない。ワーカーがまだ WaitAsync 内にいる可能性があり、
            // 破棄済みセマフォを参照すると ArgumentNullException が出るため。GC に任せる。
            // このやり方はDontDestroyOnLoad出発のクラスでのみやれる。シーン内で同じことが起きたら
            // SemaphoreSlimをDisposeする方法を考えるべき。
            _cancellationTokenSource.Dispose();
        }
    }
}
