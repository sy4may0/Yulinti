using Yulinti.Dux.ContractusDucis;
using Yulinti.Nucleus;

namespace Yulinti.Dux.Exercitus {
    internal sealed class PhantasmaPuellaeVeletudinis {
        private float _phantasmaVigoris;
        private float _phantasmaPatientiae;
        private float _phantasmaAether;
        private float _phantasmaClaritas;
        private float _phantasmaIntentio;
        private float _phantasmaDedecus;
        private float _phantasmaSonusQuietes;
        private float _phantasmaSonusMotus;

        private float _vigorMaxima;
        private float _patientiaMaxima;
        private float _claritasMaxima;
        private float _aetherMaxima;
        private float _intentioMaxima;
        private float _dedecusMaxima;
        private float _sonusQuietesMaxima;
        private float _sonusMotusMaxima;

        public PhantasmaPuellaeVeletudinis() {
            _phantasmaVigoris = 0f;
            _phantasmaPatientiae = 0f;
            _phantasmaAether = 0f;
            _phantasmaClaritas = 0f;
            _phantasmaIntentio = 0f;
            _phantasmaDedecus = 0f;
            _phantasmaSonusQuietes = 0f;
            _phantasmaSonusMotus = 0f;

            // 将来Config取得とかに変わるかもしれないので、やりやすいように値にしておく。
            _vigorMaxima = 1f;
            _patientiaMaxima = 1f;
            _claritasMaxima = 1f;
            _aetherMaxima = 1f;
            _intentioMaxima = 1f;
            _dedecusMaxima = 1f;
            _sonusQuietesMaxima = 1f;
            _sonusMotusMaxima = 1f;
        }

        public float PhantasmaVigoris => _phantasmaVigoris;
        public float PhantasmaPatientiae => _phantasmaPatientiae;
        public float PhantasmaAether => _phantasmaAether;
        public float PhantasmaClaritas => _phantasmaClaritas;
        public float PhantasmaIntentio => _phantasmaIntentio;
        public float PhantasmaDedecus => _phantasmaDedecus;
        public float PhantasmaSonusQuietes => _phantasmaSonusQuietes;
        public float PhantasmaSonusMotus => _phantasmaSonusMotus;

        public void Addo(
            float dtVigoris = 0f,
            float dtPatientiae = 0f,
            float dtAether = 0f,
            float dtClaritas = 0f,
            float dtIntentio = 0f,
            float dtDedecus = 0f,
            float dtSonusQuietes = 0f,
            float dtSonusMotus = 0f
        ) {
            _phantasmaVigoris = DuxMath.Clamp(_phantasmaVigoris + dtVigoris, 0f, _vigorMaxima);
            _phantasmaPatientiae = DuxMath.Clamp(_phantasmaPatientiae + dtPatientiae, 0f, _patientiaMaxima);
            _phantasmaAether = DuxMath.Clamp(_phantasmaAether + dtAether, 0f, _aetherMaxima);
            _phantasmaClaritas = DuxMath.Clamp(_phantasmaClaritas + dtClaritas, 0f, _claritasMaxima);
            _phantasmaIntentio = DuxMath.Clamp(_phantasmaIntentio + dtIntentio, 0f, _intentioMaxima);
            _phantasmaDedecus = DuxMath.Clamp(_phantasmaDedecus + dtDedecus, 0f, _dedecusMaxima);
            _phantasmaSonusQuietes = DuxMath.Clamp(_phantasmaSonusQuietes + dtSonusQuietes, 0f, _sonusQuietesMaxima);
            _phantasmaSonusMotus = DuxMath.Clamp(_phantasmaSonusMotus + dtSonusMotus, 0f, _sonusMotusMaxima);
        }

        public void Pono(
            float vigor,
            float patientia,
            float aether,
            float claritas,
            float intentio,
            float dedecus,
            float sonusQuietes,
            float sonusMotus
        ) {
            _phantasmaVigoris = DuxMath.Clamp(vigor, 0f, _vigorMaxima);
            _phantasmaPatientiae = DuxMath.Clamp(patientia, 0f, _patientiaMaxima);
            _phantasmaAether = DuxMath.Clamp(aether, 0f, _aetherMaxima);
            _phantasmaClaritas = DuxMath.Clamp(claritas, 0f, _claritasMaxima);
            _phantasmaIntentio = DuxMath.Clamp(intentio, 0f, _intentioMaxima);
            _phantasmaDedecus = DuxMath.Clamp(dedecus, 0f, _dedecusMaxima);
            _phantasmaSonusQuietes = DuxMath.Clamp(sonusQuietes, 0f, _sonusQuietesMaxima);
            _phantasmaSonusMotus = DuxMath.Clamp(sonusMotus, 0f, _sonusMotusMaxima);
        }
    }

