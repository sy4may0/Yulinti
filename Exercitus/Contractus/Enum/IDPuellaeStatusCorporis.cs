namespace Yulinti.Exercitus.Contractus {
    public enum IDPuellaeStatusCorporis {
        None,
        Quies,                // Idle
        Ambulatio,            // Walk
        Cursus,               // Run
        Incumbo,              // Crouch
        IncumboAmbulationem  // CrouchWalk
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
