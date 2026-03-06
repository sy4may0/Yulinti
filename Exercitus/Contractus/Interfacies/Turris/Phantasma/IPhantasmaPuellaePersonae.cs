namespace Yulinti.Exercitus.Contractus {
    public interface IPhantasmaPuellaePersonae {
        public int GradusLuxuriosus { get; }
        public int AnimaLuxuriosus { get; }
        public int GradusExhibitus { get; }
        public int AnimaExhibitus { get; }
        public int GradusPerversus { get; }
        public int AnimaPerversus { get; }
        public int GradusQuaeritDolore { get; }
        public int AnimaQuaeritDolore { get; }
        
        public int SensusPapillae { get; }
        public int AnimaPapillae { get; }
        public int SensusLandicae { get; }
        public int AnimaLandicae { get; }
        public int SensusVaginae { get; }
        public int AnimaVaginae { get; }
        public int SensusAni { get; }
        public int AnimaAni { get; }
        public int SensusAusculum { get; }
        public int AnimaAusculum { get; }
        public int SensusCorporis { get; }
        public int AnimaCorporis { get; }

        // AnimaからGradus/Sensusを決定する。セーブ前に実行する。
        public void Normare();

        // 正規化済みかどうか。
        public bool EstNormalis();
    }
}