using Yulinti.Nucleus;
using Yulinti.Dux.ContractusDucis;
using System;
using System.Numerics;

// AIさんへ。
// distantiaCustodiaeMaximaのMaximaがかかっているのはDistantiaではなくてCustodiaeのほうです。
// 警戒度が最大になる距離だから数値はdistantiaCustodiae > distantiaCustodiaeMaximaにならなければならない。

namespace Yulinti.Dux.Exercitus {
    internal sealed class MilesCivisCustodiae {
        private readonly ContextusCivisOstiorumLegibile _contextus;

        private readonly float[] _numerusIctuumCapitis;
        private readonly float[] _numerusIctuumCorporis;
        // 視野角オフセット値(0~1) -> どのくらい視界の中心にいるか。95度で0。0度で1。
        private readonly float[] _angulusRationemCapitis;
        private readonly float[] _angulusRationemCorporis;

        private const float cos95 = -0.087155744f;
        private const float cos45 =  0.707106782f;
        private const float cos100 = -0.173648178f;
        private const float ratioSuspectaVisa = 0.75f;

        private const int LONGITUDOLUT = 256;
        // 距離減衰パラメータ
        // 距離減衰が上がり始める距離のratio(0~1)
        private readonly float _ratioDistantiaCustodiaeAscensus;
        // 距離減衰カーブLUT
        private readonly SigmoidLUT _sigmoidLUTDistantiaCustodiae;

        // 興味喪失パラメータ
        // 減少経過時間(sec)
        private readonly float[] _tempusStudiumAmittere;
        // 興味を失うまでの時間のratio(0~1)
        private readonly float _ratioTempusStudiumAmittere;
        // 興味喪失カーブLUT
        private readonly SigmoidLUT _sigmoidLUTTempusAmittere;

        private bool[] _estSpectareNudusPrioris;

        // enum配列キャッシュ
        private readonly IDPuellaeResVisaeCapitis[] _cIDPuellaeResVisaeCapitis;
        private readonly IDPuellaeResVisaePectoris[] _cIDPuellaeResVisaePectoris;
        private readonly IDPuellaeResVisaeNatium[] _cIDPuellaeResVisaeNatium;
        private readonly IDPuellaeResNudusAnterior[] _cIDPuellaeResNudusAnterior;
        private readonly IDPuellaeResNudusPosterior[] _cIDPuellaeResNudusPosterior;

        public MilesCivisCustodiae(ContextusCivisOstiorumLegibile contextus) {
            _contextus = contextus;
            _numerusIctuumCapitis = new float[contextus.Civis.Longitudo];
            _numerusIctuumCorporis = new float[contextus.Civis.Longitudo];
            _angulusRationemCapitis = new float[contextus.Civis.Longitudo];
            _angulusRationemCorporis = new float[contextus.Civis.Longitudo];
            _tempusStudiumAmittere = new float[contextus.Civis.Longitudo];
            for (int i = 0; i < contextus.Civis.Longitudo; i++) {
                _numerusIctuumCapitis[i] = 0;
                _numerusIctuumCorporis[i] = 0;
                _angulusRationemCapitis[i] = 0f;
                _angulusRationemCorporis[i] = 0f;
                _tempusStudiumAmittere[i] = 0f;
            }
            _cIDPuellaeResVisaeCapitis = (IDPuellaeResVisaeCapitis[])Enum.GetValues(typeof(IDPuellaeResVisaeCapitis));
            _cIDPuellaeResVisaePectoris = (IDPuellaeResVisaePectoris[])Enum.GetValues(typeof(IDPuellaeResVisaePectoris));
            _cIDPuellaeResVisaeNatium = (IDPuellaeResVisaeNatium[])Enum.GetValues(typeof(IDPuellaeResVisaeNatium));
            _cIDPuellaeResNudusAnterior = (IDPuellaeResNudusAnterior[])Enum.GetValues(typeof(IDPuellaeResNudusAnterior));
            _cIDPuellaeResNudusPosterior = (IDPuellaeResNudusPosterior[])Enum.GetValues(typeof(IDPuellaeResNudusPosterior));

            // 距離減衰パラメータ初期化
            _ratioDistantiaCustodiaeAscensus = DuxMath.Clamp(
                DuxMath.InverseLeap(
                    _contextus.Configuratio.Custodiae.DistantiaCustodiae,
                    _contextus.Configuratio.Custodiae.DistantiaCustodiaeMaxima,
                    _contextus.Configuratio.Custodiae.DistantiaCustodiaeAscensus
                ),
            0f, 1f);
            _sigmoidLUTDistantiaCustodiae = new SigmoidLUT(
                _contextus.Configuratio.Custodiae.PrecalculusDistantiaAscensus,
                _ratioDistantiaCustodiaeAscensus,
                LONGITUDOLUT
            );

            // 興味喪失パラメータ初期化
            _ratioTempusStudiumAmittere = DuxMath.Clamp(_contextus.Configuratio.Custodiae.TempusStudiumAmittereSec / _contextus.Configuratio.Custodiae.TempusStudiumAmittereMaximaSec, 0f, 1f);
            _sigmoidLUTTempusAmittere = new SigmoidLUT(
                _contextus.Configuratio.Custodiae.PraeruptioTempusAmittere,
                _ratioTempusStudiumAmittere,
                LONGITUDOLUT
            );

            _estSpectareNudusPrioris = new bool[_contextus.Civis.Longitudo];
            for (int i = 0; i < _contextus.Civis.Longitudo; i++) {
                _estSpectareNudusPrioris[i] = false;
            }
        }

