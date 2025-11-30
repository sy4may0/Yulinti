namespace Yulinti.Dux.Miles {
    internal struct OrdinatioMotusHorizontalis {
        public float velocitas;
        public float tempusLevigatum;

        public OrdinatioMotusHorizontalis(float velocitas, float tempusLevigatum) {
            this.velocitas = velocitas;
            this.tempusLevigatum = tempusLevigatum;
        }
    }

    internal struct OrdinatioMotusVerticalis {
        public float velocitas;
        public float tempusLevigatum;

        public OrdinatioMotusVerticalis(float velocitas, float tempusLevigatum) {
            this.velocitas = velocitas;
            this.tempusLevigatum = tempusLevigatum;
        }
    }

    internal struct OrdinatioMotusRotationisY {
        public float rotatioY;
        public float tempusLevigatum;

        public OrdinatioMotusRotationisY(float rotatioY, float tempusLevigatum) {
            this.rotatioY = rotatioY;
            this.tempusLevigatum = tempusLevigatum;
        }
    }

    internal struct OrdinatioMotus {
        public OrdinatioMotusHorizontalis horizontalis;
        public OrdinatioMotusVerticalis verticalis;
        public OrdinatioMotusRotationisY rotationisY;

        public OrdinatioMotus(
            OrdinatioMotusHorizontalis horizontalis,
            OrdinatioMotusVerticalis verticalis,
            OrdinatioMotusRotationisY rotationisY
        ) {
            this.horizontalis = horizontalis;
            this.verticalis = verticalis;
            this.rotationisY = rotationisY;
        }
    }
}
