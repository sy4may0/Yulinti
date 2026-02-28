using Yulinti.Exercitus.Contractus;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Yulinti.Exercitus.Dux {
    internal sealed class LegatusSalsamenti : ILegatus, ILegatusIncipabilis, ILegatusLiberabilis {
        private readonly ITurrisMundus _turrisMundus;
        private readonly IVelumSalsamenti _velumSalsamenti;
        private readonly ILegatusConfirmationis _legatusConfirmationis;
        private readonly ITurrisInterpretationis _turrisInterpretationis;
        private readonly ITurrisSalsamenti _turrisSalsamenti;

        private CancellationTokenSource _cancellationTokenSource;

        // Dux -> Velumへのコールバック
        private Action<Guid> _aeAdPremereOneraLudum;
        private Action<Guid> _aeAdPremereDeletoLudum;
        private Action _aeAdPremereExi;

        // Demittereで受け取り、Tollereで実行する、画面クローズ時のコールバック。
        private Action _adReditum;

        private bool _estProcessusButton;

        public LegatusSalsamenti(
            ITurrisMundus turrisMundus,
            IVelumSalsamenti velumSalsamenti,
            ITurrisSalsamenti turrisSalsamenti,
            ILegatusConfirmationis legatusConfirmationis,
            ITurrisInterpretationis turrisInterpretationis
        ) {
            _turrisMundus = turrisMundus;
            _velumSalsamenti = velumSalsamenti;
            _turrisSalsamenti = turrisSalsamenti;
            _legatusConfirmationis = legatusConfirmationis;
            _turrisInterpretationis = turrisInterpretationis;

            _aeAdPremereOneraLudum = AdPremereOneraLudum;
            _aeAdPremereDeletoLudum = AdPremereDeletoLudum;
            _aeAdPremereExi = AdPremereExi;

            _adReditum = null;
        }

        public void Incipere() {
            _velumSalsamenti.Initare();
            Tollere();
        }

        public async Task Demittere(Action adReditum) {
            InitareCancellationToken();
            try {
                // UIを表示
                _velumSalsamenti.DemittereSalsamenti();

                _velumSalsamenti.AdPremereOneraLudum(_aeAdPremereOneraLudum);
                _velumSalsamenti.AdPremereDeletoLudum(_aeAdPremereDeletoLudum);
                _velumSalsamenti.AdPremereExi(_aeAdPremereExi);

                CancellationToken cancellationToken = _cancellationTokenSource.Token;
                // Notitiaをロード
                IReadOnlyList<IOstiumSalsamentiNotitiae> notitiaManualis = 
                    await _turrisSalsamenti.ArcessereNotitiamManualem(cancellationToken);
                IReadOnlyList<IOstiumSalsamentiNotitiae> notitiaAutomaticus = 
                    await _turrisSalsamenti.ArcessereNotitiamAutomaticam(cancellationToken);

                // UIにNotitiaを表示
                _velumSalsamenti.RenovareTablaeManualis(notitiaManualis);
                _velumSalsamenti.RenovareTablaeAutomaticus(notitiaAutomaticus);
            } catch (OperationCanceledException) {
                //キャンセルしてよい。何もしない。
            } catch (Exception e) {
                Carnifex.Intermissio(e);
            } finally {
                _adReditum = adReditum;
            }
        }

        public void Tollere() {
            InterrumpereCancellationToken();
            _velumSalsamenti.TollereSalsamenti();
            _adReditum?.Invoke();
            _adReditum = null;
        }

        private void AdPremereOneraLudum(Guid id) {
            _ = PremereOneraLudum(id);
        }

        private async Task PremereOneraLudum(Guid id) {
            if (!ConariIncipereProcessumButton()) {
                return;
            }

            try {
                if (!ConariAcquirereCancellationToken(out CancellationToken cancellationToken)) {
                    return;
                }

                await _turrisSalsamenti.Arcessere(id, cancellationToken);
                _turrisMundus.AdMudum(IDMundi.MundusTestScene);
            } catch (OperationCanceledException) {
                //キャンセルしてよい。何もしない。
            } catch (Exception e) {
                Carnifex.Intermissio(e);
            } finally {
                FinireProcessumButton();
            }
        }

        private void AdPremereDeletoLudum(Guid id) {
            _ = PremereDeletoLudum(id);
        }

        private async Task PremereDeletoLudum(Guid id) {
            if (!ConariIncipereProcessumButton()) {
                return;
            }
            try {
                if (!ConariAcquirereCancellationToken(out CancellationToken cancellationToken)) {
                    return;
                }
                bool estConfirmationis = await _legatusConfirmationis.DemittereAsync(
                    _turrisInterpretationis.LegoTextus(IDTextus.SALSAMENTUM_DELETO_CONFIRMATIONIS_TITULUS),
                    _turrisInterpretationis.LegoTextus(IDTextus.SALSAMENTUM_DELETO_CONFIRMATIONIS_TEXTUS),
                    _turrisInterpretationis.LegoTextus(IDTextus.SALSAMENTUM_DELETO_CONFIRMATIONIS_BUTTON_ITA),
                    _turrisInterpretationis.LegoTextus(IDTextus.SALSAMENTUM_DELETO_CONFIRMATIONIS_BUTTON_NON),
                    null,
                    null,
                    cancellationToken
                );

                if (!estConfirmationis) {
                    return;
                }

                await _turrisSalsamenti.Deleto(id, cancellationToken);
                // リストをリロード
                IReadOnlyList<IOstiumSalsamentiNotitiae> notitiaManualis = 
                    await _turrisSalsamenti.ArcessereNotitiamManualem(cancellationToken);
                IReadOnlyList<IOstiumSalsamentiNotitiae> notitiaAutomaticus = 
                    await _turrisSalsamenti.ArcessereNotitiamAutomaticam(cancellationToken);
                _velumSalsamenti.RenovareTablaeManualis(notitiaManualis);
                _velumSalsamenti.RenovareTablaeAutomaticus(notitiaAutomaticus);

            } catch (OperationCanceledException) {
                //キャンセルしてよい。何もしない。
            } catch (Exception e) {
                Carnifex.Intermissio(e);
            } finally {
                FinireProcessumButton();
                UnityEngine.Debug.Log("PremereDeletoLudum: FinireProcessumButton");
            }
        }

        private void AdPremereExi() {
            PremereExi();
        }

        private void PremereExi() {
            if (!ConariIncipereProcessumButton()) {
                return;
            }
            try {
            } catch (Exception e) {
                Carnifex.Intermissio(e);
            } finally {
                FinireProcessumButton();
                try {
                    Tollere();
                } catch (Exception e) {
                    Carnifex.Intermissio(e);
                }
            }
        }

        public void Liberare() {
            InterrumpereCancellationToken();
        }

        private bool ConariIncipereProcessumButton() {
            if (_estProcessusButton) {
                return false;
            }
            _estProcessusButton = true;
            DeactivareButtons();
            return true;
        }

        private void FinireProcessumButton() {
            ActivareButtons();
            _estProcessusButton = false;
        }

        private void ActivareButtons() {
            _velumSalsamenti.ActivareButton(ButtonSalsamenti.Exi);
            _velumSalsamenti.ActivareButton(ButtonSalsamenti.OneraLudum);
            _velumSalsamenti.ActivareButton(ButtonSalsamenti.DeletoLudum);
        }

        private void DeactivareButtons() {
            _velumSalsamenti.DeactivareButton(ButtonSalsamenti.Exi);
            _velumSalsamenti.DeactivareButton(ButtonSalsamenti.OneraLudum);
            _velumSalsamenti.DeactivareButton(ButtonSalsamenti.DeletoLudum);
        }

        private void InitareCancellationToken() {
            InterrumpereCancellationToken();
            _cancellationTokenSource = new CancellationTokenSource();
        }

        private bool ConariAcquirereCancellationToken(out CancellationToken cancellationToken) {
            if (_cancellationTokenSource == null) {
                cancellationToken = CancellationToken.None;
                return false;
            }
            cancellationToken = _cancellationTokenSource.Token;
            return true;
        }

        private void InterrumpereCancellationToken() {
            if (_cancellationTokenSource == null) {
                return;
            }
            if (!_cancellationTokenSource.IsCancellationRequested) {
                _cancellationTokenSource.Cancel();
            }
            _cancellationTokenSource.Dispose();
            _cancellationTokenSource = null;
        }
    }
}
