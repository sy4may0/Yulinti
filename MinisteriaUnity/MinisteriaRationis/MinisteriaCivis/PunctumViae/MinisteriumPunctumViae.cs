using System;
using System.Collections.Generic;
using UnityEngine;
using Yulinti.Nucleus;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public class MinisteriumPunctumViae
    {
        private readonly Dictionary<IDPunctumViaeTypi, PunctumViae[]> _punctaViae;

        public MinisteriumPunctumViae(ConfiguratioPunctumViae configuratio)
        {
            _punctaViae = new Dictionary<IDPunctumViaeTypi, PunctumViae[]>();

            GameObject[] gameObjects = configuratio.PunctaViae.Evolvo(
                IDErrorum.MINISTERIUMPUNCTUMVIAE_CONFIGURATION_NULL
            );

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
                _punctaViae[typus] = tmp.ToArray();
            }
        }
    }
}