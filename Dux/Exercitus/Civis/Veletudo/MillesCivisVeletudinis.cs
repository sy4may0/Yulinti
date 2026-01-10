using Yulinti.Dux.ContractusDucis;
using System;

namespace Yulinti.Dux.Exercitus {
    internal sealed class MilesCivisVeletudinis {
        private readonly ContextusCivisOstiorumLegibile _contextus;
        private readonly IOstiumCivisMutabile _ostiumCivisMut;
        private float[] _phantasmaVitae;
        private float[] _phantasmaVisa;
        private bool[] _phantasmaEstVigilantia;
        private bool[] _phantasmaEstDetectio;

        public MilesCivisVeletudinis(
            ContextusCivisOstiorumLegibile contextusOstiorum,
            IOstiumCivisMutabile ostiumCivisMut
        ) {
            _contextus = contextusOstiorum;
            _ostiumCivisMut = ostiumCivisMut;
            _phantasmaVitae = new float[contextusOstiorum.Civis.Longitudo];
            _phantasmaVisa = new float[contextusOstiorum.Civis.Longitudo];
            _phantasmaEstVigilantia = new bool[contextusOstiorum.Civis.Longitudo];
            _phantasmaEstDetectio = new bool[contextusOstiorum.Civis.Longitudo];
        }

        public void InitarePhantasma(ResFluidaCivisVeletudinis resFluida) {
            for (int i = 0; i < _contextus.Civis.Longitudo; i++) {
                if (resFluida.EstDominare(i)) {
                    _phantasmaVitae[i] = resFluida.Vitae(i);
                    _phantasmaVisa[i] = resFluida.Visa(i);
                    _phantasmaEstVigilantia[i] = resFluida.EstVigilantia(i);
                    _phantasmaEstDetectio[i] = resFluida.EstDetectio(i);
                }
            }
        }

        public void Addo(OrdinatioCivisVeletudinisValoris ordinatio) {
            _phantasmaVitae[ordinatio.IdCivis] += ordinatio.DtVitae;
        }

        public void AddoVisa(int idCivis, OrdinatioCivisCustodiaeVisa visa) {
            _phantasmaVisa[idCivis] += visa.DtVisa;
        }

        public void AddDetectio(int idCivis, OrdinatioCivisCustodiaeDetectio detectio) {
            _phantasmaEstVigilantia[idCivis] = detectio.EstVigilantia;
            _phantasmaEstDetectio[idCivis] = detectio.EstDetectio;
        }

        public void Applicare(ResFluidaCivisVeletudinis resFluida) {
            for (int i = 0; i < _contextus.Civis.Longitudo; i++) {
                if (resFluida.EstDominare(i)) {
                    resFluida.RenovareVitae(i, DuxMath.Clamp(_phantasmaVitae[i], 0f, 1f));
                    resFluida.RenovareVisa(i, DuxMath.Clamp(_phantasmaVisa[i], 0f, 1f));
                    resFluida.RenovareVigilantia(i, _phantasmaEstVigilantia[i]);
                    resFluida.RenovareDetectio(i, _phantasmaEstDetectio[i]);
                }
            }
            PurgareAll();
        }

        public void PurgareAll() {
            for (int i = 0; i < _contextus.Civis.Longitudo; i++) {
                Purgare(i);
            }
        }

        public void Purgare(int id) {
            _phantasmaVitae[id] = 1f;
            _phantasmaVisa[id] = 0f;
            _phantasmaEstVigilantia[id] = false;
            _phantasmaEstDetectio[id] = false;
        }

        public void Incarnare(int id) {
            _ostiumCivisMut.Incarnare(id);
        }

        public void Spirituare(int id) {
            _ostiumCivisMut.Spirituare(id);
        }

        public void PonoAdIncarnare(Action<int> adIncarnare) {
            _ostiumCivisMut.PonoAdIncarnare(adIncarnare);
        }

        public void PonoAdSpirituare(Action<int> adSpirituare) {
            _ostiumCivisMut.PonoAdSpirituare(adSpirituare);
        }

        public void ApplicareMors(
            OrdinatioCivisVeletudinisMortis ordinatio,
            ResFluidaCivisVeletudinis resFluida
        ) {
            if (ordinatio.EstIncarnere) {
                Incarnare(ordinatio.IdCivis);
            } else if (ordinatio.EstSpirituare) {
                Spirituare(ordinatio.IdCivis);
            }
        }
    }
}
