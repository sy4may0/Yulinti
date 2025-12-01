using UnityEngine;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class MiniateriumPuellaeLoci {
        private readonly CharacterController _characterController;
        private readonly ITemporis _temporis;

        private float _refVelocitisHorizontalis;
        private float _refVelocitisVerticalis;
        private float _refRotationisY;

        private float _velocitasHorizontalisActualis;
        private float _velocitasVerticalisActualis;
        private float _rotationisYActualis;

        public MiniateriumPuellaeLoci(IAnchoraPuellae anchoraPuellae, ITemporis temporis) {
            if (temporis == null) {
                Errorum.Fatal(IDErrorum.MINIATERIUMPUELLAELOCI_TEMPORIS_NULL);
            }

            _characterController = anchoraPuellae.CharacterController;
            _temporis = temporis;
            _refVelocitisHorizontalis = 0f;
            _refVelocitisVerticalis = 0f;
            _refRotationisY = 0f;
            _velocitasHorizontalisActualis = 0f;
            _velocitasVerticalisActualis = 0f;
            _rotationisYActualis = _characterController.transform.rotation.eulerAngles.y;
        }

        public float VelHorizontalisActualis => _velocitasHorizontalisActualis;
        public float VelVerticalisActualis => _velocitasVerticalisActualis;
        public float RotatioYActualis => _rotationisYActualis;
        public Vector3 Positio => _characterController.transform.position;
        public Quaternion Rotatio => _characterController.transform.rotation;

        private void PurgareVelocitates() {
            _refVelocitisHorizontalis = 0f;
            _refVelocitisVerticalis = 0f;
            _velocitasHorizontalisActualis = 0f;
            _velocitasVerticalisActualis = 0f;
        }

        private void PurgareRotationes() {
            _refRotationisY = 0f;
            _rotationisYActualis = _characterController.transform.rotation.eulerAngles.y;
        }

        public void PonoPositionemCoacte(Vector3 positio) {
            _characterController.transform.position = positio;
            PurgareVelocitates();
        }

        public void PonoRotationemCoacte(Quaternion rotatio) {
            _characterController.transform.rotation = rotatio;
            PurgareRotationes();
        }

        public void Moto(
            float velocitasHorizontalisDesiderata,
            float tempusLevigatumHorizontalis,
            float velocitasVerticalisDesiderata,
            float tempusLevigatumVerticalis,
            float rotatioYDesiderata,
            float tempusLevigatumRotatioY,
            float intervallum
        ) {
            _velocitasHorizontalisActualis = ComputareVelocitasHorizontalis(
                velocitasHorizontalisDesiderata,
                tempusLevigatumHorizontalis,
                intervallum
            );
            _velocitasVerticalisActualis = ComputareVelocitasVerticalis(
                velocitasVerticalisDesiderata,
                tempusLevigatumVerticalis,
                intervallum
            );
            _rotationisYActualis = ComputareRotationisY(
                rotatioYDesiderata,
                tempusLevigatumRotatioY,
                intervallum
            );

            Vector3 motusHorizontalis =
                _characterController.transform.forward * _velocitasHorizontalisActualis * intervallum;
            Vector3 motusVerticalis =
                Vector3.up * _velocitasVerticalisActualis * intervallum;
            Quaternion rotatio = Quaternion.Euler(0f, _rotationisYActualis, 0f);

            _characterController.transform.rotation = rotatio;
            _characterController.Move(motusHorizontalis + motusVerticalis);
        }

        private float ComputareVelocitasHorizontalis(
            float velocitasDesiderata,
            float tempusLevigatum,
            float intervallum
        ) {
            float velocitas = 0f;
            if (tempusLevigatum <= 0.000001f) {
                velocitas = velocitasDesiderata;
            } else {
                velocitas = Mathf.SmoothDamp(
                    _velocitasHorizontalisActualis,
                    velocitasDesiderata,
                    ref _refVelocitisHorizontalis,
                    tempusLevigatum,
                    Mathf.Infinity,
                    intervallum
                );
            }

            return velocitas;
        }

        private float ComputareVelocitasVerticalis(
            float velocitasVerticalisDesiderata,
            float tempusLevigatumVerticalis,
            float intervallum
        ) {
            float velocitas = 0f;
            if (tempusLevigatumVerticalis <= 0.000001f) {
                velocitas = velocitasVerticalisDesiderata;
            } else {
                velocitas = Mathf.SmoothDamp(
                    _velocitasVerticalisActualis,
                    velocitasVerticalisDesiderata,
                    ref _refVelocitisVerticalis,
                    tempusLevigatumVerticalis,
                    Mathf.Infinity,
                    intervallum
                );
            }
            return velocitas;
        }

        private float ComputareRotationisY(
            float rotatioYDesiderata,
            float tempusLevigatum,
            float intervallum
        ) {
            float rotatioY = 0f;
            if (tempusLevigatum <= 0.000001f) {
                rotatioY = rotatioYDesiderata;
            } else {
                rotatioY = Mathf.SmoothDampAngle(
                    _rotationisYActualis,
                    rotatioYDesiderata,
                    ref _refRotationisY,
                    tempusLevigatum,
                    Mathf.Infinity,
                    intervallum
                );
            }

            return rotatioY;

        }
    }
}





