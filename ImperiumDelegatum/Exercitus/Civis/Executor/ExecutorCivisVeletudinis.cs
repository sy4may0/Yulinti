using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

// 全体設計: このクラスでClampしない。Maximaは見ない。Clampは反映時にResFluidaが行う。

namespace Yulinti.ImperiumDelegatum.Exercitus {
    // 値タイプつきの値。
    internal sealed class ValorisCivisVeletudinis {
        public float Valor { get; set; }
        private TypusValoris _typusValoris;

        public ValorisCivisVeletudinis(float valor, TypusValoris typusValoris) {
            Valor = valor;
            _typusValoris = typusValoris;
        }

        public TypusValoris TypusValoris => _typusValoris;
    }

    internal sealed class PhantasmaCivisVeletudinis {
        private ValorisCivisVeletudinis[] _phantasmaVitae;
        private ValorisCivisVeletudinis[] _phantasmaVisus;
        private ValorisCivisVeletudinis[] _phantasmaVisa;
        private ValorisCivisVeletudinis[] _phantasmaAuditus;
        private ValorisCivisVeletudinis[] _phantasmaAudita;
        private ValorisCivisVeletudinis[] _phantasmaSuspecta;
        private ValorisCivisVeletudinis[] _phantasmaStudium;
        private ValorisCivisVeletudinis[] _phantasmaIntentio;
        private ValorisCivisVeletudinis[] _phantasmaTorelantiaAnomaliaeMaxima;
        private ValorisCivisVeletudinis[] _phantasmaTorelantiaAnomaliaeMinima;

        private ValorisCivisVeletudinis[] _phantasmaVitaeMaxima;
        private ValorisCivisVeletudinis[] _phantasmaVisusMaxima;
        private ValorisCivisVeletudinis[] _phantasmaVisaMaxima;
        private ValorisCivisVeletudinis[] _phantasmaAuditusMaxima;
        private ValorisCivisVeletudinis[] _phantasmaAuditaMaxima;
        private ValorisCivisVeletudinis[] _phantasmaSuspectaMaxima;
        private ValorisCivisVeletudinis[] _phantasmaStudiumMaxima;
        private ValorisCivisVeletudinis[] _phantasmaIntentioMaxima;
        private ValorisCivisVeletudinis[] _phantasmaTorelantiaAnomaliaeMaximaMaxima;
        private ValorisCivisVeletudinis[] _phantasmaTorelantiaAnomaliaeMinimaMaxima;

