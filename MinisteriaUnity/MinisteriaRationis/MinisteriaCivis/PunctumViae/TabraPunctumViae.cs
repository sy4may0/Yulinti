using UnityEngine;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;
using System.Collections.Generic;
using System;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class TabraPunctumViae {
        private readonly PunctumViae[][] _punctaViae;

        public TabraPunctumViae(GameObject[] wayPoints) {
            int typusCount = Enum.GetValues(typeof(IDPunctumViaeTypi)).Length;
            _punctaViae = new PunctumViae[typusCount][];

            GameObject[] gameObjects = wayPoints;

            List<PunctumViae> puncta = new List<PunctumViae>(gameObjects.Length);

            for (int i = 0; i < gameObjects.Length; i++) {
                PunctumViae pv = gameObjects[i].GetComponent<PunctumViae>();
                if (pv == null) {
                    Errorum.Fatal(IDErrorum.PUNCTUMVIAE_MONOBEHAVIOUR_ITEM_IS_NULL);
                }
                pv.Initio();
                puncta.Add(pv);
            }

            foreach (IDPunctumViaeTypi typus in Enum.GetValues(typeof(IDPunctumViaeTypi)))
            {
                List<PunctumViae> tmp = new List<PunctumViae>();
                foreach (PunctumViae pv in puncta)
                {
                    if (pv.Typus == typus)
                    {
                        tmp.Add(pv);
                    }
                }
                _punctaViae[(int)typus] = tmp.ToArray();
            }
        }

        public PunctumViae[] Lego(IDPunctumViaeTypi typus) => _punctaViae[(int)typus];
    }
}