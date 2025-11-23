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

        private float _elevatioActualis = 0f;

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

            if (differentia < -_thesaurusPuellaeInTerrae.MaxElevatio) {
                _elevatioActualis = 0f;
                return;
            }

            if (differentia >= 0f) {
                _elevatioActualis = 0f;
                return;
            }

            // 急に動くケースは無視。
            if (MathF.Abs(MathF.Abs(differentia) - MathF.Abs(_elevatioActualis)) > 0.05f) {
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

            // 足補正高度適用 
            // PedisMinが下 -> PedisMin-Terrae差 + PedisYCorrectivus
            // PedisMinが上(DigitusPedisMinが下) -> DigitusPedisMin-Terrae差 + DigitusPedisYCorrectivus
            float differentiaTerraeDex = (altitudoPedisDex < altitudoDigitusPedisDex) ?
                altitudoPedisDex - (altitudoTerraeDex + _thesaurusPuellaeInTerrae.PesYCorrectivus)
                : altitudoDigitusPedisDex - (altitudoTerraeDex + _thesaurusPuellaeInTerrae.DigitusPedisYCorrectivus);

            float differentiaTerraeSin = (altitudoPedisSin < altitudoDigitusPedisSin) ?
                altitudoPedisSin - (altitudoTerraeSin + _thesaurusPuellaeInTerrae.PesYCorrectivus)
                : altitudoDigitusPedisSin - (altitudoTerraeSin + _thesaurusPuellaeInTerrae.DigitusPedisYCorrectivus);

            return MathF.Min(differentiaTerraeDex, differentiaTerraeSin);
        }

        private float AltitudoTerraeDextra() {
            return _osPuellaeRelationisTerraeLeg.AltitudoTerraeDextra(
                _thesaurusPuellaeInTerrae.RaycastAltitudo,
                _thesaurusPuellaeInTerrae.RaycastDistantia
            );
        }

        private float AltitudoTerraeSinistra() {
            return _osPuellaeRelationisTerraeLeg.AltitudoTerraeSinistra(
                _thesaurusPuellaeInTerrae.RaycastAltitudo,
                _thesaurusPuellaeInTerrae.RaycastDistantia
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