        public PhantasmaCivisVeletudinis(int longitudo) {
            _phantasmaVitae = new ValorisCivisVeletudinis[longitudo];
            _phantasmaVisus = new ValorisCivisVeletudinis[longitudo];
            _phantasmaVisa = new ValorisCivisVeletudinis[longitudo];
            _phantasmaAuditus = new ValorisCivisVeletudinis[longitudo];
            _phantasmaAudita = new ValorisCivisVeletudinis[longitudo];
            _phantasmaSuspecta = new ValorisCivisVeletudinis[longitudo];
            _phantasmaStudium = new ValorisCivisVeletudinis[longitudo];
            _phantasmaIntentio = new ValorisCivisVeletudinis[longitudo];
            _phantasmaTorelantiaAnomaliaeMaxima = new ValorisCivisVeletudinis[longitudo];
            _phantasmaTorelantiaAnomaliaeMinima = new ValorisCivisVeletudinis[longitudo];

            _phantasmaVitaeMaxima = new ValorisCivisVeletudinis[longitudo];
            _phantasmaVisusMaxima = new ValorisCivisVeletudinis[longitudo];
            _phantasmaVisaMaxima = new ValorisCivisVeletudinis[longitudo];
            _phantasmaAuditusMaxima = new ValorisCivisVeletudinis[longitudo];
            _phantasmaAuditaMaxima = new ValorisCivisVeletudinis[longitudo];
            _phantasmaSuspectaMaxima = new ValorisCivisVeletudinis[longitudo];
            _phantasmaStudiumMaxima = new ValorisCivisVeletudinis[longitudo];
            _phantasmaIntentioMaxima = new ValorisCivisVeletudinis[longitudo];
            _phantasmaTorelantiaAnomaliaeMaximaMaxima = new ValorisCivisVeletudinis[longitudo];
            _phantasmaTorelantiaAnomaliaeMinimaMaxima = new ValorisCivisVeletudinis[longitudo];

            for (int i = 0; i < longitudo; i++) {
                _phantasmaVitae[i] = new ValorisCivisVeletudinis(0f, TypusValoris.Fluidus);
                _phantasmaVisus[i] = new ValorisCivisVeletudinis(0f, TypusValoris.Fixus);
                _phantasmaVisa[i] = new ValorisCivisVeletudinis(0f, TypusValoris.Fluidus);
                _phantasmaAuditus[i] = new ValorisCivisVeletudinis(0f, TypusValoris.Fixus);
                _phantasmaAudita[i] = new ValorisCivisVeletudinis(0f, TypusValoris.Fluidus);
                _phantasmaSuspecta[i] = new ValorisCivisVeletudinis(0f, TypusValoris.Fluidus);
                _phantasmaStudium[i] = new ValorisCivisVeletudinis(0f, TypusValoris.Fluidus);
                _phantasmaIntentio[i] = new ValorisCivisVeletudinis(0f, TypusValoris.Fluidus);
                _phantasmaTorelantiaAnomaliaeMaxima[i] = new ValorisCivisVeletudinis(0f, TypusValoris.Fixus);
                _phantasmaTorelantiaAnomaliaeMinima[i] = new ValorisCivisVeletudinis(0f, TypusValoris.Fixus);

                // CivisのMaximaも毎フレームMilesが再計算するためFixus。
                _phantasmaVitaeMaxima[i] = new ValorisCivisVeletudinis(1f, TypusValoris.Fixus);
                _phantasmaVisusMaxima[i] = new ValorisCivisVeletudinis(1f, TypusValoris.Fixus);
                _phantasmaVisaMaxima[i] = new ValorisCivisVeletudinis(1f, TypusValoris.Fixus);
                _phantasmaAuditusMaxima[i] = new ValorisCivisVeletudinis(1f, TypusValoris.Fixus);
                _phantasmaAuditaMaxima[i] = new ValorisCivisVeletudinis(1f, TypusValoris.Fixus);
                _phantasmaSuspectaMaxima[i] = new ValorisCivisVeletudinis(1f, TypusValoris.Fixus);
                _phantasmaStudiumMaxima[i] = new ValorisCivisVeletudinis(1f, TypusValoris.Fixus);
                _phantasmaIntentioMaxima[i] = new ValorisCivisVeletudinis(1f, TypusValoris.Fixus);
                _phantasmaTorelantiaAnomaliaeMaximaMaxima[i] = new ValorisCivisVeletudinis(1f, TypusValoris.Fixus);
                _phantasmaTorelantiaAnomaliaeMinimaMaxima[i] = new ValorisCivisVeletudinis(1f, TypusValoris.Fixus);
            }
        }

        public float PhantasmaVitae(int idCivis) => _phantasmaVitae[idCivis].Valor;
        public float PhantasmaVisus(int idCivis) => _phantasmaVisus[idCivis].Valor;
        public float PhantasmaVisa(int idCivis) => _phantasmaVisa[idCivis].Valor;
        public float PhantasmaAuditus(int idCivis) => _phantasmaAuditus[idCivis].Valor;
        public float PhantasmaAudita(int idCivis) => _phantasmaAudita[idCivis].Valor;
        public float PhantasmaSuspecta(int idCivis) => _phantasmaSuspecta[idCivis].Valor;
        public float PhantasmaStudium(int idCivis) => _phantasmaStudium[idCivis].Valor;
        public float PhantasmaIntentio(int idCivis) => _phantasmaIntentio[idCivis].Valor;
        public float PhantasmaTorelantiaAnomaliaeMaxima(int idCivis) => _phantasmaTorelantiaAnomaliaeMaxima[idCivis].Valor;
        public float PhantasmaTorelantiaAnomaliaeMinima(int idCivis) => _phantasmaTorelantiaAnomaliaeMinima[idCivis].Valor;

