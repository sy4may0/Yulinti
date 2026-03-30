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
        private readonly IPraecoConfirmationis _praecoConfirmationis;
        private readonly ITurrisInterpretationis _turrisInterpretationis;
        private readonly ITurrisSalsamenti _turrisSalsamenti;
        private readonly ITurrisSoniVeli _turrisSoniVeli;

        // Operatio
        private readonly OperatioSalsamenti _operatioSalsamenti;

        // 上位Operatio
        private readonly IOperatioInternaIndexusPrincipalis _operatioInternaIndexusPrincipalis;

        private readonly CuratorVela _curatorVela;

        private readonly IOstiumSignumCancellationisLegibile _ostiumSignumCancellationisLegibile;

        private bool _estActivumUsus;

        public PraecoSalsamenti(
            ITurrisMundus turrisMundus,
            IVelumSalsamenti velumSalsamenti,
            ITurrisSalsamenti turrisSalsamenti,
            IPraecoConfirmationis praecoConfirmationis,
            ITurrisInterpretationis turrisInterpretationis,
            ITurrisSoniVeli turrisSoniVeli,
            OperatioSalsamenti operatioSalsamenti,
            IOperatioInternaIndexusPrincipalis operatioInternaIndexusPrincipalis,
            CuratorVela curatorVela,
            IOstiumSignumCancellationisLegibile ostiumSignumCancellationisLegibile
        ) {
            _turrisMundus = turrisMundus;
            _velumSalsamenti = velumSalsamenti;
            _turrisSalsamenti = turrisSalsamenti;
            _praecoConfirmationis = praecoConfirmationis;
            _turrisInterpretationis = turrisInterpretationis;
            _turrisSoniVeli = turrisSoniVeli;
            _curatorVela = curatorVela;
            _ostiumSignumCancellationisLegibile = ostiumSignumCancellationisLegibile;
            _operatioSalsamenti = operatioSalsamenti;
            _operatioInternaIndexusPrincipalis = operatioInternaIndexusPrincipalis;

            _operatioSalsamenti.Initiare(Executare, ExecutareGuid);
            _estActivumUsus = true;
        }

        public void Incipere() {
            Tollere();
        }

        public async Task Demittere() {
            try {
                // UIを表示
                _velumSalsamenti.DemittereSalsamenti();

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
                _estActivumUsus = true;
            } catch (OperationCanceledException) {
                //キャンセルしてよい。何もしない。
            } catch (Exception e) {
                Carnifex.Intermissio(e);
            }
        }

        public void Tollere() {
            _velumSalsamenti.TollereSalsamenti();
            _operatioInternaIndexusPrincipalis.RenovareStatumSalsamenti();
            _estActivumUsus = true;
        }

        private void ExecutareGuid(UsusSalsamenti usus, Guid id) {
            if (usus == UsusSalsamenti.OneraLudum) {
                _ = PremereOneraLudum(id);
            } else if (usus == UsusSalsamenti.DeletoLudum) {
                _ = PremereDeletoLudum(id);
            } else {
                Carnifex.Error(LogTextus.PraecoSalsamenti_EXECUTARE_USUS_INVALID);
            }
        }

        private void Executare(UsusSalsamenti usus) {
            if (usus == UsusSalsamenti.Exi) {
                PremereExi();
            } else {
                Carnifex.Error(LogTextus.PraecoSalsamenti_EXECUTARE_USUS_INVALID_NEED_GUID);
            }
        }

        private async Task PremereOneraLudum(Guid id) {
            try {
                if (!ConareUsus()) {
                    return;
                }
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
                LiberareUsus();
            }
        }

        private async Task PremereDeletoLudum(Guid id) {
            try {
                if (!ConareUsus()) {
                    return;
                }
                CancellationToken cancellationToken = _ostiumSignumCancellationisLegibile.Signum;
                bool estConfirmationis = await _praecoConfirmationis.DemittereAsync(
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
                LiberareUsus();
            }
        }

        private void PremereExi() {
            try {
                if (!ConareUsus()) {
                    return;
                }
                _turrisSoniVeli.Sonare(IDSonusVeli.Exire);
                Tollere();
            } catch (Exception e) {
                Carnifex.Intermissio(e);
            } finally {
                LiberareUsus();
            }
        }

        private bool ConareUsus() {
            if (!_estActivumUsus) {
                return false;
            }
            _estActivumUsus = false;
            return true;
        }

        private void LiberareUsus() {
            _estActivumUsus = true;
        }

        public void Liberare() {
            _operatioSalsamenti.Purgare();
        }
    }
}
