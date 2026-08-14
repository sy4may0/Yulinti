using System;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class PhantasmaCivisPersonae {
        private float _vitae;
        private float _visus;
        private float _auditus;
        private float _torelantiaAnomaliaeMaxima;
        private float _torelantiaAnomaliaeMinima;

        public float Vitae => _vitae;
        public float Visus => _visus;
        public float Auditus => _auditus;
        public float TorelantiaAnomaliaeMaxima => _torelantiaAnomaliaeMaxima;
        public float TorelantiaAnomaliaeMinima => _torelantiaAnomaliaeMinima;

        public PhantasmaCivisPersonae(
        ) {
            _vitae = 0f;
            _visus = 0f;
            _auditus = 0f;
            _torelantiaAnomaliaeMaxima = 0f;
            _torelantiaAnomaliaeMinima = 0f;
        }

        public void Renovare(
            float vitae,
            float visus,
            float auditus,
            float torelantiaAnomaliaeMaxima,
            float torelantiaAnomaliaeMinima
        ) {
            _vitae = vitae;
            _visus = visus;
            _auditus = auditus;
            _torelantiaAnomaliaeMaxima = torelantiaAnomaliaeMaxima;
            _torelantiaAnomaliaeMinima = torelantiaAnomaliaeMinima;
        }

        public void Purgare() {
            _vitae = 0f;
            _visus = 0f;
            _auditus = 0f;
            _torelantiaAnomaliaeMaxima = 0f;
            _torelantiaAnomaliaeMinima = 0f;
        }
    }

    internal sealed class MilesCivisPersonae {
        private readonly TabulaCivisPersonae _tabulaCivisPersonae;
        private readonly PhantasmaCivisPersonae[] _phantasmasCivisPersonae;
        private readonly IOstiumCarrusCivis _carrus;

        public MilesCivisPersonae(
            IConfiguratioCiviumPersonarum configuratioCiviumPersonarum,
            IOstiumCivisLegibile ostiumCivisLegibile,
            IOstiumCarrusCivis carrus,
            Random random
        ) {
            _tabulaCivisPersonae = new TabulaCivisPersonae(
                configuratioCiviumPersonarum.Configurationes,
                random
            );

            int longitudo = ostiumCivisLegibile.Longitudo;
            _phantasmasCivisPersonae = new PhantasmaCivisPersonae[longitudo];
            for (int i = 0; i < longitudo; i++) {
                _phantasmasCivisPersonae[i] = new PhantasmaCivisPersonae();
            }

            _carrus = carrus;
        }

        public void Initare(int idCivis, IDCivisPersonae personae) {
            _phantasmasCivisPersonae[idCivis].Renovare(
                _tabulaCivisPersonae.VitaInitialis(personae),
                _tabulaCivisPersonae.VisusBasis(personae),
                _tabulaCivisPersonae.AuditusBasis(personae),
                _tabulaCivisPersonae.TorelantiaAnomaliaeMaxima(personae),
                _tabulaCivisPersonae.TorelantiaAnomaliaeMinima(personae)
            );

            _carrus.PostulareVeletudinisValoris(
                idCivis,
                dtVitae: _phantasmasCivisPersonae[idCivis].Vitae,
                dtVisus: _phantasmasCivisPersonae[idCivis].Visus,
                dtAuditus: _phantasmasCivisPersonae[idCivis].Auditus,
                dtTorelantiaAnomaliaeMaxima: _phantasmasCivisPersonae[idCivis].TorelantiaAnomaliaeMaxima,
                dtTorelantiaAnomaliaeMinima: _phantasmasCivisPersonae[idCivis].TorelantiaAnomaliaeMinima
            );
        }

        public void Purgare(int idCivis) {
            _phantasmasCivisPersonae[idCivis].Purgare();
        }

        public void Ordinare(int idCivis) {
            _carrus.PostulareVeletudinisValoris(
                idCivis,
                dtVisus: _phantasmasCivisPersonae[idCivis].Visus,
                dtAuditus: _phantasmasCivisPersonae[idCivis].Auditus,
                dtTorelantiaAnomaliaeMaxima: _phantasmasCivisPersonae[idCivis].TorelantiaAnomaliaeMaxima,
                dtTorelantiaAnomaliaeMinima: _phantasmasCivisPersonae[idCivis].TorelantiaAnomaliaeMinima
            );
        }
    }
}