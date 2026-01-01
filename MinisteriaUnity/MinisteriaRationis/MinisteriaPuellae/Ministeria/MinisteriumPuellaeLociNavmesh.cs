using UnityEngine;
using UnityEngine.AI;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Dux.ContractusDucis;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal class MinisteriumPuellaeLociNavmesh {
        private readonly IConfiguratioPuellaeLoci _configLoci;
        private readonly NavMeshAgent _agent;

        public MinisteriumPuellaeLociNavmesh(
            IConfiguratioPuellaeLoci configLoci,
            IAnchoraPuellae anchoraPuellae
        ) {
            _configLoci = configLoci;
            _agent = anchoraPuellae.NavMeshAgent;
        }

        public bool EstActivum => !_agent.isStopped;
        public bool EstAdPerveni() {
            if (!EstActivum) return false;
            return AdPerveni();
        }

        public float VelocitasHorizontalisActualis() {
            if (!EstActivum) return 0f;
            Vector3 v = _agent.velocity;
            Vector3 hv = new Vector3(v.x, 0f, v.z);
            return hv.magnitude;
        }

        public float VelocitasVerticalisActualis() {
            if (!EstActivum) return 0f;
            return _agent.velocity.y;
        }

        public float RotatioYActualis() {
            if (!EstActivum) return 0f;
            return _agent.transform.eulerAngles.y;
        }

        public Vector3 Positio() {
            if (!EstActivum) return Vector3.zero;
            return _agent.transform.position;
        }
        public Quaternion Rotatio() {
            if (!EstActivum) return Quaternion.identity;
            return _agent.transform.rotation;
        }

        public void Activare() {
            if (_agent.isStopped) return;
            _agent.isStopped = false;
        }

        public void Deactivare() {
            if (!_agent.isStopped) return;
            _agent.isStopped = true;
        }

        public void Transporto(Vector3 positio, Quaternion rotatio) {
            if (!EstActivum) return;
            _agent.ResetPath();
            _agent.Warp(positio);
            _agent.transform.rotation = rotatio;
        }

        public void IncipereMigrare(Vector3 positio) {
            if (!EstActivum) return;
            _agent.SetDestination(positio);
        }

        public void TerminareMigrare() {
            if (!EstActivum) return;
            _agent.ResetPath();
        }

        public void PonoVelocitatem(float velocitatem) {
            if (!EstActivum) return;
            _agent.speed = velocitatem;
        }
        public void PonoAccelerationem(float accelerationem) {
            if (!EstActivum) return;
            _agent.acceleration = accelerationem;
        }
        public void PonoVelocitatemRotationis(int velocitatemRotationisDeg) {
            if (!EstActivum) return;
            _agent.angularSpeed = velocitatemRotationisDeg;
        }
        public void PonoDistantiaDeaccelerationis(float distantiaDeaccelerationis) {
            if (!EstActivum) return;
            _agent.stoppingDistance = distantiaDeaccelerationis;
        }

        public float LegoVelocitatem() {
            if (!EstActivum) return 0f;
            return _agent.speed;
        }
        public float LegoAccelerationem() {
            if (!EstActivum) return 0f;
            return _agent.acceleration;
        }
        public float LegoVelocitatemRotationisDeg() {
            if (!EstActivum) return 0f;
            return (int)_agent.angularSpeed;
        }
        public float LegoDistantiaDeaccelerationis() {
            if (!EstActivum) return 0f;
            return _agent.stoppingDistance;
        }

        private bool AdPerveni() {
            if (!EstActivum) return false;
            if (!_agent.pathPending) {
                if (_agent.remainingDistance <= _configLoci.DistantiaAdPerveni) {
                    return true;
                }
            }
            return false;
        }



    }
}