namespace Yulinti.Dux.Exercitus {
    internal readonly struct OrdinatioPuellaeMotusHorizontalis2 {
        public readonly float Velocitas { get; }
        public readonly float TempusLevigatum { get; }

        public OrdinatioPuellaeMotusHorizontalis2(float velocitas, float tempusLevigatum) {
            Velocitas = velocitas;
            TempusLevigatum = tempusLevigatum;
        }
    }

    internal readonly struct OrdinatioPuellaeMotusVerticalis2 {
        public readonly float Velocitas { get; }
        public readonly float TempusLevigatum { get; }

        public OrdinatioPuellaeMotusVerticalis2(float velocitas, float tempusLevigatum) {
            Velocitas = velocitas;
            TempusLevigatum = tempusLevigatum;
        }
    }

    internal readonly struct OrdinatioPuellaeMotusRotationisY2 {
        public readonly float RotatioY { get; }
        public readonly float TempusLevigatum { get; }

        public OrdinatioPuellaeMotusRotationisY2(float rotatioY, float tempusLevigatum) {
            RotatioY = rotatioY;
            TempusLevigatum = tempusLevigatum;
        }
    }

    internal readonly struct OrdinatioPuellaeMotus2 {
        public readonly OrdinatioPuellaeMotusHorizontalis2 Horizontalis { get; }
        public readonly OrdinatioPuellaeMotusVerticalis2 Verticalis { get; }
        public readonly OrdinatioPuellaeMotusRotationisY2 RotationisY { get; }

        public OrdinatioPuellaeMotus2(
            OrdinatioPuellaeMotusHorizontalis2 horizontalis,
            OrdinatioPuellaeMotusVerticalis2 verticalis,
            OrdinatioPuellaeMotusRotationisY2 rotationisY
        ) {
            Horizontalis = horizontalis;
            Verticalis = verticalis;
            RotationisY = rotationisY;
        }
    }
}