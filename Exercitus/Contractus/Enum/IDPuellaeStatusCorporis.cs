namespace Yulinti.Exercitus.Contractus {
    public enum IDPuellaeStatusCorporis {
        Quies,                // Idle
        Ambulatio,            // Walk
        Cursus,               // Run
        Incumbo,              // Crouch
        IncumboAmbulationem,  // CrouchWalk

        // 特殊ステート Portus用
        StasisPortus
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
