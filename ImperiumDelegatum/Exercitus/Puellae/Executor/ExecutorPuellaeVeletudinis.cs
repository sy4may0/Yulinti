using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

// 全体設計: このクラスでClampしない。Maximaは見ない。Clampは反映時にResFluidaが行う。

namespace Yulinti.ImperiumDelegatum.Exercitus {
    // 値のタイプ。流動か固定か。
    // Fluidus: 流動値。毎フレーム前回の値を参照する。VigorやPatientiaなど増減する値。
    // Fixus: 固定値。毎フレーム前回の値を参照しない。ClaritasやIntentioなど、毎フレーム特定の値が確定する。
    internal enum TypusValoris {
        Fluidus,
        Fixus
    }

    // 値タイプつきの値。
    internal sealed class ValorisPuellaeVeletudinis {
        public float Valor { get; set; }
        private TypusValoris _typusValoris;

        public ValorisPuellaeVeletudinis(float valor, TypusValoris typusValoris) {
            Valor = valor;
            _typusValoris = typusValoris;
        }

        public TypusValoris TypusValoris => _typusValoris;
    }

    internal sealed class PhantasmaPuellaeVeletudinis {
        private ValorisPuellaeVeletudinis _phantasmaVigoris;
        private ValorisPuellaeVeletudinis _phantasmaPatientiae;
        private ValorisPuellaeVeletudinis _phantasmaAether;
        private ValorisPuellaeVeletudinis _phantasmaClaritas;
        private ValorisPuellaeVeletudinis _phantasmaIntentio;
        private ValorisPuellaeVeletudinis _phantasmaDedecus;
        private ValorisPuellaeVeletudinis _phantasmaSonusQuietes;
        private ValorisPuellaeVeletudinis _phantasmaSonusMotus;

        private ValorisPuellaeVeletudinis _phantasmaVigorMaxima;
        private ValorisPuellaeVeletudinis _phantasmaPatientiaeMaxima;
        private ValorisPuellaeVeletudinis _phantasmaClaritasMaxima;
        private ValorisPuellaeVeletudinis _phantasmaAetherMaxima;
        private ValorisPuellaeVeletudinis _phantasmaIntentioMaxima;
        private ValorisPuellaeVeletudinis _phantasmaDedecusMaxima;
        private ValorisPuellaeVeletudinis _phantasmaSonusQuietesMaxima;
        private ValorisPuellaeVeletudinis _phantasmaSonusMotusMaxima;

        public PhantasmaPuellaeVeletudinis() {
            _phantasmaVigoris = new ValorisPuellaeVeletudinis(0f, TypusValoris.Fluidus);
            _phantasmaPatientiae = new ValorisPuellaeVeletudinis(0f, TypusValoris.Fluidus);
            _phantasmaAether = new ValorisPuellaeVeletudinis(0f, TypusValoris.Fluidus);
            _phantasmaClaritas = new ValorisPuellaeVeletudinis(0f, TypusValoris.Fixus);
            _phantasmaIntentio = new ValorisPuellaeVeletudinis(0f, TypusValoris.Fixus);
            _phantasmaDedecus = new ValorisPuellaeVeletudinis(0f, TypusValoris.Fluidus);
            _phantasmaSonusQuietes = new ValorisPuellaeVeletudinis(0f, TypusValoris.Fixus);
            _phantasmaSonusMotus = new ValorisPuellaeVeletudinis(0f, TypusValoris.Fixus);

            _phantasmaVigorMaxima = new ValorisPuellaeVeletudinis(1f, TypusValoris.Fixus);
            _phantasmaPatientiaeMaxima = new ValorisPuellaeVeletudinis(1f, TypusValoris.Fixus);
            _phantasmaClaritasMaxima = new ValorisPuellaeVeletudinis(1f, TypusValoris.Fixus);
            _phantasmaAetherMaxima = new ValorisPuellaeVeletudinis(1f, TypusValoris.Fixus);
            _phantasmaIntentioMaxima = new ValorisPuellaeVeletudinis(1f, TypusValoris.Fixus);
            _phantasmaDedecusMaxima = new ValorisPuellaeVeletudinis(1f, TypusValoris.Fixus);
            _phantasmaSonusQuietesMaxima = new ValorisPuellaeVeletudinis(1f, TypusValoris.Fixus);
            _phantasmaSonusMotusMaxima = new ValorisPuellaeVeletudinis(1f, TypusValoris.Fixus);
        }