        private float ComputareVisus(
            float visus,
            float distantia,
            float distantiaCustodiae,
            float distantiaCustodiaeMaxima
        ) {
            // シグモイド関数でカーブを計算する。
            float d = DuxMath.Clamp(DuxMath.InverseLeap(
                distantiaCustodiae,
                distantiaCustodiaeMaxima,
                distantia
            ), 0f, 1f);

            float k = _sigmoidLUTDistantiaCustodiae[d];

            return visus * k;
        }

        private float ComputareDistantia(int idCivis) {
            if (!_contextus.Civis.EstActivum(idCivis)) return float.MaxValue;
            Vector3 positioPuellae = _contextus.PuellaeResVisae.LegoPositionemRadix();
            Vector3 positioCivis = _contextus.Loci.Positio(idCivis);
            return (positioCivis - positioPuellae).Length();
        }

        public void Ordinare(
            int idCivis,
            IResFluidaCivisLegibile resFluida
        ) {
            float consumptio = ComputareConsumptioVisae(idCivis, resFluida);
            ResolvereSuspectaVisa(idCivis, resFluida);

            float numerusIctuum = 
                _numerusIctuumCapitis[idCivis] * _angulusRationemCapitis[idCivis] + 
                _numerusIctuumCorporis[idCivis] * _angulusRationemCorporis[idCivis];

            // 視認数0で減少する。
            if (numerusIctuum <= Numerus.Epsilon) {
                if (resFluida.Veletudinis.Visa(idCivis) <= Numerus.Epsilon &&
                    resFluida.Veletudinis.Suspecta(idCivis) <= Numerus.Epsilon) return;

                _contextus.Carrus.PostulareVeletudinisValoris(
                    idCivis,
                    dtVisa: consumptio,
                    dtSuspecta: consumptio
                );

                return;
            }

            // Nudus視認数を更新する。
            bool estSpectareNudus = ResolvereSpectareNudus(idCivis);
            if (!estSpectareNudus) {
                Memorator.MemorareErrorum(IDErrorum.MILIESCIVISCUSTODIAE_RESOLVERESPECTARENUDUS_FAILED);
            }


            float distantia = ComputareDistantia(idCivis);
            // distantiaがDistantiaCustodiaeより大きい場合はVisaeを減少する。
            if (distantia > _contextus.Configuratio.Custodiae.DistantiaCustodiae) {
                if (resFluida.Veletudinis.Visa(idCivis) <= Numerus.Epsilon &&
                    resFluida.Veletudinis.Suspecta(idCivis) <= Numerus.Epsilon) return;

                _contextus.Carrus.PostulareVeletudinisValoris(
                    idCivis,
                    dtVisa: consumptio,
                    dtSuspecta: consumptio
                );

                return;
            }

            // 非SpectareNudus時はVisaのみ減少する。演算はやる。
            if (!resFluida.Veletudinis.EstSpectareNudus(idCivis)) {
                // 視認中なので興味喪失時間ではなく固定減少値を使用
                float dtVisaReductio = _contextus.Configuratio.Custodiae.ConsumptioVisaeSec * _contextus.Temporis.Intervallum;
                _contextus.Carrus.PostulareVeletudinisValoris(
                    idCivis,
                    dtVisa: dtVisaReductio
                );
            }

            float visus = resFluida.Veletudinis.Visus(idCivis);
            float distantiaCustodiaeMaxima = _contextus.Configuratio.Custodiae.DistantiaCustodiaeMaxima;
            float distantiaCustodiae = _contextus.Configuratio.Custodiae.DistantiaCustodiae;
            float ratio = ComputareVisus(visus, distantia, distantiaCustodiae, distantiaCustodiaeMaxima);

            // /100は固定補正値。
            // 視認数 * ratioVirsus / 毎秒 * 視認度上昇倍率
            float dtVisa = (numerusIctuum/100f) * ratio * _contextus.Temporis.Intervallum;
            // 固定設定レシオを乗算する。
            dtVisa *= _contextus.Configuratio.Custodiae.RatioVisus;
            // PuellaeステートのClaritasを適用する。
            dtVisa *= _contextus.ResFPuellae.Veletudinis.Claritas;
            // 興味喪失時間をリセット
            _tempusStudiumAmittere[idCivis] = 0f;


            // Nudus視認時はVisaとsuspectaを上昇させる。Nudus非視認時はSuspectaを上昇させる。
            // [TODO] Suspecta上昇は不審度によって変えるが、まだ不審度をResFluidaに反映していないので、Visaと同じ値で固定。
            //        注) SpectareNudus時は不審度ではなくVisaと一致で上昇させる。
            if (resFluida.Veletudinis.EstSpectareNudus(idCivis)) {
                _contextus.Carrus.PostulareVeletudinisValoris(
                    idCivis,
                    dtVisa: dtVisa,
                    dtSuspecta: dtVisa
                );
            } else {
                _contextus.Carrus.PostulareVeletudinisValoris(
                    idCivis,
                    dtSuspecta: dtVisa
                );
            }
        }

