using System.Numerics;
using Yulinti.Dux.ContractusDucis;
using Yulinti.Nucleus;
using System;

namespace Yulinti.Dux.Exercitus {
    internal sealed class ResolutorCivisIctuumVisae : IResolutorCivisIctuumVisae {
        private readonly ContextusCivisOstiorumLegibile _contextus;
        private readonly AbacusDistantiaeVisus _abacusDistantiaeVisus;

        // 角度補正の合成用
        // _abacusDistantiaeVisusAngliが0 -> 1に増加するにつれ、AnguliVisus0からAnguliVisus1への補正が増加する。
        private readonly AbacusDistantiaeVisus _abacusDistantiaeVisusAngli;
        private readonly AbacusAnguliVisus _abacusAnguliVisus0;
        private readonly AbacusAnguliVisus _abacusAnguliVisus1;

        private readonly IDPuellaeResVisaeCapitis[] _cIDPuellaeResVisaeCapitis;
        private readonly IDPuellaeResVisaePectoris[] _cIDPuellaeResVisaePectoris;
        private readonly IDPuellaeResVisaeNatium[] _cIDPuellaeResVisaeNatium;

        private readonly float[] _visaIctuumCapitis;
        private readonly float[] _visaIctuumCorporis;

        private readonly IResolutorCivisDistantia _resolutorCivisDistantia;

        public ResolutorCivisIctuumVisae(
            ContextusCivisOstiorumLegibile contextus,
            IResolutorCivisDistantia resolutorCivisDistantia
        ) {
            _contextus = contextus;
            _resolutorCivisDistantia = resolutorCivisDistantia;
            _abacusDistantiaeVisus = new AbacusDistantiaeVisus(
                distantiaMaxima: _contextus.Configuratio.Custodiae.DistantiaVisaeMaxima,
                distantiaMin: _contextus.Configuratio.Custodiae.DistantiaVisaeMin,
                distantiaMedius: _contextus.Configuratio.Custodiae.DistantiaVisaeMedius,
                praeruptioDistantiaeVisus: _contextus.Configuratio.Custodiae.PraeruptioDistantiaVisae
            );

            _abacusDistantiaeVisusAngli = new AbacusDistantiaeVisus(
                distantiaMaxima: _contextus.Configuratio.Custodiae.DistantiaAnguliVisusMaxima,
                distantiaMin: _contextus.Configuratio.Custodiae.DistantiaAnguliVisusMin,
                distantiaMedius: _contextus.Configuratio.Custodiae.DistantiaAnguliVisusMedius,
                praeruptioDistantiaeVisus: _contextus.Configuratio.Custodiae.PraeruptioDistantiaAnguliVisus
            );

            // 近距離で適用する視野角
            _abacusAnguliVisus0 = new AbacusAnguliVisus(
                angulusMaximaRad: DuxMath.Deg2Rad(_contextus.Configuratio.Custodiae.AngulusVisus0Maxima),
                angulusMinRad: DuxMath.Deg2Rad(_contextus.Configuratio.Custodiae.AngulusVisus0Min),
                angulusMediusRad: DuxMath.Deg2Rad(_contextus.Configuratio.Custodiae.AngulusVisus0Medius),
                praeruptioAnguliVisus: _contextus.Configuratio.Custodiae.PraeruptioAngulusVisus0
            );
            // 遠距離で適用する視野角
            _abacusAnguliVisus1 = new AbacusAnguliVisus(
                angulusMaximaRad: DuxMath.Deg2Rad(_contextus.Configuratio.Custodiae.AngulusVisus1Maxima),
                angulusMinRad: DuxMath.Deg2Rad(_contextus.Configuratio.Custodiae.AngulusVisus1Min),
                angulusMediusRad: DuxMath.Deg2Rad(_contextus.Configuratio.Custodiae.AngulusVisus1Medius),
                praeruptioAnguliVisus: _contextus.Configuratio.Custodiae.PraeruptioAngulusVisus1
            );

            _cIDPuellaeResVisaeCapitis = (IDPuellaeResVisaeCapitis[])Enum.GetValues(typeof(IDPuellaeResVisaeCapitis));
            _cIDPuellaeResVisaePectoris = (IDPuellaeResVisaePectoris[])Enum.GetValues(typeof(IDPuellaeResVisaePectoris));
            _cIDPuellaeResVisaeNatium = (IDPuellaeResVisaeNatium[])Enum.GetValues(typeof(IDPuellaeResVisaeNatium));

            _visaIctuumCapitis = new float[contextus.Civis.Longitudo];
            _visaIctuumCorporis = new float[contextus.Civis.Longitudo];

            for (int i = 0; i < contextus.Civis.Longitudo; i++) {
                _visaIctuumCapitis[i] = 0f;
                _visaIctuumCorporis[i] = 0f;
            }
        }

