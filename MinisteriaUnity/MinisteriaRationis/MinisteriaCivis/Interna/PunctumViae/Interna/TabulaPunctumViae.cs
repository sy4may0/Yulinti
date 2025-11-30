using UnityEngine;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using System.Collections.Generic;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class TabulaPunctumViae {
        private readonly Dictionary<IAnchoraPunctumViae, PunctumViae> _tabla;

        public TabulaPunctumViae(IAnchoraPunctumViae[] anchoraPunctumViae) {
            _tabla = new Dictionary<IAnchoraPunctumViae, PunctumViae>(anchoraPunctumViae.Length);
            foreach (IAnchoraPunctumViae anc in anchoraPunctumViae) {
                PunctumViae pv = new PunctumViae(
                    anc,
                    FabricaResolvor.Creare(anc.Typus).Evolvo(IDErrorum.PUNCTUMVIAE_RESOLVOR_CREATION_FAILED),
                    this
                );
                _tabla.Add(anc, pv);
            }
        }

        public PunctumViae Lego(IAnchoraPunctumViae anchoraPunctumViae) => _tabla[anchoraPunctumViae];

        public PunctumViae[] IacereOrdinem(
            IAnchoraPunctumViae[] anchorae
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
                IAnchoraPunctumViae anc = anchorae[i].GetComponent<IAnchoraPunctumViae>();
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