        public float PhantasmaVitaeMaxima(int idCivis) => _phantasmaVitaeMaxima[idCivis].Valor;
        public float PhantasmaVisusMaxima(int idCivis) => _phantasmaVisusMaxima[idCivis].Valor;
        public float PhantasmaVisaMaxima(int idCivis) => _phantasmaVisaMaxima[idCivis].Valor;
        public float PhantasmaAuditusMaxima(int idCivis) => _phantasmaAuditusMaxima[idCivis].Valor;
        public float PhantasmaAuditaMaxima(int idCivis) => _phantasmaAuditaMaxima[idCivis].Valor;
        public float PhantasmaSuspectaMaxima(int idCivis) => _phantasmaSuspectaMaxima[idCivis].Valor;
        public float PhantasmaStudiumMaxima(int idCivis) => _phantasmaStudiumMaxima[idCivis].Valor;
        public float PhantasmaIntentioMaxima(int idCivis) => _phantasmaIntentioMaxima[idCivis].Valor;
        public float PhantasmaTorelantiaAnomaliaeMaximaMaxima(int idCivis) => _phantasmaTorelantiaAnomaliaeMaximaMaxima[idCivis].Valor;
        public float PhantasmaTorelantiaAnomaliaeMinimaMaxima(int idCivis) => _phantasmaTorelantiaAnomaliaeMinimaMaxima[idCivis].Valor;

        public void Addo(
            int idCivis,
            float dtVitae = 0f,
            float dtVisus = 0f,
            float dtVisa = 0f,
            float dtAuditus = 0f,
            float dtAudita = 0f,
            float dtSuspecta = 0f,
            float dtStudium = 0f,
            float dtIntentio = 0f,
            float dtTorelantiaAnomaliaeMaxima = 0f,
            float dtTorelantiaAnomaliaeMinima = 0f,
            float dtVitaeMaxima = 0f,
            float dtVisusMaxima = 0f,
            float dtVisaMaxima = 0f,
            float dtAuditusMaxima = 0f,
            float dtAuditaMaxima = 0f,
            float dtSuspectaMaxima = 0f,
            float dtStudiumMaxima = 0f,
            float dtIntentioMaxima = 0f,
            float dtTorelantiaAnomaliaeMaximaMaxima = 0f,
            float dtTorelantiaAnomaliaeMinimaMaxima = 0f
        ) {
            _phantasmaVitae[idCivis].Valor = _phantasmaVitae[idCivis].Valor + dtVitae;
            _phantasmaVisus[idCivis].Valor = _phantasmaVisus[idCivis].Valor + dtVisus;
            _phantasmaVisa[idCivis].Valor = _phantasmaVisa[idCivis].Valor + dtVisa;
            _phantasmaAuditus[idCivis].Valor = _phantasmaAuditus[idCivis].Valor + dtAuditus;
            _phantasmaAudita[idCivis].Valor = _phantasmaAudita[idCivis].Valor + dtAudita;
            _phantasmaSuspecta[idCivis].Valor = _phantasmaSuspecta[idCivis].Valor + dtSuspecta;
            _phantasmaStudium[idCivis].Valor = _phantasmaStudium[idCivis].Valor + dtStudium;
            _phantasmaIntentio[idCivis].Valor = _phantasmaIntentio[idCivis].Valor + dtIntentio;
            _phantasmaTorelantiaAnomaliaeMaxima[idCivis].Valor = _phantasmaTorelantiaAnomaliaeMaxima[idCivis].Valor + dtTorelantiaAnomaliaeMaxima;
            _phantasmaTorelantiaAnomaliaeMinima[idCivis].Valor = _phantasmaTorelantiaAnomaliaeMinima[idCivis].Valor + dtTorelantiaAnomaliaeMinima;
            _phantasmaVitaeMaxima[idCivis].Valor = _phantasmaVitaeMaxima[idCivis].Valor + dtVitaeMaxima;
            _phantasmaVisusMaxima[idCivis].Valor = _phantasmaVisusMaxima[idCivis].Valor + dtVisusMaxima;
            _phantasmaVisaMaxima[idCivis].Valor = _phantasmaVisaMaxima[idCivis].Valor + dtVisaMaxima;
            _phantasmaAuditusMaxima[idCivis].Valor = _phantasmaAuditusMaxima[idCivis].Valor + dtAuditusMaxima;
            _phantasmaAuditaMaxima[idCivis].Valor = _phantasmaAuditaMaxima[idCivis].Valor + dtAuditaMaxima;
            _phantasmaSuspectaMaxima[idCivis].Valor = _phantasmaSuspectaMaxima[idCivis].Valor + dtSuspectaMaxima;
            _phantasmaStudiumMaxima[idCivis].Valor = _phantasmaStudiumMaxima[idCivis].Valor + dtStudiumMaxima;
            _phantasmaIntentioMaxima[idCivis].Valor = _phantasmaIntentioMaxima[idCivis].Valor + dtIntentioMaxima;
            _phantasmaTorelantiaAnomaliaeMaximaMaxima[idCivis].Valor = _phantasmaTorelantiaAnomaliaeMaximaMaxima[idCivis].Valor + dtTorelantiaAnomaliaeMaximaMaxima;
            _phantasmaTorelantiaAnomaliaeMinimaMaxima[idCivis].Valor = _phantasmaTorelantiaAnomaliaeMinimaMaxima[idCivis].Valor + dtTorelantiaAnomaliaeMinimaMaxima;
        }

