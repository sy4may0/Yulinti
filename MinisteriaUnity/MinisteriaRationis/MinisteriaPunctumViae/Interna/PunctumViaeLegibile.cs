using System.Numerics;
using Yulinti.Dux.ContractusDucis;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class PunctumViaeLegibile : IPunctumViaeLegibile {
        private readonly PunctumViae _punctumViae;

        public PunctumViaeLegibile(PunctumViae punctumViae) {
            _punctumViae = punctumViae;
        }

        public int ID => _punctumViae.ID;
        public IDPunctumViaeTypi Typus => _punctumViae.Typus;
        public Vector3 Positio => InterpressNumericus.ToNumerics(_punctumViae.Positio);
        public bool EstActivum => _punctumViae.EstActivum;
    }
}