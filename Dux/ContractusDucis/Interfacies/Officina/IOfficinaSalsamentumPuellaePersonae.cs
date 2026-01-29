// Save, Loadを管理する。
namespace Yulinti.Dux.ContractusDucis {
    public interface IOfficinaSalsamentumPuellaePersonae {
        // SaveSlot番号
        public int LoculusServandi { get; }
        // セーブ
        public void PostulareServare(IResFluidaPuellaePersonaeLegibile resFluida);
        // ロード -> ロードしたら↓のデータを更新する。
        public void Legere();

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
    }
}