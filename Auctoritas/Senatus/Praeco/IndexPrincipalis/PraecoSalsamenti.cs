using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Auctoritas.Contractus;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Yulinti.Auctoritas.Senatus {
    internal sealed class PraecoSalsamenti : IPraeco, IPraecoIncipabilis, IPraecoLiberabilis {
        private readonly ITurrisMundus _turrisMundus;
        private readonly IVelumSalsamenti _velumSalsamenti;
        private readonly IPraecoConfirmationis _legatusConfirmationis;
        private readonly ITurrisInterpretationis _turrisInterpretationis;
        private readonly ITurrisSalsamenti _turrisSalsamenti;
        private readonly ITurrisSoniVeli _turrisSoniVeli;

        private readonly CuratorVela _curatorVela;

        private readonly IOstiumSignumCancellationisLegibile _ostiumSignumCancellationisLegibile;

        // Dux -> Velumへのコールバック
        private Action<Guid> _aeAdPremereOneraLudum;
        private Action<Guid> _aeAdPremereDeletoLudum;
        private Action _aeAdPremereExi;

        // Demittereで受け取り、Tollereで実行する、画面クローズ時のコールバック。
        private Action _adReditum;

        private bool _estProcessusButton;

        public PraecoSalsamenti(
            ITurrisMundus turrisMundus,
            IVelumSalsamenti velumSalsamenti,
            ITurrisSalsamenti turrisSalsamenti,
            IPraecoConfirmationis legatusConfirmationis,
            ITurrisInterpretationis turrisInterpretationis,
            ITurrisSoniVeli turrisSoniVeli,
            CuratorVela curatorVela,
            IOstiumSignumCancellationisLegibile ostiumSignumCancellationisLegibile
        ) {
            _turrisMundus = turrisMundus;
            _velumSalsamenti = velumSalsamenti;
            _turrisSalsamenti = turrisSalsamenti;
            _legatusConfirmationis = legatusConfirmationis;
            _turrisInterpretationis = turrisInterpretationis;
            _turrisSoniVeli = turrisSoniVeli;
            _curatorVela = curatorVela;
            _ostiumSignumCancellationisLegibile = ostiumSignumCancellationisLegibile;

            _aeAdPremereOneraLudum = AdPremereOneraLudum;
            _aeAdPremereDeletoLudum = AdPremereDeletoLudum;
            _aeAdPremereExi = AdPremereExi;

            _adReditum = null;
        }

        public void Incipere() {
            Tollere();
        }

        public async Task Demittere(Action adReditum) {
            try {
                // UIを表示
                _velumSalsamenti.DemittereSalsamenti();

                _velumSalsamenti.AdPremereOneraLudum(_aeAdPremereOneraLudum);
                _velumSalsamenti.AdPremereDeletoLudum(_aeAdPremereDeletoLudum);
                _velumSalsamenti.AdPremereExi(_aeAdPremereExi);

                CancellationToken cancellationToken = _ostiumSignumCancellationisLegibile.Signum;
                // Notitiaをロード
                IReadOnlyList<IOstiumSalsamentiNotitiae> notitiaManualis = 
                    await _turrisSalsamenti.ArcessereNotitiamManualem(cancellationToken);
                IReadOnlyList<IOstiumSalsamentiNotitiae> notitiaAutomaticus = 
                    await _turrisSalsamenti.ArcessereNotitiamAutomaticam(cancellationToken);

                // UIにNotitiaを表示
                _velumSalsamenti.RenovareTablaeManualis(notitiaManualis);
                _velumSalsamenti.RenovareTablaeAutomaticus(notitiaAutomaticus);

                // 表示SE
                _turrisSoniVeli.Sonare(IDSonusVeli.Demittere);
            } catch (OperationCanceledException) {
                //キャンセルしてよい。何もしない。
            } catch (Exception e) {
                Carnifex.Intermissio(e);
            } finally {
                _adReditum = adReditum;
            }
        }

        public void Tollere() {
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
                CancellationToken cancellationToken = _ostiumSignumCancellationisLegibile.Signum;

                await _turrisSalsamenti.Arcessere(id, cancellationToken);
                _curatorVela.TollereVelaOmnium();
                _turrisSoniVeli.Sonare(IDSonusVeli.SubmittereAdditum);
                _turrisMundus.AdMundum(IDMundi.MundusPortus);
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
                CancellationToken cancellationToken = _ostiumSignumCancellationisLegibile.Signum;
                bool estConfirmationis = await _legatusConfirmationis.DemittereAsync(
                    _turrisInterpretationis.LegoTextus(IDTextus.SALSAMENTUM_DELETO_CONFIRMATIONIS_TITULUS),
                    _turrisInterpretationis.LegoTextus(IDTextus.SALSAMENTUM_DELETO_CONFIRMATIONIS_TEXTUS),
                    _turrisInterpretationis.LegoTextus(IDTextus.SALSAMENTUM_DELETO_CONFIRMATIONIS_BUTTON_ITA),
                    _turrisInterpretationis.LegoTextus(IDTextus.SALSAMENTUM_DELETO_CONFIRMATIONIS_BUTTON_NON),
                    null,
                    null,
                    IDSonusVeli.Submittere,
                    IDSonusVeli.Exire,
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
                    _turrisSoniVeli.Sonare(IDSonusVeli.Exire);
                    Tollere();
                } catch (Exception e) {
                    Carnifex.Intermissio(e);
                }
            }
        }

        public void Liberare() { }

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
    }
}
