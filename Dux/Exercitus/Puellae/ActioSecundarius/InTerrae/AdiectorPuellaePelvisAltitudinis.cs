using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using System.Numerics;
using System;

namespace Yulinti.Dux.Exercitus {
    internal sealed class AdiectorPuellaePelvisAltitudinis {
        private readonly IOstiumPuellaeRelationisTerraeLegibile _osPuellaeRelationisTerraeLeg;
        private readonly IOstiumPuellaeOssisMutabile _osPuellaeOssisMut;
        private readonly IOstiumPuellaeOssisLegibile _osPuellaeOssisLeg;
        private readonly ThesaurusPuellaeActionisSecundarius _thesaurus;

        private float _elevatioActualis = 0f;

        public AdiectorPuellaePelvisAltitudinis(
            IOstiumPuellaeRelationisTerraeLegibile osPuellaeRelationisTerraeLeg,
            IOstiumPuellaeOssisMutabile osPuellaeOssisMut,
            IOstiumPuellaeOssisLegibile osPuellaeOssisLeg,
            ThesaurusPuellaeActionisSecundarius thesaurus
        ) {
            _osPuellaeRelationisTerraeLeg = osPuellaeRelationisTerraeLeg;
            _osPuellaeOssisMut = osPuellaeOssisMut;
            _osPuellaeOssisLeg = osPuellaeOssisLeg;
            _thesaurus = thesaurus;
        }

        public void ElevoPelvis() {
            float differentia = ComputareDifferentiam();

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

            Vector3 pelvisPositionis = _osPuellaeOssisLeg.LegoPositionem(IDPuellaeOssis.Hips);
            pelvisPositionis.Y -= differentia;

            _osPuellaeOssisMut.PonoPositionem(IDPuellaeOssis.Hips, pelvisPositionis);

            _elevatioActualis = differentia;
        }

        private float ComputareDifferentiam() {
            float altitudoTerraeDex = AltitudoTerraeDextra();
            float altitudoTerraeSin = AltitudoTerraeSinistra();

            float altitudoPedisDex = AltitudoPedis(IDPuellaeOssis.RightFoot);
            float altitudoPedisSin = AltitudoPedis(IDPuellaeOssis.LeftFoot);
            float altitudoDigitusPedisDex = AltitudoDigitusPedis(IDPuellaeOssis.RightToe);
            float altitudoDigitusPedisSin = AltitudoDigitusPedis(IDPuellaeOssis.LeftToe);
            // ヒールとかの調整をやる場合、ここDebugして出たaltitudeをCorrectivusに入れるとちょうどぴったりになるよ。

            float differentiaTerraeDex = (altitudoPedisDex < altitudoDigitusPedisDex) ?
                altitudoPedisDex - (altitudoTerraeDex + _thesaurus.PesYCorrectivus)
                : altitudoDigitusPedisDex - (altitudoTerraeDex + _thesaurus.DigitusPedisYCorrectivus);

            float differentiaTerraeSin = (altitudoPedisSin < altitudoDigitusPedisSin) ?
                altitudoPedisSin - (altitudoTerraeSin + _thesaurus.PesYCorrectivus)
                : altitudoDigitusPedisSin - (altitudoTerraeSin + _thesaurus.DigitusPedisYCorrectivus);

            return MathF.Min(differentiaTerraeDex, differentiaTerraeSin);
        }

        private float AltitudoTerraeDextra() {
            return _osPuellaeRelationisTerraeLeg.AltitudoTerraeDextra(
                _thesaurus.RaycastAltitudo,
                _thesaurus.RaycastDistantia
            );
        }

        private float AltitudoTerraeSinistra() {
            return _osPuellaeRelationisTerraeLeg.AltitudoTerraeSinistra(
                _thesaurus.RaycastAltitudo,
                _thesaurus.RaycastDistantia
            );
        }

        private float AltitudoPedis(IDPuellaeOssis idPedisOssis) {
            Vector3 pesPositionisDex = _osPuellaeOssisLeg.LegoPositionem(idPedisOssis);

            return pesPositionisDex.Y;
        }

        private float AltitudoDigitusPedis(IDPuellaeOssis idDigitusPedisOssis) {
            Vector3 digitusPedisPositionis = _osPuellaeOssisLeg.LegoPositionem(idDigitusPedisOssis);

            return digitusPedisPositionis.Y;
        }
    }
}
