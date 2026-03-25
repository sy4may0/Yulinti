using System.Numerics;
using Yulinti.ImperiumDelegatum.Contractus;
using System;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ResolutorCivisIctuumVisae : IResolutorCivisIctuumVisae {
        private readonly IConfiguratioCivisCustodiae _configuratioCivisCustodiae;
        private readonly IOstiumCivisLegibile _civis;
        private readonly IOstiumCivisVisaeLegibile _visa;
        private readonly IOstiumPuellaeResVisaeLegibile _puellaeResVisae;
        private readonly AbacusDistantiae _abacusDistantiaeVisus;

        // 角度補正の合成用
        // _abacusDistantiaeVisusAngliが0 -> 1に増加するにつれ、AnguliVisus0からAnguliVisus1への補正が増加する。
        private readonly AbacusDistantiae _abacusDistantiaeVisusAngli;
        private readonly AbacusAnguli _abacusAnguliVisus0;
        private readonly AbacusAnguli _abacusAnguliVisus1;

        private readonly IDPuellaeResVisaeCapitis[] _cIDPuellaeResVisaeCapitis;
        private readonly IDPuellaeResVisaePectoris[] _cIDPuellaeResVisaePectoris;
        private readonly IDPuellaeResVisaeNatium[] _cIDPuellaeResVisaeNatium;

        private readonly float[] _visaIctuumCapitis;
        private readonly float[] _visaIctuumCorporis;

        private readonly IResolutorCivisDistantia _resolutorCivisDistantia;

        public ResolutorCivisIctuumVisae(
            IConfiguratioCivisCustodiae configuratioCivisCustodiae,
            IOstiumCivisLegibile civis,
            IOstiumCivisVisaeLegibile visa,
            IOstiumPuellaeResVisaeLegibile puellaeResVisae,
            IResolutorCivisDistantia resolutorCivisDistantia
        ) {
            _configuratioCivisCustodiae = configuratioCivisCustodiae;
            _civis = civis;
            _visa = visa;
            _puellaeResVisae = puellaeResVisae;
            _resolutorCivisDistantia = resolutorCivisDistantia;
            _abacusDistantiaeVisus = new AbacusDistantiae(
                _configuratioCivisCustodiae.DistantiaVisaeMaxima,
                _configuratioCivisCustodiae.DistantiaVisaeMin,
                _configuratioCivisCustodiae.DistantiaVisaeMedius,
                _configuratioCivisCustodiae.PraeruptioDistantiaVisae
            );

            _abacusDistantiaeVisusAngli = new AbacusDistantiae(
                _configuratioCivisCustodiae.DistantiaAnguliVisusMaxima,
                _configuratioCivisCustodiae.DistantiaAnguliVisusMin,
                _configuratioCivisCustodiae.DistantiaAnguliVisusMedius,
                _configuratioCivisCustodiae.PraeruptioDistantiaAnguliVisus
            );

            // 近距離で適用する視野角
            _abacusAnguliVisus0 = new AbacusAnguli(
                Mathematica.Deg2Rad(_configuratioCivisCustodiae.AngulusVisus0Maxima),
                Mathematica.Deg2Rad(_configuratioCivisCustodiae.AngulusVisus0Min),
                Mathematica.Deg2Rad(_configuratioCivisCustodiae.AngulusVisus0Medius),
                _configuratioCivisCustodiae.PraeruptioAngulusVisus0
            );
            // 遠距離で適用する視野角
            _abacusAnguliVisus1 = new AbacusAnguli(
                Mathematica.Deg2Rad(_configuratioCivisCustodiae.AngulusVisus1Maxima),
                Mathematica.Deg2Rad(_configuratioCivisCustodiae.AngulusVisus1Min),
                Mathematica.Deg2Rad(_configuratioCivisCustodiae.AngulusVisus1Medius),
                _configuratioCivisCustodiae.PraeruptioAngulusVisus1
            );

            _cIDPuellaeResVisaeCapitis = (IDPuellaeResVisaeCapitis[])Enum.GetValues(typeof(IDPuellaeResVisaeCapitis));
            _cIDPuellaeResVisaePectoris = (IDPuellaeResVisaePectoris[])Enum.GetValues(typeof(IDPuellaeResVisaePectoris));
            _cIDPuellaeResVisaeNatium = (IDPuellaeResVisaeNatium[])Enum.GetValues(typeof(IDPuellaeResVisaeNatium));

            _visaIctuumCapitis = new float[_civis.Longitudo];
            _visaIctuumCorporis = new float[_civis.Longitudo];

            for (int i = 0; i < _civis.Longitudo; i++) {
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
            float ratioDistantia = _abacusDistantiaeVisus.ComputareRatioVectorialisInversus(positioCivisCapitis, positioPuellaeResVisae);
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

            float ratioDistantia = _abacusDistantiaeVisusAngli.ComputareRatioVectorialisInversus(positioCivisCapitis, positioPuellaeResVisae);
            // angulusMaximaで0、angulusMinで1となるように逆補正を使う
            float ratioAngulus0 = _abacusAnguliVisus0.ComputareRatioVectorialisInversus(directioCivisCapitis, directio);
            float ratioAngulus1 = _abacusAnguliVisus1.ComputareRatioVectorialisInversus(directioCivisCapitis, directio);

            // anglulus0が近距離、anglulus1が遠距離の補正値。
            float ratio = Mathematica.Lerp01(ratioAngulus1, ratioAngulus0, ratioDistantia);

            return ratio;
        }

        private float ComputareVisaIctuum(
            int idCivis, 
            float visus, // ベース視力
            Vector3 positioResVisae, // 視認対象の位置
            Vector3 positioCivisCapitis,
            Vector3 directioCivisCapitis
        ) {
            if (!_visa.EstVisa(idCivis, positioResVisae)) return 0f;

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
            if (!_puellaeResVisae.ConareLegoCapitis(idCapitis, out positioResVisae)) return 0f;
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
            if (!_puellaeResVisae.ConareLegoPectoris(idPectoris, out positioResVisae)) return 0f;
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
            if (!_puellaeResVisae.ConareLegoNatium(idNatium, out positioResVisae)) return 0f;
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
            if (!_resolutorCivisDistantia.EstCustodiaeVisae(idCivis)) {
                _visaIctuumCapitis[idCivis] = 0f;
                _visaIctuumCorporis[idCivis] = 0f;
                return;
            }

            Vector3 positioCivisCapitis = default;
            Vector3 directioCivisCapitis = default;

            if (!(
                _visa.ConareLegoPositioCapitis(idCivis, out positioCivisCapitis) && 
                _visa.ConareLegoDirectioCapitis(idCivis, out directioCivisCapitis)
            )) {
                Notarius.Memorare(LogTextus.ResolutorCivisIctuumVisae_RESOLUTORCIVISICTUUM_CONARELEGO_FAILED);
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
