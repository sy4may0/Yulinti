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
            GUI.Label(new Rect(10, 50, 300, 20), "Civis0 Suspecta: " + _resFCivisVeletudinis.Suspecta(0));
            GUI.Label(new Rect(10, 70, 300, 20), "Civis0 EstVigilantia: " + _resFCivisVeletudinis.EstVigilantia(0));
            GUI.Label(new Rect(10, 90, 300, 20), "Civis0 EstDetectio: " + _resFCivisVeletudinis.EstDetectio(0));

            GUI.Label(new Rect(10, 110, 300, 20), "Puellae Vigor: " + _resFPuellaeVeletudinis.Vigor);
            GUI.Label(new Rect(10, 130, 300, 20), "Puellae Patientia: " + _resFPuellaeVeletudinis.Patientia);
            GUI.Label(new Rect(10, 150, 300, 20), "Puellae Claritas: " + _resFPuellaeVeletudinis.Claritas);
            GUI.Label(new Rect(10, 170, 300, 20), "Puellae Aether: " + _resFPuellaeVeletudinis.Aether);
            GUI.Label(new Rect(10, 190, 300, 20), "Puellae Intentio: " + _resFPuellaeVeletudinis.Intentio);
            GUI.Label(new Rect(10, 210, 300, 20), "Puellae EstNudusAnterior: " + _resFPuellaeVeletudinis.EstNudusAnterior);
            GUI.Label(new Rect(10, 230, 300, 20), "Puellae EstNudusPosterior: " + _resFPuellaeVeletudinis.EstNudusPosterior);

            GUI.Label(new Rect(10, 250, 300, 20), "Civis0 EstSpectareNudusAnterior: " + _resFCivisVeletudinis.EstSpectareNudusAnterior(0));
            GUI.Label(new Rect(10, 270, 300, 20), "Civis0 EstSpectareNudusPosterior: " + _resFCivisVeletudinis.EstSpectareNudusPosterior(0));

            GUI.Label(new Rect(10, 290, 300, 20), "Puellae SonusQuietes: " + _resFPuellaeVeletudinis.SonusQuietes);
            GUI.Label(new Rect(10, 310, 300, 20), "Puellae SonusMotus: " + _resFPuellaeVeletudinis.SonusMotus);

            GUI.Label(new Rect(10, 330, 300, 20), "Civis0 Audita: " + _resFCivisVeletudinis.Audita(0));
            GUI.Label(new Rect(10, 350, 300, 20), "Civis0 EstDetectioSonora: " + _resFCivisVeletudinis.EstDetectioSonora(0));
            GUI.Label(new Rect(10, 370, 300, 20), "Civis0 EstSuspecta: " + _resFCivisVeletudinis.EstSuspecta(0));
        }

        public void Activare() {
            _estActivum = true;
        }

        public void Deactivare() {
            _estActivum = false;
        }
    }
}