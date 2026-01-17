using System;
using System.Numerics;
using Yulinti.Nucleus;

namespace Yulinti.Dux.Exercitus {
    internal struct MotusPuellaeHorizontalis {
        public readonly float Velocitas { get; }
        public readonly float TempusLevigatum { get; }
        public MotusPuellaeHorizontalis(float velocitas, float tempusLevigatum) {
            Velocitas = velocitas;
            TempusLevigatum = tempusLevigatum;
        }
    }

    internal struct MotusPuellaeRotationisY {
        public readonly float RotatioY { get; }
        public readonly float TempusLevigatum { get; }
        public MotusPuellaeRotationisY(float rotatioY, float tempusLevigatum) {
            RotatioY = rotatioY;
            TempusLevigatum = tempusLevigatum;
        }
    }

    internal static class InstrumentaPuellaeMotus {
        public static MotusPuellaeHorizontalis OrdinareMotusHorizontalis(
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
                return new MotusPuellaeHorizontalis(velocitasAptata, 0f);
            }

            float dv = MathF.Abs(velocitasAptata - velocitasActualis);
            float aEx = (velocitasAptata > velocitasActualis) 
                         ? MathF.Max(acceleratio, Numerus.Epsilon)
                         : MathF.Max(deceleratio, Numerus.Epsilon);
            float tempusLevigatum = 
                dv > Numerus.Epsilon ? 2f * MathF.Sqrt(dv / aEx) : tempusLevigatumMin;
            tempusLevigatum = Math.Clamp(tempusLevigatum, tempusLevigatumMin, tempusLevigatumMax);

            return new MotusPuellaeHorizontalis(velocitasAptata, tempusLevigatum);
        }


        public static MotusPuellaeRotationisY OrdinareMotusRotationisY(
            float rotatioYDesiderata,
            float rotatioYActualis,
            float tempusLevigatum,
            bool estLevigatum
        ) {
            if (!estLevigatum) {
                return new MotusPuellaeRotationisY(rotatioYDesiderata, 0f);
            }

            return new MotusPuellaeRotationisY(rotatioYDesiderata, tempusLevigatum);
        }

        public static MotusPuellaeRotationisY OrdinareMotusRotationisYSecutoria(
            Vector3 directioCameraDexterXZ,
            Vector3 directioCameraAnteriorXZ,
            Vector2 inputMotus,
            float rotatioYActualis,
            float tempusLevigatum,
            float limenInputQuadratum,
            bool estLevigatum
        ) {
            if (inputMotus.LengthSquared() < limenInputQuadratum) {
                return new MotusPuellaeRotationisY(rotatioYActualis, 0f);
            }

            Vector3 directio = 
                directioCameraDexterXZ * inputMotus.X + 
                directioCameraAnteriorXZ * inputMotus.Y;

            if (directio.LengthSquared() < Single.Epsilon) {
                return new MotusPuellaeRotationisY(rotatioYActualis, 0f);
            }

            Vector3 directioUnitioris = Vector3.Normalize(directio);
            float rotatioYDesiderata = 
                MathF.Atan2(directioUnitioris.X, directioUnitioris.Z) * Numerus.Rad2Deg;

            return new MotusPuellaeRotationisY(
                rotatioYDesiderata, tempusLevigatum
            );
        }

        public static MotusPuellaeRotationisY OrdinareMotusSineRotationisY(
            float rotatioYActualis
        ) {
            return new MotusPuellaeRotationisY(rotatioYActualis, 0f);
        }
    }
}
