using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using System.Numerics;
using System;

namespace Yulinti.ImperiumDelegatum.Exercitus {

    // Ictuum: 聴認状態: resfluida.auditaを上昇させる。
    // Auditae: 発覚状態: この状態では常にauditaを上げ続ける。一定時間でSurdusに移行。
    // Surdus: 聴認状態から一定時間経過後に遷移する状態。auditaを一定で下げ続ける。一定時間でConsumptioに移行。
    // Consumptio: 聴認状態から一定時間経過後に遷移する状態。StudiumAmittereで興味喪失度を計算してauditaを下げ続ける。EstAudiviがTrueになったらIctuumに移行。
    internal enum CustodiaCivisAuditaeModi {
        Ictuum,
        Auditae,
        Surdus,
        Consumptio
    }

    internal sealed class ResolutorCivisAuditae {
        private readonly IConfiguratioCivisCustodiae _configuratioCivisCustodiae;
        private readonly IOstiumTemporisLegibile _temporis;
        private readonly IOstiumCivisLegibile _civis;
        private readonly IOstiumCarrusCivis _carrus;
        private readonly Random _random;

        private readonly IResolutorCivisIctuumAuditae _resolutorCivisIctuumAuditae;

        private readonly CustodiaCivisAuditaeModi[] _modiActualis;
        private readonly AbacusTemporis[] _abacusStudiumAmittere;

        private readonly IResolutorCivisDistantia _resolutorCivisDistantia;

        // Auditae時計
        private readonly IHorologium[] _horologiumTemereAuditae;
        // Surdus時計
        private readonly IHorologium[] _horologiumTemereSurdus;

        public ResolutorCivisAuditae(
            IConfiguratioCivisCustodiae configuratioCivisCustodiae,
            IOstiumTemporisLegibile temporis,
            IOstiumCarrusCivis carrus,
            IOstiumCivisLegibile civis,
            Random random,
            IResolutorCivisIctuumAuditae resolutorCivisIctuumAuditae,
            IResolutorCivisDistantia resolutorCivisDistantia
        ) {
            _configuratioCivisCustodiae = configuratioCivisCustodiae;
            _temporis = temporis;
            _carrus = carrus;
            _civis = civis;
            _random = random;
            _resolutorCivisIctuumAuditae = resolutorCivisIctuumAuditae;
            _resolutorCivisDistantia = resolutorCivisDistantia;
            _horologiumTemereAuditae = new IHorologium[_civis.Longitudo];
            _horologiumTemereSurdus = new IHorologium[_civis.Longitudo];

            _modiActualis = new CustodiaCivisAuditaeModi[_civis.Longitudo];
            _abacusStudiumAmittere = new AbacusTemporis[_civis.Longitudo];
            for (int i = 0; i < _civis.Longitudo; i++) {
                _modiActualis[i] = CustodiaCivisAuditaeModi.Consumptio;
                _abacusStudiumAmittere[i] = new AbacusTemporis(
                    _configuratioCivisCustodiae.TempusStudiumAmittereMaximaSec,
                    0f,
                    _configuratioCivisCustodiae.TempusStudiumAmittereSec,
                    _configuratioCivisCustodiae.PraeruptioTempusAmittere
                );
                _horologiumTemereAuditae[i] = new HorologiumTemere(
                    _configuratioCivisCustodiae.TempusAuditaeSecMinima,
                    _configuratioCivisCustodiae.TempusAuditaeSecMaxima,
                    _random
                );
                _horologiumTemereSurdus[i] = new HorologiumTemere(
                    _configuratioCivisCustodiae.TempusSurdaMinima,
                    _configuratioCivisCustodiae.TempusSurdaMaxima,
                    _random
                );
            }
        }

        public void Initare(int idCivis) {
            _modiActualis[idCivis] = CustodiaCivisAuditaeModi.Consumptio;
            _abacusStudiumAmittere[idCivis].Purgere();
            _horologiumTemereAuditae[idCivis].Purgere();
            _horologiumTemereSurdus[idCivis].Purgere();
        }

        // Ictuumからの遷移
        private void ResolvereModiIctuum(
            int idCivis,
            IResFluidaCivisLegibile resFluida
        ) {
            // 範囲外の場合、Consumptioに遷移。
            if (!_resolutorCivisDistantia.EstCustodiaeAuditae(idCivis)) {
                _modiActualis[idCivis] = CustodiaCivisAuditaeModi.Consumptio;
                _abacusStudiumAmittere[idCivis].Purgere();
                return;
            }
            // 聴認0の場合、Consumptioに遷移。
            if (!_resolutorCivisIctuumAuditae.EstAudita(idCivis)){
                _modiActualis[idCivis] = CustodiaCivisAuditaeModi.Consumptio;
                _abacusStudiumAmittere[idCivis].Purgere();
                return;
            }

            // DetectioSonora状態になったらAuditaeに遷移、時計を有効化。
            if (resFluida.Veletudinis.EstDetectioSonora(idCivis)) {
                _modiActualis[idCivis] = CustodiaCivisAuditaeModi.Auditae;
                _horologiumTemereAuditae[idCivis].Activare();
                _horologiumTemereSurdus[idCivis].Deactivare();
                return;
            }
        }

