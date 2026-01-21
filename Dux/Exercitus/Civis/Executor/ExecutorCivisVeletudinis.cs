using Yulinti.Dux.ContractusDucis;
using Yulinti.Nucleus;

namespace Yulinti.Dux.Exercitus {
    internal sealed class PhantasmaCivisVeletudinis {
        private float[] _phantasmaVitae;
        private float[] _phantasmaVisus;
        private float[] _phantasmaVisa;
        private float[] _phantasmaAudita;
        private float[] _phantasmaSuspecta;

        private float _vitaeMaxima;
        private float _visusMaxima;
        private float _visaMaxima;
        private float _auditaMaxima;
        private float _suspectaMaxima;

        public PhantasmaCivisVeletudinis(int longitudo) {
            _phantasmaVitae = new float[longitudo];
            _phantasmaVisus = new float[longitudo];
            _phantasmaVisa = new float[longitudo];
            _phantasmaAudita = new float[longitudo];
            _phantasmaSuspecta = new float[longitudo];
            _vitaeMaxima = 1f;
            _visusMaxima = 1f;
            _visaMaxima = 1f;
            _auditaMaxima = 1f;
            _suspectaMaxima = 1f;

            for (int i = 0; i < longitudo; i++) {
                _phantasmaVitae[i] = 1f;
                _phantasmaVisus[i] = 0f;
                _phantasmaVisa[i] = 0f;
                _phantasmaAudita[i] = 0f;
                _phantasmaSuspecta[i] = 0f;
            }
        }
        public float PhantasmaVitae(int idCivis) {
            return _phantasmaVitae[idCivis];
        }
        public float PhantasmaVisus(int idCivis) {
            return _phantasmaVisus[idCivis];
        }
        public float PhantasmaVisa(int idCivis) {
            return _phantasmaVisa[idCivis];
        }
        public float PhantasmaAudita(int idCivis) {
            return _phantasmaAudita[idCivis];
        }
        public float PhantasmaSuspecta(int idCivis) {
            return _phantasmaSuspecta[idCivis];
        }

        public void Addo(
            int idCivis,
            float dtVitae = 0f,
            float dtVisus = 0f,
            float dtVisa = 0f,
            float dtAudita = 0f,
            float dtSuspecta = 0f
        ) {
            _phantasmaVitae[idCivis] = DuxMath.Clamp(_phantasmaVitae[idCivis] + dtVitae, 0f, _vitaeMaxima);
            _phantasmaVisus[idCivis] = DuxMath.Clamp(_phantasmaVisus[idCivis] + dtVisus, 0f, _visusMaxima);
            _phantasmaVisa[idCivis] = DuxMath.Clamp(_phantasmaVisa[idCivis] + dtVisa, 0f, _visaMaxima);
            _phantasmaAudita[idCivis] = DuxMath.Clamp(_phantasmaAudita[idCivis] + dtAudita, 0f, _auditaMaxima);
            _phantasmaSuspecta[idCivis] = DuxMath.Clamp(_phantasmaSuspecta[idCivis] + dtSuspecta, 0f, _suspectaMaxima);
        }

        public void Pono(
            int idCivis,
            float vitae,
            float visus,
            float visa,
            float audita,
            float suspecta
        ) {
            _phantasmaVitae[idCivis] = DuxMath.Clamp(vitae, 0f, _vitaeMaxima);
            _phantasmaVisus[idCivis] = DuxMath.Clamp(visus, 0f, _visusMaxima);
            _phantasmaVisa[idCivis] = DuxMath.Clamp(visa, 0f, _visaMaxima);
            _phantasmaAudita[idCivis] = DuxMath.Clamp(audita, 0f, _auditaMaxima);
            _phantasmaSuspecta[idCivis] = DuxMath.Clamp(suspecta, 0f, _suspectaMaxima);
        }
    }

    internal sealed class ExecutorCivisVeletudinis : IExecutorCivis {
        private readonly IConfiguratioCivisCustodiae _configuratioCivisCustodiae;
        private readonly IOstiumCivisLegibile _ostiumCivisLegibile;
        private readonly ResFluidaCivisVeletudinis _resFluidaVeletudinis;

        private readonly DuxQueue<IOrdinatioCivisVeletudinisCondicionis>[] _queueVeletudinisCondicionis;
        private readonly PhantasmaCivisVeletudinis _phantasma;

