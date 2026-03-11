using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Auctoritas.Contractus;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal class OnusConfirmationis {
        public string Titulus { get; }
        public string Textus { get; }
        public string ButtonIta { get; }
        public string ButtonNon { get; }
        public IDSonusVeli SonusIta { get; }
        public IDSonusVeli SonusNon { get; }
        public Action AdPremereIta { get; }
        public Action AdPremereNon { get; }

        public TaskCompletionSource<bool> Tcs { get; }
        public CancellationToken Ct { get; }

        public OnusConfirmationis(
            string titulus,
            string textus,
            string buttonIta,
            string buttonNon,
            Action adPremereIta,
            Action adPremereNon,
            IDSonusVeli sonusIta,
            IDSonusVeli sonusNon,
            TaskCompletionSource<bool> tcs,
            CancellationToken ct
        ) {
            Titulus = titulus;
            Textus = textus;
            ButtonIta = buttonIta;
            ButtonNon = buttonNon;
            AdPremereIta = adPremereIta;
            AdPremereNon = adPremereNon;
            SonusIta = sonusIta;
            SonusNon = sonusNon;
            Tcs = tcs;
            Ct = ct;
        }
    }

    internal sealed class PraecoConfirmationis : IPraeco, IPraecoConfirmationis, IPraecoIncipabilisRadicis, IPraecoLiberabilisRadicis {
        private readonly IVelumConfirmationis _velumConfirmationis;
        private readonly ITurrisSoniVeli _turrisSoniVeli;

        private readonly ConcurrentQueue<OnusConfirmationis> _queueConfirmationis;
        private readonly SemaphoreSlim _semaphoreConfirmationis;

        // ワーカー起動済みかガード
        private int _istOperariusConfirmationis;

        private readonly CancellationTokenSource _cancellationTokenSource;

        // 現在ワーカーが扱っている onus（任意：ログ等に使う）
        private OnusConfirmationis _onusOperarius;

        internal PraecoConfirmationis(
            IVelumConfirmationis velumConfirmationis,
            ITurrisSoniVeli turrisSoniVeli
        ) {
            _velumConfirmationis = velumConfirmationis;
            _turrisSoniVeli = turrisSoniVeli;

            _queueConfirmationis = new ConcurrentQueue<OnusConfirmationis>();

            // キューに積まれた回数だけ起こせるように maxCount は大きく（or 省略）
            _semaphoreConfirmationis = new SemaphoreSlim(0, int.MaxValue);

            _istOperariusConfirmationis = 0;

            _cancellationTokenSource = new CancellationTokenSource();
            _onusOperarius = null;
        }

        public void Incipere() {
            _velumConfirmationis.Initare();
            IncipereOperariusConfirmationis(); // 常駐ワーカー起動
        }

        private void IncipereOperariusConfirmationis() {
            if (Interlocked.CompareExchange(ref _istOperariusConfirmationis, 1, 0) != 0) {
                return;
            }
            _ = IterareOperariusConfirmationis(_cancellationTokenSource.Token);
        }

        private async Task IterareOperariusConfirmationis(CancellationToken cancellationToken) {
            try {
                while (!cancellationToken.IsCancellationRequested) {
                    // キューが空なら完全に寝る
                    await _semaphoreConfirmationis.WaitAsync(cancellationToken);

                    // 1回起きたら1件だけ処理（await で直列化されるので同時表示しない）
                    if (_queueConfirmationis.TryDequeue(out OnusConfirmationis onus)) {
                        await DemittereConfirmationis(onus);
                    }
                }
            } catch (OperationCanceledException) {
                // キャンセルで終了
            } catch (ObjectDisposedException) {
                // Liberareが呼ばれた
            } catch (Exception e) {
                Carnifex.Intermissio(e);
            } finally {
                Interlocked.Exchange(ref _istOperariusConfirmationis, 0);
            }
        }

        /// <summary>
        /// UI を表示し、ボタン押下で閉じるまで待つ。
        /// “閉じ待ち” は Semaphore ではなく TaskCompletionSource で行う。
        /// </summary>
        private async Task DemittereConfirmationis(OnusConfirmationis onus) {
            // ここで「閉じた」(= どちらか押された) を待つ
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

                void AdPremereNonInvolutus() {
                    if (Interlocked.Exchange(ref istPremere, 1) != 0) return;
                    try { 
                        _turrisSoniVeli.Sonare(onus.SonusNon);
                        onus.AdPremereNon?.Invoke();
                    }
                    finally { tcs.TrySetResult(false); }
                }

                // UI表示（UIスレッド制約があるなら IVelumConfirmationis 側で吸収する想定）
                _velumConfirmationis.DemittereConfirmationis(
                    onus.Titulus, onus.Textus, onus.ButtonIta, onus.ButtonNon,
                    AdPremereItaInvolutus,
                    AdPremereNonInvolutus
                );

                // UIが閉じる（= どちらか押される）まで待つ
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
                    _velumConfirmationis.TollereConfirmationis();
                } catch (Exception e) {
                    Carnifex.Error(e);
                }
            }
        }

        // DemittereとDemittereAsyncの作りの考え。
        // Demittereは実行後に処理をForgetする。同期関数から実行する。
        // この時、Confirmの結果を撮りたい場合はActionを渡す。
        // DemittereAsyncは実行後に処理を返す。非同期関数から実行する。
        // Actionは入れてもいいが、そのままawaitでDemittereを待って、結果のboolで処理したほうが良い。

        public void Demittere(
            string titulus,
            string textus,
            string buttonIta,
            string buttonNon,
            Action adPremereIta = null,
            Action adPremereNon = null,
            IDSonusVeli sonusIta = IDSonusVeli.Submittere,
            IDSonusVeli sonusNon = IDSonusVeli.Exire,
            CancellationToken cancellationToken = default
        ) {
            _ = DemittereAsync(
                titulus, textus, buttonIta, buttonNon, 
                adPremereIta, adPremereNon, 
                sonusIta, sonusNon,
                cancellationToken
            );
        }

        public Task<bool> DemittereAsync(
            string titulus,
            string textus,
            string buttonIta,
            string buttonNon,
            Action adPremereIta = null,
            Action adPremereNon = null,
            IDSonusVeli sonusIta = IDSonusVeli.Submittere,
            IDSonusVeli sonusNon = IDSonusVeli.Exire,
            CancellationToken cancellationToken = default
        ) {
            // 遅延起動 (Incipere を呼び忘れても動くように)
            IncipereOperariusConfirmationis();

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            OnusConfirmationis onus = new OnusConfirmationis(
                titulus, textus, buttonIta, buttonNon, 
                adPremereIta, adPremereNon, 
                sonusIta, sonusNon,
                tcs, cancellationToken
            );
            _queueConfirmationis.Enqueue(onus);
            _semaphoreConfirmationis.Release();

            return tcs.Task;
        }

        public void Liberare() {
            _cancellationTokenSource.Cancel();
            _onusOperarius?.Tcs.TrySetCanceled(_cancellationTokenSource.Token);

            while (_queueConfirmationis.TryDequeue(out OnusConfirmationis onus)) {
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