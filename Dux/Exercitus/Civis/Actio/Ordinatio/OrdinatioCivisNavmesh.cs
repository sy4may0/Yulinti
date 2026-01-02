using System.Numerics;

namespace Yulinti.Dux.Exercitus {
    internal readonly struct OrdinatioCivisNavmesh {
        public readonly Vector3 Positio { get; }
        public readonly float VelocitasDesiderata { get; }
        public readonly float Acceleratio { get; }
        public readonly int VelocitasRotationis { get; }
        public readonly float DistantiaDeaccelerationis { get; }

        public OrdinatioCivisNavmesh(
            Vector3 positio,
            float velocitasDesiderata,
            float accelerationem,
            int velocitasRotationis,
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
