using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using System.Numerics;
using System;

namespace Yulinti.Dux.Exercitus {
    internal sealed class AdiectorPuellaePelvisAltitudinis {
        private readonly ContextusPuellaeOstiorumLegibile _contextusOstiorum;
        private readonly IOstiumPuellaeOssisMutabile _osPuellaeOssisMut;
        private readonly IConfiguratioPuellaeActionisSecundarius _configuratio;

        private float _elevatioActualis = 0f;

        public AdiectorPuellaePelvisAltitudinis(
            IOstiumPuellaeOssisMutabile osPuellaeOssisMut,
            ContextusPuellaeOstiorumLegibile contextusOstiorum
        ) {
            _osPuellaeOssisMut = osPuellaeOssisMut;
            _contextusOstiorum = contextusOstiorum;
            _configuratio = _contextusOstiorum.Configuratio.ActionisSecundarius;
        }

        public void ElevoPelvis() {
            float differentia = ComputareDifferentiam();

            if (differentia < -_configuratio.MaxElevatio) {
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

            Vector3 pelvisPositionis = _contextusOstiorum.Ossis.LegoPositionem(IDPuellaeOssis.Hips);
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
                altitudoPedisDex - (altitudoTerraeDex + _configuratio.PesYCorrectivus)
                : altitudoDigitusPedisDex - (altitudoTerraeDex + _configuratio.DigitusPedisYCorrectivus);

            float differentiaTerraeSin = (altitudoPedisSin < altitudoDigitusPedisSin) ?
                altitudoPedisSin - (altitudoTerraeSin + _configuratio.PesYCorrectivus)
                : altitudoDigitusPedisSin - (altitudoTerraeSin + _configuratio.DigitusPedisYCorrectivus);

            return MathF.Min(differentiaTerraeDex, differentiaTerraeSin);
        }

        private float AltitudoTerraeDextra() {
            return _contextusOstiorum.RelationisTerrae.AltitudoTerraeDextra(
                _configuratio.RaycastAltitudo,
                _configuratio.RaycastDistantia
            );
        }

        private float AltitudoTerraeSinistra() {
            return _contextusOstiorum.RelationisTerrae.AltitudoTerraeSinistra(
                _configuratio.RaycastAltitudo,
                _configuratio.RaycastDistantia
            );
        }

        private float AltitudoPedis(IDPuellaeOssis idPedisOssis) {
            Vector3 pesPositionisDex = _contextusOstiorum.Ossis.LegoPositionem(idPedisOssis);

            return pesPositionisDex.Y;
        }

        private float AltitudoDigitusPedis(IDPuellaeOssis idDigitusPedisOssis) {
            Vector3 digitusPedisPositionis = _contextusOstiorum.Ossis.LegoPositionem(idDigitusPedisOssis);

            return digitusPedisPositionis.Y;
        }
    }
}
