namespace Yulinti.Dux.Exercitus {
    internal struct OrdinatioPuellaeMotusHorizontalis {
        public float velocitas;
        public float tempusLevigatum;

        public OrdinatioPuellaeMotusHorizontalis(float velocitas, float tempusLevigatum) {
            this.velocitas = velocitas;
            this.tempusLevigatum = tempusLevigatum;
        }
    }

    internal struct OrdinatioPuellaeMotusVerticalis {
        public float velocitas;
        public float tempusLevigatum;

        public OrdinatioPuellaeMotusVerticalis(float velocitas, float tempusLevigatum) {
            this.velocitas = velocitas;
            this.tempusLevigatum = tempusLevigatum;
        }
    }

    internal struct OrdinatioPuellaeMotusRotationisY {
        public float rotatioY;
        public float tempusLevigatum;

        public OrdinatioPuellaeMotusRotationisY(float rotatioY, float tempusLevigatum) {
            this.rotatioY = rotatioY;
            this.tempusLevigatum = tempusLevigatum;
        }
    }

    internal struct OrdinatioPuellaeMotus {
        public OrdinatioPuellaeMotusHorizontalis horizontalis;
        public OrdinatioPuellaeMotusVerticalis verticalis;
        public OrdinatioPuellaeMotusRotationisY rotationisY;

        public OrdinatioPuellaeMotus(
            OrdinatioPuellaeMotusHorizontalis horizontalis,
            OrdinatioPuellaeMotusVerticalis verticalis,
            OrdinatioPuellaeMotusRotationisY rotationisY
        ) {
            this.horizontalis = horizontalis;
            this.verticalis = verticalis;
            this.rotationisY = rotationisY;
        }
    }
}
