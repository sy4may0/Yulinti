using UnityEngine;
using UnityEngine.AI;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class MinisteriumCivisLoci {
        private readonly TabulaCivis _tabulaCivis;
        private readonly IConfiguratioCivisLoci _configLoci;

        private readonly float[] _refVelocitisHorizontalis;
        private readonly float[] _refRotationisY;

        private readonly float[] _velocitasHorizontalisActualis;
        private readonly float[] _rotationisYActualis;

        private bool[] _estMotus;
        private bool[] _estNavMesh;

        public MinisteriumCivisLoci(
            TabulaCivis tabulaCivis,
            IConfiguratioCivisLoci configLoci
        ) {
            _tabulaCivis = tabulaCivis;
            _configLoci = configLoci;

            _refVelocitisHorizontalis = new float[tabulaCivis.Longitudo];
            _refRotationisY = new float[tabulaCivis.Longitudo];
            _velocitasHorizontalisActualis = new float[tabulaCivis.Longitudo];
            _rotationisYActualis = new float[tabulaCivis.Longitudo];

            _estMotus = new bool[tabulaCivis.Longitudo];
            _estNavMesh = new bool[tabulaCivis.Longitudo];
            for (int id = 0; id < tabulaCivis.Longitudo; id++) {
                _estMotus[id] = true;
                _estNavMesh[id] = false;
            }
        }

        public int[] IDs => _tabulaCivis.IDs;
        public int Longitudo => _tabulaCivis.Longitudo;

        private bool ConareLegoNavMesh(int id, out IAnchoraCivis anchora) {
            if (!_tabulaCivis.ConareLego(id, out anchora)) return false;
            if (anchora.NavMeshAgent == null) return false;
            if (!anchora.EstActivum) return false;
            return anchora.NavMeshAgent.enabled;
        }

        public bool EstActivum(int id) {
            return ConareLegoNavMesh(id, out _);
        }

        public void ActivareMotus(int id) {
            if (EstActivumMotus(id)) return;
            if (!ConareLegoNavMesh(id, out IAnchoraCivis anchora)) return;
            anchora.NavMeshAgent.isStopped = true;
            anchora.NavMeshAgent.updateRotation = false;
            anchora.NavMeshAgent.updatePosition = false;
            _estMotus[id] = true;
            _estNavMesh[id] = false;
            // 速度をNavMesh移動から同期する。
            _velocitasHorizontalisActualis[id] = VelocitasHorizontalisNavMesh(id, anchora);
            _rotationisYActualis[id] = anchora.NavMeshAgent.transform.eulerAngles.y;
            anchora.NavMeshAgent.ResetPath();
        }

        public void ActivareNavMesh(int id) {
            if (EstActivumNavMesh(id)) return;
            if (!ConareLegoNavMesh(id, out IAnchoraCivis anchora)) return;
            anchora.NavMeshAgent.isStopped = false;
            anchora.NavMeshAgent.updateRotation = true;
            anchora.NavMeshAgent.updatePosition = true;
            _estMotus[id] = false;
            _estNavMesh[id] = true;
            // 多分NavMeshAgentに初速を与えることができない。 
            Transporto(
                id,
                anchora.NavMeshAgent.transform.position,
                anchora.NavMeshAgent.transform.rotation
            );
            anchora.NavMeshAgent.ResetPath();
        }

        public bool EstActivumMotus(int id) {
            return _estMotus[id];
        }
        public bool EstActivumNavMesh(int id) {
            return _estNavMesh[id];
        }

        // NavMesh制御
        public bool EstAdPerveni(int id) {
            if (!EstActivumNavMesh(id)) return false;
            if (!ConareLegoNavMesh(id, out IAnchoraCivis anchora)) return false;
            if (!anchora.NavMeshAgent.pathPending) {
                if (anchora.NavMeshAgent.remainingDistance <= _configLoci.DistantiaAdPerveni) {
                    return true;
                }
            }
            return false;
        }

        // NavMesh制御
        public bool EstMigrare(int id) {
            if (!EstActivumNavMesh(id)) return false;
            if (!ConareLegoNavMesh(id, out IAnchoraCivis anchora)) return false;
            return !anchora.NavMeshAgent.pathPending && anchora.NavMeshAgent.hasPath;
        }

        // 共通
        public float VelocitasHorizontalisActualis(int id) {
            if (!ConareLegoNavMesh(id, out IAnchoraCivis anchora)) return 0f;
            if (EstActivumNavMesh(id)) {
                return VelocitasHorizontalisNavMesh(id, anchora);
            } else {
                return _velocitasHorizontalisActualis[id];
            }
        }

        private float VelocitasHorizontalisNavMesh(int id, IAnchoraCivis anchora) {
            Vector3 v = anchora.NavMeshAgent.velocity;
            Vector3 hv = new Vector3(v.x, 0f, v.z);
            return hv.magnitude;
        }

        // 共通
        public float RotatioYActualis(int id) {
            if (!ConareLegoNavMesh(id, out IAnchoraCivis anchora)) return 0f;
            return anchora.NavMeshAgent.transform.eulerAngles.y;
        }

        // 共通
        public Vector3 Positio(int id) {
            if (!ConareLegoNavMesh(id, out IAnchoraCivis anchora)) return Vector3.zero;
            return anchora.NavMeshAgent.transform.position;
        }

        // 共通
        public Quaternion Rotatio(int id) {
            if (!ConareLegoNavMesh(id, out IAnchoraCivis anchora)) return Quaternion.identity;
            return anchora.NavMeshAgent.transform.rotation;
        }

        // 共通
        public void Transporto(int id, Vector3 positio, Quaternion rotatio) {
            if (!ConareLegoNavMesh(id, out IAnchoraCivis anchora)) return;
            if (NavMesh.SamplePosition(positio, out NavMeshHit hit, 5f, NavMesh.AllAreas)) {
                positio = hit.position;
            }
            anchora.NavMeshAgent.Warp(positio);
            anchora.NavMeshAgent.transform.rotation = rotatio;
            Purgare(id, anchora.NavMeshAgent);
        }

        // NavMesh制御
        public void InitareMigrare(int id) {
            if (!EstActivumNavMesh(id)) return;
            if (!ConareLegoNavMesh(id, out IAnchoraCivis anchora)) return;
            anchora.NavMeshAgent.ResetPath();
        }

        // NavMesh制御
        public void IncipereMigrare(int id, Vector3 positio) {
            if (!EstActivumNavMesh(id)) return;
            if (!ConareLegoNavMesh(id, out IAnchoraCivis anchora)) return;
            if (EstMigrare(id)) return;
            UnityEngine.Debug.LogError("MinisteriumCivisLoci: IncipereMigrare: id: " + id + " positio: " + positio);
            anchora.NavMeshAgent.SetDestination(positio);
        }

        // NavMesh制御
        public void PonoVelocitatem(int id, float velocitatem) {
            if (!EstActivumNavMesh(id)) return;
            if (!ConareLegoNavMesh(id, out IAnchoraCivis anchora)) return;
            anchora.NavMeshAgent.speed = velocitatem;
        }

        // NavMesh制御
        public void PonoAccelerationem(int id, float accelerationem) {
            if (!ConareLegoNavMesh(id, out IAnchoraCivis anchora)) return;
            anchora.NavMeshAgent.acceleration = accelerationem;
        }

        // NavMesh制御
        public void PonoVelocitatemRotationis(int id, int velocitatemRotationisDeg) {
            if (!ConareLegoNavMesh(id, out IAnchoraCivis anchora)) return;
            anchora.NavMeshAgent.angularSpeed = velocitatemRotationisDeg;
        }

        // NavMesh制御
        public void PonoDistantiaDeaccelerationis(int id, float distantiaDeaccelerationis) {
            if (!ConareLegoNavMesh(id, out IAnchoraCivis anchora)) return;
            anchora.NavMeshAgent.stoppingDistance = distantiaDeaccelerationis;
        }

        // Motus制御
        public void Moto(
            int id,
            float velocitasHorizontalisDesiderata,
            float tempusLevigatumHorizontalis,
            float rotatioYDesiderata,
            float tempusLevigatumRotatioY,
            float intervallum
        ) {
            if (!EstActivumMotus(id)) return;
            if (!ConareLegoNavMesh(id, out IAnchoraCivis anchora)) return;

            NavMeshAgent navMeshAgent = anchora.NavMeshAgent;

            _velocitasHorizontalisActualis[id] = ComputareVelocitasHorizontalis(
                id,
                velocitasHorizontalisDesiderata,
                tempusLevigatumHorizontalis,
                intervallum
            );
            _rotationisYActualis[id] = ComputareRotationisY(
                id,
                rotatioYDesiderata,
                tempusLevigatumRotatioY,
                intervallum
            );

            Vector3 motusHorizontalis = navMeshAgent.transform.forward * _velocitasHorizontalisActualis[id] * intervallum;
            Quaternion rotatio = Quaternion.Euler(0f, _rotationisYActualis[id], 0f);

            navMeshAgent.transform.rotation = rotatio;
            navMeshAgent.Move(motusHorizontalis);

            // Actualis回転は実体と同期する。
            // Actualis速度は壁衝突とかを無視するため、計算で求めた値を使う。
            _rotationisYActualis[id] = navMeshAgent.transform.rotation.eulerAngles.y;
        }

        private void Purgare(int id, NavMeshAgent navMeshAgent) {
            _refVelocitisHorizontalis[id] = 0f;
            _velocitasHorizontalisActualis[id] = 0f;
            _refRotationisY[id] = 0f;
            _rotationisYActualis[id] = navMeshAgent.transform.rotation.eulerAngles.y;
 
        }

        private float ComputareVelocitasHorizontalis(
            int id,
            float velocitasDesiderata,
            float tempusLevigatum,
            float intervallum
        ) {
            if (tempusLevigatum <= 0.000001f) {
                return velocitasDesiderata;
            } else {
                return Mathf.SmoothDamp(
                    _velocitasHorizontalisActualis[id],
                    velocitasDesiderata,
                    ref _refVelocitisHorizontalis[id],
                    tempusLevigatum,
                    Mathf.Infinity,
                    intervallum
                );
            }
        }

        private float ComputareRotationisY(
            int id,
            float rotatioYDesiderata,
            float tempusLevigatum,
            float intervallum
        ) {
            if (tempusLevigatum <= 0.000001f) {
                return rotatioYDesiderata;
            } else {
                return Mathf.SmoothDampAngle(
                    _rotationisYActualis[id],
                    rotatioYDesiderata,
                    ref _refRotationisY[id],
                    tempusLevigatum,
                    Mathf.Infinity,
                    intervallum
                );
            }
        }
    }
}
