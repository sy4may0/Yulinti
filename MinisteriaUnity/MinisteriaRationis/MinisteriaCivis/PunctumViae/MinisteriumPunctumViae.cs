using System;
using System.Collections.Generic;
using UnityEngine;
using Yulinti.Nucleus;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public class MinisteriumPunctumViae
    {
        private TabraPunctumViae _tabraPunctumViae;

        public MinisteriumPunctumViae(ConfiguratioPunctumViae configuratio)
        {
            _tabraPunctumViae = new TabraPunctumViae(configuratio.PunctaViae.Evolvo(
                IDErrorum.MINISTERIUMPUNCTUMVIAE_CONFIGURATION_NULL
            ));
        }

        public PunctumViae[] Lego(IDPunctumViaeTypi typus) => _tabraPunctumViae.Lego(typus);
    }
}