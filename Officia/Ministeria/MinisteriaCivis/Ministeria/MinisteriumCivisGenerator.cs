using System;
using Cysharp.Threading.Tasks;
using Yulinti.ImperiumDelegatum.Contractus;
using UnityEngine;
using Yulinti.Nucleus;
using System.Threading;
using Yulinti.Officia.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Officia.Ministeria {
    internal sealed class MinisteriumCivisGenerator : IMinisteriumIncipabilis, IMinisteriumLiberabilis {
        private readonly MinisteriumCivis _miCivis;
        private readonly IConfiguratioCivisGenerator _configuratio;
        private readonly ISignumCancellationisLegibile _signumCancellationisLegibile;
        private bool _estGenerare;
        private bool _estInitiare;

        public MinisteriumCivisGenerator(
            MinisteriumCivis miCivis,
            IConfiguratioCivisGenerator configuratio,
            ISignumCancellationisLegibile signumCancellationisLegibile
        ) {
            _miCivis = miCivis;
            _configuratio = configuratio;
            _signumCancellationisLegibile = signumCancellationisLegibile;
            _estGenerare = false;
            _estInitiare = false;
        }

        public void Incipere() {
            Initiare();
            Generare();
        }

        private void Initiare() {
            InitiareAsync().Forget();
            TempusExactumInitiareAsync().Forget();
        }

        private void Generare() {
            GenerareAsync().Forget();
        }
        
        private async UniTask InitiareAsync() {
            try {
                _estInitiare = true;
                while (_estInitiare) {
                    await UniTask.Delay(10);
                    if (_miCivis.LongitudoActivum >= _configuratio.PopulatioInitialis) {
                        break;
                    }
                    _miCivis.Incarnare(_miCivis.LegoIDIntactus());
                }
                _estInitiare = false;
            }
            catch (OperationCanceledException) { }
            catch (Exception e) {
                Notarius.Memorare(e);
            }
        }

        private async UniTask GenerareAsync() {
            try {
                _estGenerare = true;
                while (_estGenerare) {
                    int d = UnityEngine.Random.Range(
                        _configuratio.IntervallumMinimus * 1000,
                        _configuratio.IntervallumMaximus * 1000
                    );
                    await UniTask.Delay(d, cancellationToken: _signumCancellationisLegibile.Signum);
                    if (_miCivis.LongitudoActivum >= _configuratio.PopulatioMaxima) {
                        continue;
                    }
                    _miCivis.Incarnare(_miCivis.LegoIDIntactus());
                }
                _estGenerare = false;
            }
            catch (OperationCanceledException) { }
            catch (Exception e) {
                Notarius.Memorare(e);
            }
        }

        public void Terminare() {
            _estGenerare = false;
        }

        private async UniTask TempusExactumInitiareAsync() {
            try {
                await UniTask.Delay(30 * 1000);
                if (_estInitiare) {
                    Carnifex.Intermissio(LogTextus.MinisteriumCivisGenerator_GENERATORCIVIS_TIMEOUT_INITIARE);
                }
            }
            catch (OperationCanceledException) { }
            catch (Exception e) {
                Notarius.Memorare(e);
            }
        }

        public void Liberare() {
            Terminare();
        }
    }
}
