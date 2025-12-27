using System;
using System.Numerics;
using Yulinti.Nucleus;

namespace Yulinti.Dux.Exercitus {
    internal static class InstrumentaPuellaeMotus2 {
        public static OrdinatioPuellaeMotusHorizontalis2 OrdinareMotusHorizontalis(
            Vector2 inputMotus,
            float velocitasDesiderata,
            float velocitasActualis,
            float acceleratio,
            float deceleratio,
            float tempusLevigatumMin,
            float tempusLevigatumMax,
            float limenInputQuadratum,
            bool estLevigatum
        ) {
            float velocitasAptata = (inputMotus.LengthSquared() >= limenInputQuadratum) 
                                    ? velocitasDesiderata : 0f;
            if (!estLevigatum) {
                return new OrdinatioPuellaeMotusHorizontalis2(velocitasAptata, 0f);
            }

            float dv = MathF.Abs(velocitasAptata - velocitasActualis);
            float aEx = (velocitasAptata > velocitasActualis) 
                         ? MathF.Max(acceleratio, Numerus.Epsilon)
                         : MathF.Max(deceleratio, Numerus.Epsilon);
            float tempusLevigatum = 
                dv > Numerus.Epsilon ? 2f * MathF.Sqrt(dv / aEx) : tempusLevigatumMin;
            tempusLevigatum = Math.Clamp(tempusLevigatum, tempusLevigatumMin, tempusLevigatumMax);

            return new OrdinatioPuellaeMotusHorizontalis2(velocitasAptata, tempusLevigatum);
        }

        public static OrdinatioPuellaeMotusVerticalis2 OrdinareMotusVerticalis(
            bool estInTerra,
            float velocitasActualis,
            float acceleratioGravitatis,
            float velocitasContactus,
            float velocitasMax,
            float intervallum
        ) {
            if (estInTerra) {
                return new OrdinatioPuellaeMotusVerticalis2(velocitasContactus, 0f);
            } else {
                float velocitas = velocitasActualis + acceleratioGravitatis * intervallum;
                return new OrdinatioPuellaeMotusVerticalis2(velocitas < velocitasMax ? velocitasMax : velocitas, 0f);
            }
        }

        public static OrdinatioPuellaeMotusRotationisY2 OrdinareMotusRotationisY(
            float rotatioYDesiderata,
            float rotatioYActualis,
            float tempusLevigatum,
            bool estLevigatum
        ) {
            if (!estLevigatum) {
                return new OrdinatioPuellaeMotusRotationisY2(rotatioYDesiderata, 0f);
            }

            return new OrdinatioPuellaeMotusRotationisY2(rotatioYDesiderata, tempusLevigatum);
        }

        public static OrdinatioPuellaeMotusRotationisY2 OrdinareMotusRotationisYSecutoria(
            Vector3 directioCameraDexterXZ,
            Vector3 directioCameraAnteriorXZ,
            Vector2 inputMotus,
            float rotatioYActualis,
            float tempusLevigatum,
            float limenInputQuadratum,
            bool estLevigatum
        ) {
            if (inputMotus.LengthSquared() < limenInputQuadratum) {
                return new OrdinatioPuellaeMotusRotationisY2(rotatioYActualis, 0f);
            }

            Vector3 directio = 
                directioCameraDexterXZ * inputMotus.X + 
                directioCameraAnteriorXZ * inputMotus.Y;

            if (directio.LengthSquared() < Single.Epsilon) {
                return new OrdinatioPuellaeMotusRotationisY2(rotatioYActualis, 0f);
            }

            Vector3 directioUnitioris = Vector3.Normalize(directio);
            float rotatioYDesiderata = 
                MathF.Atan2(directioUnitioris.X, directioUnitioris.Z) * Numerus.Rad2Deg;

            return OrdinareMotusRotationisY(
                rotatioYDesiderata, rotatioYActualis, tempusLevigatum, estLevigatum
            );
        }

        public static OrdinatioPuellaeMotusRotationisY2 OrdinareMotusSineRotationisY(
            float rotatioYActualis
        ) {
            return new OrdinatioPuellaeMotusRotationisY2(rotatioYActualis, 0f);
        }

    }
}
