using Yulinti.ImperiumDelegatum.Contractus;
using System.Numerics;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    // Ordinatioを受け取り、Executorに渡す。
    internal sealed class CarrusPuellaeLoci : IOstiumCarrusPuellaeLoci {
        private readonly ExecutorPuellaeLoci _exLoci;

        private readonly LacusOrdinatioPuellaeLoci _lacusOrdinatio;

        public CarrusPuellaeLoci(
            ExecutorPuellaeLoci exLoci
        ) {
            _exLoci = exLoci;
            _lacusOrdinatio = new LacusOrdinatioPuellaeLoci();
        }

        // AurigaがConfirmare後に実行する。使用済みOrdinatioをLacusへ回収する。
        public void Colligere() {
            _lacusOrdinatio.ColligereOmnia();
        }

        public void PostulareMotus(
            float velocitasHorizontalis,
            float tempusLevigatumHorizontalis,
            float rotatioYDeg,
            float tempusLevigatumRotationisYDeg
        ){
            if(_lacusOrdinatio.EmittareMotus(out var ordinatio)) {
                ordinatio.Pono(velocitasHorizontalis, tempusLevigatumHorizontalis, rotatioYDeg, tempusLevigatumRotationisYDeg);
                _exLoci.Executare(ordinatio);
            }
        }

        public void PostulareNavmesh(
            Vector3 positio,
            float velocitasDesiderata,
            float accelerationem,
            int velocitasRotationis,
            float distantiaDeaccelerationis
        ){
            if(_lacusOrdinatio.EmittareNavmesh(out var ordinatio)) {
                ordinatio.Pono(positio, velocitasDesiderata, accelerationem, velocitasRotationis, distantiaDeaccelerationis);
                _exLoci.Executare(ordinatio);
            }
        }

        public void PostulareNavmeshInitii(
            Vector3 positio,
            Quaternion rotatio
        ){
            if(_lacusOrdinatio.EmittareNavmeshInitii(out var ordinatio)) {
                ordinatio.Pono(positio, rotatio);
                _exLoci.Executare(ordinatio);
            }
        }
    }
}
