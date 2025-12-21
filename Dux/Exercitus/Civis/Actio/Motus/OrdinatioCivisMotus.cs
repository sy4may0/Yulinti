namespace Yulinti.Dux.Exercitus {
    internal struct OrdinatioCivisMotusHorizontalis {
        public float velocitas;
        public float tempusLevigatum;

        public OrdinatioCivisMotusHorizontalis(float velocitas, float tempusLevigatum) {
            this.velocitas = velocitas;
            this.tempusLevigatum = tempusLevigatum;
        }
    }

    internal struct OrdinatioCivisMotusVerticalis {
        public float velocitas;
        public float tempusLevigatum;

        public OrdinatioCivisMotusVerticalis(float velocitas, float tempusLevigatum) {
            this.velocitas = velocitas;
            this.tempusLevigatum = tempusLevigatum;
        }
    }

    internal struct OrdinatioCivisMotusRotationisY {
        public float rotatioY;
        public float tempusLevigatum;

        public OrdinatioCivisMotusRotationisY(float rotatioY, float tempusLevigatum) {
            this.rotatioY = rotatioY;
            this.tempusLevigatum = tempusLevigatum;
        }
    }

    internal struct OrdinatioCivisMotus {
        public bool estNihil;
        public OrdinatioCivisMotusHorizontalis horizontalis;
        public OrdinatioCivisMotusVerticalis verticalis;
        public OrdinatioCivisMotusRotationisY rotationisY;

        public OrdinatioCivisMotus(
            OrdinatioCivisMotusHorizontalis horizontalis,
            OrdinatioCivisMotusVerticalis verticalis,
            OrdinatioCivisMotusRotationisY rotationisY,
            bool estNihil = false
        ) {
            this.estNihil = estNihil;
            this.horizontalis = horizontalis;
            this.verticalis = verticalis;
            this.rotationisY = rotationisY;
        }
        public static OrdinatioCivisMotus NihilMotus => new OrdinatioCivisMotus(
            new OrdinatioCivisMotusHorizontalis(0f, 0f),
            new OrdinatioCivisMotusVerticalis(0f, 0f),
            new OrdinatioCivisMotusRotationisY(0f, 0f),
            true
        );
    }
}