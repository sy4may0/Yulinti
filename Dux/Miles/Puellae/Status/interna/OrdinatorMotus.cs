using System;
using System.Numerics;
using Yulinti.Nucleus.Constans;

namespace Yulinti.Dux.Miles.Puellae.Interna {
    public static class OrdinatorMotus {
        public static OrdinatioMotusHorizontalis OrdinareMotusHorizontalis(
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
                return new OrdinatioMotusHorizontalis(velocitasAptata, 0f);
            }

            float dv = MathF.Abs(velocitasAptata - velocitasActualis);
            float aEx = (velocitasAptata > velocitasActualis) 
                         ? MathF.Max(acceleratio, Numerus.Epsilon)
                         : MathF.Max(deceleratio, Numerus.Epsilon);
            float tempusLevigatum = 
                dv > Numerus.Epsilon ? 2f * MathF.Sqrt(dv / aEx) : tempusLevigatumMin;
            tempusLevigatum = Math.Clamp(tempusLevigatum, tempusLevigatumMin, tempusLevigatumMax);

            return new OrdinatioMotusHorizontalis(velocitasAptata, tempusLevigatum);
        }

        public static OrdinatioMotusVerticalis OrdinareMotusVerticalis(
            bool estInTerra,
            float velocitasActualis,
            float acceleratioGravitatis,
            float velocitasContactus,
            float velocitasMax,
            float intervallum
        ) {
            // TODO: ここも速度に対するSmoothTimeを入れるか? 物理的には9.8固定だからこれで良いんじゃない?

            if (estInTerra) {
                return new OrdinatioMotusVerticalis(velocitasContactus, 0f);
            } else {
                float velocitas = velocitasActualis + acceleratioGravitatis * intervallum;
                return new OrdinatioMotusVerticalis(velocitas < velocitasMax ? velocitasMax : velocitas, 0f);
            }
        }

        public static OrdinatioMotusRotationisY OrdinareMotusRotationisY(
            float rotatioYDesiderata,
            float rotatioYActualis,
            float tempusLevigatum,
            bool estLevigatum
        ) {
            if (!estLevigatum) {
                return new OrdinatioMotusRotationisY(rotatioYDesiderata, 0f);
            }

            return new OrdinatioMotusRotationisY(rotatioYDesiderata, tempusLevigatum);
        }

        public static OrdinatioMotusRotationisY OrdinareMotusRotationisYSecutoria(
            Vector3 directioCameraDexterXZ,
            Vector3 directioCameraAnteriorXZ,
            Vector2 inputMotus,
            float rotatioYActualis,
            float tempusLevigatum,
            float limenInputQuadratum,
            bool estLevigatum
        ) {
            if (inputMotus.LengthSquared() < limenInputQuadratum) {
                return new OrdinatioMotusRotationisY(rotatioYActualis, 0f);
            }

            Vector3 directio = 
                directioCameraDexterXZ * inputMotus.X + 
                directioCameraAnteriorXZ * inputMotus.Y;

            if (directio.LengthSquared() < Single.Epsilon) {
                return new OrdinatioMotusRotationisY(rotatioYActualis, 0f);
            }

            Vector3 directioUnitioris = Vector3.Normalize(directio);
            float rotatioYDesiderata = 
                MathF.Atan2(directioUnitioris.X, directioUnitioris.Z) * Numerus.Rad2Deg;

            return OrdinareMotusRotationisY(
                rotatioYDesiderata, rotatioYActualis, tempusLevigatum, estLevigatum
            );
        }

        public static OrdinatioMotusRotationisY OrdinareMotusSineRotationisY(
            float rotatioYActualis
        ) {
            return new OrdinatioMotusRotationisY(rotatioYActualis, 0f);
        }

    }
}
