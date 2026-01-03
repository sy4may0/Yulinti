namespace Yulinti.Dux.Exercitus {
    internal readonly struct OrdinatioCivisMotusHorizontalis {
        public readonly float Velocitas { get; }
        public readonly float TempusLevigatum { get; }

        public OrdinatioCivisMotusHorizontalis(float velocitas, float tempusLevigatum) {
            Velocitas = velocitas;
            TempusLevigatum = tempusLevigatum;
        }
    }

    internal readonly struct OrdinatioCivisMotusVerticalis {
        public readonly float Velocitas { get; }
        public readonly float TempusLevigatum { get; }

        public OrdinatioCivisMotusVerticalis(float velocitas, float tempusLevigatum) {
            Velocitas = velocitas;
            TempusLevigatum = tempusLevigatum;
        }
    }

    internal readonly struct OrdinatioCivisMotusRotationisY {
        public readonly float RotatioY { get; }
        public readonly float TempusLevigatum { get; }

        public OrdinatioCivisMotusRotationisY(float rotatioY, float tempusLevigatum) {
            RotatioY = rotatioY;
            TempusLevigatum = tempusLevigatum;
        }
    }

    internal readonly struct OrdinatioCivisMotus {
        public readonly OrdinatioCivisMotusHorizontalis Horizontalis { get; }
        public readonly OrdinatioCivisMotusVerticalis Verticalis { get; }
        public readonly OrdinatioCivisMotusRotationisY RotationisY { get; }

        public OrdinatioCivisMotus(
            OrdinatioCivisMotusHorizontalis horizontalis,
            OrdinatioCivisMotusVerticalis verticalis,
            OrdinatioCivisMotusRotationisY rotationisY
        ) {
            Horizontalis = horizontalis;
            Verticalis = verticalis;
            RotationisY = rotationisY;
        }
    }
}