        // Nudus視認前後の挙動を扱う。
        private void ResolvereSuspectaVisa(int idCivis, IResFluidaCivisLegibile resFluida) {
            // 前回のSpectareと今のSpectareが同じなら何もしない。
            if (_estSpectareNudusPrioris[idCivis] == resFluida.Veletudinis.EstSpectareNudus(idCivis)) return;
            bool _estSpectare = resFluida.Veletudinis.EstSpectareNudus(idCivis);

            // 非視認 -> 視認
            if (_estSpectare) {
                // VisaをSuspectaの75%まで上げる。すでに超えている場合は何もしない。
                float visa = resFluida.Veletudinis.Visa(idCivis);
                float suspecta = resFluida.Veletudinis.Suspecta(idCivis);
                float dtVisa = (suspecta * ratioSuspectaVisa - visa); // 一括で上げる。Temporisで割らない。 
                if (dtVisa > 0f) {
                    _contextus.Carrus.PostulareVeletudinisValoris(
                        idCivis,
                        dtVisa: dtVisa
                    );
                }
            } else {
                // Visilantia, Detectio時はSuspectaを1とする。
                // それ以外はSuspectaをVisaに合わせる。
                float visa = resFluida.Veletudinis.Visa(idCivis);
                float suspecta = resFluida.Veletudinis.Suspecta(idCivis);
                if (resFluida.Veletudinis.EstVigilantia(idCivis) || resFluida.Veletudinis.EstDetectio(idCivis)) {
                    _contextus.Carrus.PostulareVeletudinisValoris(
                        idCivis,
                        dtSuspecta: 1f
                    );
                } else {
                    _contextus.Carrus.PostulareVeletudinisValoris(
                        idCivis,
                        dtSuspecta: visa - suspecta
                    );
                }
            }

            _estSpectareNudusPrioris[idCivis] = _estSpectare;

        }

