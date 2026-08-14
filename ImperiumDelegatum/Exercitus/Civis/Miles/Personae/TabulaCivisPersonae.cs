using System;
using System.Numerics;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class TabulaCivisPersonae {
        private readonly IConfiguratioCivisPersonae[] _configurationes;
        private readonly Random _random;

        public TabulaCivisPersonae(
            IConfiguratioCivisPersonae[] configurationes,
            Random random
        ) {
            int longitudo = Enum.GetValues(typeof(IDCivisPersonae)).Length;
            _configurationes = new IConfiguratioCivisPersonae[longitudo];
            _random = random;

            foreach (var configuration in configurationes) {
                _configurationes[(int)configuration.IDCivisPersonae] = configuration;
            }
        }

        private float Temere(Vector2 range) {
            float min = range.X;
            float max = range.Y;
            return min + (float)_random.NextDouble() * (max - min);
        }


        public float VitaInitialis(IDCivisPersonae idCivisPersonae) {
            return Temere(_configurationes[(int)idCivisPersonae].VitaInitialis);
        }

        public float VisusBasis(IDCivisPersonae idCivisPersonae) {
            return Temere(_configurationes[(int)idCivisPersonae].VisusBasis);
        }

        public float AuditusBasis(IDCivisPersonae idCivisPersonae) {
            return Temere(_configurationes[(int)idCivisPersonae].AuditusBasis);
        }

        public float TorelantiaAnomaliaeMaxima(IDCivisPersonae idCivisPersonae) {
            return Temere(_configurationes[(int)idCivisPersonae].TorelantiaAnomaliaeMaxima);
        }

        public float TorelantiaAnomaliaeMinima(IDCivisPersonae idCivisPersonae) {
            return Temere(_configurationes[(int)idCivisPersonae].TorelantiaAnomaliaeMinima);
        }
    }
}