        public float PhantasmaVigoris => _phantasmaVigoris.Valor;
        public float PhantasmaPatientiae => _phantasmaPatientiae.Valor;
        public float PhantasmaAether => _phantasmaAether.Valor;
        public float PhantasmaClaritas => _phantasmaClaritas.Valor;
        public float PhantasmaIntentio => _phantasmaIntentio.Valor;
        public float PhantasmaDedecus => _phantasmaDedecus.Valor;
        public float PhantasmaSonusQuietes => _phantasmaSonusQuietes.Valor;
        public float PhantasmaSonusMotus => _phantasmaSonusMotus.Valor;

        public float PhantasmaVigorMaxima => _phantasmaVigorMaxima.Valor;
        public float PhantasmaPatientiaeMaxima => _phantasmaPatientiaeMaxima.Valor;
        public float PhantasmaClaritasMaxima => _phantasmaClaritasMaxima.Valor;
        public float PhantasmaAetherMaxima => _phantasmaAetherMaxima.Valor;
        public float PhantasmaIntentioMaxima => _phantasmaIntentioMaxima.Valor;
        public float PhantasmaDedecusMaxima => _phantasmaDedecusMaxima.Valor;
        public float PhantasmaSonusQuietesMaxima => _phantasmaSonusQuietesMaxima.Valor;
        public float PhantasmaSonusMotusMaxima => _phantasmaSonusMotusMaxima.Valor;

        public void Addo(
            float dtVigoris = 0f,
            float dtPatientiae = 0f,
            float dtAether = 0f,
            float dtClaritas = 0f,
            float dtIntentio = 0f,
            float dtDedecus = 0f,
            float dtSonusQuietes = 0f,
            float dtSonusMotus = 0f,
            float dtVigorMaxima = 0f,
            float dtPatientiaeMaxima = 0f,
            float dtClaritasMaxima = 0f,
            float dtAetherMaxima = 0f,
            float dtIntentioMaxima = 0f,
            float dtDedecusMaxima = 0f,
            float dtSonusQuietesMaxima = 0f,
            float dtSonusMotusMaxima = 0f
        ) {
            _phantasmaVigoris.Valor = _phantasmaVigoris.Valor + dtVigoris;
            _phantasmaPatientiae.Valor = _phantasmaPatientiae.Valor + dtPatientiae;
            _phantasmaAether.Valor = _phantasmaAether.Valor + dtAether;
            _phantasmaClaritas.Valor = _phantasmaClaritas.Valor + dtClaritas;
            _phantasmaIntentio.Valor = _phantasmaIntentio.Valor + dtIntentio;
            _phantasmaDedecus.Valor = _phantasmaDedecus.Valor + dtDedecus;
            _phantasmaSonusQuietes.Valor = _phantasmaSonusQuietes.Valor + dtSonusQuietes;
            _phantasmaSonusMotus.Valor = _phantasmaSonusMotus.Valor + dtSonusMotus;
            _phantasmaVigorMaxima.Valor = _phantasmaVigorMaxima.Valor + dtVigorMaxima;
            _phantasmaPatientiaeMaxima.Valor = _phantasmaPatientiaeMaxima.Valor + dtPatientiaeMaxima;
            _phantasmaClaritasMaxima.Valor = _phantasmaClaritasMaxima.Valor + dtClaritasMaxima;
            _phantasmaAetherMaxima.Valor = _phantasmaAetherMaxima.Valor + dtAetherMaxima;
            _phantasmaIntentioMaxima.Valor = _phantasmaIntentioMaxima.Valor + dtIntentioMaxima;
            _phantasmaDedecusMaxima.Valor = _phantasmaDedecusMaxima.Valor + dtDedecusMaxima;
            _phantasmaSonusQuietesMaxima.Valor = _phantasmaSonusQuietesMaxima.Valor + dtSonusQuietesMaxima;
            _phantasmaSonusMotusMaxima.Valor = _phantasmaSonusMotusMaxima.Valor + dtSonusMotusMaxima;
        }

