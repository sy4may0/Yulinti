using UnityEngine;
using UnityEngine.AI;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Dux.ContractusDucis;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal class MinisteriumCivisLociNavmesh {
        private readonly IConfiguratioCivisLoci _configLoci;
        private readonly TabulaCivis _tabulaCivis;

        public MinisteriumCivisLociNavmesh(
            TabulaCivis tabulaCivis,
            IConfiguratioCivisLoci configLoci
        ) {
            _tabulaCivis = tabulaCivis;
            _configLoci = configLoci;
        }

        public int[] IDs => _tabulaCivis.IDs;
        public int Longitudo => _tabulaCivis.Longitudo;

        public bool EstActivum(int id) {
            if (!_tabulaCivis.ConareLego(id, out IAnchoraCivis anchora)) return false;
            if (anchora.NavMeshAgent == null) return false;
            if (!anchora.EstActivum) return false;
            return anchora.NavMeshAgent.enabled;
        }

        public bool EstAdPerveni(int id) {
            if (!EstActivum(id)) return false;
            if (!_tabulaCivis.ConareLego(id, out IAnchoraCivis anchora)) return false;
            return AdPerveni(anchora.NavMeshAgent);
        }

        public bool EstMigrare(int id) {
            if (!EstActivum(id)) return false;
            if (!_tabulaCivis.ConareLego(id, out IAnchoraCivis anchora)) return false;
            return anchora.NavMeshAgent.pathPending && !anchora.NavMeshAgent.hasPath;
        }

        public float VelocitasHorizontalisActualis(int id) {
            if (!EstActivum(id)) return 0f;
            if (!_tabulaCivis.ConareLego(id, out IAnchoraCivis anchora)) return 0f;
            return VelocitasHorizontaris(anchora.NavMeshAgent);
        }

        public float VelocitasVerticalisActualis(int id) {
            if (!EstActivum(id)) return 0f;
            if (!_tabulaCivis.ConareLego(id, out IAnchoraCivis anchora)) return 0f;
            return anchora.NavMeshAgent.velocity.y;
        }
        public float RotatioYActualis(int id) {
            if (!EstActivum(id)) return 0f;
            if (!_tabulaCivis.ConareLego(id, out IAnchoraCivis anchora)) return 0f;
            return anchora.NavMeshAgent.transform.eulerAngles.y;
        }

        public Vector3 Positio(int id) {
            if (!EstActivum(id)) return Vector3.zero;
            if (!_tabulaCivis.ConareLego(id, out IAnchoraCivis anchora)) return Vector3.zero;
            return anchora.NavMeshAgent.transform.position;
        }
        public Quaternion Rotatio(int id) {
            if (!EstActivum(id)) return Quaternion.identity;
            if (!_tabulaCivis.ConareLego(id, out IAnchoraCivis anchora)) return Quaternion.identity;
            return anchora.NavMeshAgent.transform.rotation;
        }


        public void Activare(int id) {
            if (!_tabulaCivis.ConareLego(id, out IAnchoraCivis anchora)) return;
            if (!anchora.EstActivum || anchora.NavMeshAgent == null) return;
            anchora.NavMeshAgent.enabled = true;
        }

        public void Deactivare(int id) {
            if (!EstActivum(id)) return;
            if (!_tabulaCivis.ConareLego(id, out IAnchoraCivis anchora)) return;
            anchora.NavMeshAgent.enabled = false;
        }

        public void Transporto(int id, Vector3 positio, Quaternion rotatio) {
            if (!EstActivum(id)) return;
            if (!_tabulaCivis.ConareLego(id, out IAnchoraCivis anchora)) return;
            anchora.NavMeshAgent.ResetPath();
            anchora.NavMeshAgent.Warp(positio);
            anchora.NavMeshAgent.transform.rotation = rotatio;
        }

        public void InitareMigrare(int id) {
            if (!EstActivum(id)) return;
            if (!_tabulaCivis.ConareLego(id, out IAnchoraCivis anchora)) return;
            anchora.NavMeshAgent.ResetPath();
        }

        public void IncipereMigrare(int id, Vector3 positio) {
            if (!EstActivum(id)) return;
            if (!_tabulaCivis.ConareLego(id, out IAnchoraCivis anchora)) return;
            if (EstMigrare(id)) return;
            anchora.NavMeshAgent.SetDestination(positio);
        }

        public void TerminareMigrare(int id) {
            if (!EstActivum(id)) return;
            if (!_tabulaCivis.ConareLego(id, out IAnchoraCivis anchora)) return;
            anchora.NavMeshAgent.ResetPath();
        }

        public void PonoVelocitatem(int id, float velocitatem) {
            if (!EstActivum(id)) return;
            if (!_tabulaCivis.ConareLego(id, out IAnchoraCivis anchora)) return;
            anchora.NavMeshAgent.speed = velocitatem;
        }
        public void PonoAccelerationem(int id, float accelerationem) {
            if (!EstActivum(id)) return;
            if (!_tabulaCivis.ConareLego(id, out IAnchoraCivis anchora)) return;
            anchora.NavMeshAgent.acceleration = accelerationem;
        }
        public void PonoVelocitatemRotationis(int id, int velocitatemRotationisDeg) {
            if (!EstActivum(id)) return;
            if (!_tabulaCivis.ConareLego(id, out IAnchoraCivis anchora)) return;
            anchora.NavMeshAgent.angularSpeed = velocitatemRotationisDeg;
        }
        public void PonoDistantiaDeaccelerationis(int id, float distantiaDeaccelerationis) {
            if (!EstActivum(id)) return;
            if (!_tabulaCivis.ConareLego(id, out IAnchoraCivis anchora)) return;
            anchora.NavMeshAgent.stoppingDistance = distantiaDeaccelerationis;
        }

        public float LegoVelocitatem(int id) {
            if (!EstActivum(id)) return 0f;
            if (!_tabulaCivis.ConareLego(id, out IAnchoraCivis anchora)) return 0f;
            return anchora.NavMeshAgent.speed;
        }
        public float LegoAccelerationem(int id) {
            if (!EstActivum(id)) return 0f;
            if (!_tabulaCivis.ConareLego(id, out IAnchoraCivis anchora)) return 0f;
            return anchora.NavMeshAgent.acceleration;
        }
        public float LegoDistantiaDeaccelerationis(int id) {
            if (!EstActivum(id)) return 0f;
            if (!_tabulaCivis.ConareLego(id, out IAnchoraCivis anchora)) return 0f;
            return anchora.NavMeshAgent.stoppingDistance;
        }
        public int LegoVelocitatemRotationisDeg(int id) {
            if (!EstActivum(id)) return 0;
            if (!_tabulaCivis.ConareLego(id, out IAnchoraCivis anchora)) return 0;
            return (int)anchora.NavMeshAgent.angularSpeed;
        }

        private bool AdPerveni(NavMeshAgent navmesh) {
            if (!navmesh.pathPending) {
                if (navmesh.remainingDistance <= _configLoci.DistantiaAdPerveni) {
                    return true;
                }
            }
            return false;
        }

        private float VelocitasHorizontaris(NavMeshAgent navmesh) {
            Vector3 v = navmesh.velocity;
            Vector3 hv = new Vector3(v.x, 0f, v.z);
            return hv.magnitude;
        }
    }
}
