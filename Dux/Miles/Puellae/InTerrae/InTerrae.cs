using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Dux.Thesaurus;
using System.Numerics;
using System;

namespace Yulinti.Dux.Miles {
    internal sealed class InTerrae {
        private readonly IOstiumPuellaeRelationisTerraeLegibile _osPuellaeRelationisTerraeLeg;
        private readonly IOstiumPuellaeOssisMutabile _osPuellaeOssisMut;
        private readonly IOstiumPuellaeOssisLegibile _osPuellaeOssisLeg;
        private readonly ThesaurusPuellaeInTerrae _thesaurusPuellaeInTerrae;

        public InTerrae(
            IOstiumPuellaeRelationisTerraeLegibile osPuellaeRelationisTerraeLeg,
            IOstiumPuellaeOssisMutabile osPuellaeOssisMut,
            IOstiumPuellaeOssisLegibile osPuellaeOssisLeg,
            ThesaurusPuellaeInTerrae thesaurusPuellaeInTerrae
        ) {
            _osPuellaeRelationisTerraeLeg = osPuellaeRelationisTerraeLeg;
            _osPuellaeOssisMut = osPuellaeOssisMut;
            _osPuellaeOssisLeg = osPuellaeOssisLeg;
            _thesaurusPuellaeInTerrae = thesaurusPuellaeInTerrae;
        }

        public void ElevoPelvis() {
            float differentia = ComputareDifferentiam();

            if (differentia >= 0f) {
                return;
            }

            Vector3 pelvisPositionis = _osPuellaeOssisLeg.LegoPositionem(IDPuellaeOssis.Hips);
            pelvisPositionis.Y -= differentia;
            _osPuellaeOssisMut.PonoPositionem(IDPuellaeOssis.Hips, pelvisPositionis);
        }

        private float ComputareDifferentiam() {
            float altitudoTerrae = AltitudoTerrae();
            float altitudoPedisMin = AltitudoPedisMin();
            float altitudoDigitusPedisMin = AltitudoDigitusPedisMin();

            // 足補正高度適用 
            // PedisMinが下 -> PedisMin-Terrae差 + PedisYCorrectivus
            // PedisMinが上(DigitusPedisMinが下) -> DigitusPedisMin-Terrae差 + DigitusPedisYCorrectivus
            float differentiaTerrae = (altitudoPedisMin < altitudoDigitusPedisMin) ?
                altitudoPedisMin - (altitudoTerrae + _thesaurusPuellaeInTerrae.PesYCorrectivus)
                : altitudoDigitusPedisMin - (altitudoTerrae + _thesaurusPuellaeInTerrae.DigitusPedisYCorrectivus);

            return differentiaTerrae;
        }

        private float AltitudoTerrae() {
            return _osPuellaeRelationisTerraeLeg.AltitudoTerrae(
                _thesaurusPuellaeInTerrae.RaycastAltitudo,
                _thesaurusPuellaeInTerrae.RaycastDistantia
            );
        }

        private float AltitudoPedisMin() {
            Vector3 pesPositionisDex = _osPuellaeOssisLeg.LegoPositionem(IDPuellaeOssis.RightFoot);
            Vector3 pesPositionisSin = _osPuellaeOssisLeg.LegoPositionem(IDPuellaeOssis.LeftFoot);

            return MathF.Min(pesPositionisDex.Y, pesPositionisSin.Y);
        }

        private float AltitudoDigitusPedisMin() {
            Vector3 digitusPedisPositionisDex = _osPuellaeOssisLeg.LegoPositionem(IDPuellaeOssis.RightToe);
            Vector3 digitusPedisPositionisSin = _osPuellaeOssisLeg.LegoPositionem(IDPuellaeOssis.LeftToe);

            return MathF.Min(digitusPedisPositionisDex.Y, digitusPedisPositionisSin.Y);
        }
    }
}