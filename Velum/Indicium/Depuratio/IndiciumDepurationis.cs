using UnityEngine;
using Yulinti.Dux.ContractusDucis;
using Yulinti.Velum.ContractusVeli;

namespace Yulinti.Velum.Indicium {
    internal sealed class IndiciumDepurationis : IIndicium {
        private readonly IResFluidaPuellaeVeletudinisLegibile _resFPuellaeVeletudinis;
        private readonly IResFluidaCivisVeletudinisLegibile _resFCivisVeletudinis;

        private bool _estActivum = false;

        // VContainer注入
        public IndiciumDepurationis(
            IResFluidaPuellaeVeletudinisLegibile resFPuellaeVeletudinis,
            IResFluidaCivisVeletudinisLegibile resFCivisVeletudinis
        ) {
            _resFPuellaeVeletudinis = resFPuellaeVeletudinis;
            _resFCivisVeletudinis = resFCivisVeletudinis;
            // Debugは面倒なので最初からActive
            _estActivum = true;
        }

        // 表示
        public void AdIndicium() {
            // デバッグしたい値を逐次変えて表示。
            if (!_estActivum) return;

            GUI.Label(new Rect(10, 10, 300, 20), "Civis0 Visa: " + _resFCivisVeletudinis.Visa(0));
            GUI.Label(new Rect(10, 30, 300, 20), "Civis0 Visus: " + _resFCivisVeletudinis.Visus(0));
            GUI.Label(new Rect(10, 50, 300, 20), "Civis0 EstVigilantia: " + _resFCivisVeletudinis.EstVigilantia(0));
            GUI.Label(new Rect(10, 70, 300, 20), "Civis0 EstDetectio: " + _resFCivisVeletudinis.EstDetectio(0));

            GUI.Label(new Rect(10, 90, 300, 20), "Puellae Vigor: " + _resFPuellaeVeletudinis.Vigor);
        }

        public void Activare() {
            _estActivum = true;
        }

        public void Deactivare() {
            _estActivum = false;
        }
    }
}