        public void Purgere(int idCivis) {
            _phantasmaVitae[idCivis].Valor = 0f;
            _phantasmaVisus[idCivis].Valor = 0f;
            _phantasmaVisa[idCivis].Valor = 0f;
            _phantasmaAuditus[idCivis].Valor = 0f;
            _phantasmaAudita[idCivis].Valor = 0f;
            _phantasmaSuspecta[idCivis].Valor = 0f;
            _phantasmaStudium[idCivis].Valor = 0f;
            _phantasmaIntentio[idCivis].Valor = 0f;
            _phantasmaTorelantiaAnomaliaeMaxima[idCivis].Valor = 0f;
            _phantasmaTorelantiaAnomaliaeMinima[idCivis].Valor = 0f;
            _phantasmaVitaeMaxima[idCivis].Valor = 0f;
            _phantasmaVisusMaxima[idCivis].Valor = 0f;
            _phantasmaVisaMaxima[idCivis].Valor = 0f;
            _phantasmaAuditusMaxima[idCivis].Valor = 0f;
            _phantasmaAuditaMaxima[idCivis].Valor = 0f;
            _phantasmaSuspectaMaxima[idCivis].Valor = 0f;
            _phantasmaStudiumMaxima[idCivis].Valor = 0f;
            _phantasmaIntentioMaxima[idCivis].Valor = 0f;
            _phantasmaTorelantiaAnomaliaeMaximaMaxima[idCivis].Valor = 0f;
            _phantasmaTorelantiaAnomaliaeMinimaMaxima[idCivis].Valor = 0f;
        }

        // 毎フレームの初期化時に、Phantasmaの値を初期化する。
        // 流動値はvalorFluida(ResFluidaの値)で初期化する。
        // 固定値は0で初期化する。
        private void InitarePhantasma(
            ValorisCivisVeletudinis valoris,
            float valorFluida
        ) {
            if (valoris.TypusValoris == TypusValoris.Fluidus) {
                valoris.Valor = valorFluida;
            } else if (valoris.TypusValoris == TypusValoris.Fixus) {
                valoris.Valor = 0f;
            }
        }

        public void InitarePhantasma(
            int idCivis,
            ResFluidaCivisVeletudinis resFluidaVeletudinis
        ) {
            InitarePhantasma(_phantasmaVitae[idCivis], resFluidaVeletudinis.Vitae(idCivis));
            InitarePhantasma(_phantasmaVisus[idCivis], resFluidaVeletudinis.Visus(idCivis));
            InitarePhantasma(_phantasmaVisa[idCivis], resFluidaVeletudinis.Visa(idCivis));
            InitarePhantasma(_phantasmaAuditus[idCivis], resFluidaVeletudinis.Auditus(idCivis));
            InitarePhantasma(_phantasmaAudita[idCivis], resFluidaVeletudinis.Audita(idCivis));
            InitarePhantasma(_phantasmaSuspecta[idCivis], resFluidaVeletudinis.Suspecta(idCivis));
            InitarePhantasma(_phantasmaStudium[idCivis], resFluidaVeletudinis.Studium(idCivis));
            InitarePhantasma(_phantasmaIntentio[idCivis], resFluidaVeletudinis.Intentio(idCivis));
            InitarePhantasma(_phantasmaTorelantiaAnomaliaeMaxima[idCivis], resFluidaVeletudinis.TorelantiaAnomaliaeMaxima(idCivis));
            InitarePhantasma(_phantasmaTorelantiaAnomaliaeMinima[idCivis], resFluidaVeletudinis.TorelantiaAnomaliaeMinima(idCivis));
            InitarePhantasma(_phantasmaVitaeMaxima[idCivis], resFluidaVeletudinis.VitaeMaxima(idCivis));
            InitarePhantasma(_phantasmaVisusMaxima[idCivis], resFluidaVeletudinis.VisusMaxima(idCivis));
            InitarePhantasma(_phantasmaVisaMaxima[idCivis], resFluidaVeletudinis.VisaMaxima(idCivis));
            InitarePhantasma(_phantasmaAuditusMaxima[idCivis], resFluidaVeletudinis.AuditusMaxima(idCivis));
            InitarePhantasma(_phantasmaAuditaMaxima[idCivis], resFluidaVeletudinis.AuditaMaxima(idCivis));
            InitarePhantasma(_phantasmaSuspectaMaxima[idCivis], resFluidaVeletudinis.SuspectaMaxima(idCivis));
            InitarePhantasma(_phantasmaStudiumMaxima[idCivis], resFluidaVeletudinis.StudiumMaxima(idCivis));
            InitarePhantasma(_phantasmaIntentioMaxima[idCivis], resFluidaVeletudinis.IntentioMaxima(idCivis));
            InitarePhantasma(_phantasmaTorelantiaAnomaliaeMaximaMaxima[idCivis], resFluidaVeletudinis.TorelantiaAnomaliaeMaximaMaxima(idCivis));
            InitarePhantasma(_phantasmaTorelantiaAnomaliaeMinimaMaxima[idCivis], resFluidaVeletudinis.TorelantiaAnomaliaeMinimaMaxima(idCivis));
        }
    }

