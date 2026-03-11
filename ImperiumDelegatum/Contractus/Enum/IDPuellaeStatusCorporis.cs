namespace Yulinti.ImperiumDelegatum.Contractus {
    public enum IDPuellaeStatusCorporis {
        Quies,                // Idle
        Ambulatio,            // Walk
        Cursus,               // Run
        Incumbo,              // Crouch
        IncumboAmbulationem,  // CrouchWalk

        // 特殊ステート Portus用
        StasisPortus,

        // エモートステート
        // エモートは必ずPosituraIncipalisからスタートする。
        // エモート入力 -> PosituraIncipalisに入る。
        // PosituraIncipalisは速度0に減速、規定以下まで減速したらエモートステートに遷移する。
        SpectaculumIncipalis,    // エモート入る前の準備ステート。
        SpectaculumFormosa01,    // Formosaポーズ01

        // 特殊ステート Nihil用
        Nihil = 999999
    }

    public enum IDPuellaeStatusCorporisModiMotus {
        MotusQuietus,
        MotusLoci
    }

    public enum IDPuellaeStatusCorporisModiNavmesh {
        NavmeshQuietus,
        NavmeshLoci
    }
}
