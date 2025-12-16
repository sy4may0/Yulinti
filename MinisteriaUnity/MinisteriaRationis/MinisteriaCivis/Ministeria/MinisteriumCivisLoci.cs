using UnityEngine;
using UnityEngine.AI;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Dux.ContractusDucis;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal class MinisteriumCivisLoci {
        private readonly NavMeshAgent _navmesh;
        private readonly IConfiguratioCivisLoci _config;

        public MinisteriumCivisLoci(
            IAnchoraCivis anchora,
            IConfiguratioCivisLoci config
        ) {
            _navmesh = anchora.NavMeshAgent;
            _config = config;
        }

        public bool EstActivum => _navmesh.enabled;
        public bool EstAdPerveni => AdPerveni();

        public float VelocitasHorizontalisActualis => VelocitasHorizontaris();
        public float VelocitasVerticalisActualis => _navmesh.velocity.y;
        public float RotatioYActualis => _navmesh.transform.rotation.y;

        public Vector3 Positio => _navmesh.transform.position;
        public Quaternion Rotatio => _navmesh.transform.rotation;


        public void Activare() {
            _navmesh.enabled = true;
        }

        public void Deactivare() {
            _navmesh.enabled = false;
        }

        public void Transporto(Vector3 positio) {
            if (!EstActivum) return;
            _navmesh.ResetPath();
            _navmesh.Warp(positio);
        }

        public void IncipereMigrare(Vector3 positio) {
            if (!EstActivum) return;
            _navmesh.SetDestination(positio);
        }

        public void TerminareMigrare() {
            if (!EstActivum) return;
            _navmesh.ResetPath();
        }

        private bool AdPerveni() {
            if (!EstActivum && !_navmesh.pathPending) {
                if (_navmesh.remainingDistance <= _config.DistantiaAdPerveni) {
                    return true;
                }
            }
            return false;
        }

        private float VelocitasHorizontaris() {
            Vector3 v = _navmesh.velocity;
            Vector3 hv = new Vector3(v.x, 0f, v.z);
            return hv.magnitude;
        }

    }
}