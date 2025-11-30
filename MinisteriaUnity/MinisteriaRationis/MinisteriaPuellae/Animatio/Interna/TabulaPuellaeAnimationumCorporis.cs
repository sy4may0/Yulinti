using UnityEngine;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;
using System;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class TabulaPuellaeAnimationumCorporis {
        private readonly IStructuraAnimationis[] _animationes;

        public TabulaPuellaeAnimationumCorporis(IConfiguratioPuellaeAnimationisCorporis[] config) {
            int longitudo = Enum.GetValues(typeof(IDPuellaeAnimationisCorporis)).Length;
            _animationes = new IStructuraAnimationis[longitudo];

            _animationes[(int)IDPuellaeAnimationisCorporis.None] = null;

            foreach (IConfiguratioPuellaeAnimationisCorporis c in config) {
                _animationes[(int)c.ID] = FabricaStructuraeAnimationis.Create(
                    c.Animatio.Evolvo(IDErrorum.TABULAPUELLAEANIMATIONUMCORPORIS_ANIMATION_NULL),
                    c.TempusEvanescentiae,
                    c.Lenitio,
                    c.EstSimultaneum,
                    c.EstImpeditivus
                );
            }

            for (int i = 1; i < longitudo; i++) {
                if (_animationes[i] == null) {
                    Errorum.Fatal(IDErrorum.TABULAPUELLAEANIMATIONUMCORPORIS_CONFIG_NOT_FOUND);
                }
            }
        }

        public IStructuraAnimationis Lego(IDPuellaeAnimationisCorporis idCorporis) => _animationes[(int)idCorporis];
    }
}