    internal sealed class ExecutorCivisVeletudinis : IExecutorCivis {
        private readonly IConfiguratioCivisCustodiae _configuratioCivisCustodiae;
        private readonly IOstiumCivisLegibile _ostiumCivisLegibile;
        private readonly ResFluidaCivisVeletudinis _resFluidaVeletudinis;

        private readonly Ordo<IOrdinatioCivisVeletudinisCondicionis>[] _queueVeletudinisCondicionis;
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
            _queueVeletudinisCondicionis = new Ordo<IOrdinatioCivisVeletudinisCondicionis>[_ostiumCivisLegibile.Longitudo];
            for (int i = 0; i < _ostiumCivisLegibile.Longitudo; i++) {
                _queueVeletudinisCondicionis[i] = new Ordo<IOrdinatioCivisVeletudinisCondicionis>(ConstansCivis.LongitudoOrdinatioVeletudinisCondicionis);
            }
        }

        // Incarnare時にこれを実行する。
        // - Phantasma初期化
        // - resFluida初期化
        public void Initare(int idCivis) {
            _queueVeletudinisCondicionis[idCivis].Purgere();
            _phantasma.Purgere(idCivis);
            _resFluidaVeletudinis.Purgare(idCivis);
        }

        public void Primum(int idCivis) {
            _queueVeletudinisCondicionis[idCivis].Purgere();
            // 流動する値は現在の値で初期化する。
            // フレーム毎に確定する値(視力、聴力など)は0で初期化する。
            _phantasma.InitarePhantasma(idCivis, _resFluidaVeletudinis);
        }

        public void Executare(int idCivis, IOrdinatioCivisVeletudinisValoris veletudinisValoris) {
            _phantasma.Addo(
                idCivis,
                dtVitae: veletudinisValoris.DtVitae,
                dtVisus: veletudinisValoris.DtVisus,
                dtVisa: veletudinisValoris.DtVisa,
                dtAuditus: veletudinisValoris.DtAuditus,
                dtAudita: veletudinisValoris.DtAudita,
                dtSuspecta: veletudinisValoris.DtSuspecta,
                dtStudium: veletudinisValoris.DtStudium,
                dtIntentio: veletudinisValoris.DtIntentio,
                dtTorelantiaAnomaliaeMaxima: veletudinisValoris.DtTorelantiaAnomaliaeMaxima,
                dtTorelantiaAnomaliaeMinima: veletudinisValoris.DtTorelantiaAnomaliaeMinima
            );
        }

