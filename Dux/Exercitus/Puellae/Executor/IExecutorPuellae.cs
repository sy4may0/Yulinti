namespace Yulinti.Dux.Exercitus {
    internal interface IExecutorPuellae {
        // Pulsusの最初に実行
        void Primum();
        // PulsusまたはPulsusTardusの最後に実行
        void Confirmare();
        // 完全初期化
        void Purgare();
    }
}