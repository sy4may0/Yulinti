using UnityEngine;
using UnityEngine.AI;
using Yulinti.Dux.ContractusDucis;
using Yulinti.Nucleus;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class MinisteriumPuellaeLoci {
        private readonly IAnchoraPuellae _anchoraPuellae;
        private readonly IConfiguratioPuellaeLoci _configLoci;

        private float _refVelocitasHorizontalis;
        private float _refRotationisY;

        private float _velocitasHorizontalisActualis;
        private float _rotationisYActualis;

        private bool _estMotus;
        private bool _estNavMesh;

        private bool _estErrans;

        public MinisteriumPuellaeLoci(
            IAnchoraPuellae anchoraPuellae,
            IConfiguratioPuellaeLoci configLoci
        ) {
            if (configLoci == null) {
                Errorum.Fatal(IDErrorum.MINIATERIUMPUELLAELOCI_CONFIG_NULL);
            }
            _anchoraPuellae = anchoraPuellae;
            _configLoci = configLoci;

            _refVelocitasHorizontalis = 0f;
            _refRotationisY = 0f;
            _velocitasHorizontalisActualis = 0f;
            _rotationisYActualis = ConareLegoNavMesh(out NavMeshAgent navMeshAgent)
                ? navMeshAgent.transform.rotation.eulerAngles.y
                : 0f;

            _estMotus = true;
            _estNavMesh = false;
        }

        private bool ConareLegoNavMesh(out NavMeshAgent navMeshAgent) {
            navMeshAgent = _anchoraPuellae?.NavMeshAgent;
            if (navMeshAgent == null) return false;
            if (!navMeshAgent.enabled) return false;
            return navMeshAgent.gameObject.activeInHierarchy;
        }

        public bool EstActivum() {
            return ConareLegoNavMesh(out _);
        }

        public bool EstErrans() {
            return _estErrans;
        }

        public void ActivareMotus() {
            if (EstActivumMotus()) return;
            if (!ConareLegoNavMesh(out NavMeshAgent navMeshAgent)) return;
            navMeshAgent.isStopped = true;
            navMeshAgent.updateRotation = false;
            navMeshAgent.updatePosition = false;
            _estMotus = true;
            _estNavMesh = false;
            _velocitasHorizontalisActualis = VelocitasHorizontalisNavMesh(navMeshAgent);
            _rotationisYActualis = navMeshAgent.transform.eulerAngles.y;
            navMeshAgent.ResetPath();
        }

        public bool ActivareNavMesh() {
            if (EstActivumNavMesh()) return true;
            if (!ConareLegoNavMesh(out NavMeshAgent navMeshAgent)) return false;
            navMeshAgent.isStopped = false;
            navMeshAgent.updateRotation = true;
            navMeshAgent.updatePosition = true;
            _estMotus = false;
            _estNavMesh = true;
            bool r = Transporto(
                navMeshAgent.transform.position,
                navMeshAgent.transform.rotation
            );
            navMeshAgent.ResetPath();
            return r;
        }

        public bool EstActivumMotus() {
            return _estMotus;
        }

        public bool EstActivumNavMesh() {
            return _estNavMesh;
        }

        public bool EstAdPerveni() {
            if (!EstActivumNavMesh()) return false;
            if (!ConareLegoNavMesh(out NavMeshAgent navMeshAgent)) return false;
            if (!navMeshAgent.pathPending) {
                if (navMeshAgent.remainingDistance <= _configLoci.DistantiaAdPerveni) {
                    return true;
                }
            }
            return false;
        }

        public bool EstMigrare() {
            if (!EstActivumNavMesh()) return false;
            if (!ConareLegoNavMesh(out NavMeshAgent navMeshAgent)) return false;
            return !navMeshAgent.pathPending && navMeshAgent.hasPath;
        }

        public float VelocitasHorizontalisActualis() {
            if (!ConareLegoNavMesh(out NavMeshAgent navMeshAgent)) return 0f;
            if (EstActivumNavMesh()) {
                return VelocitasHorizontalisNavMesh(navMeshAgent);
            }
            return _velocitasHorizontalisActualis;
        }

        private float VelocitasHorizontalisNavMesh(NavMeshAgent navMeshAgent) {
            Vector3 v = navMeshAgent.velocity;
            Vector3 hv = new Vector3(v.x, 0f, v.z);
            return hv.magnitude;
        }

        public float RotatioYActualis() {
            if (!ConareLegoNavMesh(out NavMeshAgent navMeshAgent)) return 0f;
            return navMeshAgent.transform.eulerAngles.y;
        }

        public Vector3 Positio() {
            if (!ConareLegoNavMesh(out NavMeshAgent navMeshAgent)) return Vector3.zero;
            return navMeshAgent.transform.position;
        }

        public Quaternion Rotatio() {
            if (!ConareLegoNavMesh(out NavMeshAgent navMeshAgent)) return Quaternion.identity;
            return navMeshAgent.transform.rotation;
        }

        public bool Transporto(Vector3 positio, Quaternion rotatio) {
            if (!ConareLegoNavMesh(out NavMeshAgent navMeshAgent)) return false;
            if (NavMesh.SamplePosition(positio, out NavMeshHit hit, 5f, NavMesh.AllAreas)) {
                positio = hit.position;
            }
            _estErrans = !navMeshAgent.Warp(positio);
            if (_estErrans) return false;
            navMeshAgent.transform.rotation = rotatio;
            Purgare(navMeshAgent);
            return !_estErrans;
        }

        public void InitareMigrare() {
            if (!EstActivumNavMesh()) return;
            if (!ConareLegoNavMesh(out NavMeshAgent navMeshAgent)) return;
            navMeshAgent.ResetPath();
        }

        public void IncipereMigrare(Vector3 positio) {
            if (!EstActivumNavMesh()) return;
            if (!ConareLegoNavMesh(out NavMeshAgent navMeshAgent)) return;
            navMeshAgent.ResetPath();
            navMeshAgent.SetDestination(positio);
        }

        public void PonoVelocitatem(float velocitatem) {
            if (!EstActivumNavMesh()) return;
            if (!ConareLegoNavMesh(out NavMeshAgent navMeshAgent)) return;
            navMeshAgent.speed = velocitatem;
        }

        public void PonoAccelerationem(float accelerationem) {
            if (!ConareLegoNavMesh(out NavMeshAgent navMeshAgent)) return;
            navMeshAgent.acceleration = accelerationem;
        }

        public void PonoVelocitatemRotationis(int velocitatemRotationisDeg) {
            if (!ConareLegoNavMesh(out NavMeshAgent navMeshAgent)) return;
            navMeshAgent.angularSpeed = velocitatemRotationisDeg;
        }

        public void PonoDistantiaDeaccelerationis(float distantiaDeaccelerationis) {
            if (!ConareLegoNavMesh(out NavMeshAgent navMeshAgent)) return;
            navMeshAgent.stoppingDistance = distantiaDeaccelerationis;
        }

        public void Moto(
            float velocitasHorizontalisDesiderata,
            float tempusLevigatumHorizontalis,
            float rotatioYDesiderata,
            float tempusLevigatumRotatioY,
            float intervallum
        ) {
            if (!EstActivumMotus()) return;
            if (!ConareLegoNavMesh(out NavMeshAgent navMeshAgent)) return;

            _velocitasHorizontalisActualis = ComputareVelocitasHorizontalis(
                velocitasHorizontalisDesiderata,
                tempusLevigatumHorizontalis,
                intervallum
            );
            _rotationisYActualis = ComputareRotationisY(
                rotatioYDesiderata,
                tempusLevigatumRotatioY,
                intervallum
            );

            Vector3 motusHorizontalis = navMeshAgent.transform.forward * _velocitasHorizontalisActualis * intervallum;
            Quaternion rotatio = Quaternion.Euler(0f, _rotationisYActualis, 0f);

            navMeshAgent.transform.rotation = rotatio;
            navMeshAgent.Move(motusHorizontalis);

            _rotationisYActualis = navMeshAgent.transform.rotation.eulerAngles.y;
        }

        private void Purgare(NavMeshAgent navMeshAgent) {
            _refVelocitasHorizontalis = 0f;
            _velocitasHorizontalisActualis = 0f;
            _refRotationisY = 0f;
            _rotationisYActualis = navMeshAgent.transform.rotation.eulerAngles.y;
        }

        private float ComputareVelocitasHorizontalis(
            float velocitasDesiderata,
            float tempusLevigatum,
            float intervallum
        ) {
            if (tempusLevigatum <= 0.000001f) {
                return velocitasDesiderata;
            }
            return Mathf.SmoothDamp(
                _velocitasHorizontalisActualis,
                velocitasDesiderata,
                ref _refVelocitasHorizontalis,
                tempusLevigatum,
                Mathf.Infinity,
                intervallum
            );
        }

        private float ComputareRotationisY(
            float rotatioYDesiderata,
            float tempusLevigatum,
            float intervallum
        ) {
            if (tempusLevigatum <= 0.000001f) {
                return rotatioYDesiderata;
            }
            return Mathf.SmoothDampAngle(
                _rotationisYActualis,
                rotatioYDesiderata,
                ref _refRotationisY,
                tempusLevigatum,
                Mathf.Infinity,
                intervallum
            );
        }
    }
}