        public float VisaCapitis(int idCivis) => _visaIctuumCapitis[idCivis];
        public float VisaCorporis(int idCivis) => _visaIctuumCorporis[idCivis];
        public bool EstVisa(int idCivis) => _visaIctuumCapitis[idCivis] + _visaIctuumCorporis[idCivis] > Numerus.Epsilon;

        public void Initare(int idCivis) {
            _visaIctuumCapitis[idCivis] = 0f;
            _visaIctuumCorporis[idCivis] = 0f;
        }

        // 距離による視力レシオを計算する。
        private float ComputareRatioDistantia(
            Vector3 positioCivisCapitis, // 頭の位置
            Vector3 positioPuellaeResVisae  // 視認対象の位置
        ) {
            float ratioDistantia = _abacusDistantiaeVisus.ComputareRatioInversus(positioCivisCapitis, positioPuellaeResVisae);
            return ratioDistantia;
        }
         
        // 視野角による視力レシオを計算する。
        private float ComputareRatioAngulus(
            Vector3 positioCivisCapitis, // 頭の位置
            Vector3 positioPuellaeResVisae, // 視認対象の位置
            Vector3 directioCivisCapitis // 頭の方向(視線)
        ) {
            // Capitis -> PuellaeResVisaeのDirectioを計算
            Vector3 directio = positioPuellaeResVisae - positioCivisCapitis;
            // ゼロベクトル回避
            if (directio.LengthSquared() < Numerus.EpsilonSq) return 1f;

            float ratioDistantia = _abacusDistantiaeVisusAngli.ComputareRatioInversus(positioCivisCapitis, positioPuellaeResVisae);
            // angulusMaximaで0、angulusMinで1となるように逆補正を使う
            float ratioAngulus0 = _abacusAnguliVisus0.ComputareRatioInversus(directioCivisCapitis, directio);
            float ratioAngulus1 = _abacusAnguliVisus1.ComputareRatioInversus(directioCivisCapitis, directio);

            // anglulus0が近距離、anglulus1が遠距離の補正値。
            float ratio = DuxMath.Lerp(ratioAngulus1, ratioAngulus0, ratioDistantia);

            UnityEngine.Debug.Log($"ratioDistantia: {ratioDistantia}, ratioAngulus0: {ratioAngulus0}, ratioAngulus1: {ratioAngulus1}, ratio: {ratio}");
            return ratio;
        }

