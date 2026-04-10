namespace Yulinti.Auctoritas.Contractus {
    public interface IOperatioPortusPuellaeFormae {
        // 通常ボタン用
        void Executare(UsusPortusPuellaeFormae usus);
        // スライダー操作用
        void Executare(UsusPortusPuellaeFormae usus, float ratio);
    }
}