using Yulinti.Dux.ContractusDucis;
using System;
using System.Numerics;

namespace Yulinti.Dux.Exercitus {
    internal sealed class MotorPuellae {
        private Vector3 _positioPrior;
        private Vector3 _positioPosterior;

        private readonly IOstiumPuellaeLociMutabile _ostiumPuellaeLociMutabile;
        private readonly IOstiumPuellaeLociLegibile _ostiumPuellaeLociLegibile;
        private readonly IOstiumTemporisLegibile _ostiumTemporisLegibile;

        public MotorPuellae(
            IOstiumPuellaeLociMutabile ostiumPuellaeLociMutabile,
            IOstiumPuellaeLociLegibile ostiumPuellaeLociLegibile,
            IOstiumTemporisLegibile ostiumTemporisLegibile
        ) {
            _ostiumPuellaeLociMutabile = ostiumPuellaeLociMutabile;
            _ostiumPuellaeLociLegibile = ostiumPuellaeLociLegibile;
            _ostiumTemporisLegibile = ostiumTemporisLegibile;
        }

        public void ApplicareMotus(OrdinatioPuellaeMotus ordinatio) {
            _ostiumPuellaeLociMutabile.Moto(
                ordinatio.horizontalis.velocitas,
                ordinatio.horizontalis.tempusLevigatum,
                ordinatio.verticalis.velocitas,
                ordinatio.verticalis.tempusLevigatum,
                ordinatio.rotationisY.rotatioY,
                ordinatio.rotationisY.tempusLevigatum,
                _ostiumTemporisLegibile.Intervallum
            );
        }
    }
}