        public void Purgere() {
            _phantasmaVigoris.Valor = 0f;
            _phantasmaPatientiae.Valor = 0f;
            _phantasmaAether.Valor = 0f;
            _phantasmaClaritas.Valor = 0f;
            _phantasmaIntentio.Valor = 0f;
            _phantasmaDedecus.Valor = 0f;
            _phantasmaSonusQuietes.Valor = 0f;
            _phantasmaSonusMotus.Valor = 0f;
            _phantasmaVigorMaxima.Valor = 0f;
            _phantasmaPatientiaeMaxima.Valor = 0f;
            _phantasmaClaritasMaxima.Valor = 0f;
            _phantasmaAetherMaxima.Valor = 0f;
            _phantasmaIntentioMaxima.Valor = 0f;
            _phantasmaDedecusMaxima.Valor = 0f;
            _phantasmaSonusQuietesMaxima.Valor = 0f;
            _phantasmaSonusMotusMaxima.Valor = 0f;
        }

        // 毎フレームの初期化時に、Phantasmaの値を初期化する。
        // 流動値はvalorFluida(ResFluidaの値)で初期化する。
        // 固定値は0で初期化する。
        private void InitarePhantasma(
            ValorisPuellaeVeletudinis valoris, 
            float valorFluida
        ) {
            if (valoris.TypusValoris == TypusValoris.Fluidus) {
                valoris.Valor = valorFluida;
            } else if (valoris.TypusValoris == TypusValoris.Fixus) {
                valoris.Valor = 0f;
            }
        }

        public void InitarePhantasma(
            ResFluidaPuellaeVeletudinis resFluidaVeletudinis
        ) {
            InitarePhantasma(_phantasmaVigoris, resFluidaVeletudinis.Vigor);
            InitarePhantasma(_phantasmaPatientiae, resFluidaVeletudinis.Patientia);
            InitarePhantasma(_phantasmaAether, resFluidaVeletudinis.Aether);
            InitarePhantasma(_phantasmaClaritas, resFluidaVeletudinis.Claritas);
            InitarePhantasma(_phantasmaIntentio, resFluidaVeletudinis.Intentio);
            InitarePhantasma(_phantasmaDedecus, resFluidaVeletudinis.Dedecus);
            InitarePhantasma(_phantasmaSonusQuietes, resFluidaVeletudinis.SonusQuietes);
            InitarePhantasma(_phantasmaSonusMotus, resFluidaVeletudinis.SonusMotus);
            InitarePhantasma(_phantasmaVigorMaxima, resFluidaVeletudinis.VigorMaxima);
            InitarePhantasma(_phantasmaPatientiaeMaxima, resFluidaVeletudinis.PatientiaMaxima);
            InitarePhantasma(_phantasmaClaritasMaxima, resFluidaVeletudinis.ClaritasMaxima);
            InitarePhantasma(_phantasmaAetherMaxima, resFluidaVeletudinis.AetherMaxima);
            InitarePhantasma(_phantasmaIntentioMaxima, resFluidaVeletudinis.IntentioMaxima);
            InitarePhantasma(_phantasmaDedecusMaxima, resFluidaVeletudinis.DedecusMaxima);
            InitarePhantasma(_phantasmaSonusQuietesMaxima, resFluidaVeletudinis.SonusQuietesMaxima);
            InitarePhantasma(_phantasmaSonusMotusMaxima, resFluidaVeletudinis.SonusMotusMaxima);
        }
    }

