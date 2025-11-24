using Yulinti.Nucleus;
using UnityEngine;

namespace Yulinti.MinisteriaUnity.ConfiguratioMinisterii {
    public interface IConfiguratioCivisNavMesh {
        bool GenerareNavMeshAgent { get; }
        float RadiusNavMeshAgent { get; }
        float AltitudoNavMeshAgent { get; }
        float VelocitasNavMeshAgent { get; }
        float AceleratioNavMeshAgent { get; }
        float VelocitasRotationis { get; }
        float AltitudoBasisPedis { get; }
    }

    public interface IConfiguratioCivisOrdinatae : IConfiguratioCivisNavMesh {
        NihilAut<GameObject> CivisPrefab { get; }
        string IterAdCapitis { get; }
    }
}