namespace Yulinti.ImperiumDelegatum.Contractus {
    public enum IDCivisPersonae {
        Nihil,
        // 通常Civisグループ
        VirIustus, // 正義マン TAM 0 ~ 199 
        VirCommunis, // 一般人 TAM 0 ~ 199
        VirVilis, // TAM 200 ~ 300
        VirTurpis, // TAM 200 ~ 500
        VirAbiectus, // TAM 500 ~ Maxima
        VirInsanus, // TAM 0 ~ 199
        MulierIustus, // TAM 0 ~ 199
        MulierCommunis, // TAM 0 ~ 199
        MulierVilis, // TAM 200 ~ 300
        MulierTurpis, // TAM 200 ~ 500
        MulierAbiectus, // TAM 500 ~ Maxima
        MulierInsanus // TAM 0 ~ Minima
    }
}