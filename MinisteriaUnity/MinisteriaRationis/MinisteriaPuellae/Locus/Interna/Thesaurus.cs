using UnityEngine;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis.MinisteriaPuellae.Locus.Interna {
    // 速度と回転を蓄積して、後で反映する。
    public sealed class Thesaurus {
        private float _thesaurusVelocitisHorizontalis;
        private float _thesaurusVelocitisVerticalis;
        private float _thesaurusRotationisY;

        public Thesaurus() {
            _thesaurusVelocitisHorizontalis = 0f;
            _thesaurusVelocitisVerticalis = 0f;
            _thesaurusRotationisY = 0f;
        }

        // 水平速度を蓄積加算。
        public void AddoVelHorizontalis(float velocitas) {
            _thesaurusVelocitisHorizontalis += velocitas;
        }

        // 垂直速度を蓄積加算。
        public void AddoVelVerticalis(float velocitas) {
            _thesaurusVelocitisVerticalis += velocitas;
        }

        // 回転を設定。加算せず上書き。
        // [NOTE] 風とかで追加回転がある場合、今の加算蓄積設計では対応できない。
        // トルク蓄積とかを実装してDeltaTime/Intervallumでやらないといけない。
        public void PonoRotationisY(float rotatioY) {
            _thesaurusRotationisY = rotatioY;
        }

        // 蓄積値をリセット。
        public void Purgare() {
            _thesaurusVelocitisHorizontalis = 0f;
            _thesaurusVelocitisVerticalis = 0f;
            _thesaurusRotationisY = 0f;
        }

        public float VelocitasHorizontalis => _thesaurusVelocitisHorizontalis;
        public float VelocitasVerticalis => _thesaurusVelocitisVerticalis;
        public float RotatioY => _thesaurusRotationisY;

        public Vector3 Motus(Vector3 directio, float intervallum) {
            // 最終的な移動量を算出。
            Vector3 horizontalis = directio * _thesaurusVelocitisHorizontalis * intervallum;
            Vector3 verticalis = Vector3.up * _thesaurusVelocitisVerticalis * intervallum;
            return horizontalis + verticalis;
        }

        public Quaternion Rotatio(float rotationisYPre) {
            // 最終的な回転を算出。
            return Quaternion.Euler(0, rotationisYPre + _thesaurusRotationisY, 0);
        }
    }
}