    internal sealed class ExecutorPuellaeVeletudinis : IExecutorPuellae {
        private readonly IConfiguratioPuellaeVeletudinis _configuratioVeletudinis;
        // SonusMotusに速度補正をかけるため使用する。
        private readonly IOstiumPuellaeLociLegibile _ostiumPuellaeLociLegibile;
        private readonly ResFluidaPuellaeVeletudinis _resFluidaVeletudinis;
        private readonly IOstiumPuellaeResVisaeMutabile _ostiumPuellaeResVisaeMutabile;

        private readonly DuxQueue<IOrdinatioPuellaeVeletudinisNudi> _queueVeletudinisNudi;
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
            _queueVeletudinisNudi = new DuxQueue<IOrdinatioPuellaeVeletudinisNudi>(ConstansPuellae.LongitudoOrdinatioVeletudinisNudi);
        }

        public void Initare() {
            _queueVeletudinisNudi.Purgere();
            _phantasma.Pono(
                vigor: 0f,
                patientia: 0f,
                aether: 0f,
                dedecus: 0f,
                claritas: 0f,
                intentio: 0f,
                sonusQuietes: 0f,
                sonusMotus: 0f
            );
            _resFluidaVeletudinis.Purgare();
            _ostiumPuellaeResVisaeMutabile.Activare();
        }

        public void Primum() {
            _queueVeletudinisNudi.Purgere();
            // 流動する値(スタミナ、HPなど)は現在の値で初期化する。
            // フレーム毎に確定する値(視認性、音量など)は0で初期化する。
            _phantasma.Pono(
                vigor: _resFluidaVeletudinis.Vigor,
                patientia: _resFluidaVeletudinis.Patientia,
                aether: _resFluidaVeletudinis.Aether,
                claritas: 0f,
                intentio: 0f,
                dedecus: 0f,
                sonusQuietes: 0f,
                sonusMotus: 0f
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
            IOrdinatioPuellaeVeletudinisNudi veletudinisNudi
        ) {
            if (!_queueVeletudinisNudi.ConarePono(veletudinisNudi)) {
                Memorator.MemorareErrorum(IDErrorum.EXECUTORPUELLAEVELETUDINIS_ORDINATIO_VELETUDINISNUDI_QUEUE_FULL);
                return;
            }
        }

        private float ComputareSonusMotus() {
            float velocitasSoniMax = _configuratioVeletudinis.VelocitasSoniMaxima;
            float velocitasSoniMin = 0f;
            float velocitasActualis = _ostiumPuellaeLociLegibile.VelocitasHorizontalisActualis();

            float ratio = DuxMath.InverseLerp(velocitasSoniMin, velocitasSoniMax, velocitasActualis);
            return ratio;
        }

        private void ApplicareValoris() {
            _resFluidaVeletudinis.RenovareValoris(
                vigor: _phantasma.PhantasmaVigoris,
                patientia: _phantasma.PhantasmaPatientiae,
                aether: _phantasma.PhantasmaAether,
                claritas: _phantasma.PhantasmaClaritas,
                intentio: _phantasma.PhantasmaIntentio,
                dedecus: _phantasma.PhantasmaDedecus,
                sonusQuietes: _phantasma.PhantasmaSonusQuietes,
                sonusMotus: _phantasma.PhantasmaSonusMotus * ComputareSonusMotus() // 速度補正をかける。
            );

            _resFluidaVeletudinis.ResolvereExhauritaVigoris(
                _configuratioVeletudinis.LimenExhauritaVigoris,
                _configuratioVeletudinis.LimenRefectaVigoris,
                1f // VigorMaxima Config設定可能にするならここを変える。
            );
            _resFluidaVeletudinis.ResolvereExhauritaPatientiae(
                _configuratioVeletudinis.LimenExhauritaPatientiae,
                _configuratioVeletudinis.LimenRefectaPatientiae,
                1f // PatientiaMaxima Config設定可能にするならここを変える。
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
            _phantasma.Pono(
                vigor: 0f,
                patientia: 0f,
                aether: 0f,
                claritas: 0f,
                intentio: 0f,
                dedecus: 0f,
                sonusQuietes: 0f,
                sonusMotus: 0f
            );
            _resFluidaVeletudinis.Purgare();
        }
    }
}