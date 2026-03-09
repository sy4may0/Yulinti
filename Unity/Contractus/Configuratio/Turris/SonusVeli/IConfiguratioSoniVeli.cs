using UnityEngine;

namespace Yulinti.Unity.Contractus {
    public interface IConfiguratioSoniVeli {
        AudioClip Sonus { get; }
        float VisSoniBasis { get; }          // 基礎音量
        float TempusRefrigerationis { get; } // クールダウンタイム
    }
}