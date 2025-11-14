using UnityEngine
using Yulinti.MinisteriaUnity.MinisteriaNuclei;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class MinisteriumPuellaeRerationisTerrae {
        private readonly IFukaGrounderConfig _config;

        private readonly Transform _pesDexter;
        private readonly Transform _pesSinister;
        private readonly Transform _digitusPedisDexter;
        private readonly Transform _digitusPedisSinister;

        public MinisteriumPuellaeRelationisTerrae(IFukaGrounderConfig config) {
            if (config == null) {
                ModeratorErrorum.Fatal("MinisteriumPuellaeRerationisTerraeのFukaGrounderConfigがnullです。");
            }
            if (
                config.LeftFoot == null ||
                config.RightFoot == null ||
                config.LeftToe == null ||
                config.RightToe == null
            ) {
                ModeratorErrorum.Fatal("MinisteriumPuellaeRerationisTerraeのFukaGrounderConfigが不完全です。");
            }
            _config = config;

        _pesDexter = config.RightFoot;
        _pesSinister = config.LeftFoot;
        _digitusPedisDexter = config.RightToe;
        _digitusPedisSinister = config.LeftToe;
        }

        private float LegoTerramPositionemY(
            Vector3 rayOriginis, Vector3 rayDirectionis,
            float distantia, LayerMask stratum
        ) {
            if (Physics.Raycast(rayOriginis, rayDirectionis, out var hit, distantia, stratum)) {
                return hit.point.y + _config.Epsilon;
            }
            return float.NegativeInfinity;
        }
        private float ComputareTerramPositionemY(
            Transform pes, Transform digitusPedis
        ) {
            float altitude = _config.CastHeight;
            float distantia = _config.CastDistance;
            float stratum = _config.CastLayer;

            if (digitusPedis == null) {
                Vector3 rayOriginis = pes.position + Vector3.up * altitude;
                return LegoTerramPositionemY(rayOriginis, -Vector3.up, altitude + distantia, stratum);
            } else {
                float dy = Vector3.Dot(pes.position - digitusPedis.position, Vector3.up);
                Vector3 rayOriginis = (dy < 0f) 
                    ? pes.position + Vector3.up * altitude
                    : digitusPedis.position + Vector3.up * altitude;
                return LegoTerramPositionemY(rayOriginis, -Vector3.up, altitude + distantia, stratum);
            }
        }

        public float AltitudeTerrae() {
            float altitude = ComputareTerramPositionemY(_pesDexter, _digitusPedisDexter);
            if (float.IsNegativeInfinity(altitude)) {
                altitude = ComputareTerramPositionemY(_pesSinister, _digitusPedisSinister);
            }
            return altitude;
        }
    }
}