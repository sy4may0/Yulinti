using UnityEngine;

namespace Yulinti.MinisteriaUnity.Anchora {
    // IAnchora
    // MonoBehaviourに追加実装する。
    // Positio: 位置取得
    // Rotatio: 回転取得
    // Scale: スケール取得
    // Initio: 初期化関数 -> バリデーションとかを行う。
    public interface IAnchora {
        Vector3 Positio { get; }
        Quaternion Rotatio { get; }
        Vector3 Scala { get; }
        bool Validare();
    }
}