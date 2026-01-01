using UnityEngine;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Dux.ContractusDucis;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class MinisteriumCivisLoci {
        private readonly TabulaCivis _tabulaCivis;

        private float[] _refVelocitisHorizontalis;
        private float[] _refVelocitisVerticalis;
        private float[] _refRotationisY;

        private float[] _velocitasHorizontalisActualis;
        private float[] _velocitasVerticalisActualis;
        private float[] _rotationisYActualis;

        private bool[] _estActivumCC;

        public MinisteriumCivisLoci(TabulaCivis tabulaCivis) {
            _tabulaCivis = tabulaCivis;
            // 0fですべて初期化
            _refVelocitisHorizontalis = new float[tabulaCivis.Longitudo];
            _refVelocitisVerticalis = new float[tabulaCivis.Longitudo];
            _refRotationisY = new float[tabulaCivis.Longitudo];
            _velocitasHorizontalisActualis = new float[tabulaCivis.Longitudo];
            _velocitasVerticalisActualis = new float[tabulaCivis.Longitudo];
            _rotationisYActualis = new float[tabulaCivis.Longitudo];
            _estActivumCC = new bool[tabulaCivis.Longitudo];
        }

        public int[] IDs => _tabulaCivis.IDs;
        public int Longitudo => _tabulaCivis.Longitudo;

        public bool EstActivum(int id) {
            if (!_tabulaCivis.ConareLego(id, out IAnchoraCivis anchora)) return false;
            if (!anchora.EstActivum) return false;
            if (anchora.CharacterController == null) return false;
            if (!_estActivumCC[id]) return false;
            return true;
        }

        public float VelocitasHorizontalisActualis(int id) {
            if (!EstActivum(id)) return 0f;
            return _velocitasHorizontalisActualis[id];
        }

        public float VelocitasVerticalisActualis(int id) {
            if (!EstActivum(id)) return 0f;
            return _velocitasVerticalisActualis[id];
        }

        public float RotatioYActualis(int id) {
            if (!EstActivum(id)) return 0f;
            return _rotationisYActualis[id];
        }

        public Vector3 Positio(int id) {
            if (!EstActivum(id)) return Vector3.zero;
            if (!_tabulaCivis.ConareLego(id, out IAnchoraCivis anchora)) return Vector3.zero;
            return anchora.CharacterController.transform.position;
        }
        public Quaternion Rotatio(int id) {
            if (!EstActivum(id)) return Quaternion.identity;
            if (!_tabulaCivis.ConareLego(id, out IAnchoraCivis anchora)) return Quaternion.identity;
            return anchora.CharacterController.transform.rotation;
        }

        private void PurgareVelocitates(int id) {
            _refVelocitisHorizontalis[id] = 0f;
            _refVelocitisVerticalis[id] = 0f;
            _velocitasHorizontalisActualis[id] = 0f;
            _velocitasVerticalisActualis[id] = 0f;
        }
        private void PurgareRotationes(int id) {
            if (!_tabulaCivis.ConareLego(id, out IAnchoraCivis anchora)) return;
            _refRotationisY[id] = 0f;
            _rotationisYActualis[id] = anchora.CharacterController.transform.rotation.eulerAngles.y;
        }

        public void Activare(int id) {
            _estActivumCC[id] = true;
        }
        public void Deactivare(int id) {
            _estActivumCC[id] = false;
        }

        public void PonoPositionemCoacte(int id, Vector3 positio) {
            if (!EstActivum(id)) return;
            if (!_tabulaCivis.ConareLego(id, out IAnchoraCivis anchora)) return;
            anchora.CharacterController.transform.position = positio;
            PurgareVelocitates(id);
        }
        public void PonoRotationemCoacte(int id, Quaternion rotatio) {
            if (!EstActivum(id)) return;
            if (!_tabulaCivis.ConareLego(id, out IAnchoraCivis anchora)) return;
            anchora.CharacterController.transform.rotation = rotatio;
            PurgareRotationes(id);
        }

        public void Moto(
            int id,
            float velocitasHorizontalisDesiderata,
            float tempusLevigatumHorizontalis,
            float velocitasVerticalisDesiderata,
            float tempusLevigatumVerticalis,
            float rotatioYDesiderata,
            float tempusLevigatumRotatioY,
            float intervallum
        ) {
            if (!EstActivum(id)) return;
            if (!_tabulaCivis.ConareLego(id, out IAnchoraCivis anchora)) return;

            _velocitasHorizontalisActualis[id] = ComputareVelocitasHorizontalis(
                id,
                velocitasHorizontalisDesiderata,
                tempusLevigatumHorizontalis,
                intervallum
            );
            _velocitasVerticalisActualis[id] = ComputareVelocitasVerticalis(
                id,
                velocitasVerticalisDesiderata,
                tempusLevigatumVerticalis,
                intervallum
            );
            _rotationisYActualis[id] = ComputareRotationisY(
                id,
                rotatioYDesiderata,
                tempusLevigatumRotatioY,
                intervallum
            );

            Vector3 motusHorizontalis =
                anchora.CharacterController.transform.forward * _velocitasHorizontalisActualis[id] * intervallum;
            Vector3 motusVerticalis =
                Vector3.up * _velocitasVerticalisActualis[id] * intervallum;
            Quaternion rotatio = Quaternion.Euler(0f, _rotationisYActualis[id], 0f);

            anchora.CharacterController.transform.rotation = rotatio;
            anchora.CharacterController.Move(motusHorizontalis + motusVerticalis);
        }

        private float ComputareVelocitasHorizontalis(
            int id,
            float velocitasDesiderata,
            float tempusLevigatum,
            float intervallum
        ) {
            float velocitas = 0f;
            if (tempusLevigatum <= 0.000001f) {
                velocitas = velocitasDesiderata;
            } else {
                velocitas = Mathf.SmoothDamp(
                    _velocitasHorizontalisActualis[id],
                    velocitasDesiderata,
                    ref _refVelocitisHorizontalis[id],
                    tempusLevigatum,
                    Mathf.Infinity,
                    intervallum
                );
            }

            return velocitas;
        }

        private float ComputareVelocitasVerticalis(
            int id,
            float velocitasVerticalisDesiderata,
            float tempusLevigatumVerticalis,
            float intervallum
        ) {
            float velocitas = 0f;
            if (tempusLevigatumVerticalis <= 0.000001f) {
                velocitas = velocitasVerticalisDesiderata;
            } else {
                velocitas = Mathf.SmoothDamp(
                    _velocitasVerticalisActualis[id],
                    velocitasVerticalisDesiderata,
                    ref _refVelocitisVerticalis[id],
                    tempusLevigatumVerticalis,
                    Mathf.Infinity,
                    intervallum
                );
            }
            return velocitas;
        }

        private float ComputareRotationisY(
            int id,
            float rotatioYDesiderata,
            float tempusLevigatum,
            float intervallum
        ) {
            float rotatioY = 0f;
            if (tempusLevigatum <= 0.000001f) {
                rotatioY = rotatioYDesiderata;
            } else {
                rotatioY = Mathf.SmoothDampAngle(
                    _rotationisYActualis[id],
                    rotatioYDesiderata,
                    ref _refRotationisY[id],
                    tempusLevigatum,
                    Mathf.Infinity,
                    intervallum
                );
            }

            return rotatioY;
        }
    }
}