        // Auditaeからの遷移
        private void ResolvereModiAuditae(
            int idCivis,
            IResFluidaCivisLegibile resFluida
        ) {
            // Auditae時計が終了したらSurdusに遷移、時計を有効化。
            if (_horologiumTemereAuditae[idCivis].EstExhaurita(_temporis.Intervallum)) {
                _modiActualis[idCivis] = CustodiaCivisAuditaeModi.Surdus;
                _horologiumTemereSurdus[idCivis].Activare();
                _horologiumTemereAuditae[idCivis].Deactivare();
                return;
            }

            // それ以外はSurdus時計を無効化。
            _horologiumTemereSurdus[idCivis].Deactivare();
        }

        // Surdusからの遷移
        private void ResolvereModiSurdus(
            int idCivis,
            IResFluidaCivisLegibile resFluida
        ) {
            // Surdus時計が終了したらConsumptioに遷移、時計をすべて無効化。
            if (_horologiumTemereSurdus[idCivis].EstExhaurita(_temporis.Intervallum)) {
                _modiActualis[idCivis] = CustodiaCivisAuditaeModi.Consumptio;
                _horologiumTemereAuditae[idCivis].Deactivare();
                _horologiumTemereSurdus[idCivis].Deactivare();
                return;
            }
        }

        // Consumptioからの遷移
        private void ResolvereModiConsumptio(
            int idCivis,
            IResFluidaCivisLegibile resFluida
        ) {
            // 聴認ありの場合、Ictuumに遷移。
            if (_resolutorCivisIctuumAuditae.EstAudita(idCivis)) {
                _modiActualis[idCivis] = CustodiaCivisAuditaeModi.Ictuum;
                _abacusStudiumAmittere[idCivis].Purgere();
                // 時計をすべて初期化
                _horologiumTemereAuditae[idCivis].Purgere();
                _horologiumTemereSurdus[idCivis].Purgere();
                return;
            }
        }

        private void Resolvere(
            int idCivis,
            IResFluidaCivisLegibile resFluida
        ) {
            switch (_modiActualis[idCivis]) {
                case CustodiaCivisAuditaeModi.Ictuum:
                    ResolvereModiIctuum(idCivis, resFluida);
                    break;
                case CustodiaCivisAuditaeModi.Auditae:
                    ResolvereModiAuditae(idCivis, resFluida);
                    break;
                case CustodiaCivisAuditaeModi.Surdus:
                    ResolvereModiSurdus(idCivis, resFluida);
                    break;
                case CustodiaCivisAuditaeModi.Consumptio:
                    ResolvereModiConsumptio(idCivis, resFluida);
                    break;
            }
        }

        private void Ictuum(
            int idCivis,
            IResFluidaCivisLegibile resFluida
        ) {
            // Ictuum状態での処理
            float audita = _resolutorCivisIctuumAuditae.Audita(idCivis) / 100f; // 0~0.01
            // 設定による上昇補正値
            audita *= _configuratioCivisCustodiae.RatioAudita;  // 0.10とか0.15とか。
            audita *= _temporis.Intervallum; // フレーム時間を適用する。

            _carrus.PostulareVeletudinisValoris(
                idCivis,
                dtAudita: audita
            );
        }

        private void Auditae(
            int idCivis,
            IResFluidaCivisLegibile resFluida
        ) {
            float dtAudita = 1.0f;
            _carrus.PostulareVeletudinisValoris(
                idCivis,
                dtAudita: dtAudita
            );
        }

        private void Surdus(
            int idCivis,
            IResFluidaCivisLegibile resFluida
        ) {
            float dtAudita = _configuratioCivisCustodiae.ConsumptioAuditaeSec * _temporis.Intervallum;
            _carrus.PostulareVeletudinisValoris(
                idCivis,
                dtAudita: dtAudita
            );
        }

        private void Consumptio(
            int idCivis,
            IResFluidaCivisLegibile resFluida
        ) {
            _abacusStudiumAmittere[idCivis].Pulsus(_temporis.Intervallum);
            float ratio = _abacusStudiumAmittere[idCivis].ComputareRatio();
            float dtAudita = _configuratioCivisCustodiae.ConsumptioAuditaeSec * ratio * _temporis.Intervallum;
            _carrus.PostulareVeletudinisValoris(
                idCivis,
                dtAudita: dtAudita
            );
        }

        public void Ordinare(
            int idCivis,
            IResFluidaCivisLegibile resFluida
        ) {
            Resolvere(idCivis, resFluida);
            switch (_modiActualis[idCivis]) {
                case CustodiaCivisAuditaeModi.Ictuum:
                    if (resFluida.Veletudinis.Audita(idCivis) >= 1f - Numerus.Epsilon) break;
                    Ictuum(idCivis, resFluida);
                    break;
                case CustodiaCivisAuditaeModi.Auditae:
                    if (resFluida.Veletudinis.Audita(idCivis) >= 1f - Numerus.Epsilon) break;
                    Auditae(idCivis, resFluida);
                    break;
                case CustodiaCivisAuditaeModi.Surdus:
                    if (resFluida.Veletudinis.Audita(idCivis) <= Numerus.Epsilon) break;
                    Surdus(idCivis, resFluida);
                    break;
                case CustodiaCivisAuditaeModi.Consumptio:
                    if (resFluida.Veletudinis.Audita(idCivis) <= Numerus.Epsilon) break;
                    Consumptio(idCivis, resFluida);
                    break;
                default:
                    break;
            }
        }
    }
}