        // Detectio状態ではConsumptioVisaeDetectioSecで減少する。
        // Vigilantia/通常時は興味喪失パラメータに従ってConsumptioVisaeSecで減少する。
        private float ComputareConsumptioVisae(
            int idCivis,
            IResFluidaCivisLegibile resFluida
        ) {
            if (resFluida.Veletudinis.EstDetectio(idCivis)) {
                _tempusStudiumAmittere[idCivis] = 0f;
                return _contextus.Configuratio.Custodiae.ConsumptioVisaeDetectioSec * _contextus.Temporis.Intervallum;
            } else {
                _tempusStudiumAmittere[idCivis] += _contextus.Temporis.Intervallum;
                // 経過時間を0~1に正規化
                float t = DuxMath.Clamp(_tempusStudiumAmittere[idCivis] / _contextus.Configuratio.Custodiae.TempusStudiumAmittereMaximaSec, 0f, 1f);
                float ratio = _sigmoidLUTTempusAmittere[t];
                return _contextus.Configuratio.Custodiae.ConsumptioVisaeSec * ratio * _contextus.Temporis.Intervallum;
            }
        }

        public void ResolvereIctuum() {
            for (int i = 0; i < _contextus.Civis.Longitudo; i++) {
                _numerusIctuumCapitis[i] = 0;
                _numerusIctuumCorporis[i] = 0;
                float distantia = ComputareDistantia(i);
                // 最大視認距離より遠いNPCは視認数を0とする。
                if (distantia > _contextus.Configuratio.Custodiae.DistantiaCustodiae) continue;

                Vector3 positioCivisCapitis = default;
                Vector3 directioCivisCapitis = default;
                if (
                    _contextus.Visa.ConareLegoPositioCapitis(i, out positioCivisCapitis) && 
                    _contextus.Visa.ConareLegoDirectioCapitis(i, out directioCivisCapitis)
                ) {
                } else {
                    // ここしくじると気づけなさそうだからロギング。
                    Memorator.MemorareErrorum(IDErrorum.MILIESCIVISCUSTODIAE_CONARELEGO_FAILED);
                    positioCivisCapitis = _contextus.Loci.Positio(i);
                    directioCivisCapitis = new Vector3(0f, 1f, 0f);
                }

                float summaAngulusRationemCapitis = 0f;
                float summaAngulusRationemCorporis = 0f;

                // 頭の視認数を取得。
                foreach (IDPuellaeResVisaeCapitis idCapitis in _cIDPuellaeResVisaeCapitis) {
                    if (_contextus.PuellaeResVisae.ConareLegoCapitis(idCapitis, out Vector3 positionem)) {
                        if (_contextus.Visa.EstVisa(i, positionem)) {
                            _numerusIctuumCapitis[i] += 1f;
                            // 視野角における角度を計算しておく。
                            summaAngulusRationemCapitis += ComputareAngulusRationem(
                                positioCivisCapitis,
                                directioCivisCapitis,
                                positionem
                            );
                        }
                    }
                }

                // 胸の視認数を取得。
                foreach (IDPuellaeResVisaePectoris idPectoris in _cIDPuellaeResVisaePectoris) {
                    if (_contextus.PuellaeResVisae.ConareLegoPectoris(idPectoris, out Vector3 positionem)) {
                        if (_contextus.Visa.EstVisa(i, positionem)) {
                            _numerusIctuumCorporis[i] += 1f;
                            // 視野角における角度を計算しておく。
                            summaAngulusRationemCorporis += ComputareAngulusRationem(
                                positioCivisCapitis,
                                directioCivisCapitis,
                                positionem
                            );
                        }
                    }
                }

                // ケツ視認数を取得。
                foreach (IDPuellaeResVisaeNatium idNatium in _cIDPuellaeResVisaeNatium) {
                    if (_contextus.PuellaeResVisae.ConareLegoNatium(idNatium, out Vector3 positionem)) {
                        if (_contextus.Visa.EstVisa(i, positionem)) {
                            _numerusIctuumCorporis[i] += 1f;
                            // 視野角における角度を計算しておく。
                            summaAngulusRationemCorporis += ComputareAngulusRationem(
                                positioCivisCapitis,
                                directioCivisCapitis,
                                positionem
                            );
                        }
                    }
                }

                // 視野角角度の平均値を計算する。↑後で合成してNumerusIctuumに反映する。
                _angulusRationemCapitis[i] = summaAngulusRationemCapitis / _cIDPuellaeResVisaeCapitis.Length;
                _angulusRationemCorporis[i] = summaAngulusRationemCorporis / (_cIDPuellaeResVisaePectoris.Length + _cIDPuellaeResVisaeNatium.Length);
            }
        }

