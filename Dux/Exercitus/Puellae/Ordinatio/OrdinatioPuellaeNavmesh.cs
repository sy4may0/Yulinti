using System.Numerics;

namespace Yulinti.Dux.Exercitus {
    internal readonly struct OrdinatioPuellaeNavmesh {
        public readonly Vector3 Positio { get; }
        public readonly float VelocitasDesiderata { get; }
        public readonly float Acceleratio { get; }
        public readonly float VelocitasRotationis { get; }
        public readonly float DistantiaDeaccelerationis { get; }

        public OrdinatioPuellaeNavmesh(
            in Vector3 positio,
            float velocitasDesiderata,
            float accelerationem,
            float velocitasRotationis,
            float distantiaDeaccelerationis
        ) {
            Positio = positio;
            VelocitasDesiderata = velocitasDesiderata;
            Acceleratio = accelerationem;
            VelocitasRotationis = velocitasRotationis;
            DistantiaDeaccelerationis = distantiaDeaccelerationis;
        }
    }
}
