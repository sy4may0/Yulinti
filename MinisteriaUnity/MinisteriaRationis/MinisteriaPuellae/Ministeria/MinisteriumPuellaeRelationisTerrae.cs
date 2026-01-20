using UnityEngine;
using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.Dux.ContractusDucis;
using Yulinti.Nucleus;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class MinisteriumPuellaeRelationisTerrae {
        private readonly Transform _rightFoot;
        private readonly Transform _leftFoot;
        private readonly Transform _rightToe;
        private readonly Transform _leftToe;
        private readonly LayerMask _raycastStratum;

        public MinisteriumPuellaeRelationisTerrae(IConfiguratioPuellaeRelationisTerrae config, IAnchoraPuellae anchoraPuellae) {
            _rightFoot = anchoraPuellae.OsRightFoot;
            _leftFoot = anchoraPuellae.OsLeftFoot;
            _rightToe = anchoraPuellae.OsRightToe;
            _leftToe = anchoraPuellae.OsLeftToe;
            _raycastStratum = config.RaycastStratum.Evolvo(IDErrorum.MINISTERIUMPUELLAERELATIONISTERRAE_RAYCAST_STRATUM_NULL);
        }

        private float LegoTerramPositionemY(
            Vector3 rayOriginis, Vector3 rayDirectionis,
            float distantia
        ) {
            if (Physics.Raycast(rayOriginis, rayDirectionis, out var hit, distantia, _raycastStratum)) {
                return hit.point.y + Mathf.Epsilon;
            }
            return float.NegativeInfinity;
        }

        private float ComputareTerramPositionemY(
            Transform pes, Transform digitusPedis,
            float altitudo, float distantia
        ) {
            float dy = Vector3.Dot(pes.position - digitusPedis.position, Vector3.up);
            Vector3 rayOriginis = (dy < 0f)
                ? pes.position + Vector3.up * altitudo
                : digitusPedis.position + Vector3.up * altitudo;
            return LegoTerramPositionemY(rayOriginis, -Vector3.up, altitudo + distantia);
        }

        public float AltitudoTerraeDextra(
            float rayCastAltitudo, float rayCastDistantia
        ) {
            float altitudoTerrae = ComputareTerramPositionemY(
                _rightFoot, _rightToe,
                rayCastAltitudo, rayCastDistantia
            );
            return altitudoTerrae;
        }

        public float AltitudoTerraeSinistra(
            float rayCastAltitudo, float rayCastDistantia
        ) {
            float altitudoTerrae = ComputareTerramPositionemY(
                _leftFoot, _leftToe,
                rayCastAltitudo, rayCastDistantia
            );
            return altitudoTerrae;
        }
    }
}



