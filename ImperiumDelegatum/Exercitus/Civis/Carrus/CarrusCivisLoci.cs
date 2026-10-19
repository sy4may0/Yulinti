using Yulinti.ImperiumDelegatum.Contractus;
using System.Numerics;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    // Ordinatioを受け取り、Executorに渡す。
    internal sealed class CarrusCivisLoci : IOstiumCarrusCivisLoci {
        private readonly ExecutorCivisLoci _exLoci;

        private readonly LacusOrdinatioCivisLoci _lacusOrdinatio;

        public CarrusCivisLoci(
            IOstiumCivisLegibile ostiumCivisLegibile,
            ExecutorCivisLoci exLoci
        ) {
            _exLoci = exLoci;
            _lacusOrdinatio = new LacusOrdinatioCivisLoci(ostiumCivisLegibile.Longitudo);
        }

        // AurigaがConfirmare後に実行する。使用済みOrdinatioをLacusへ回収する。
        public void Colligere(int idCivis) {
            _lacusOrdinatio.ColligereOmnia(idCivis);
        }

        public void PostulareMotus(
            int idCivis,
            float velocitasHorizontalis,
            float tempusLevigatumHorizontalis,
            float rotatioYDeg,
            float tempusLevigatumRotationisYDeg
        ) {
            if (_lacusOrdinatio.EmittareMotus(idCivis, out var ordinatio)) {
                ordinatio.Pono(velocitasHorizontalis, tempusLevigatumHorizontalis, rotatioYDeg, tempusLevigatumRotationisYDeg);
                _exLoci.Executare(idCivis, ordinatio);
            }
        }

        public void PostulareNavmesh(
            int idCivis,
            Vector3 positio,
            bool estTransporto,
            float velocitasDesiderata,
            float accelerationem,
            int velocitasRotationis,
            float distantiaDeaccelerationis
        ) {
            if (_lacusOrdinatio.EmittareNavmesh(idCivis, out var ordinatio)) {
                ordinatio.Pono(positio, estTransporto, velocitasDesiderata, accelerationem, velocitasRotationis, distantiaDeaccelerationis);
                _exLoci.Executare(idCivis, ordinatio);
            }
        }
    }
}