        // 頭の方向とNavmesh方向の角度を計算し、視野角オフセット値(0~1)を計算する。
        // 視野範囲を95度円錐形として、そこから中心に向かって0 -> 1 
        // 距離が近くなるほど視野範囲を45度に近づける。
        public float ComputareAngulusRationem(
            Vector3 positioCivisCapitis,
            Vector3 directioCivisCapitis,
            Vector3 positioPuellaeResVisae
        ) {
            Vector3 directio = positioPuellaeResVisae - positioCivisCapitis;
            if (directio.LengthSquared() < Numerus.EpsilonSq) return 0f;
            float distantia = directio.Length();

            float d = Vector3.Dot(Vector3.Normalize(directioCivisCapitis), Vector3.Normalize(directio));

            float dN = DuxMath.Clamp(
                (_contextus.Configuratio.Custodiae.DistantiaCustodiae - distantia) / 
                (_contextus.Configuratio.Custodiae.DistantiaCustodiae - _contextus.Configuratio.Custodiae.DistantiaCustodiaeMaxima),
                0f,
                1f
            );

            dN = dN * dN * (3f - 2f * dN); // smoothstep
            float cosAngulus = 1f + (cos45 - 1f) * dN; // Lerp

            float ratio = DuxMath.Clamp(
                (d - cos95) / (cosAngulus - cos95),
                0f,
                1f
            );
            return ratio * ratio * (3f - 2f * ratio); // smoothstep
        }

        // Nudus視認ポイントのForward方向と、視認ポイントPosからCivisの頭PosまでのDirectioを比較する。
        // 角度が100度以内なら視認判定とし、ResFluidaのSpectareNudusを更新する。
        private bool ResolvereSpectareNudus(
            int idCivis
        ) {
            bool estSpectareNudusAnterior = false;
            bool estSpectareNudusPosterior = false;

            Vector3 positioCivisCapitis = default;
            if (!_contextus.Visa.ConareLegoPositioCapitis(idCivis, out positioCivisCapitis)) return false;

            foreach (IDPuellaeResNudusAnterior idNudusAnterior in _cIDPuellaeResNudusAnterior) {
                Vector3 directioResNudusAnterior = default;
                Vector3 positioResNudus = default;

                if (!_contextus.PuellaeResVisae.ConareLegoNudusAnterior(idNudusAnterior, out positioResNudus)) continue;
                if (!_contextus.PuellaeResVisae.ConareLegoNudusAnteriorDirectio(idNudusAnterior, out directioResNudusAnterior)) continue;

                Vector3 directio = positioCivisCapitis - positioResNudus;
                float angle = Vector3.Dot(Vector3.Normalize(directioResNudusAnterior), Vector3.Normalize(directio));
                if (angle > cos100) {
                    estSpectareNudusAnterior = true;
                }
            }
            foreach (IDPuellaeResNudusPosterior idNudusPosterior in _cIDPuellaeResNudusPosterior) {
                Vector3 directioResNudusPosterior = default;
                Vector3 positioResNudus = default;

                if (!_contextus.PuellaeResVisae.ConareLegoNudusPosterior(idNudusPosterior, out positioResNudus)) continue;
                if (!_contextus.PuellaeResVisae.ConareLegoNudusPosteriorDirectio(idNudusPosterior, out directioResNudusPosterior)) continue;

                Vector3 directio = positioCivisCapitis - positioResNudus;
                float angle = Vector3.Dot(Vector3.Normalize(directioResNudusPosterior), Vector3.Normalize(directio));
                if (angle > cos100) {
                    estSpectareNudusPosterior = true;
                }
            }

            // Executorを実行する。
            _contextus.Carrus.PostulareVeletudinisSpectare(
                idCivis,
                estSpectareNudusAnterior,
                estSpectareNudusPosterior
            );

            return true;
        }
    }
}