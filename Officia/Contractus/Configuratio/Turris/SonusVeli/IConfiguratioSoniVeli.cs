using UnityEngine;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.Officia.Contractus {
    public interface IConfiguratioSoniVeli {
        IDSonusVeli Id { get; }
        AudioClip Sonus { get; }
        float VisSoniBasis { get; }          // 基礎音量
        float TempusRefrigerationis { get; } // クールダウンタイム
        int Prioritas { get; }
    }
}