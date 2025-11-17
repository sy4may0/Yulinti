using UnityEngine;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;
using Yulinti.MinisteriaUnity.Interna;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class MinisteriumPuellaeRelationisTerrae {
        private readonly IConfiguratioPuellaeRelationisTerrae _config;

        private readonly Transform _rightFoot;
        private readonly Transform _leftFoot;
        private readonly Transform _rightToe;
        private readonly Transform _leftToe;

        public MinisteriumPuellaeRelationisTerrae(IConfiguratioPuellaeRelationisTerrae config) {
            if (config == null) {
                ModeratorErrorum.Fatal("MinisteriumPuellaeRelationisTerraeのConfiguratioPuellaeRelationisTerraeがnullです。");
            }
            if (
                config.LeftFoot == null ||
                config.RightFoot == null ||
                config.LeftToe == null ||
                config.RightToe == null
            ) {
                ModeratorErrorum.Fatal("MinisteriumPuellaeRelationisTerraeのConfiguratioPuellaeRelationisTerraeが不完全です。");
            }
            _config = config;

        _rightFoot = config.RightFoot;
        _leftFoot = config.LeftFoot;
        _rightToe = config.RightToe;
        _leftToe = config.LeftToe;
        }

        private float LegoTerramPositionemY(
            Vector3 rayOriginis, Vector3 rayDirectionis,
            float distantia, LayerMask stratum
        ) {
            if (Physics.Raycast(rayOriginis, rayDirectionis, out var hit, distantia, stratum)) {
                return hit.point.y + Mathf.Epsilon;
            }
            return float.NegativeInfinity;
        }
        private float ComputareTerramPositionemY(
            Transform pes, Transform digitusPedis,
            float altitudo, float distantia, LayerMask stratum
        ) {
            if (digitusPedis == null) {
                Vector3 rayOriginis = pes.position + Vector3.up * altitudo;
                return LegoTerramPositionemY(rayOriginis, -Vector3.up, altitudo + distantia, stratum);
            } else {
                float dy = Vector3.Dot(pes.position - digitusPedis.position, Vector3.up);
                Vector3 rayOriginis = (dy < 0f) 
                    ? pes.position + Vector3.up * altitudo
                    : digitusPedis.position + Vector3.up * altitudo;
                return LegoTerramPositionemY(rayOriginis, -Vector3.up, altitudo + distantia, stratum);
            }
        }

        public float AltitudoTerrae(
            float rayCastAltitudo, float rayCastDistantia, LayerMask rayCastStratum
        ) {
            float altitudoTerrae = ComputareTerramPositionemY(
                _rightFoot, _rightToe,
                rayCastAltitudo, rayCastDistantia, rayCastStratum
            );
            if (float.IsNegativeInfinity(altitudoTerrae)) {
                altitudoTerrae = ComputareTerramPositionemY(
                    _leftFoot, _leftToe,
                    rayCastAltitudo, rayCastDistantia, rayCastStratum
                );
            }
            return altitudoTerrae;
        }
    }
}