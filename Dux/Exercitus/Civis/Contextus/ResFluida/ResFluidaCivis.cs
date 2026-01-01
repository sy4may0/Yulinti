using Yulinti.Dux.ContractusDucis;
using System;

namespace Yulinti.Dux.Exercitus {
    internal sealed class ResFluidaCivis {
        // 基本情報
        private readonly int _idCivis;
        private int _vitae;
        private bool _estDominare;

        // ステート情報
        private IDCivisStatusNavmesh _idStatusNavmeshActualis;
        private IDCivisStatusNavmesh _idStatusNavmeshProximus;

        // 移動情報
        private bool _estNavmesh;
        private int _idPunctumViaeActualis;
        private int _idPunctumViaeProximus;
        private float _velocitasActualisHorizontalis;
        private float _velocitasActualisVerticalis;
        private float _rotatioYActualis;
        private bool _estInTerra;

        public ResFluidaCivis() {
            _vitae = 100;
            _estDominare = false;

            _idStatusNavmeshActualis = IDCivisStatusNavmesh.None;
            _idStatusNavmeshProximus = IDCivisStatusNavmesh.None;

            _estNavmesh = false;
            _idPunctumViaeActualis = -1;
            _idPunctumViaeProximus = -1;
            _velocitasActualisHorizontalis = 0f;
            _velocitasActualisVerticalis = -2f;
            _rotatioYActualis = 0f;
            _estInTerra = true;
        }

        public int IDCivis => _idCivis;
        public int Vitae => _vitae;
        public bool EstDominare => _estDominare;

        public IDCivisStatusNavmesh IDStatusNavmeshActualis => _idStatusNavmeshActualis;
        public IDCivisStatusNavmesh IDStatusNavmeshProximus => _idStatusNavmeshProximus;

        public int IDPunctumViaeActualis => _idPunctumViaeActualis;
        public int IDPunctumViaeProximus => _idPunctumViaeProximus;
        public float VelocitasActualisHorizontalis => _velocitasActualisHorizontalis;
        public float VelocitasActualisVerticalis => _velocitasActualisVerticalis;
        public float RotatioYActualis => _rotatioYActualis;
        public bool EstInTerra => _estInTerra;

        public void Dominare() {
            _estDominare = true;
        }

        public void Liberare() {
            _estDominare = false;
        }

        public void AddereVitae(int vita) {
            _vitae = (int)Math.Clamp(_vitae + vita, 0, 100);
        }

        public bool EstExhaurita() {
            return _vitae <= 0;
        }

        public void RenovareBasis(
            int vitae,
            bool estDominare
        ) {
            _vitae = vitae;
            _estDominare = estDominare;
        }

        public void RenovareStatus(
            IDCivisStatusNavmesh idStatusNavmeshActualis,
            IDCivisStatusNavmesh idStatusNavmeshProximus
        ) {
            _idStatusNavmeshActualis = idStatusNavmeshActualis;
            _idStatusNavmeshProximus = idStatusNavmeshProximus;
        }

        public void RenovareMotus(
            bool estNavmesh,
            int idPunctumViaeActualis,
            int idPunctumViaeProximus,
            float velocitasActualisHorizontalis,
            float velocitasActualisVerticalis,
            float rotatioYActualis,
            bool estInTerra
        ) {
            _estNavmesh = estNavmesh;
            _idPunctumViaeActualis = idPunctumViaeActualis;
            _idPunctumViaeProximus = idPunctumViaeProximus;
            _velocitasActualisHorizontalis = velocitasActualisHorizontalis;
            _velocitasActualisVerticalis = velocitasActualisVerticalis;
            _rotatioYActualis = rotatioYActualis;
            _estInTerra = estInTerra;
        }
    }
}