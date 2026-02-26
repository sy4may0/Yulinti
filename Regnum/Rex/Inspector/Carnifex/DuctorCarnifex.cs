using System;
using System.Collections.Concurrent;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Regnum.Rex {
    public class DuctorCarnifex : IIncipabilis, ILiberabilis {
        private readonly CarnifexVelum _carnifexVelum;
        private readonly CarnifexBasis _carnifexBasis;
    
        private readonly ConcurrentQueue<string> _queueNotati = new();
        private readonly SemaphoreSlim _semaphoreNotati = new(0, int.MaxValue);
    
        // ワーカーが起動済みかガード
        private int _istOperariusNotati = 0;
    
        private readonly CancellationTokenSource _cts = new();
    
        public DuctorCarnifex(CarnifexVelum carnifexVelum, CarnifexBasis carnifexBasis) {
            _carnifexVelum = carnifexVelum;
            _carnifexBasis = carnifexBasis;
        }

        public void Incipere() {
            IncipereOperariusNotati(); // ここで常駐ワーカーを起動
        }
    
        private void IncipereOperariusNotati() {
            if (Interlocked.CompareExchange(ref _istOperariusNotati, 1, 0) != 0)
                return;
    
            IterareOperariusNotati(_cts.Token).Forget();
        }
    
        private async UniTaskVoid IterareOperariusNotati(CancellationToken ct) {
            try {
                while (!ct.IsCancellationRequested) {
                    // キューが空(セマフォが0)なら完全にOperariusはおねんねする。
                    await _semaphoreNotati.WaitAsync(ct).AsUniTask();
    
                    // semaphore = Notatre1通知。キューから１つ取って処理する。
                    if (_queueNotati.TryDequeue(out var textus)) {
                        await DemittereNotati(textus, ct);
                    }
                }
            }
            catch (OperationCanceledException) {
                // 終了
            }
            catch (ObjectDisposedException) {
                // 終了(Liberare()が呼ばれた)
            }
            catch (Exception e) {
                _carnifexBasis.Error(e);
            }
            finally {
                Interlocked.Exchange(ref _istOperariusNotati, 0);
            }
        }
    
   
        private async UniTask DemittereNotati(string textus, CancellationToken ct) {
            try {
                await UniTask.SwitchToMainThread(ct);
                _carnifexVelum.DemittereNotati(textus);
    
                await UniTask.Delay(TimeSpan.FromSeconds(ConstansCarnifex.TempusDemittereNotati), cancellationToken: ct);
    
                await UniTask.SwitchToMainThread(ct);
                _carnifexVelum.TollereNotati();
            }
            catch (OperationCanceledException) { }
            catch (Exception e) { _carnifexBasis.Error(e); }
        }

        public void Notare(string textus) {
            // Velum未起動であればBasisに通知する。
            if (!_carnifexVelum.EstActivum) {
                _carnifexBasis.Notare(textus);
                return;
            }

            _queueNotati.Enqueue(textus);
    
            // 追加シグナル（セマフォを1増やす）
            _semaphoreNotati.Release();
        }
 
    
        public void Liberare() {
            _cts.Cancel();
            _cts.Dispose();
            _semaphoreNotati.Dispose();
        }
    }
}