using Cysharp.Threading.Tasks;
using Yulinti.Exercitus.Contractus;
using UnityEngine;
using Yulinti.Nucleus;
using System.Threading;
using Yulinti.Unity.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Unity.Ministeria {
    internal sealed class MinisteriumCivisGenerator : IMinisteriumIncipabilis, IMinisteriumLiberabilis {
        private readonly MinisteriumCivis _miCivis;
        private readonly IConfiguratioCivisGenerator _configuratio;
        private readonly CancellationTokenSource _cancellationTokenSource;
        private bool _estGenerare;
        private bool _estInitiare;

        public MinisteriumCivisGenerator(
            MinisteriumCivis miCivis,
            IConfiguratioCivisGenerator configuratio
        ) {
            _miCivis = miCivis;
            _configuratio = configuratio;
            _cancellationTokenSource = new CancellationTokenSource();
            _estGenerare = false;
            _estInitiare = false;
        }

        public void Incipere() {
            Initiare();
            Generare();
        }

        private void Initiare() {
            InitiareAsync().Forget(e => Notarius.Memorare(e));
            TempusExactumInitiareAsync().Forget(e => Notarius.Memorare(e));
        }

        private void Generare() {
            GenerareAsync().Forget(e => Notarius.Memorare(e));
        }
        
        private async UniTask InitiareAsync() {
            _estInitiare = true;
            while (_estInitiare) {
                // 10ms
                await UniTask.Delay(10);
                if (_miCivis.LongitudoActivum >= _configuratio.PopulatioInitialis) {
                    break;
                }

                // LegoIDIntactusはエラーなら-1を返す。Incarnareは-1を無視する。
                _miCivis.Incarnare(_miCivis.LegoIDIntactus());
            }
            _estInitiare = false;
        }

        private async UniTask GenerareAsync() {
            _estGenerare = true;
            while (_estGenerare) {
                // 10ms
                int d = Random.Range(
                    _configuratio.IntervallumMinimus * 1000,
                    _configuratio.IntervallumMaximus * 1000
                );
                await UniTask.Delay(d, cancellationToken: _cancellationTokenSource.Token);
                if (_miCivis.LongitudoActivum >= _configuratio.PopulatioMaxima) {
                    continue;
                }

                // LegoIDIntactusはエラーなら-1を返す。Incarnareは-1を無視する。
                _miCivis.Incarnare(_miCivis.LegoIDIntactus());
            }
            _estGenerare = false;
        }

        public void Terminare() {
            _estGenerare = false;
            _cancellationTokenSource.Cancel();
        }

        private async UniTask TempusExactumInitiareAsync() {
            await UniTask.Delay(30 * 1000);
            if (_estInitiare) {
                Carnifex.Intermissio(LogTextus.MinisteriumCivisGenerator_GENERATORCIVIS_TIMEOUT_INITIARE);
            }
        }

        public void Liberare() {
            Terminare();
        }
    }
}