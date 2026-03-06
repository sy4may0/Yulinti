namespace Yulinti.Exercitus.Contractus {
    public enum IDPuellaeStatusCorporis {
        Quies,                // Idle
        Ambulatio,            // Walk
        Cursus,               // Run
        Incumbo,              // Crouch
        IncumboAmbulationem,  // CrouchWalk

        // 特殊ステート Portus用
        StasisPortus,

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
