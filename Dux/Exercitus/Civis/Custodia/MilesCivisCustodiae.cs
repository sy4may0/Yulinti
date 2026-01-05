using Yulinti.Nucleus;
using Yulinti.Dux.ContractusDucis;
using System;
using System.Numerics;

namespace Yulinti.Dux.Exercitus {
    internal sealed class MilesCivisCustodiae {
        private readonly ContextusCivisOstiorumLegibile _contextus;

        private readonly int[] _numerusIctuumCapitis;
        private readonly int[] _numerusIctuumCorporis;

        // enum配列キャッシュ
        private readonly IDPuellaeResVisaeCapitis[] _cIDPuellaeResVisaeCapitis;
        private readonly IDPuellaeResVisaePectoris[] _cIDPuellaeResVisaePectoris;
        private readonly IDPuellaeResVisaeNatium[] _cIDPuellaeResVisaeNatium;

        public MilesCivisCustodiae(ContextusCivisOstiorumLegibile contextus) {
            _contextus = contextus;
            _numerusIctuumCapitis = new int[contextus.Civis.Longitudo];
            _numerusIctuumCorporis = new int[contextus.Civis.Longitudo];
            for (int i = 0; i < contextus.Civis.Longitudo; i++) {
                _numerusIctuumCapitis[i] = 0;
                _numerusIctuumCorporis[i] = 0;
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
            // 視認数0で5%毎秒減少する。
            if (_numerusIctuumCapitis[idCivis] == 0 && _numerusIctuumCorporis[idCivis] == 0) return new OrdinatioCivis(
                idCivis,
                veletudinisCustodiae: OrdinatioCivisVeletudinisCustodiae.FromVisa(idCivis, new OrdinatioCivisCustodiaeVisa(
                    _contextus.Configuratio.Custodiae.ConsumptioVisaeSec * _contextus.Temporis.Intervallum
                ))
            );

            float distantia = ComputareDistantia(idCivis);
            // distantiaがDistantiaCustodiaeMaximaより大きい場合は5%毎秒減少する。
            if (distantia > _contextus.Configuratio.Custodiae.DistantiaCustodiaeMaxima) return new OrdinatioCivis(
                idCivis,
                veletudinisCustodiae: OrdinatioCivisVeletudinisCustodiae.FromVisa(idCivis, new OrdinatioCivisCustodiaeVisa(
                    _contextus.Configuratio.Custodiae.ConsumptioVisaeSec * _contextus.Temporis.Intervallum
                ))
            );

            float visus = resFluida.Veletudinis.Visus(idCivis);
            float distantiaCustodiaeMaxima = _contextus.Configuratio.Custodiae.DistantiaCustodiaeMaxima;
            float distantiaCustodiae = _contextus.Configuratio.Custodiae.DistantiaCustodiae;
            float ratioVirsus = ComputareVisus(visus, distantia, distantiaCustodiae, distantiaCustodiaeMaxima);

            // 視認数 * 10 * ratioVirsus / 毎秒
            float numerusIctuum = _numerusIctuumCapitis[idCivis] + _numerusIctuumCorporis[idCivis];
            float dtVisa = numerusIctuum * 10f * ratioVirsus * _contextus.Temporis.Intervallum;
            return new OrdinatioCivis(
                idCivis,
                veletudinisCustodiae: OrdinatioCivisVeletudinisCustodiae.FromVisa(idCivis, new OrdinatioCivisCustodiaeVisa(dtVisa))
            );
        }


        public void ResolvereIctuum() {
            for (int i = 0; i < _contextus.Civis.Longitudo; i++) {
                _numerusIctuumCapitis[i] = 0;
                _numerusIctuumCorporis[i] = 0;
                float distantia = ComputareDistantia(i);
                // 最大視認距離より遠いNPCは視認数を0とする。
                if (distantia > _contextus.Configuratio.Custodiae.DistantiaCustodiae) continue;

                // 頭の視認数を取得。
                foreach (IDPuellaeResVisaeCapitis idCapitis in _cIDPuellaeResVisaeCapitis) {
                    if (_contextus.PuellaeResVisae.ConareLegoCapitis(idCapitis, out Vector3 positionem)) {
                        if (_contextus.Visa.EstVisa(i, positionem)) {
                            _numerusIctuumCapitis[i]++;
                        }
                    }
                }
                // 胸の視認数を取得。
                foreach (IDPuellaeResVisaePectoris idPectoris in _cIDPuellaeResVisaePectoris) {
                    if (_contextus.PuellaeResVisae.ConareLegoPectoris(idPectoris, out Vector3 positionem)) {
                        if (_contextus.Visa.EstVisa(i, positionem)) {
                            _numerusIctuumCorporis[i]++;
                        }
                    }
                }
                // ケツ視認数を取得。
                foreach (IDPuellaeResVisaeNatium idNatium in _cIDPuellaeResVisaeNatium) {
                    if (_contextus.PuellaeResVisae.ConareLegoNatium(idNatium, out Vector3 positionem)) {
                        if (_contextus.Visa.EstVisa(i, positionem)) {
                            _numerusIctuumCorporis[i]++;
                        }
                    }
                }
                UnityEngine.Debug.Log($"numerusIctuumCapitis: {_numerusIctuumCapitis[i]}, numerusIctuumCorporis: {_numerusIctuumCorporis[i]}");
            }
        }
    }
}