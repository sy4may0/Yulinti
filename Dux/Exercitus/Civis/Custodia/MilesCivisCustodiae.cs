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

        // enum配列キャッシュ
        private readonly IDPuellaeResVisaeCapitis[] _cIDPuellaeResVisaeCapitis;
        private readonly IDPuellaeResVisaePectoris[] _cIDPuellaeResVisaePectoris;
        private readonly IDPuellaeResVisaeNatium[] _cIDPuellaeResVisaeNatium;

        public MilesCivisCustodiae(ContextusCivisOstiorumLegibile contextus) {
            _contextus = contextus;
            _numerusIctuumCapitis = new float[contextus.Civis.Longitudo];
            _numerusIctuumCorporis = new float[contextus.Civis.Longitudo];
            _angulusRationemCapitis = new float[contextus.Civis.Longitudo];
            _angulusRationemCorporis = new float[contextus.Civis.Longitudo];
            for (int i = 0; i < contextus.Civis.Longitudo; i++) {
                _numerusIctuumCapitis[i] = 0;
                _numerusIctuumCorporis[i] = 0;
                _angulusRationemCapitis[i] = 0f;
                _angulusRationemCorporis[i] = 0f;
            }
            _cIDPuellaeResVisaeCapitis = (IDPuellaeResVisaeCapitis[])Enum.GetValues(typeof(IDPuellaeResVisaeCapitis));
            _cIDPuellaeResVisaePectoris = (IDPuellaeResVisaePectoris[])Enum.GetValues(typeof(IDPuellaeResVisaePectoris));
            _cIDPuellaeResVisaeNatium = (IDPuellaeResVisaeNatium[])Enum.GetValues(typeof(IDPuellaeResVisaeNatium));
        }

        private float ComputareVisus(
            float visus,
            float distantia,
            float distantiaCustodiae,
            float distantiaCustodiaeMaxima
        ) {
            float t = (MathF.Abs(distantiaCustodiaeMaxima - distantiaCustodiae) > Numerus.Epsilon)
                ? (distantia - distantiaCustodiae) / (distantiaCustodiaeMaxima - distantiaCustodiae)
                : 0f;
            t = DuxMath.Clamp(t, 0f, 1f);
            float k = t * t * (3f - 2f * t);
            return visus * k / 100f;
        }

        private float ComputareDistantia(int idCivis) {
            if (!_contextus.Civis.EstActivum(idCivis)) return float.MaxValue;
            Vector3 positioPuellae = _contextus.PuellaeResVisae.LegoPositionemRadix();
            Vector3 positioCivis = _contextus.Loci.Positio(idCivis);
            return (positioCivis - positioPuellae).Length();
        }

        public OrdinatioCivis Ordinare(
            int idCivis,
            IResFluidaCivisLegibile resFluida
        ) {
            // 警戒時はVisaeVigilantiaSecで減少する。
            // 通常時はVisaeSecで減少する。
            float consumptio = _contextus.Configuratio.Custodiae.ConsumptioVisaeSec * _contextus.Temporis.Intervallum;
            if (resFluida.Veletudinis.EstVigilantia(idCivis) || resFluida.Veletudinis.EstDetectio(idCivis)) {
                consumptio = _contextus.Configuratio.Custodiae.ConsumptioVisaeVigilantiaSec * _contextus.Temporis.Intervallum;
            }

            float numerusIctuum = 
                _numerusIctuumCapitis[idCivis] * _angulusRationemCapitis[idCivis] + 
                _numerusIctuumCorporis[idCivis] * _angulusRationemCorporis[idCivis];

            // 視認数0で減少する。
            if (numerusIctuum <= Numerus.Epsilon) return new OrdinatioCivis(
                idCivis,
                veletudinisCustodiae: OrdinatioCivisVeletudinisCustodiae.FromVisa(idCivis, new OrdinatioCivisCustodiaeVisa(
                    consumptio
                ))
            );

            float distantia = ComputareDistantia(idCivis);
            // distantiaがDistantiaCustodiaeより大きい場合は5%毎秒減少する。
            if (distantia > _contextus.Configuratio.Custodiae.DistantiaCustodiae) return new OrdinatioCivis(
                idCivis,
                veletudinisCustodiae: OrdinatioCivisVeletudinisCustodiae.FromVisa(idCivis, new OrdinatioCivisCustodiaeVisa(
                    consumptio
                ))
            );

            float visus = resFluida.Veletudinis.Visus(idCivis);
            float distantiaCustodiaeMaxima = _contextus.Configuratio.Custodiae.DistantiaCustodiaeMaxima;
            float distantiaCustodiae = _contextus.Configuratio.Custodiae.DistantiaCustodiae;
            float ratioVirsus = ComputareVisus(visus, distantia, distantiaCustodiae, distantiaCustodiaeMaxima);

            // 視認数 * 10 * ratioVirsus / 毎秒
            float dtVisa = numerusIctuum * 10f * ratioVirsus * _contextus.Temporis.Intervallum;
            return new OrdinatioCivis(
                idCivis,
                veletudinisCustodiae: OrdinatioCivisVeletudinisCustodiae.FromVisa(idCivis, new OrdinatioCivisCustodiaeVisa(dtVisa))
            );
        }

        // Detectio判定を行う。
        public OrdinatioCivis OrdinareDetectio(
            int idCivis,
            IResFluidaCivisLegibile resFluida
        ) {
            bool vigilantiaProximus = resFluida.Veletudinis.EstVigilantia(idCivis);
            bool detectioProximus = resFluida.Veletudinis.EstDetectio(idCivis);
            // 通常時変動
            OrdinatioCivis ordinatio = OrdinatioCivis.Nihil(idCivis);
            if (!resFluida.Veletudinis.EstVigilantia(idCivis) && !resFluida.Veletudinis.EstDetectio(idCivis)) {
                if (resFluida.Veletudinis.Visa(idCivis) > _contextus.Configuratio.Custodiae.LimenVigilantia + 3f) {
                    // 通常 -> 警戒
                    vigilantiaProximus = true;
                    detectioProximus = false;
                }
            // 警戒時変動
            } else if (resFluida.Veletudinis.EstVigilantia(idCivis)) {
                if (resFluida.Veletudinis.Visa(idCivis) > _contextus.Configuratio.Custodiae.LimenDetectio + 3f) {
                    // 警戒 -> 検知
                    vigilantiaProximus = false;
                    detectioProximus = true;
                } else if (resFluida.Veletudinis.Visa(idCivis) < _contextus.Configuratio.Custodiae.LimenVigilantia - 3f) {
                    // 警戒 -> 通常
                    vigilantiaProximus = false;
                    detectioProximus = false;
                }
            } else if (resFluida.Veletudinis.EstDetectio(idCivis)) {
                if (resFluida.Veletudinis.Visa(idCivis) < _contextus.Configuratio.Custodiae.LimenDetectio - 3f) {
                    // 検知 -> 警戒
                    vigilantiaProximus = true;
                    detectioProximus = false;
                }
            }
            return new OrdinatioCivis(
                idCivis,
                veletudinisCustodiae: OrdinatioCivisVeletudinisCustodiae.FromDetectio(idCivis, new OrdinatioCivisCustodiaeDetectio(
                    vigilantiaProximus,
                    detectioProximus
                ))
            );
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
                            summaAngulusRationemCorporis += ComputareAngulusRationem(
                                positioCivisCapitis,
                                directioCivisCapitis,
                                positionem
                            );
                        }
                    }
                }

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
    }
}