        private float ComputareVisaIctuum(
            int idCivis, 
            float visus, // ベース視力
            Vector3 positioResVisae, // 視認対象の位置
            Vector3 positioCivisCapitis,
            Vector3 directioCivisCapitis
        ) {
            if (!_contextus.Visa.EstVisa(idCivis, positioResVisae)) return 0f;

            float ratioDistantia = ComputareRatioDistantia(positioCivisCapitis, positioResVisae);
            float ratioAngulus = ComputareRatioAngulus(positioCivisCapitis, positioResVisae, directioCivisCapitis);

            float visa = visus * ratioDistantia * ratioAngulus;
            return visa;
        }
        private float ComputareVisaIctuum(
            int idCivis,
            float visus, // ベース視力
            IDPuellaeResVisaeCapitis idCapitis,
            Vector3 positioCivisCapitis,
            Vector3 directioCivisCapitis
        ) {
            Vector3 positioResVisae = default;
            if (!_contextus.PuellaeResVisae.ConareLegoCapitis(idCapitis, out positioResVisae)) return 0f;
            return ComputareVisaIctuum(idCivis, visus, positioResVisae, positioCivisCapitis, directioCivisCapitis);
        }
        private float ComputareVisaIctuum(
            int idCivis,
            float visus, // ベース視力
            IDPuellaeResVisaePectoris idPectoris,
            Vector3 positioCivisCapitis,
            Vector3 directioCivisCapitis
        ) {
            Vector3 positioResVisae = default;
            if (!_contextus.PuellaeResVisae.ConareLegoPectoris(idPectoris, out positioResVisae)) return 0f;
            return ComputareVisaIctuum(idCivis, visus, positioResVisae, positioCivisCapitis, directioCivisCapitis);
        }
        private float ComputareVisaIctuum(
            int idCivis,
            float visus, // ベース視力
            IDPuellaeResVisaeNatium idNatium,
            Vector3 positioCivisCapitis,
            Vector3 directioCivisCapitis
        ) {
            Vector3 positioResVisae = default;
            if (!_contextus.PuellaeResVisae.ConareLegoNatium(idNatium, out positioResVisae)) return 0f;
            return ComputareVisaIctuum(idCivis, visus, positioResVisae, positioCivisCapitis, directioCivisCapitis);
        }

        // 視認度を計算する。
        // !! RayCastが発生する。FixedUpdate内で呼び出し値更新を行うこと。
        // 以下の処理を実行する。
        // 1. 全視認対象に対して、視認判定がTrueの場合、以下の値を算出する。
        //    - ベース視力(visus) * 距離によるレシオ * 視野角によるレシオ
        // 2. 全視認対象で1.を算出し、合計を_visaIctuumCapitisと_visaIctuumCorporisに格納する。
        // 視認度は視認対象(ResVisae)の数によって増減する。多いほど見えやすくなる。
        public void Resolvere(
            int idCivis, IResFluidaCivisLegibile resFluida
        ) {
            // 視認範囲外の場合は視認数を0とする。
            if (!_resolutorCivisDistantia.EstCustodiae(idCivis)) {
                _visaIctuumCapitis[idCivis] = 0f;
                _visaIctuumCorporis[idCivis] = 0f;
                return;
            }

            Vector3 positioCivisCapitis = default;
            Vector3 directioCivisCapitis = default;

            if (!(
                _contextus.Visa.ConareLegoPositioCapitis(idCivis, out positioCivisCapitis) && 
                _contextus.Visa.ConareLegoDirectioCapitis(idCivis, out directioCivisCapitis)
            )) {
                Memorator.MemorareErrorum(IDErrorum.RESOLUTORCIVISICTUUM_CONARELEGO_FAILED);
                _visaIctuumCapitis[idCivis] = 0f;
                _visaIctuumCorporis[idCivis] = 0f;
                return;
            }

            float visus = resFluida.Veletudinis.Visus(idCivis);
            float summaVisaIctuumCapitis = 0f;
            float summaVisaIctuumCorporis = 0f;

            foreach (IDPuellaeResVisaeCapitis idCapitis in _cIDPuellaeResVisaeCapitis) {
                float visa = ComputareVisaIctuum(idCivis, visus, idCapitis, positioCivisCapitis, directioCivisCapitis);
                summaVisaIctuumCapitis += visa;
            }
            foreach (IDPuellaeResVisaePectoris idPectoris in _cIDPuellaeResVisaePectoris) {
                float visa = ComputareVisaIctuum(idCivis, visus, idPectoris, positioCivisCapitis, directioCivisCapitis);
                summaVisaIctuumCorporis += visa;
            }
            foreach (IDPuellaeResVisaeNatium idNatium in _cIDPuellaeResVisaeNatium) {
                float visa = ComputareVisaIctuum(idCivis, visus, idNatium, positioCivisCapitis, directioCivisCapitis);
                summaVisaIctuumCorporis += visa;
            }

            _visaIctuumCapitis[idCivis] = summaVisaIctuumCapitis;
            _visaIctuumCorporis[idCivis] = summaVisaIctuumCorporis;
        }
    }
}
