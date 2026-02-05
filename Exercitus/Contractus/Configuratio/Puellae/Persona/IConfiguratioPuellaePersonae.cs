namespace Yulinti.Exercitus.Contractus {
    public interface IConfiguratioPuellaePersonae {
        // 経験値倍率の初期値(Lv0での倍率)
        int OffsetAnimae { get; }

        // 最大レベル
        int GradusMaximus { get; }
        // 最大感度レベル
        int SensusMaximus { get; }

        // 必要経験値係数
        int CofficiensAnimae { get; }

        
    }
}