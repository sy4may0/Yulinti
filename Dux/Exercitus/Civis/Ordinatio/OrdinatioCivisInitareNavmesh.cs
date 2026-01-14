using System.Numerics;

namespace Yulinti.Dux.Exercitus {
    internal readonly struct OrdinatioCivisInitareNavmesh {
        public readonly Vector3 Positio { get; }

        public OrdinatioCivisInitareNavmesh(
            in Vector3 positio
        ) {
            Positio = positio;
        }
    }
}
