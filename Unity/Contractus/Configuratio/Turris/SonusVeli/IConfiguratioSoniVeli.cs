using UnityEngine;
using Yulinti.Exercitus.Contractus;

namespace Yulinti.Unity.Contractus {
    public interface IConfiguratioSoniVeli {
        IDSonusVeli Id { get; }
        AudioClip Sonus { get; }
        float VisSoniBasis { get; }          // 基礎音量
        float TempusRefrigerationis { get; } // クールダウンタイム
        int Prioritas { get; }
    }
}