using UnityEngine;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;
using Yulinti.MinisteriaUnity.MinisteriaNuclei;
using Yulinti.MinisteriaUnity.MinisteriaRationis.MinisteriaPuellae.Locus.Interna;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class MiniateriumPuellaeLoci {
        private readonly CharacterController _characterController;

        private Thesaurus _thesaurus;

        private float _refVelocitisHorizontalis;
        private float _refVelocitisVerticalis;
        private float _refRotationisY;

        private float _velocitasHorizontalisPre;
        private float _velocitasVerticalisPre;
        private float _rotationisYPre;

        public MiniateriumPuellaeLoci(IConfiguratioPuellaeLoci config) {
            _characterController = config.CharacterController;
            if (_characterController == null) {
                ModeratorErrorum.Fatal("MiniateriumPuellaeLociのConfiguratioPuellaeLociのCharacterControllerがnullです。");
            }
            _thesaurus = new Thesaurus();
            _refVelocitisHorizontalis = 0f;
            _refVelocitisVerticalis = 0f;
            _refRotationisY = 0f;
            _velocitasHorizontalisPre = 0f;
            _velocitasVerticalisPre = 0f;
            _rotationisYPre = _characterController.transform.rotation.eulerAngles.y;
        }

        public float VelHorizontalisPre => _velocitasHorizontalisPre;
        public float VelVerticalisPre => _velocitasVerticalisPre;
        public float RotatioYPre => _rotationisYPre;
        public Vector3 Positio => _characterController.transform.position;
        public Quaternion Rotatio => _characterController.transform.rotation;

        private void PurgareVelocitates() {
            _refVelocitisHorizontalis = 0f;
            _refVelocitisVerticalis = 0f;
            _velocitasHorizontalisPre = 0f;
            _velocitasVerticalisPre = 0f;
        }

        private void PurgareRotationes() {
            _refRotationisY = 0f;
            _rotationisYPre = _characterController.transform.rotation.eulerAngles.y;
        }

        public void PonoPositionemCoacte(Vector3 positio) {
            _characterController.transform.position = positio;
            PurgareVelocitates();
        }

        public void PonoRotationemCoacte(Quaternion rotatio) {
            _characterController.transform.rotation = rotatio;
            PurgareRotationes();
        }

        public void AddoVelocitatemHorizontalisLate(
            float velocitasMeta,
            float tempusLevis,
            float intervallum
        ) {
            float velocitas = 0f;
            if (tempusLevis <= 0.000001f) {
                velocitas = velocitasMeta;
            } else {
                velocitas = Mathf.SmoothDamp(
                    _velocitasHorizontalisPre,
                    velocitasMeta,
                    ref _refVelocitisHorizontalis,
                    tempusLevis,
                    Mathf.Infinity,
                    intervallum
                );
            }

            _thesaurus.AddoVelHorizontalis(velocitas);
        }

        public void AddoVelocitatemVerticalisLate(
            float velocitasMeta,
            float tempusLevis,
            float intervallum
        ) {
            float velocitas = 0f;
            if (tempusLevis <= 0.000001f) {
                velocitas = velocitasMeta;
            } else {
                velocitas = Mathf.SmoothDamp(
                    _velocitasVerticalisPre,
                    velocitasMeta,
                    ref _refVelocitisVerticalis,
                    tempusLevis,
                    Mathf.Infinity,
                    intervallum
                );
            }

            _thesaurus.AddoVelVerticalis(velocitas);
        }

        public void PonoRotationisYLate(
            float rotatioYMeta,
            float tempusLevis,
            float intervallum
        ) {
            float rotatioY = 0f;
            if (tempusLevis <= 0.000001f) {
                rotatioY = rotatioYMeta;
            } else {
                rotatioY = Mathf.SmoothDampAngle(
                    _rotationisYPre,
                    rotatioYMeta,
                    ref _refRotationisY,
                    tempusLevis,
                    Mathf.Infinity,
                    intervallum
                );
            }

            _thesaurus.PonoRotationisY(Mathf.DeltaAngle(_rotationisYPre, rotatioY));
        }

        public void ApplicareMotum(float intervallum) {
            // 蓄積加算された速度を反映
            _characterController.transform.rotation = 
                _thesaurus.Rotatio(_rotationisYPre);
            _characterController.Move(
                _thesaurus.Motus(_characterController.transform.forward, intervallum));
            
            // 現在の速度と回転を保存
            _rotationisYPre = _characterController.transform.rotation.eulerAngles.y;
            _velocitasHorizontalisPre = _thesaurus.VelocitasHorizontalis;
            _velocitasVerticalisPre = _thesaurus.VelocitasVerticalis;
            
            // 蓄積値をリセット。
            _thesaurus.Purgare();
        }
    }
}