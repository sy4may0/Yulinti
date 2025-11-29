using UnityEngine;
using System.Collections.Generic;
using Yulinti.MinisteriaUnity.Anchora;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class TabulaPunctumViae {
        private readonly Dictionary<AnchoraPunctumViae, PunctumViae> _tabla;

        public TabulaPunctumViae(AnchoraPunctumViae[] anchoraPunctumViae) {
            _tabla = new Dictionary<AnchoraPunctumViae, PunctumViae>(anchoraPunctumViae.Length);
            foreach (AnchoraPunctumViae anc in anchoraPunctumViae) {
                PunctumViae pv = new PunctumViae(
                    anc,
                    FabricaResolvor.Creare(anc.Typus).Evolvo(IDErrorum.PUNCTUMVIAE_RESOLVOR_CREATION_FAILED),
                    this
                );
                _tabla.Add(anc, pv);
            }
        }

        public PunctumViae Lego(AnchoraPunctumViae anchoraPunctumViae) => _tabla[anchoraPunctumViae];

        public PunctumViae[] IacereOrdinem(
            AnchoraPunctumViae[] anchorae
        ) {
            if (anchorae.Length == 0) {
                return new PunctumViae[0];
            }

            PunctumViae[] punctaViae = new PunctumViae[anchorae.Length];
            for (int i = 0; i < anchorae.Length; i++) {
                punctaViae[i] = Lego(anchorae[i]);
            }
            return punctaViae;
        }

        public PunctumViae[] IacereOrdinem(
            GameObject[] anchorae
        ) {
            if (anchorae.Length == 0) {
                return new PunctumViae[0];
            }

            PunctumViae[] punctaViae = new PunctumViae[anchorae.Length];
            for (int i = 0; i < anchorae.Length; i++) {
                AnchoraPunctumViae anc = anchorae[i].GetComponent<AnchoraPunctumViae>();
                if (anc == null) {
                    Memorator.MemorareErrorum(IDErrorum.TABULAPUNCTUMVIAE_GAMEOBJECT_HAS_NO_ANCHORA);
                    return new PunctumViae[0];
                }
                punctaViae[i] = Lego(anc);
            }
            return punctaViae;
        }
    }
}