    internal sealed class ExecutorPuellaeVeletudinis : IExecutorPuellae {
        private readonly IConfiguratioPuellaeVeletudinis _configuratioVeletudinis;
        // SonusMotusに速度補正をかけるため使用する。
        private readonly IOstiumPuellaeLociLegibile _ostiumPuellaeLociLegibile;
        private readonly ResFluidaPuellaeVeletudinis _resFluidaVeletudinis;
        private readonly IOstiumPuellaeResVisaeMutabile _ostiumPuellaeResVisaeMutabile;

        private readonly Ordo<IOrdinatioPuellaeVeletudinisNudi> _queueVeletudinisNudi;
        private readonly PhantasmaPuellaeVeletudinis _phantasma;

        public ExecutorPuellaeVeletudinis(
            IConfiguratioExercitusPuellae configuratioExercitusPuellae,
            IOstiumPuellaeResVisaeMutabile ostiumPuellaeResVisaeMutabile,
            IOstiumPuellaeLociLegibile ostiumPuellaeLociLegibile,
            ResFluidaPuellaeVeletudinis resFluidaVeletudinis
        ) {
            _configuratioVeletudinis = configuratioExercitusPuellae.Veletudo;
            _resFluidaVeletudinis = resFluidaVeletudinis;
            _ostiumPuellaeResVisaeMutabile = ostiumPuellaeResVisaeMutabile;
            _ostiumPuellaeLociLegibile = ostiumPuellaeLociLegibile;
            _phantasma = new PhantasmaPuellaeVeletudinis();
            _queueVeletudinisNudi = new Ordo<IOrdinatioPuellaeVeletudinisNudi>(ConstansPuellae.LongitudoOrdinatioVeletudinisNudi);
        }

        public void Initare() {
            _queueVeletudinisNudi.Purgere();
            _phantasma.Purgere();
            _resFluidaVeletudinis.Purgare();
            _ostiumPuellaeResVisaeMutabile.Activare();
        }

        public void Primum() {
            _queueVeletudinisNudi.Purgere();
            // 流動する値(スタミナ、HPなど)は現在の値で初期化する。
            // フレーム毎に確定する値(視認性、音量など)は0で初期化する。
            _phantasma.InitarePhantasma(
                _resFluidaVeletudinis
            );
        }

        public void Executare(
            IOrdinatioPuellaeVeletudinis veletudinis
        ) {
            _phantasma.Addo(
                dtVigoris: veletudinis.DtVigoris,
                dtPatientiae: veletudinis.DtPatientiae,
                dtAether: veletudinis.DtAetheris,
                dtClaritas: veletudinis.DtClaritas,
                dtIntentio: veletudinis.DtIntentio,
                dtDedecus: veletudinis.DtDedecus,
                dtSonusQuietes: veletudinis.DtSonusQuietes,
                dtSonusMotus: veletudinis.DtSonusMotus
            );
        }

        public void Executare(
            IOrdinatioPuellaeVeletudinisMaxima veletudinisMaxima
        ) {
            _phantasma.Addo(
                dtVigorMaxima: veletudinisMaxima.DtVigorMaxima,
                dtPatientiaeMaxima: veletudinisMaxima.DtPatientiaeMaxima,
                dtAetherMaxima: veletudinisMaxima.DtAetherMaxima,
                dtClaritasMaxima: veletudinisMaxima.DtClaritasMaxima,
                dtIntentioMaxima: veletudinisMaxima.DtIntentioMaxima,
                dtDedecusMaxima: veletudinisMaxima.DtDedecusMaxima,
                dtSonusQuietesMaxima: veletudinisMaxima.DtSonusQuietesMaxima,
                dtSonusMotusMaxima: veletudinisMaxima.DtSonusMotusMaxima
            );
        }

