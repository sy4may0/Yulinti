using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using System.Numerics;
using System;

namespace Yulinti.Dux.Exercitus {
    internal sealed class AdiectorPuellaePelvisAltitudinis {
        private readonly IOstiumPuellaeOssisMutabile _osPuellaeOssisMut;
        private readonly ThesaurusPuellaeActionisSecundarius _thesaurus;

        private float _elevatioActualis = 0f;

        public AdiectorPuellaePelvisAltitudinis(
            IOstiumPuellaeOssisMutabile osPuellaeOssisMut,
            ThesaurusPuellaeActionisSecundarius thesaurus
        ) {
            _osPuellaeOssisMut = osPuellaeOssisMut;
            _thesaurus = thesaurus;
        }

        public void ElevoPelvis(
            ContextusPuellaeOstiorumLegibile contextusOstiorum
        ) {
            IOstiumPuellaeRelationisTerraeLegibile relationisTerraeLeg = contextusOstiorum.RelationisTerrae;
            IOstiumPuellaeOssisLegibile ossisLeg = contextusOstiorum.Ossis;

            float differentia = ComputareDifferentiam(
                relationisTerraeLeg,
                ossisLeg
            );

            if (differentia < -_thesaurus.MaxElevatio) {
                _elevatioActualis = 0f;
                return;
            }

            if (differentia >= 0f) {
                _elevatioActualis = 0f;
                return;
            }

            if (MathF.Abs(MathF.Abs(differentia) - MathF.Abs(_elevatioActualis)) > 0.1f) {
                return;
            }

            Vector3 pelvisPositionis = ossisLeg.LegoPositionem(IDPuellaeOssis.Hips);
            pelvisPositionis.Y -= differentia;

            _osPuellaeOssisMut.PonoPositionem(IDPuellaeOssis.Hips, pelvisPositionis);

            _elevatioActualis = differentia;
        }

        private float ComputareDifferentiam(
            IOstiumPuellaeRelationisTerraeLegibile relationisTerraeLeg,
            IOstiumPuellaeOssisLegibile ossisLeg
        ) {
            float altitudoTerraeDex = AltitudoTerraeDextra(relationisTerraeLeg);
            float altitudoTerraeSin = AltitudoTerraeSinistra(relationisTerraeLeg);

            float altitudoPedisDex = AltitudoPedis(ossisLeg, IDPuellaeOssis.RightFoot);
            float altitudoPedisSin = AltitudoPedis(ossisLeg, IDPuellaeOssis.LeftFoot);
            float altitudoDigitusPedisDex = AltitudoDigitusPedis(ossisLeg, IDPuellaeOssis.RightToe);
            float altitudoDigitusPedisSin = AltitudoDigitusPedis(ossisLeg, IDPuellaeOssis.LeftToe);
            // ヒールとかの調整をやる場合、ここDebugして出たaltitudeをCorrectivusに入れるとちょうどぴったりになるよ。

            float differentiaTerraeDex = (altitudoPedisDex < altitudoDigitusPedisDex) ?
                altitudoPedisDex - (altitudoTerraeDex + _thesaurus.PesYCorrectivus)
                : altitudoDigitusPedisDex - (altitudoTerraeDex + _thesaurus.DigitusPedisYCorrectivus);

            float differentiaTerraeSin = (altitudoPedisSin < altitudoDigitusPedisSin) ?
                altitudoPedisSin - (altitudoTerraeSin + _thesaurus.PesYCorrectivus)
                : altitudoDigitusPedisSin - (altitudoTerraeSin + _thesaurus.DigitusPedisYCorrectivus);

            return MathF.Min(differentiaTerraeDex, differentiaTerraeSin);
        }

        private float AltitudoTerraeDextra(IOstiumPuellaeRelationisTerraeLegibile relationisTerraeLeg) {
            return relationisTerraeLeg.AltitudoTerraeDextra(
                _thesaurus.RaycastAltitudo,
                _thesaurus.RaycastDistantia
            );
        }

        private float AltitudoTerraeSinistra(IOstiumPuellaeRelationisTerraeLegibile relationisTerraeLeg) {
            return relationisTerraeLeg.AltitudoTerraeSinistra(
                _thesaurus.RaycastAltitudo,
                _thesaurus.RaycastDistantia
            );
        }

        private float AltitudoPedis(IOstiumPuellaeOssisLegibile ossisLeg, IDPuellaeOssis idPedisOssis) {
            Vector3 pesPositionisDex = ossisLeg.LegoPositionem(idPedisOssis);

            return pesPositionisDex.Y;
        }

        private float AltitudoDigitusPedis(IOstiumPuellaeOssisLegibile ossisLeg, IDPuellaeOssis idDigitusPedisOssis) {
            Vector3 digitusPedisPositionis = ossisLeg.LegoPositionem(idDigitusPedisOssis);

            return digitusPedisPositionis.Y;
        }
    }
}
