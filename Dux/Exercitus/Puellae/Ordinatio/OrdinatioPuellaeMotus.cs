namespace Yulinti.Dux.Exercitus {
    internal readonly struct OrdinatioPuellaeMotusHorizontalis {
        public readonly float Velocitas { get; }
        public readonly float TempusLevigatum { get; }

        public OrdinatioPuellaeMotusHorizontalis(float velocitas, float tempusLevigatum) {
            Velocitas = velocitas;
            TempusLevigatum = tempusLevigatum;
        }
    }

    internal readonly struct OrdinatioPuellaeMotusVerticalis {
        public readonly float Velocitas { get; }
        public readonly float TempusLevigatum { get; }

        public OrdinatioPuellaeMotusVerticalis(float velocitas, float tempusLevigatum) {
            Velocitas = velocitas;
            TempusLevigatum = tempusLevigatum;
        }
    }

    internal readonly struct OrdinatioPuellaeMotusRotationisY {
        public readonly float RotatioY { get; }
        public readonly float TempusLevigatum { get; }

        public OrdinatioPuellaeMotusRotationisY(float rotatioY, float tempusLevigatum) {
            RotatioY = rotatioY;
            TempusLevigatum = tempusLevigatum;
        }
    }

    internal readonly struct OrdinatioPuellaeMotus {
        public readonly OrdinatioPuellaeMotusHorizontalis Horizontalis { get; }
        public readonly OrdinatioPuellaeMotusVerticalis Verticalis { get; }
        public readonly OrdinatioPuellaeMotusRotationisY RotationisY { get; }

        public OrdinatioPuellaeMotus(
            in OrdinatioPuellaeMotusHorizontalis horizontalis,
            in OrdinatioPuellaeMotusVerticalis verticalis,
            in OrdinatioPuellaeMotusRotationisY rotationisY
        ) {
            Horizontalis = horizontalis;
            Verticalis = verticalis;
            RotationisY = rotationisY;
        }
    }
}