        public void Executare(
            IOrdinatioPuellaeVeletudinisNudi veletudinisNudi
        ) {
            if (!_queueVeletudinisNudi.ConarePono(veletudinisNudi)) {
                Notarius.Memorare(LogTextus.ExecutorPuellaeVeletudinis_EXECUTORPUELLAEVELETUDINIS_ORDINATIO_VELETUDINISNUDI_QUEUE_FULL);
                return;
            }
        }

        private float ComputareRationemSonusMotus() {
            float velocitasSoniMax = _configuratioVeletudinis.VelocitasSoniMaxima;
            float velocitasSoniMin = 0f;
            float velocitasActualis = _ostiumPuellaeLociLegibile.VelocitasHorizontalisActualis();

            float ratio = Mathematica.InverseLerp01(velocitasSoniMin, velocitasSoniMax, velocitasActualis);
            return ratio;
        }

        private void ApplicareValoris() {
            // 必ずMaximaを先に反映しろ。
            _resFluidaVeletudinis.RenovareMaxima(
                vigorMaxima: _phantasma.PhantasmaVigorMaxima,
                patientiaMaxima: _phantasma.PhantasmaPatientiaeMaxima,
                claritasMaxima: _phantasma.PhantasmaClaritasMaxima,
                aetherMaxima: _phantasma.PhantasmaAetherMaxima,
                intentioMaxima: _phantasma.PhantasmaIntentioMaxima,
                dedecusMaxima: _phantasma.PhantasmaDedecusMaxima,
                sonusQuietesMaxima: _phantasma.PhantasmaSonusQuietesMaxima,
                sonusMotusMaxima: _phantasma.PhantasmaSonusMotusMaxima
            );

            _resFluidaVeletudinis.RenovareValoris(
                vigor: _phantasma.PhantasmaVigoris,
                patientia: _phantasma.PhantasmaPatientiae,
                aether: _phantasma.PhantasmaAether,
                claritas: _phantasma.PhantasmaClaritas,
                intentio: _phantasma.PhantasmaIntentio,
                dedecus: _phantasma.PhantasmaDedecus,
                sonusQuietes: _phantasma.PhantasmaSonusQuietes,
                sonusMotus: _phantasma.PhantasmaSonusMotus * ComputareRationemSonusMotus() // 速度補正をかける。
            );

            _resFluidaVeletudinis.ResolvereExhauritaVigoris(
                _configuratioVeletudinis.LimenExhauritaVigoris,
                _configuratioVeletudinis.LimenRefectaVigoris
            );
            _resFluidaVeletudinis.ResolvereExhauritaPatientiae(
                _configuratioVeletudinis.LimenExhauritaPatientiae,
                _configuratioVeletudinis.LimenRefectaPatientiae
            );
        }

        private void ApplicareNudus() {
            while (_queueVeletudinisNudi.ConareLego(out IOrdinatioPuellaeVeletudinisNudi veletudinisNudi)) {
                _resFluidaVeletudinis.RenovareNudusAnterior(veletudinisNudi.EstNudusAnterior);
                _resFluidaVeletudinis.RenovareNudusPosterior(veletudinisNudi.EstNudusPosterior);
            }
            // 現在のNudusの状態によって、対象のNudusAnterior/NudusPosteriorを有効/無効にする。
            if (_resFluidaVeletudinis.EstNudusAnterior) {
                _ostiumPuellaeResVisaeMutabile.ActivareNudusAnterior();
            } else {
                _ostiumPuellaeResVisaeMutabile.DeactivateNudusAnterior();
            }

            if (_resFluidaVeletudinis.EstNudusPosterior) {
                _ostiumPuellaeResVisaeMutabile.ActivareNudusPosterior();
            } else {
                _ostiumPuellaeResVisaeMutabile.DeactivateNudusPosterior();
            }
        }

        public void Confirmare() {
            ApplicareValoris();
            ApplicareNudus();
        }

        public void Purgare() {
            _phantasma.Purgere();
            _resFluidaVeletudinis.Purgare();
        }
    }
}