        public ExecutorCivisVeletudinis(
            IConfiguratioExercitusCivis configuratioExercitusCivis,
            ResFluidaCivisVeletudinis resFluidaVeletudinis,
            IOstiumCivisLegibile ostiumCivisLegibile
        ) {
            _configuratioCivisCustodiae = configuratioExercitusCivis.Custodiae;
            _resFluidaVeletudinis = resFluidaVeletudinis;
            _ostiumCivisLegibile = ostiumCivisLegibile;
            _phantasma = new PhantasmaCivisVeletudinis(resFluidaVeletudinis.Longitudo);
            _queueVeletudinisCondicionis = new DuxQueue<IOrdinatioCivisVeletudinisCondicionis>[_ostiumCivisLegibile.Longitudo];
            for (int i = 0; i < _ostiumCivisLegibile.Longitudo; i++) {
                _queueVeletudinisCondicionis[i] = new DuxQueue<IOrdinatioCivisVeletudinisCondicionis>(ConstansCivis.LongitudoOrdinatioVeletudinisCondicionis);
            }
        }

        // Incarnare時にこれを実行する。
        // - Phantasma初期化
        // - resFluida初期化
        // - Dominare
        public void Initare(int idCivis) {
            _queueVeletudinisCondicionis[idCivis].Purgere();
            _phantasma.Pono(
                idCivis,
                vitae: 1f,
                visus: 0f, 
                visa: 0f,
                audita: 0f,
                suspecta: 0f
            );
            _resFluidaVeletudinis.Purgare(idCivis);
            _resFluidaVeletudinis.Dominare(idCivis);
        }

        public void Primum(int idCivis) {
            _queueVeletudinisCondicionis[idCivis].Purgere();
            _phantasma.Pono(
                idCivis,
                vitae: _resFluidaVeletudinis.Vitae(idCivis),
                visus: 0f, // 視力はフレーム毎に加算して固定値を取る。
                visa: _resFluidaVeletudinis.Visa(idCivis),
                audita: _resFluidaVeletudinis.Audita(idCivis),
                suspecta: _resFluidaVeletudinis.Suspecta(idCivis)
            );
        }

        public void Executare(int idCivis, IOrdinatioCivisVeletudinisValoris veletudinisValoris) {
            _phantasma.Addo(
                idCivis,
                dtVitae: veletudinisValoris.DtVitae,
                dtVisus: veletudinisValoris.DtVisus,
                dtVisa: veletudinisValoris.DtVisa,
                dtAudita: veletudinisValoris.DtAudita,
                dtSuspecta: veletudinisValoris.DtSuspecta
            );
        }

        public void Executare(int idCivis, IOrdinatioCivisVeletudinisCondicionis veletudinisCondicionis) {
            if (!_queueVeletudinisCondicionis[idCivis].ConarePono(veletudinisCondicionis)) {
                Memorator.MemorareErrorum(IDErrorum.EXECUTORCIVISVELETUDINISVALORIS_ORDINATIO_QUEUE_FULL);
                return;
            }
        }

        private void ApplicarePhantasma(int idCivis) {
            _resFluidaVeletudinis.RenovareValoris(
                idCivis,
                vitae: _phantasma.PhantasmaVitae(idCivis),
                visus: _phantasma.PhantasmaVisus(idCivis),
                visa: _phantasma.PhantasmaVisa(idCivis),
                audita: _phantasma.PhantasmaAudita(idCivis),
                suspecta: _phantasma.PhantasmaSuspecta(idCivis)
            );
        }

        private void ApplicareSpectare(int idCivis) {
            while (_queueVeletudinisCondicionis[idCivis].ConareLego(out var s)) {
                _resFluidaVeletudinis.RenovareCondicionis(
                    idCivis,
                    estVigilantia: s.EstVigilantia,
                    estDetectio: s.EstDetectio,
                    estAudivi: s.EstAudivi,
                    estSuspecta: s.EstSuspecta,
                    estSpectareNudusAnterior: s.EstSpectareNudusAnterior,
                    estSpectareNudusPosterior: s.EstSpectareNudusPosterior
                );
            }
        }

        public void Confirmare(int idCivis) {
            ApplicarePhantasma(idCivis);
            ApplicareSpectare(idCivis);
        }

        // Spirituare時にこれを実行する。
        // - Phantasma初期化
        // - resFluida初期化
        // - Liberare
        public void Purgare(int idCivis) {
            _phantasma.Pono(
                idCivis,
                vitae: 1f,
                visus: 0f,
                visa: 0f,
                audita: 0f,
                suspecta: 0f
            );
            _queueVeletudinisCondicionis[idCivis].Purgere();
            _resFluidaVeletudinis.Purgare(idCivis);
            _resFluidaVeletudinis.Liberare(idCivis);
        }
    }
}