        public void Executare(int idCivis, IOrdinatioCivisVeletudinisMaxima veletudinisMaxima) {
            _phantasma.Addo(
                idCivis,
                dtVitaeMaxima: veletudinisMaxima.DtVitaeMaxima,
                dtVisusMaxima: veletudinisMaxima.DtVisusMaxima,
                dtVisaMaxima: veletudinisMaxima.DtVisaMaxima,
                dtAuditusMaxima: veletudinisMaxima.DtAuditusMaxima,
                dtAuditaMaxima: veletudinisMaxima.DtAuditaMaxima,
                dtSuspectaMaxima: veletudinisMaxima.DtSuspectaMaxima,
                dtStudiumMaxima: veletudinisMaxima.DtStudiumMaxima,
                dtIntentioMaxima: veletudinisMaxima.DtIntentioMaxima,
                dtTorelantiaAnomaliaeMaximaMaxima: veletudinisMaxima.DtTorelantiaAnomaliaeMaximaMaxima,
                dtTorelantiaAnomaliaeMinimaMaxima: veletudinisMaxima.DtTorelantiaAnomaliaeMinimaMaxima
            );
        }

        public void Executare(int idCivis, IOrdinatioCivisVeletudinisCondicionis veletudinisCondicionis) {
            if (!_queueVeletudinisCondicionis[idCivis].ConarePono(veletudinisCondicionis)) {
                Notarius.Memorare(LogTextus.ExecutorCivisVeletudinis_EXECUTORCIVISVELETUDINISVALORIS_ORDINATIO_QUEUE_FULL);
                return;
            }
        }

        private void ApplicareValoris(int idCivis) {
            // 必ずMaximaを先に反映しろ。
            _resFluidaVeletudinis.RenovareMaxima(
                idCivis,
                vitaeMaxima: _phantasma.PhantasmaVitaeMaxima(idCivis),
                visusMaxima: _phantasma.PhantasmaVisusMaxima(idCivis),
                visaMaxima: _phantasma.PhantasmaVisaMaxima(idCivis),
                auditusMaxima: _phantasma.PhantasmaAuditusMaxima(idCivis),
                auditaMaxima: _phantasma.PhantasmaAuditaMaxima(idCivis),
                suspectaMaxima: _phantasma.PhantasmaSuspectaMaxima(idCivis),
                studiumMaxima: _phantasma.PhantasmaStudiumMaxima(idCivis),
                intentioMaxima: _phantasma.PhantasmaIntentioMaxima(idCivis),
                torelantiaAnomaliaeMaximaMaxima: _phantasma.PhantasmaTorelantiaAnomaliaeMaximaMaxima(idCivis),
                torelantiaAnomaliaeMinimaMaxima: _phantasma.PhantasmaTorelantiaAnomaliaeMinimaMaxima(idCivis)
            );

            _resFluidaVeletudinis.RenovareValoris(
                idCivis,
                vitae: _phantasma.PhantasmaVitae(idCivis),
                visus: _phantasma.PhantasmaVisus(idCivis),
                visa: _phantasma.PhantasmaVisa(idCivis),
                auditus: _phantasma.PhantasmaAuditus(idCivis),
                audita: _phantasma.PhantasmaAudita(idCivis),
                suspecta: _phantasma.PhantasmaSuspecta(idCivis),
                studium: _phantasma.PhantasmaStudium(idCivis),
                intentio: _phantasma.PhantasmaIntentio(idCivis),
                torelantiaAnomaliaeMaxima: _phantasma.PhantasmaTorelantiaAnomaliaeMaxima(idCivis),
                torelantiaAnomaliaeMinima: _phantasma.PhantasmaTorelantiaAnomaliaeMinima(idCivis)
            );
        }

        private void ApplicareSpectare(int idCivis) {
            while (_queueVeletudinisCondicionis[idCivis].ConareLego(out var s)) {
                _resFluidaVeletudinis.RenovareCondicionis(
                    idCivis,
                    estVigilantia: s.EstVigilantia,
                    estDetectio: s.EstDetectio,
                    estDetectioSonora: s.EstDetectioSonora,
                    estSuspecta: s.EstSuspecta,
                    estSpectareNudusAnterior: s.EstSpectareNudusAnterior,
                    estSpectareNudusPosterior: s.EstSpectareNudusPosterior,
                    statusCustodiaeCurrens: s.StatusCustodiaeCurrens
                );
            }
        }

        public void Confirmare(int idCivis) {
            ApplicareValoris(idCivis);
            ApplicareSpectare(idCivis);
        }

        // Spirituare時にこれを実行する。
        // - Phantasma初期化
        // - resFluida初期化
        public void Purgare(int idCivis) {
            _phantasma.Purgere(idCivis);
            _queueVeletudinisCondicionis[idCivis].Purgere();
            _resFluidaVeletudinis.Purgare(idCivis);
        }
    }
}
