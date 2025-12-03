namespace Yulinti.Dux.ContractusDucis {
    public interface IConfiguratioPuellaeStatusCorporis {
        IDStatus Id { get; set; }
        float VelocitasDesiderata { get; set; }
        float Acceleratio { get; set; }
        float Deceleratio { get; set; }
        bool EstLevigatum { get; set; }
    }
}